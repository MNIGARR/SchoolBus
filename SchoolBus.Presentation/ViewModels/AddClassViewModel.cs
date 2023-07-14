using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SchoolBus.Models.Concretes;
using SchoolBus.Data.Repos;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace SchoolBus.Presentation.ViewModels
{
    public class AddClassViewModel : ViewModelBase
    {
        readonly IRepository<Class>? classRepo = new Repository<Class>();

        private Class addClass = new();

        private Window dataContext;

        public Class AddClass
        {
            get { return addClass; }
            set { Set(ref addClass, value); }
        }
        public AddClassViewModel(Window window)
        {
            dataContext = window;
        }

        public ObservableCollection<Class> Classes { get; set; }

        public RelayCommand ClassCreateCommand
        {
            get => new RelayCommand(() =>
            {
                try
                {
                    if (AddClass.Name is null)
                    {
                        MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ClassViewModel.Classes.Add(addClass);
                        classRepo.Add(addClass);
                        classRepo.SaveChanges();
                        dataContext.Close();
                        MessageBox.Show("Class added", "", MessageBoxButton.OK);
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
