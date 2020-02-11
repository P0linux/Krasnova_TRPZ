using DeliveryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryServiceInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DeliveryServiceInterface(new Shop(new WaitingOrderUpdater(new TransportReturnTimeCounter(), new TimeToReadyCounter()), new DeliveryOrderUpdater(new TransportReturnTimeCounter()),
                                 new TransportReturnTimeCounter(), new TimeToReadyCounter(), new TransportChooser())));
        }
    }
}
