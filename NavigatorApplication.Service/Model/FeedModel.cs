namespace NavigatorApplication.Service.Model
{
    using System;

    public class FeedModel
    {
        public string Id { get; set; }

        public string Operation { get; set; }

        public string Title { get; set; }

        public int Entries { get; set; }

        public DateTime Date { get; set; }

        public string Photos
        {
            get { return string.Format("Feed/{0}/Photos/", Id); }
        }

        public new string ToString()
        {
            return string.Format("Id:{0}|Operation:{1}|Title{2}|Entries{3}|Date:{4}|Photos:{5}",
                Id, Operation, Title, Entries, Date, Photos);
        }
    }
}
