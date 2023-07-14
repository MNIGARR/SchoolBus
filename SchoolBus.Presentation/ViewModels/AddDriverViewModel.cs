using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using SchoolBus.Data.Repos;
using SchoolBus.Models.Concretes;
using SchoolBus.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus.Presentation.ViewModels
{
    public class AddDriverViewModel : ViewModelBase
    {
        private Window dataContext;

        public AddDriverViewModel(Window window)
        {
            dataContext = window;
            addDriver = new();
            Carsc = CarViewModel.Cars;
            Driversc = DriverViewModel.Drivers;
            for (int i = 0; i < Carsc.Count; i++)
            {
                for (int j = 0; j < Driversc.Count; j++)
                {
                    if (Carsc[i].Id == Driversc[j].CarId)
                    {
                        Carsc.Remove(Carsc[i]);
                    }
                }
            }
        }

        readonly IRepository<Driver>? driverRepo = new Repository<Driver>();
        readonly IRepository<Car>? carRepo = new Repository<Car>();

        private Driver addDriver = new();

        public Driver AddDriver
        {
            get { return addDriver; }
            set { Set(ref addDriver, value); }
        }

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }

        private Car _selectCar = new();

        public Car SelectCar
        {
            get { return _selectCar; }
            set { Set(ref _selectCar, value); }
        }


        public ObservableCollection<Car> Carsc { get; set; }
        public ObservableCollection<Driver> Driversc { get; set; }


        public RelayCommand DriverCreateCommand
        {
            get => new RelayCommand(() =>
            {
                try
                {
                    if (addDriver.FirstName != string.Empty || addDriver.LastName != string.Empty || addDriver.PhoneNumber != string.Empty || addDriver.Address != string.Empty || SelectCar is not null)
                    {
                        Carsc = new ObservableCollection<Car>(this.carRepo.GetAll());
                        addDriver.CarId = _selectCar.Id;

                        DriverViewModel.Drivers.Add(addDriver);
                        driverRepo.Add(addDriver);
                        driverRepo.SaveChanges();
                        dataContext.Close();
                        MessageBox.Show("Driver added", "", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("BOOM", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            });
        }
    }
}
