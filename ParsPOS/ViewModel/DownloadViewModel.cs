using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public class DownloadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int progress;
        int totalCount;
        string progressText;
        public Guid InstanceId { get; } = Guid.NewGuid();
        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
                UpdateProgressText();
            }
        }
        public int TotalCount
        {
            get { return totalCount; }
            set
            {
                totalCount = value;
                OnPropertyChanged(nameof(TotalCount));
            }
        }

        
        public string ProgressText
        {
            get { return progressText; }
            set
            {
                progressText = value;
                OnPropertyChanged(nameof(ProgressText));
            }
        }
        private void UpdateProgressText()
        {
            ProgressText = $"{Progress}/{TotalCount}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine($"Property {propertyName} changed.");

            // Get the property value using reflection
            var propertyInfo = GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                var propertyValue = propertyInfo.GetValue(this);
                Debug.WriteLine($"Current value of {propertyName}: {propertyValue}");
            }
        }
    }
}
