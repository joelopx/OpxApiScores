using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Resources.DtoModels
{
    public class RequestModelDto
    {
        public string UserId { get; set; }
        public bool Accepted { get; set; }
        public int RequestedQuantity { get; set; }
        public string ImgUrl { get; set; }
        public string Reason { get; set; }
    }
}