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
using System.Web.Hosting;
using System.Web.Http;

namespace ApiScoreBoard.Controllers.api
{


    public class RequestsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };

        public RequestsController(

            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<RequestModel> GetRequests()
        {
            var requests = _unitOfWork.Requests.GetAll();
            return requests;
        }
        
        [HttpPost]
        [AuditFilter]
        public IHttpActionResult AddRequest(RequestModelDto modelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            RequestModel model=Mapper.Map<RequestModelDto,RequestModel>(modelDto);
            _unitOfWork.Requests.Add(model);
            _unitOfWork.Complete();
            modelDto.Id = model.Id;
            return Created("api/Requests/"+modelDto.Id,modelDto);
        }
    }
}
