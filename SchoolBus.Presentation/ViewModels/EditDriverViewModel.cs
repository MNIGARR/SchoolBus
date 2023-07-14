using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using SchoolBus.Data.Repos;
using SchoolBus.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus.Presentation.ViewModels
{
    public class EditDriverViewModel : ViewModelBase
    {
        readonly IRepository<Car>? carRepository = new Repository<Car>();
        readonly IRepository<Driver>? driverRepository = new Repository<Driver>();

        private Driver editDriver = new();

        public Driver EditDriver
        {
            get { return editDriver; }
            set { Set(ref editDriver, value); }
        }

        private Driver _selectCar = new();

        public Driver _SelectCar
        {
            get { return _selectCar; }
            set { Set(ref _selectCar, value); }
        }


        private Window dc;
        public ObservableCollection<Car> Cars { get; set; } = new();


        public EditDriverViewModel(Window window, Driver selectDriver)
        {
            dc = window;
            editDriver = selectDriver;
            Cars = new ObservableCollection<Car>(carRepository.GetAll());
        }


        public RelayCommand DriverEditCommand
        {
            get => new RelayCommand(() =>
            {
                try
                {
                    if (editDriver.FirstName is null || editDriver.LastName is null || editDriver.PhoneNumber is null || editDriver.Address is null || editDriver.CarId is null)
                    {
                        MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        foreach (var item in DriverViewModel.Drivers)
                        {
                            if (item.Id == editDriver.Id)
                            {
                                item.FirstName = editDriver.FirstName;
                                item.LastName = editDriver.LastName;
                                item.Address = editDriver.Address;
                                item.PhoneNumber = editDriver.PhoneNumber;
                                item.CarId = editDriver.CarId;
                                break;
                            }
                        }
                        driverRepository.Update(editDriver);
                        driverRepository.SaveChanges();
                        //driverRepository.Close();
                        MessageBox.Show("Driver Edited", "", MessageBoxButton.OK);
                        //dc.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            });
        }


    }
}
