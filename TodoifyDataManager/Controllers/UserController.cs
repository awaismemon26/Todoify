﻿using Microsoft.AspNet.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TodoifyDataManager.Library.DataAccess;
using TodoifyDataManager.Library.Models;

namespace TodoifyDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();
            return data.GetUserById(userId).First();
        }
    }
}
