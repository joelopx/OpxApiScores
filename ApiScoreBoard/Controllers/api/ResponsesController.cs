using ApiScoreBoard.Helpers.Filters;
using ApiScoreBoard.Models;
using ApiScoreBoard.Persistence;
using ApiScoreBoard.Resources.DtoModels;
using ApiScoreBoard.Resources.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiScoreBoard.Controllers.api
{
    [Authorize]
    public class ResponsesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResponsesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<ResponseModelDto> GetResponses ()
        {
            var responses = _unitOfWork.Responses.GetAll();
            var query = Mapper.Map<IEnumerable<ResponseModel>,IEnumerable<ResponseModelDto>>(responses);
            return query;
        }
        [HttpPost]
        [AuditFilter]
        public IHttpActionResult AddResponse(ResponseModelDto modelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var request = _unitOfWork.Requests.GetSingle(r=>r.Id==modelDto.RequestId);
            var userId = User.Identity.GetUserId();
            var responseInDb = _unitOfWork.Responses.GetSingle(r=>r.RequestId==modelDto.RequestId && r.UserId.Equals(userId));
            if (request == null)
                return NotFound();
            if (responseInDb != null)
            {
                DeleteResponse(responseInDb.Id);
            }
            else
            {
                ResponseModel response = Mapper.Map<ResponseModelDto, ResponseModel>(modelDto);
                response.UserId = User.Identity.GetUserId();
                _unitOfWork.Responses.Add(response);
                _unitOfWork.Complete();
                var responsesQuantity = _unitOfWork.Responses.FindBy(r => r.RequestId ==modelDto.RequestId);
                if (responsesQuantity.Count()>=2)
                {
                    responsesQuantity=responsesQuantity.Where(r=>r.Accept==true);
                    if(responsesQuantity.Count()==2)
                    {
                        request.Accepted = true;
                        var usr = _unitOfWork.Users.GetSingle(u => u.Id.Equals(request.UserId));
                        usr.Points += request.RequestedQuantity;
                        _unitOfWork.Complete();
                    }
                }
            }
            

            return Created("api/Requests/" + modelDto.Id,modelDto);
        }
        private void DeleteResponse(int id)
        {
            if (id > 0 && id !=null)
            { 
                var response = _unitOfWork.Responses.GetSingle(r=>r.Id==id);
                _unitOfWork.Responses.Delete(response);
                _unitOfWork.Complete();
            }
        }
    }
}
