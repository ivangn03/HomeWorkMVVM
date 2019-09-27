using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfHomework_02.Models
{
    public class Student : INotifyPropertyChanged
    {
        private static int _id;
        private string _name;
        private string _lastName;
        private string _group;
        private int _year;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Id { get; }
        public string Name
        {
            get => _name;
            set { _name = value; Notify(); }
        }
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; Notify(); }
        }
        public string Group
        {
            get => _group;
            set { _group = value; Notify(); }
        }
        public int Year {
            get => _year;
            set { _year = value; Notify(); }
        }
        public Student()
        {
            Id = ++_id;
        }
    }
}
