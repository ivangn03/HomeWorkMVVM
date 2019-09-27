using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHomework_02.Models;
using WpfHomework_02.Repositories;
using WpfHomework_02.Services.DataService;

namespace WpfHomework_02.Moduls
{
    class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<StudentRepository>();
            Bind<IDataService<IEnumerable<Student>>>().To<JsonDataService>();
        }
    }
}
