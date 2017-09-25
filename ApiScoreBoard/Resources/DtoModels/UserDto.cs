using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Resources.DtoModels
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
        public string ImgUrl { get; set; }
    }
}