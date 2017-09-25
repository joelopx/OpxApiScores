using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.ComponentModel.Design;
using System.Web.Http;

[assembly: OwinStartup(typeof(ApiScoreBoard.Startup))]

namespace ApiScoreBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
     

            HttpConfiguration config = new HttpConfiguration();
            app.UseWebApi(config);
            ConfigureAuth(app);

            
        }
    }
}
