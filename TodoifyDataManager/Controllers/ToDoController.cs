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
    public class TodoController : ApiController
    {
        [HttpGet]
        public List<ToDoModel> GetAll()
        {
            ToDoData data = new ToDoData();

            return data.GetAll();
        }
    }
}
