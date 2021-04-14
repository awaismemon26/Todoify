using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoifyData;

using TodoifyDataManager.Library.Internal.DataAccess;
using TodoifyDataManager.Library.Models;

namespace TodoifyDataManager.Library.DataAccess
{
    /// <summary>
    /// This class gets the information of User
    /// </summary>
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };
            var output = sql.LoadData<UserModel, dynamic>($"SELECT Id, Username, Email from [dbo].[AspNetUsers] where Id = @Id", p, "DefaultConnection");

            return output;
        }
    }
}
