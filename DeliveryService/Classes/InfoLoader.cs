using DataAccess.Interfaces;
using DeliveryService.Classes;
using DeliveryService.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class InfoLoader
    {
        ProductService pService;
        TransportService tService;
        DeliveryPlaceService plService;
        PriorityService prService;
        WaitingOrderService wService;
        DeliveryOrderService dService;

        IUnitOfWork unitOfWork;

        public InfoLoader(ProductService pService, TransportService tService, DeliveryPlaceService plService, PriorityService prService, IUnitOfWork unitOfWork, WaitingOrderService wService, DeliveryOrderService dService)
        {
            this.pService = pService;
            this.tService = tService;
            this.plService = plService;
            this.prService = prService;
            this.unitOfWork = unitOfWork;
            this.dService = dService;
            this.wService = wService;
        }
        public void LoadInfo()
        {

            Product p1 = new Product("Meat", 2, 3, "Chicken");
            Product p2 = new Product("Fish", 3, 3, "Salmon");

            //ShopStorage.AvailableProducts.Add(p1);
            //ShopStorage.AvailableProducts.Add(p2);

            Transport t1 = new Transport("Truck", 20, "Truck1", 20, 15, true);
            Transport t2 = new Transport("Byke", 20, "Byke1", 4, 2, false);

            tService.Add(t1);
            tService.Add(t2);

            //p1.availableTransport.Add(t1);
            //p1.availableTransport.Add(t2);

            //p2.availableTransport.Add(t1);

            pService.Add(p1);
            pService.Add(p2);

            //ShopStorage.AllTransport.Add(t1);
            //ShopStorage.AllTransport.Add(t2);

            DeliveryPlace d1 = new DeliveryPlace("Kyiv", 20);
            DeliveryPlace d2 = new DeliveryPlace("Harkiv", 40);

            //ShopStorage.DeliveryPlaces.Add(d1);
            //ShopStorage.DeliveryPlaces.Add(d2);

            //plService.Add(d1);
            //plService.Add(d2);

            //ShopStorage.jamImpactIndexes.Add(new ShopStorage.JamInterval { startTime = new TimeSpan(6, 0, 0), endTime = new TimeSpan(7, 0, 0) }, 2);
            //ShopStorage.jamImpactIndexes.Add(new ShopStorage.JamInterval { startTime = new TimeSpan(18, 0, 0), endTime = new TimeSpan(19, 0, 0) }, 4); 

            //p1.TransportPriority.Add(t1, 1);
            //p1.TransportPriority.Add(t2, 2);

            //p2.TransportPriority.Add(t1, 1);

            //Priority pr1 = new Priority(p1, t1, 1);
            //Priority pr2 = new Priority(p1, t2, 2);
            //Priority pr3 = new Priority(p2, t1, 1);

            //prService.Add(pr1);
            //prService.Add(pr2);
            //prService.Add(pr3);

            //for (int i = 190; i < 195; i++)
            //{
                
            //    tService.DeleteById(i);
            //    unitOfWork.Commit();
                
            //}

            //for (int i = 100; i<120; i++)
            //{
            //    pService.DeleteById(i);
            //    unitOfWork.Commit();
            //}

            unitOfWork.Commit();

        }
    }
}
