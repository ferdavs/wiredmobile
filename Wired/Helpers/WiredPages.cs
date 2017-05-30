using System;
using System.ComponentModel;

namespace Wired.Helpers
{
    public static class EnumExtensions
    {
        public static string GetString(this WiredPages val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public enum WiredPages
    {
        [Description("https://www.wired.com/feed/")]
        TopStories,

        [Description("https://www.wired.com/category/business/feed/")]
        Bussiness,

        //[Description("https://www.wired.com/category/design/feed/")]
        //Design,

        [Description("https://www.wired.com/category/culture/feed/")]
        Culture,

        [Description("https://www.wired.com/category/gear/feed/")]
        Gear,

        [Description("https://www.wired.com/category/reviews/feed/")]
        Reviews,

        [Description("https://www.wired.com/category/science/feed/")]
        Science,

        [Description("https://www.wired.com/category/science-blogs/feed/")]
        ScienceBlogs,

        [Description("https://www.wired.com/category/security/feed/")]
        Security,

        [Description("https://www.wired.com/category/transportation/feed/")]
        Transportation,

        [Description("https://www.wired.com/category/photo/feed/")]
        Photo,

        [Description("Mozilla/5.0 (Windows NT 10.0, Win64, x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36")]
        UserAgent,

        [Description("https://wiredreader.herokuapp.com/")]
        ApiRoot,

        [Description("https://wiredreader.herokuapp.com/rss")]
        ApiRss,

        [Description("https://www.wired.com/category/photo/feed/wired")]
        ApiWired
    }
}
