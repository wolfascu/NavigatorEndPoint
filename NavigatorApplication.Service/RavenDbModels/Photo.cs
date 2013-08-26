﻿using System;

namespace NavigatorApplication.Service.RavenDbModels
{
    public class Photo
    {
        public string Id { get; set; }

        public string FeedId { get; set; }

        public string Title { get; set; }

        public DateTime Updated { get; set; }

        public DateTime DateTaken { get; set; }

        public string AuthorName { get; set; }

        public string AuthorURL { get; set; }

        public string PhotoURL { get; set; }

    }
}