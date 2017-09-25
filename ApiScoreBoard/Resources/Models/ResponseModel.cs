using ApiScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Resources.Models
{
    public class ResponseModel:Base
    {
        public int RequestId { get; set; }
        public string UserId { get; set; }
        public bool Accept { get; set; }
        [ForeignKey("RequestId")]
        public RequestModel RequestModel { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}