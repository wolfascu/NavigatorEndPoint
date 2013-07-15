using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorApplication.Service.DTO
{
    public interface IUrlRepository
    {
        IQueryable<Url> GetAll();
        Url Get(int id);
        Url Add(Url url);
        //void Remove(int id);
        //bool Update(Url url);
    }
}
