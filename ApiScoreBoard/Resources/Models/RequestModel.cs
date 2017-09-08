using ApiScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Resources.Models
{
    public class RequestModel:Base
    {
        public string UserId { get; set; }
        public bool Accepted { get; set; }
        public int RequestedQuantity { get; set; }
        public string ImgUrl { get; set; }
        public string Reason { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}