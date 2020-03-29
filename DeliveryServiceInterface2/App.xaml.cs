using DeliveryService;
using DeliveryService.Classes;
using DeliveryService.Iterfaces;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.UnitOfWork;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using DeliveryService.Services;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceInterface2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            //var connection = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;


            services.AddDbContext<ApplicationContext>(/*options => options.UseSqlServer(connection)*/);
            services.AddSingleton(new MapperConfiguration(conf => conf.AddProfile(new MapperProfile())).CreateMapper());
            services.AddTransient<IShop, Shop>();
            services.AddTransient<IWaitingOrderUpdater, WaitingOrderUpdater>();
            services.AddTransient<IDeliveryOrderUpdater, DeliveryOrderUpdater>();
            services.AddTransient<TransportChooser, TransportChooser>();
            services.AddTransient<ITimeToReadyCounter, TimeToReadyCounter>();
            services.AddTransient<ITransportReturnTimeCounter, TransportReturnTimeCounter>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ApplicationContext, ApplicationContext>();
            services.AddSingleton<MainWindow, MainWindow>();
            services.AddScoped<IModel, Model>();
            services.AddScoped<ViewModel, ViewModel>();
            services.AddSingleton<InfoLoader, InfoLoader>();
            services.AddTransient<ProductService, ProductService>();
            services.AddTransient<TransportService, TransportService>();
            services.AddTransient<DeliveryPlaceService, DeliveryPlaceService>();
            services.AddTransient<PriorityService, PriorityService>();
            services.AddTransient<DeliveryOrderService, DeliveryOrderService>();
            services.AddTransient<WaitingOrderService, WaitingOrderService>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModel viewModel = serviceProvider.GetService<ViewModel>();
            new MainWindow { DataContext = viewModel };
            MainWindow.Show();
        }
    }
}
