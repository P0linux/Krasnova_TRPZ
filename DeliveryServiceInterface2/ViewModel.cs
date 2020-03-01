using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryServiceInterface2
{
    class ViewModel : INotifyPropertyChanged
    {
        IModel model;
        public ViewModel(IModel model, MainWindow main)
        {
            this.model = model;
            main.GetOrder += GetOrder;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> products;
        public List<string> Products
        {
            get => model.GetProducts();
            set
            {
                products = value;
            }
        }

        private string product;
        public string Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
            }
        }

        private List<string> deliveryPlaces;
        public List<string> DeliveryPlaces
        {
            get => model.GetDeliveryPlaces();
            set
            {
                deliveryPlaces = value;
            }
        }

        private string deliveryPlace;
        public string DeliveryPlace
        {
            get
            {
                return deliveryPlace;
            }
            set
            {
                deliveryPlace = value;
            }
        }

        private string time;
        public string Time
        {
            get
            {
                if (product != null && deliveryPlace != null) return model.GetTime().ToString();
                else return time;
            } 
            set
            {
                time = value;
            }
        }

        private bool isDelivering;
        public bool IsDelivering
        {
            get
            {
                if (product != null && deliveryPlace != null) return model.GetStatus();
                else return isDelivering;
            } 
            set
            {
                isDelivering = value;
            }
        }

        public void GetOrder()
        {
            model.GetOrder(1, product, deliveryPlace);
            OnPropertyChanged("Time");
            OnPropertyChanged("IsDelivering");
        }
    }
}
