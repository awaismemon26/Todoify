using Caliburn.Micro;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoifyUI.Library.Api;
using TodoifyUI.Library.Models;

namespace TodoifyWPF.ViewModels
{
    public class TodoViewModel : Screen
    {
        ITodoEndpoint _todoEndpoint;

        public TodoViewModel(ITodoEndpoint todoEndpoint)
        {
            _todoEndpoint = todoEndpoint;
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

        private BindingList<TodoModel> _todo;

        public BindingList<TodoModel> Todos
        {
            get { return _todo; }
            set 
            { 
                _todo = value;
                NotifyOfPropertyChange(() => Todos);
            }
        }

    }
}
