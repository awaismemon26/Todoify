using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoifyUI.Library.Models
{
    public class TodoModel
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool CompletionStatus { get; set; }

        public string DisplayText 
        {
            get
            {
                if (CompletionStatus == false)
                {
                    return $"{ TaskName } ({ DueDate.ToShortDateString() })";
                }
                else
                {
                    return $"{ TaskName } (Completed)";
                }
            }
        }
    }
}
