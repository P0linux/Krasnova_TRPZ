using DeliveryService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryServiceInterface
{
    public partial class DeliveryServiceInterface : Form
    {
        Product product;
        DeliveryPlace place;
        Shop shop;
        public DeliveryServiceInterface()
        {
            InitializeComponent();
            InfoLoader.LoadInfo();
            cbProduct.SelectedIndexChanged += CbProduct_SelectedIndexChanged;
            cbPlace.SelectedIndexChanged += CbPlace_SelectedIndexChanged;

            shop = new Shop(new WaitingOrderUpdater(new TransportReturnTimeCounter(), new TimeToReadyCounter()), new DeliveryOrderUpdater(new TransportReturnTimeCounter()), 
                                 new TransportReturnTimeCounter(), new TimeToReadyCounter(), new TransportChooser());
        }

        private void CbPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            place = cbPlace.SelectedItem as DeliveryPlace;
        }

        private void CbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            product = cbProduct.SelectedItem as Product;
        }

        private void fillComboBox()
        {
            cbProduct.DataSource = ShopStorage.AvailableProducts;
            cbProduct.DisplayMember = "Name";
            cbPlace.DataSource = ShopStorage.DeliveryPlaces;
            cbPlace.DisplayMember = "Name";
        }

        private void DeliveryServiceInterface_Load(object sender, EventArgs e)
        {
            fillComboBox();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Order order = shop.CreateOrder(1, product, place);
            if (ShopStorage.DeliveryQueue.Contains(order))
            {
                textBox1.Text = "Is delivering";
                textBox2.Text = order.TimeToReady.ToString();
            }
            else
            {
                textBox1.Text = "IsWaiting";
                textBox2.Text = order.Transport.TimeReturnToShop.ToString();
            }
        }
    }
}
