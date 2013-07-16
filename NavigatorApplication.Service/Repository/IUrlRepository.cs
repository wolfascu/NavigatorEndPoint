using System.Linq;

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
