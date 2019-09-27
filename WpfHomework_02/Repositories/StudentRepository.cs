using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHomework_02.Models;
using WpfHomework_02.Services.DataService;

namespace WpfHomework_02.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        List<Student> students;
        IDataService<IEnumerable<Student>> dataService;
        public StudentRepository(IDataService<IEnumerable<Student>> dataService)
        {
            this.dataService = dataService;
            students = dataService.Load() as List<Student>;
        }
        public void Create(Student data)
        {
            students.Add(data);
        }

        public void Delete(int id)
        {
            students.Remove(this.Get(id));
        }

        public Student Get(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public void Update(Student data)
        {
            Student student = Get(data.Id);
            student = data;
        }
        public void SaveAll()
        {
            dataService.Save(students);
        }
    }
}
