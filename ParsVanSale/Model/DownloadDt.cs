using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class DownloadDt : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int progress;
        private int totalCount;

        [PrimaryKey, AutoIncrement]
        public int DownloadId { get; set; }
		private string _description;
		public string Description
		{
			get => _description;
			set
			{
				if (_description != value)
				{
					_description = value;
					OnPropertyChanged(nameof(Description));
				}
			}
		}

		private string _downloadDescription;
		public string DownloadDescription
		{
			get => _downloadDescription;
            set
            {
                if(_downloadDescription != value) 
                {
                    _downloadDescription = value;
                    OnPropertyChanged(nameof(DownloadDescription));
                }
            }
		}

		public int TotalCount
        {
            get { return totalCount; }
            set
            {
                if (totalCount != value)
                {
                    totalCount = value;
                    OnPropertyChanged(nameof(TotalCount));
                    OnPropertyChanged(nameof(CalculatedProgress));
                }
            }
        }

        public int Progress
        {
            get { return progress; }
            set
            {
                if (progress != value)
                {
                    progress = value;
                    OnPropertyChanged(nameof(Progress));
                    OnPropertyChanged(nameof(CalculatedProgress));
                }
            }
        }
        public DateTime DownloadTime { get; set; } = DateTime.Now;
        public bool IsRunning { get; set; }
        public bool? IsSuccess { get; set; }
        public bool IsCompleted { get; set; } = false;

        [Ignore]
        public double CalculatedProgress => TotalCount == 0 ? 0 : (double)Progress / TotalCount;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
