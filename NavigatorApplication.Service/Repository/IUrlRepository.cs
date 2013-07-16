using System.Linq;
using NavigatorApplication.Service.DTO;

namespace NavigatorApplication.Service.Repository
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
