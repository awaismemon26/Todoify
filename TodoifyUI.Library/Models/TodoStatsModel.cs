using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoifyUI.Library.Models
{
    public class TodoStatsModel
    {
        public int TotalCompleted { get; set; }
        public DateTime DateTime { get; set; }

        public string DisplayText 
        { 
            get 
            {
                return $"{ DateTime.ToString("dd-MM-yyyy") } -- Completed: {TotalCompleted}";
            } 
        }
    }
}
