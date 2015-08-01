using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;


namespace rssFeed
{
    class readDescr
    {
        public int _length = 0;
        public string _result="";
        public readDescr(string linkX, string pathTo, string encoding)
        {
            String result1 = "";
            try
            {
                HttpClient httpC = new HttpClient();
                var response = httpC.GetByteArrayAsync(linkX);
                Byte[] dataB = response.Result;
                String source = Encoding.GetEncoding(encoding).GetString(dataB, 0, dataB.Length - 1);
                source = WebUtility.HtmlDecode(source);
                HtmlAgilityPack.HtmlDocument resultat = new HtmlAgilityPack.HtmlDocument();
                resultat.LoadHtml(source);
                HtmlNodeCollection c = resultat.DocumentNode.SelectNodes(pathTo);
                //List<HtmlNode> c = resultat.DocumentNode.SelectNodes("//div[@class='left_colum']").ToList();"/html[1]/body[1]/div[3]/div[2]/div[1]/div[1]"
                //HtmlNodeCollection c = resultat.DocumentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[1]/div[1]");
                //List<HtmlNode> toftitle = resultat.DocumentNode.Descendants().Where
                //(x => (x.Name == "div" && x.Attributes["class"] != null &&
                // x.Attributes["class"].Value.Contains("left_colum"))).ToList();
                //if (c != null)
                //{
                //    for (int i = 0; i < c.Count; i++)
                //    {
                //        var li = c[i].Descendants("p").ToList();
                //        if (li != null)
                //        {
                //            for (int j = 0; j < li.Count; j++)
                //            {
                //                if (li[j].InnerText.Trim().StartsWith("Читайте також")) continue;
                //                result += li[j].XPath.ToString();
                //                result += li[j].InnerText.Trim();
                //                result += Environment.NewLine;
                //            }
                //        }
                //    }
                //}
                if (c != null)
                {
                    foreach (HtmlNode c1 in c)
                    {
                        result1 += c1.InnerText.Trim();
                        result1 += Environment.NewLine;

                    }
                }
            }
            catch (Exception m) { }
            //this._length = result1.Length;
            //var dog = rssFeed.NewsDatabase.Novosti.First(go => go.Link.Equals(linkX));
           // dog.Description2 = result1.Remove(200);
            
            var dog=NewsDatabase.Novosti.First(d =>d.Link.Equals(linkX));
                dog.Description2.Replace(dog.Description2 , result1);
        }
    }
}
