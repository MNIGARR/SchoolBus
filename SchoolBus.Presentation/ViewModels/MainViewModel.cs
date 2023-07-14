using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SchoolBus.Presentation.Messages;
using SchoolBus.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService navigationSevice;
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        public MainViewModel(IMessenger messenger, INavigationService navigation)
        {
            navigationSevice = navigation;
            messenger.Register<NavigationMessage>(this, message =>
                                                        {
                                                             var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
                                                             CurrentViewModel = viewModel;
                                                        });
        }

        public RelayCommand CarViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<CarViewModel>();
            });
        }

        public RelayCommand DriverViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<DriverViewModel>();
            });
        }

        public RelayCommand ParentViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<ParentViewModel>();
            });
        }

        public RelayCommand StudentViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<StudentViewModel>();
            });
        }

        public RelayCommand ClassViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<ClassViewModel>();
            });
        }

        public RelayCommand RideViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<RideViewModel>();
            });
        }

        public RelayCommand CreateRideViewCommand
        {
            get => new RelayCommand(() =>
            {
                navigationSevice.NavigateTo<CreateRideViewModel>();
            });
        }
    }
}
