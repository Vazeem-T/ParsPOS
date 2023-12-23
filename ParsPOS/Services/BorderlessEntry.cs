using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.Services
{
    public class BorderlessEntry : Entry
    {

    }
    public class EntryFocusBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CommandProperty =
             BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EntryFocusBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.Unfocused += OnUnfocused;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.Unfocused -= OnUnfocused;
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            if (Command?.CanExecute(null) == true)
            {
                Command.Execute(null);
            }
        }
    }
}
