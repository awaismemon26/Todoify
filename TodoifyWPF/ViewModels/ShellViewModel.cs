using Caliburn.Micro;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoifyUI.Library.Models;

using TodoifyWPF.EventsHelper;

namespace TodoifyWPF.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LoginEvent>
    {
        private TodoViewModel _todoVM;
        private IEventAggregator _events;
        private SimpleContainer _container;

        public ShellViewModel(TodoViewModel todoVM, IEventAggregator events, SimpleContainer container)
        {
            _events = events;
            _container = container;
            _todoVM = todoVM;

            _events.Subscribe(this);
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LoginEvent message)
        {
            ActivateItem(_todoVM); 
        }
    }
}
