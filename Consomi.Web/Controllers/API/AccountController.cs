using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Consomi.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Consomi.Web.Controllers.API
{
    public class AccountController : BaseApiController
    {
        private UserManager<IdentityUser> _userManager;

        [System.Web.Http.Route("api/users")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUsers()
        {
            IList<dynamic> list = new List<dynamic>();

            foreach (var user in this.AppUserManager.Users)
            {
                list.Add(this.TheModelFactory.Create(user));
            }

            return Ok(list);
        }



        [System.Web.Http.Route("api/user/{email}/{password}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult FindUser(string email, string password)
        {
            var user = this.AppUserManager.FindAsync(email, password);

            if (user != null)
            {
                return Json(user);
            }

            return null;

        }


 
    }
}
