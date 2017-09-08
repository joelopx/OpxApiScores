using ApiScoreBoard.Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Resources
{
    public class Base : IBase
    {
        public int Id { get; set; }
        public string CreatedBy { get ; set; }
        public DateTime? CreatedDate { get ; set ; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get ; set; }
    }
}