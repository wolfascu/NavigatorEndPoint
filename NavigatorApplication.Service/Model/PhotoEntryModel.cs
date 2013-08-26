namespace NavigatorApplication.Service.Model
{
    using System;
    using System.Collections.Generic;

    public class PhotoEntryModel
    {
        public string Id { get; set; }

        public string FeedId { get; set; }

        public string Title { get; set; }

        public DateTime Updated { get; set; }

        public DateTime DateTaken { get; set; }

        public string AuthorName { get; set; }

        public string AuthorURL { get; set; }

        public string PhotoURL { get; set; }

        public string[] UpdateTypes { get; set; }

        public List<Category> Categories { get; set; }  

        public new string ToString()
        {
            return string.Format("Id:{0}|FeedId:{1}|Title:{2}|Updated:{3}|DateTaken:{4}|AuthorName:{5}",
                Id, FeedId, Title, Updated, DateTaken, AuthorName);
        }
    }

    public class Category
    {
        public string Type { get; set; }
        public string Value { get; set; }

    }
}
