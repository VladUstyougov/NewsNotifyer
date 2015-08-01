using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;


namespace rssFeed
{
    class readFeed
    {
        string[,] rssData = null;
        Timer timer3 = new Timer();
        Timer timer4 = new Timer();
        DateTime lastTime;
        string linkToRss = "", izdatelstvo = "";
        int novostei = 0;
        string encForDescr = "utf-8", pathToDescription = "";

        public readFeed(string linkRss, string izdatel, string pathTo, string encoding = "utf-8")
        {
            this.pathToDescription = pathTo;
            this.encForDescr = encoding;
            this.linkToRss = linkRss;
            this.izdatelstvo = izdatel;
            Random r1 = new Random();
            timer3.Interval = 20000;
            timer3.Enabled = true;
            timer3.Tick += new EventHandler(timer3_Tick);
            timer4.Enabled = true;
            timer4.Tick += new EventHandler(timer4_Tick);
            timer4.Interval = 24000;
            timer4.Start();
            timer3.Start();
            //Form1.ActiveForm.Text += "Rf...";
            refr();


        }

        private String[,] getRssData(String channel)
        {
            String[,] tempRssData = null;
            try
            {
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                System.IO.Stream rssStream = myResponse.GetResponseStream();
                System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

                rssDoc.Load(rssStream);
                System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

                tempRssData = new String[100, 5];

                for (int i = 0; i < rssItems.Count; i++)
                {
                    novostei = rssItems.Count;
                    System.Xml.XmlNode rssNode;
                    rssNode = rssItems.Item(i).SelectSingleNode("title");
                    if (rssNode != null)
                    {
                        if (i == 0 && rssData != null && rssNode.InnerText == rssData[0, 0]) break;
                        tempRssData[i, 0] = rssNode.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 0] = "";
                    }

                    rssNode = rssItems.Item(i).SelectSingleNode("description");
                    if (rssNode != null)
                    {
                        tempRssData[i, 1] = rssNode.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 1] = "";
                    }

                    rssNode = rssItems.Item(i).SelectSingleNode("link");
                    if (rssNode != null)
                    {
                        tempRssData[i, 2] = rssNode.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 2] = "";
                    }
                    rssNode = rssItems.Item(i).SelectSingleNode("pubDate");
                    if (rssNode != null)
                    {
                        tempRssData[i, 3] = rssNode.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 3] = "";
                    }
                    rssNode = rssItems.Item(i).SelectSingleNode("enclosure");
                    if (rssNode != null)
                    {
                        tempRssData[i, 4] = rssNode.Attributes["url"].Value;
                    }
                    else
                    {
                        tempRssData[i, 4] = "";
                    }
                    //if (i > 5) break;
                }


                
            }
            catch (Exception e)
            {
                //Form2 otherForm;
                //otherForm = (Form2)Application.OpenForms["Form2"];
                //otherForm.TextInput += "\n readFeed-Get: " + "Error " + izdatelstvo + "\n" + e.Message + "      \n";
                //otherForm = null;
                //rssFeed.Form1._header += "E" + izdatelstvo + " ";
                //String[,] gault = new String[100, 4];
                //gault[0, 0] = "";
                //gault[0, 1] = "";
                //gault[0, 2] = "";
                //gault[0, 3] = DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm");
                //return gault;
            }
            return tempRssData;
        }


        private void refr()
        {
            int gn = 0;
            rssData = null;
            rssData = getRssData(linkToRss);
            if (rssData != null)
            {
                for (int j = 0; j < novostei; j++)
                {
                    if (rssData[j, 0] != null)
                    {
                        if (rssData[j, 2] != null)
                        {
                            if (lastTime == null) { lastTime = DateTime.Parse(rssData[15, 3]); }
                            if (lastTime < DateTime.Parse(rssData[j, 3]))
                            {
                                try
                                {
                                    gn++;
                                    News news = new News();
                                    news.Date = Convert.ToDateTime(rssData[j, 3]);

                                    String _title = Regex.Replace(Regex.Replace(rssData[j, 0], @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty).Trim().Replace("&quot;", "").Replace("#039;", "").Replace("  ", " ").Replace("<!-- google_ad_section_start -->", "").Replace("<!-- google_ad_section_end -->", "").Replace("&nbsp;", "").Replace("#39;", "").Replace("  ", " ");
                                    if (_title.Length > 196)
                                    {
                                        news.Title = _title.Remove(196);
                                    }
                                    else
                                    {
                                        news.Title = _title;
                                    }

                                    String descr = Regex.Replace((Regex.Replace(Regex.Replace(rssData[j, 1], @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim().Replace("&quot;", "").Replace("#039;", "").Replace("  ", " ").Replace("<!-- google_ad_section_start -->", "").Replace("<!-- google_ad_section_end -->", ""), "[\r\n]+", " ").Replace("#39;", "").Replace("&nbsp;", "").Replace("  ", " ");
                                    if (descr.Length > 350)
                                    {
                                        news.Description = descr.Remove(350) + "...";
                                    }
                                    else
                                    {
                                        news.Description = descr;
                                    }
                                    news.reSource = izdatelstvo;

                                    String _link = (rssData[j, 2]).Trim();
                                    if (_link.Length > 190)
                                    {
                                        news.Link = Regex.Replace(_link.Remove(190), "[\r\n]+", " ");
                                    }
                                    else
                                    {
                                        news.Link = _link;
                                    }

                                    if (rssData[j, 4] != null)
                                    {
                                        news.ImgLink = (rssData[j, 4]).Trim();
                                    }
                                    String _desciption2 = readDescr(_link, this.pathToDescription, this.encForDescr);
                                    _desciption2 = Regex.Replace(_desciption2, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty);
                                    _desciption2 = _desciption2.Trim().Replace(((char)Convert.ToChar(9)).ToString(), " ");
                                    _desciption2 = _desciption2.Replace(((char)Convert.ToChar(10)).ToString(), " ");
                                    _desciption2 = _desciption2.Replace(((char)Convert.ToChar(13)).ToString(), " ");
                                    //------------------------------------------------------
                                    _desciption2 = _desciption2.Replace("(function(){window.pagespeed=window.pagespeed||{};var b=window.pagespeed;function c(){}c.prototype.a=function(){var a=document.getElementsByTagName(\"pagespeed_iframe\");if(0<a.length){for(var a=a[0],f=document.createElement(\"iframe\"),d=0,e=a.attributes,g=e.length;d<g;++d)f.setAttribute(e[d].name,e[d].value);a.parentNode.replaceChild(f,a)}};c.prototype.convertToIframe=c.prototype.a;b.b=function(){b.deferIframe=new c};b.deferIframeInit=b.b;})(); pagespeed.deferIframeInit(); pagespeed.deferIframe.convertToIframe();", "");

                                    //-------------------------------------------------------
                                    _desciption2 = _desciption2.Replace("  ", " ").Trim().Replace("&quot;", "").Replace("#039;", "").Replace("<!-- google_ad_section_start -->", "").Replace("<!-- google_ad_section_end -->", "").Replace("#39;", "").Replace("&nbsp;", "");
                                    if (_desciption2.Length > 3990) _desciption2 = _desciption2.Remove(3990);
                                    //-----------------------------------------------------
                                    news.Description2 = _desciption2;
                                    //-----------------------------------------------------
                                    NewsDatabase.Novosti.Insert(0, news);
                                    //readDescr de = new readDescr(_link, this.pathToDescription, "utf-8");
                                    //var dog = NewsDatabase.Novosti.First(d => d.Link.Equals(_link));
                                    //Console.WriteLine(dog.Description2);
                                }
                                catch (Exception m)
                                {
                                    rssFeed.Form1._header += "E";
                                    //Form2 otherForm;
                                    //otherForm = (Form2)Application.OpenForms["Form2"];
                                    //otherForm.TextInput += "\n readFeed-Refr: " + "Error " + izdatelstvo + "\n" + m.Message + "\n";
                                    //otherForm = null;
                                    // MessageBox.Show(m.Message);
                                }
                            }
                        }

                        //if (rssData[j, 1] != null)
                        //{
                        //    Label lab = new Label();
                        //    if (rssData[j, 1].Length > 20) i += 20;
                        //    lab.Text = rssData[j, 1];
                        //    lab.Location = new Point(13, 30*j+i);
                        //    this.Controls.Add(lab);
                        //}

                        //if (rssData[j, 2] != null)
                        //{
                        //    LinkLabel linki = new LinkLabel();
                        //    linki.Width = 200;
                        //    linki.Text = "GoTo" + rssData[j, 0];
                        //    linki.Location = new Point(13,  40*j+i);
                        //    this.Controls.Add(linki);
                        //}
                    }
                }
                if (rssData[0, 3] != null)
                    lastTime = DateTime.Parse(rssData[0, 3]);
                else DateTime.Now.AddDays(-1);
            }

            rssFeed.Form1._header += gn + ".";
            gn = 0;
            novostei = 0;
        }
        public string readDescr(string linkX, string pathTo, string encoding)
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
                if (c != null)
                {
                    foreach (HtmlNode c1 in c)
                    {
                        result1 += c1.InnerText.Trim();
                        result1 += Environment.NewLine;

                    }
                }
            }
            catch (WebException e) { }
            return result1;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            refr();
        }



    }
}

