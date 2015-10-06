using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace UserInteractionModeSample
{
    public class UserInteractionTrigger : StateTriggerBase
    {
        private bool isInMouseMode;

        public UserInteractionTrigger()
        {
            Window.Current.SizeChanged += SizeChanged;
        }

        public bool IsInMouseMode
        {
            get { return this.isInMouseMode; }
            set
            {
                this.isInMouseMode = value;
            }
        }

        private async void SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (UIViewSettings.GetForCurrentView().UserInteractionMode == Windows.UI.ViewManagement.UserInteractionMode.Mouse)
                {
                    SetActive(this.IsInMouseMode);
                }
                else
                {
                    SetActive(!this.IsInMouseMode);
                }
            });
        }
    }
}
