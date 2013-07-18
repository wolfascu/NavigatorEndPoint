namespace NavigatorApplication.Service.Repository
{
    using System.Linq;
    using NavigatorApplication.Service.DTO;

    public interface IFeedRepository
    {
        IQueryable<Feed> GetAll();
        
        Feed Get(string id);
        
        Feed Add(Feed feed);
        
        void Remove(string id);
        
        void Update(Feed feed);
    }
}

