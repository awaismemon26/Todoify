using Caliburn.Micro;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using TodoifyUI.Library.Api;
using TodoifyUI.Library.Models;

namespace TodoifyWPF.ViewModels
{
    public class TodoViewModel : Screen
    {
        ITodoEndpoint _todoEndpoint;

        private BindingList<TodoModel> _todo = new BindingList<TodoModel>();
        public BindingList<TodoModel> Todos
        {
            get { return _todo; }
            set
            {
                _todo = value;
                NotifyOfPropertyChange(() => Todos);
            }
        }

        private BindingList<TodoStatsModel> _todoStats = new BindingList<TodoStatsModel>();
        public BindingList<TodoStatsModel> TodoStats
        {
            get
            {
                return _todoStats;
            }
            set
            {
                _todoStats = value;
                NotifyOfPropertyChange(() => TodoStats);
            }
        }
        private BindingList<TodoModel> _notCompletedTodo = new BindingList<TodoModel>();
        public BindingList<TodoModel> NotCompletedTodo
        {
            get { return _notCompletedTodo; }
            set
            {
                _notCompletedTodo = value;
                NotifyOfPropertyChange(() => NotCompletedTodo);
            }
        }


        private int _completedTodo;
        public int CompletedTodo
        {
            get { return _completedTodo; }
            set
            {
                _completedTodo = value;
                NotifyOfPropertyChange(() => CompletedTodo);
            }
        }

        private string _tasktextbox;
        public string TaskTextBox
        {
            get { return _tasktextbox; }
            set { _tasktextbox = value; NotifyOfPropertyChange(() => TaskTextBox); NotifyOfPropertyChange(() => CanAddTask); }
        }

        
        private TodoModel _selectedTodo;
        public TodoModel SelectedTodo
        {
            get { return _selectedTodo; }
            set
            {
                _selectedTodo = value;
                NotifyOfPropertyChange(() => SelectedTodo);
                NotifyOfPropertyChange(() => CanRemoveTask);
                NotifyOfPropertyChange(() => CanCompleteTask);
            }
        }

        private DateTime _selectedDueDate;
        public DateTime SelectedDueDate
        {
            get { return _selectedDueDate; }
            set
            {
                _selectedDueDate = value;
                NotifyOfPropertyChange(() => SelectedDueDate);
            }
        }


        public TodoViewModel(ITodoEndpoint todoEndpoint)
        {
            _todoEndpoint = todoEndpoint;
            SelectedDueDate = DateTime.Today;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadTodo();
        }

        public async Task LoadTodo()
        {
            List<TodoModel> list = await _todoEndpoint.GetAllAsync();
            Todos = new BindingList<TodoModel>(list);

            var res = Todos.Where(x => x.CompletionStatus == true).GroupBy(x => x.CreationDate);
            TodoStatsModel todoStats = new TodoStatsModel();
            foreach (var key in res)
            {
                todoStats.DateTime = key.Key;
                todoStats.TotalCompleted = key.ToList().Count;
                
            }

            TodoStats.Add(todoStats);

        }
        public async Task LoadNotCompletedTodo()
        {
            await LoadTodo();
            var notCompletedTodoList = Todos.Where(x => x.CompletionStatus == false).ToList();
            NotCompletedTodo = new BindingList<TodoModel>(notCompletedTodoList);
        }

        public bool CanRemoveTask
        {
            get
            {
                bool output = false;

                // There should be values in the Todos to remove the task
                if (Todos.Count > 0)
                {
                    output = true;
                }

                return output;
            }

        }
        public bool CanCompleteTask
        {
            get
            {
                bool output = false;

                // Selected task should be NOT completed status and there should be a values in Todos to complete the task
                if (SelectedTodo?.CompletionStatus == false && Todos.Count > 0)
                {
                    output = true;
                }

                return output;
            }
        }
        public bool CanAddTask
        {
            get
            {
                bool output = false;

                if (!string.IsNullOrEmpty(TaskTextBox))
                {
                    output = true;
                }
                return output;
            }
        }


        public void CompleteTask()
        {
            // Object DeepCopy
            TodoModel completeModel = new TodoModel();
            completeModel.CreationDate = SelectedTodo.CreationDate;
            completeModel.DueDate = SelectedTodo.DueDate;
            completeModel.TaskName = SelectedTodo.TaskName;
            completeModel.ID = SelectedTodo.ID;
            completeModel.CompletionStatus = true;

            Todos.Remove(Todos.Where(x => x.ID == SelectedTodo.ID).FirstOrDefault());

            Todos.Add(completeModel);

            // Update model completion status in database asynchronously
        }

        public void AddTask()
        {

            TodoModel todo = new TodoModel
            {
                ID = int.Parse(DateTime.Now.ToString("HHmmss")),
                TaskName = TaskTextBox,
                DueDate = SelectedDueDate,
                CreationDate = DateTime.Now,
                CompletionStatus = false
            };
            Todos.Add(todo);
            
            // Add Todo into database asynchronously
        }

        public void RemoveTask()
        {
            Todos.Remove(SelectedTodo);
            
            // Put the visible status to false and update/delete from the database
        }


    }
}
