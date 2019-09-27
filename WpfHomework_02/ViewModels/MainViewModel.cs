using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfHomework_02.Infrastacture;
using WpfHomework_02.Models;
using WpfHomework_02.Moduls;
using WpfHomework_02.Repositories;

namespace WpfHomework_02.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }
        #endregion
        #region Commands
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand CloseAndSaveCommand { get; set; }
        public ICommand ReversSortCommand { get; set; }
        public ICommand SortCommand { get; set; }
        #endregion
        public MainViewModel()
        {
            IKernel kernel = new StandardKernel(new MyModule());
            IRepository<Student>  repository = kernel.Get<IRepository<Student>>();
            Students = new ObservableCollection<Student>(repository.GetAll());
            AddCommand = new RelayCommand(x => {
                Student student = new Student { Name = "", LastName = "", Group = "", Year = 2019 };
                Students.Add(student);
                repository.Create(student);
            });
            ReversSortCommand = new RelayCommand(x =>
            {
               for(int i = 0; i < Students.Count; i++)
                {
                    Students.Move(Students.Count - 1, i);
                }
            });
            SortCommand = new RelayCommand(x => {
                
                string sort_type = (string)x;
                List<Student> sortedList = Students.OrderBy(sort => sort.GetType().GetProperty(sort_type).GetValue(sort, null)).ToList<Student>();
                for (int i = 0; i < Students.Count; i++)
                {
                    Students.Move(Students.IndexOf(sortedList[i]),i);
                }             
            });
            CloseAndSaveCommand = new RelayCommand(x => repository.SaveAll());
            RemoveCommand = new RelayCommand(
                x => {
                    repository.Delete(((Student)x).Id);
                    Students.Remove((Student)x);
                }, x=> Students.Count > 0
                );
        }
    }
}
