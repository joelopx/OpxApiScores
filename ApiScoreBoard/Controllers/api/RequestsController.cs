using ApiScoreBoard.Helpers.Filters;
using ApiScoreBoard.Models;
using ApiScoreBoard.Persistence;
using ApiScoreBoard.Resources.DtoModels;
using ApiScoreBoard.Resources.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiScoreBoard.Controllers.api
{
    
    public class RequestsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };

        public RequestsController(

            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IEnumerable<RequestModelDto> GetRequests()
        {
                var requests = _unitOfWork.Requests.FindBy(r=>r.Accepted==false);
            var userId = User.Identity.GetUserId();
            var responses = _unitOfWork.Responses.FindBy(r=>r.UserId==userId).Select(Mapper.Map<ResponseModel,ResponseModelDto>);

            var query = Mapper.Map<IEnumerable<RequestModel>, IEnumerable<RequestModelDto>>(requests);
            if (responses.Count()>0)
            {
                foreach (var item in query)
                {
                    var resp = responses.FirstOrDefault(r=>r.RequestId==item.Id);
                    if (resp!=null)
                        item.Response = resp;
                }
            }
            return query;
        }

        [HttpPost]
        [AuditFilter]
        public IHttpActionResult AddRequest(RequestModelDto modelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            ApplicationUser user = _unitOfWork.UserManager.FindByEmail(modelDto.UserEmail);
            if (user==null)
                return NotFound();
            RequestModel model = Mapper.Map<RequestModelDto, RequestModel>(modelDto);
            model.Accepted = false;
            if (User.Identity.GetUserId()== user.Id)
            {
                model.Accepted = true;
                var usr = _unitOfWork.Users.GetSingle(u=>u.Id.Equals(user.Id));
                usr.Points += modelDto.RequestedQuantity;
            }
            model.UserId = user.Id;
            model.UserEmail = user.Email;
            _unitOfWork.Requests.Add(model);
            _unitOfWork.Complete();
            modelDto.Id = model.Id;
            return Created("api/Requests/"+modelDto.Id,modelDto);
        }
        [HttpPut]
        [AuditFilter]
        public IHttpActionResult UpdateRequest(RequestModelDto modelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            RequestModel modelInDb=_unitOfWork.Requests.GetSingle(r=>r.Id==modelDto.Id);
            if (modelInDb == null)
                return NotFound();
            Mapper.Map(modelDto,modelInDb);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
