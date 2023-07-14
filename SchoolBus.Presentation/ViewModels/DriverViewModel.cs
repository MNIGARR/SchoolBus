using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolBus.Data.Repos;
using SchoolBus.Models.Concretes;
using System;
using SchoolBus.Presentation.Views;
using SchoolBus.Presentation.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SchoolBus.Presentation.Views;
using SchoolBus.Presentation.ViewModels;

using MaterialDesignThemes.Wpf;
using SchoolBus.Data;

namespace SchoolBus.Presentation.ViewModels
{
    public class DriverViewModel : ViewModelBase
    {
        private readonly IRepository<Driver> driverRepo;
        private readonly IRepository<Car> carRepo = new Repository<Car>();


        public static Driver selectDriver;

        public Driver SelectDriver
        {
            get { return selectDriver; }
            set { Set(ref selectDriver, value); }
        }

        public static ObservableCollection<Driver> Drivers { get; set; } = new();
        public static ObservableCollection<Car> Cars { get; set; } = new();

        public DriverViewModel(IRepository<Driver> driverRepo)
        {

            this.driverRepo = driverRepo;
            Drivers = new ObservableCollection<Driver>(this.driverRepo.GetAll());
        }

        public RelayCommand AddDriverCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new AddDriverView();
                window.DataContext = new AddDriverViewModel(window);
                window.Show();

            });
        }

        public RelayCommand EditDriverCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new EditDriverView();
                window.DataContext = new EditDriverViewModel(window, selectDriver);
                window.Show();

            });
        }
    }
}
