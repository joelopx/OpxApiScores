using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Resources.DtoModels
{
    public class ResponseModelDto:BaseDto
    {
        
        public int RequestId { get; set; }
        public bool Accept { get; set; }
    }
}