using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace rssFeed
{
    public static class NewsDatabase
    {
        private static List<News> _novini = null;
        public static List<News> Novosti
        {
            get
            {
                if (_novini == null)
                {
                    _novini = new List<News>();
                    News news;
                    news = new News();
                    news.Date = DateTime.Parse(DateTime.Now.AddHours(-6).ToString("yyyy-MM-dd HH:mm"));
                    news.Description = "Description";
                    news.Description2 = "Description2";
                    news.Title = "Title";
                    news.Link = "Link";
                    news.ImgLink = "";
                    news.image = new Bitmap(60,40);
                    news.reSource = "testResource";
                    _novini.Add(news);
                }
                return _novini;
            }
        }
    }
    public struct News
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Link { get; set; }
        public string ImgLink { get; set; }
        public Bitmap image { get; set; }
        public string reSource { get; set; }
    }

}