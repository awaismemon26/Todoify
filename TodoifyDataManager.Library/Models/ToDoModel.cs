using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoifyDataManager.Library.Models
{
    public class ToDoModel
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool CompletionStatus { get; set; }

        public List<ToDoModel> ToDoList { get; set; }
    }
}
