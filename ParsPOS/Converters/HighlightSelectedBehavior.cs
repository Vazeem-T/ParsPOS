using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ParsPOS.Converters
{
    public class HighlightSelectedBehavior : Behavior<ViewCell>
    {
        private Color selectedItemBackgroundColor = Colors.LightBlue;
        private VisualStateGroup visualStateManager;

        protected override void OnAttachedTo(ViewCell bindable)
        {
            base.OnAttachedTo(bindable);

            visualStateManager = bindable.GetValue(VisualStateManager.VisualStateGroupsProperty) as VisualStateGroup;
            if (visualStateManager == null)
            {
                visualStateManager = new VisualStateGroup();
                bindable.SetValue(VisualStateManager.VisualStateGroupsProperty, visualStateManager);
            }

            visualStateManager.States.Add(CreateSelectedVisualState());
        }

        private VisualState CreateSelectedVisualState()
        {
            var selectedState = new VisualState
            {
                Name = "Selected"
            };

            visualStateManager.States[0].Setters.Add(
                new Setter
                {
                    Property = View.BackgroundColorProperty,
                    Value = selectedItemBackgroundColor
                });

            return selectedState;
        }
    }
}
