using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.Services
{
    public class EntryCompletedBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CommandProperty =
       BindableProperty.CreateAttached(
           "Command",
           typeof(ICommand),
           typeof(EntryCompletedBehavior),
           null,
           propertyChanged: OnCommandPropertyChanged);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EntryCompletedBehavior behavior && newValue is ICommand newCommand)
            {
                
            }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.Completed += OnCompleted;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Completed -= OnCompleted;
            base.OnDetachingFrom(entry);
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }

    }
}
