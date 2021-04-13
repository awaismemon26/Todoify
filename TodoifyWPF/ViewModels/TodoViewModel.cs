using Caliburn.Micro;

using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        private BindingList<TodoModel> _notCompletedTodo;
        public BindingList<TodoModel> NotCompletedTodo
        {
            get { return _notCompletedTodo; }
            set
            {
                _notCompletedTodo = value;
                NotifyOfPropertyChange(() => NotCompletedTodo);
            }
        }

        private BindingList<TodoModel> _completedTodo;
        public BindingList<TodoModel> CompletedTodo
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
            
        }

        public bool CanRemoveTask
        {
            get
            {
                bool output = false;

                if (Todos.Count > 0)
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
        public void RemoveTask()
        {

        }


    }
}
