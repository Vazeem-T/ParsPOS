using ParsPOS.Views.SubForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Maui.Views;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class EntryPopUpBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.Focused += OnEntryFocused;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.Focused -= OnEntryFocused;
        }

        private void OnEntryFocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Show the popup when the entry receives focus
                var categoryPopup = new CategoryPopup();
                //categoryPopup.ItemSelected += OnItemSelected;
                
            }
        }
    }
}
