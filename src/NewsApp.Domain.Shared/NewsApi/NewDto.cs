﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.NewsApi
{
    public class NewDto
    {
       public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string Content { get; set; }
    }
}
