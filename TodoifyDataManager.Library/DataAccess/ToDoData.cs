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
    /// Data Access Class which basically gets the data from TodoifyData. 
    /// Currently for this scenario, I am getting data from TodifyData, mapping the ToDo model with our ToDoModel defined in this ToDoifyDataManager.     
    /// This will give our Manager Library Models leverage to choose which items to get from Data Model.  
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
