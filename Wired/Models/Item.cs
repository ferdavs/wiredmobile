using System;

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wired
{
    public class Item : ObservableObject
    {
        int id = -1;

        [JsonIgnore]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        string author;
        public string Author
        {
            get { return author; }
            set { SetProperty(ref author, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        DateTime pubDate;
        public DateTime PubDate
        {
            get { return pubDate; }
            set { SetProperty(ref pubDate, value); }
        }

        IEnumerable<string> categories;
        public IEnumerable<string> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        string link;
        public string Link
        {
            get { return link; }
            set { SetProperty(ref link, value); }
        }

        string imageUrl;
        public string ImageUrl
        {
            get { return imageUrl; }
            set { SetProperty(ref imageUrl, value); }
        }

        [JsonIgnore]
        public string Content
        {
            get;
            set;
        }
    }
}
