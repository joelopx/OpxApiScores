using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.ComponentModel.Design;

[assembly: OwinStartup(typeof(ApiScoreBoard.Startup))]

namespace ApiScoreBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            ConfigureAuth(app);
        }
    }
}
