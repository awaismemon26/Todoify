using System;
using System.Collections.Generic;

namespace TodoifyData
{
    /// <summary>
    /// Basic ToDo Data Model imitating database model
    /// </summary>
    public class ToDo
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool CompletionStatus { get; set; }

        private List<ToDo> list;

        public List<ToDo> GetAll()
        {
            list = new List<ToDo>()
            {
                new ToDo { ID = 1, TaskName = "Update ToDo List", CreationDate = new DateTime(2021, 03, 15), DueDate = new DateTime(2021, 03, 20), CompletionStatus = false },
                new ToDo { ID = 2, TaskName = "Plan Birthday!!", CreationDate = new DateTime(2021, 03, 25), DueDate = new DateTime(2021, 03, 27), CompletionStatus = false },
                new ToDo { ID = 3, TaskName = "Book Day Tour to Salzburg", CreationDate = new DateTime(2021, 02, 10), DueDate = new DateTime(2021, 02, 12), CompletionStatus = false },
                new ToDo { ID = 4, TaskName = "Custom PC Build", CreationDate = new DateTime(2021, 01, 05), DueDate = new DateTime(2021, 02, 25), CompletionStatus = false },
                new ToDo { ID = 5, TaskName = "Review code", CreationDate = new DateTime(2021, 01, 10), DueDate = new DateTime(2021, 01, 28), CompletionStatus = false },
                new ToDo { ID = 6, TaskName = "Finalize Semester courses", CreationDate = new DateTime(2021, 01, 01), DueDate = new DateTime(2021, 04, 10), CompletionStatus = false },
                new ToDo { ID = 7, TaskName = "Send invoice", CreationDate = new DateTime(2021, 04, 01), DueDate = new DateTime(2021, 04, 03), CompletionStatus = false },
                new ToDo { ID = 8, TaskName = "Write section on article", CreationDate = new DateTime(2021, 01, 17), DueDate = new DateTime(2021, 01, 30), CompletionStatus = false },
                new ToDo { ID = 9, TaskName = "Clean harddrives", CreationDate = new DateTime(2021, 04, 03), DueDate = new DateTime(2021, 04, 05), CompletionStatus = true },
                new ToDo { ID = 10, TaskName = "Learn Distributed Systems", CreationDate = new DateTime(2021, 04, 03), DueDate = new DateTime(2021, 04, 11), CompletionStatus = true },
            };

            return list;
        }

        

    }
}
