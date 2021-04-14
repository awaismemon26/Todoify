using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoifyData;

using TodoifyDataManager.Library.Models;

namespace TodoifyDataManager.Library.DataAccess
{
    /// <summary>
    /// Data Access Class which basically gets the data from TodoifyData Library, in the future if we need to add the database we could use this library to define models and use Dapper library to simplify our process getting from SQL database.
    /// Currently for this scenario, I am getting data from TodifyData Library, mapping the ToDo model with our ToDoModel defined in this ToDoifyDataManager Library. This will give our Manager Library Model leverage to choose which items to get from Data Model 
    /// 
    /// </summary>
    public class ToDoData
    {
        /// <summary>
        /// To Get the list of all ToDo items.
        /// </summary>
        /// <returns>List of ToDo Items</returns>
        public List<ToDoModel> GetAll()
        {
            ToDo list = new ToDo();         
            List<ToDo> _list = list.GetAll();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ToDo, ToDoModel>();
            });

            IMapper iMapper = config.CreateMapper();
            List<ToDoModel> todoList = iMapper.Map<List<ToDo>, List<ToDoModel>>(_list);

            return todoList;
        }

    }
}
