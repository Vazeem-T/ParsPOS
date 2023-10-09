using ParsPOS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public class SaleViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Invitm> items;

        private string barcodeText;       

        public string BarcodeText
        {
            get { return barcodeText; }
            set
            {
                if (barcodeText != value)
                {
                    barcodeText = value;
                    OnPropertyChanged();
                }
            }
        }

        public SaleViewModel() 
        {
        
        }

        public async void  BarcodeEntryCompleted()
        {
            try
            {
                var item = await App.Database.EntryChk(BarcodeText);
                if(item != null) 
                {
                    
                }
            }
            catch (Exception)
            {

            }
            
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
