using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHomework_02.Services.DataService
{
    public interface IDataService<T>
    {
        T Load();
        void Save(T data);
    }
}
