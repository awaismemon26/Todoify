using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoifyData
{
    public class ToDo
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool CompletionStatus { get; set; }

        public ToDo()
        {
            ToDoInit initToDo = new ToDoInit();
        }

    }

    internal class ToDoInit
    {
        internal ToDoInit()
        {
            ToDo task1 = new ToDo { ID = 1, TaskName = "Update ToDo List", CreationDate = new DateTime(2021, 03, 15), DueDate = new DateTime(2021, 03, 20), CompletionStatus = false };
            ToDo task2 = new ToDo { ID = 2, TaskName = "Plan Birthday!!", CreationDate = new DateTime(2021, 03, 25), DueDate = new DateTime(2021, 03, 27), CompletionStatus = false };
            ToDo task3 = new ToDo { ID = 3, TaskName = "Book Day Tour to Salzburg", CreationDate = new DateTime(2021, 02, 10), DueDate = new DateTime(2021, 02, 12), CompletionStatus = false };
            ToDo task4 = new ToDo { ID = 4, TaskName = "Custom PC Build", CreationDate = new DateTime(2021, 01, 05), DueDate = new DateTime(2021, 02, 25), CompletionStatus = false };
            ToDo task5 = new ToDo { ID = 5, TaskName = "Review code", CreationDate = new DateTime(2021, 01, 10), DueDate = new DateTime(2021, 01, 28), CompletionStatus = false };
            ToDo task6 = new ToDo { ID = 6, TaskName = "Finalize Semester courses", CreationDate = new DateTime(2021, 01, 01), DueDate = new DateTime(2021, 04, 10), CompletionStatus = false };
            ToDo task7 = new ToDo { ID = 7, TaskName = "Send invoice", CreationDate = new DateTime(2021, 04, 01), DueDate = new DateTime(2021, 04, 03), CompletionStatus = false };
            ToDo task8 = new ToDo { ID = 8, TaskName = "Write section on article", CreationDate = new DateTime(2021, 01, 17), DueDate = new DateTime(2021, 01, 30), CompletionStatus = false };
            ToDo task9 = new ToDo { ID = 9, TaskName = "Clean harddrives", CreationDate = new DateTime(2021, 04, 03), DueDate = new DateTime(2021, 04, 05), CompletionStatus = false };
            ToDo task10 = new ToDo { ID = 10, TaskName = "Learn Distributed Systems", CreationDate = new DateTime(2021, 01, 15), DueDate = new DateTime(2021, 04, 11), CompletionStatus = false };
        }
    }
}
