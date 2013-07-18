namespace NavigatorApplication.Service.DTO.Links
{
    /// <summary>
    /// A base class for relation links
    /// </summary>
    public class Link
    {

        public string Rel { get; private set; }
        

        public string Href { get; private set; }
        

        public string Title { get; private set; }

        public Link(string rel, string href, string title = null)
        {
           // Ensure.Argument.NotNullOrEmpty(rel, "rel");
          //  Ensure.Argument.NotNullOrEmpty(href, "href");

            Rel = rel;
            Href = href;
            Title = title;
        }

        public override string ToString()
        {
            return Href;
        }
    }
}
