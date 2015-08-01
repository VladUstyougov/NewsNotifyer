using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace rssFeed
{
    public partial class Form1 : Form
    {
        public static string _header { get; set; }
        public List<News> listNews;
        int sec = 0, min = 0, hur = 0;
        //int mouse_x = 0, mouse_y = 0;
        //bool lock_form = false;

         int wdtDisplay = Screen.PrimaryScreen.Bounds.Width;
         int hgtDisplay = Screen.PrimaryScreen.Bounds.Height;
        //int maxtitle = 0, maxdescription = 0, maxlink = 0, maximglink = 0;
        //Form errorForm;

        protected override bool ShowWithoutActivation { get { return true; } }

        public Form1()
        {

            InitializeComponent();
            //Form2 f2 = new Form2();
            //errorForm = new Form();
            //errorForm.Visible = true;
            this.Location = new Point(0, 0);
            _header = "";
            this.Visible = false;
            this.Text = _header;
            readFeed a1 = new readFeed("http://www.ukrinform.ua/ukr/rss/news/lastnews", "ukrinform.ua", "//div[@class='left_colum']/p");
            readFeed a2 = new readFeed("http://censor.net.ua/includes/news_ru.xml", "censor.net", "//div[@class='text']");
            readFeed a3 = new readFeed("http://zik.ua/ua/rss/export.rss", "zik.ua", "//div[@class='post-full']/p");
            readFeed a4 = new readFeed("http://www.radiosvoboda.org/api/epiqq", "radiosvoboda.org", "//div[@class='zoomMe']/p");
            readFeed a5 = new readFeed("http://www.epravda.com.ua/rss/", "Економічної правдa", "//div[@class='text']/p", "windows-1251");//windows-1251
            readFeed a6 = new readFeed("http://rss.unian.net/site/news_ukr.rss", "unian.net", "//div[@class='article_body']");
            readFeed a7 = new readFeed("http://www.eurointegration.com.ua/rss/", "eurointegration.com.ua", "//div[@class='text']", "windows-1251");//windows-1251
            readFeed a8 = new readFeed("http://gordonua.com/xml/rss.html", "gordonua.com", "//div[@class='block article']/p");
            readFeed a9 = new readFeed("http://www.5.ua/novyny/rss", "5.ua", "//div[@class='article-content']/p");
            readFeed a10 = new readFeed("http://www.accbud.ua/news/category/sobytija/rss", "accbud.ua", "//div[@class='news-main']/p");
            readFeed a12 = new readFeed("http://rss.dw.de/xml/rss-ru-all", "dw.de", "//div[@class='longText']/p");
            readFeed a13 = new readFeed("http://www.zagorodna.com/rss/index.php?lang_id=1", "zagorodna.com", "//div[@class='txt']/span");
            readFeed a14 = new readFeed("http://www.dsnews.ua/static/rss/newsline.rss.xml", "Деловая Столица", "//div[@class='publication-text']");
            readFeed a15 = new readFeed("http://cripo.com.ua/export/rss.xml", "Украина криминальная", "//div[@id='subj']/p", "windows-1251");//windows-1251
            readFeed a16 = new readFeed("http://magnolia-tv.com/rss.xml", "magnolia", "//div[@class='art-article']/p");
            readFeed a17 = new readFeed("http://lb.ua/rss/news.xml", "LB.ua", "//div[@class='post-text']/div");
            readFeed a18 = new readFeed("http://www.day.kiev.ua/uk/news-rss.xml", "День", "//div[@class='field-item even']/p");
            readFeed a19 = new readFeed("http://zaxid.net/rss/all.xml", "Zaxid.net", "//span[@id='newsSummary']/p");
            readFeed a20 = new readFeed("http://www.charter97.org/ru/rss/ukraine/", "Хартия97", "//article[@class='article']/p", "utf-8");
            readFeed a21 = new readFeed("http://www.pravda.com.ua/rss/view_news/", "Украинская Правда", "//div[@class='text']", "windows-1251");
            readFeed a22 = new readFeed("http://hvylya.net/feed/", "Хвиля", "//div[@id='article-area']/p", "utf-8");
            readFeed a24 = new readFeed("http://www.depo.ua/static/rss/newsline.ukr.rss.xml", "depo.ua", "//div[@id='newsText']/p");

            //readFeed a23 = new readFeed("http://svidok.ua/ua/news/rss/", "Свiдок", "//div[@class='entry _ga1_on_']/p");
            //readFeed a24 = new readFeed("http://www.hromadske.tv/rss", "Громадське", "//div[@class='text-wrapp']/p");
            //readFeed a11 = new readFeed("http://expres.ua/rss.xml", "expres.ua", "//div[@class='node-content']/p");

            //--readFeed a13 = new readFeed("http://k-z.com.ua/rss/5-kievskie-novosti", "Конфликты и законы");
            //--readFeed a20 = new readFeed("http://www.segodnya.ua/xml/rss.html", "Сегодня");
            //--readFeed a20 = new readFeed("http://mykyiv.com.ua/k2-items/novyny?format=feed&type=rss", "mykyiv.com.ua-20");
            //--readFeed a21 = new readFeed("http://telegraf.com.ua/yandex-feed/", "ТЕЛЕГРАФ-21");
            //--readFeed a22 = new readFeed("http://admin10.rabota.ua/Export/vacancy/feed.ashx?ntid=2793018", "Samsung Vacancy");

            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();
            rss();
            timer2.Enabled = true;
            timer2.Interval = 30000;
            timer2.Start();


        }


        private void GetOtherFormTextBox(string str)
        {
            //Form2 otherForm;
            //otherForm=(Form2)Application.OpenForms["Form2"];
            //otherForm.TextInput = str ;
            //  otherForm=null;
        }
        String strWithParam, p1, p2, p3, p4, p5;

        public void rss()
        {
            int j = 0, i = 5;
            if (rssFeed.NewsDatabase.Novosti.Count > 0)
            {
                this.Controls.Clear();
                int maxwidth = this.Width - 20;
                int _imgsize = 0;
                foreach (News key in rssFeed.NewsDatabase.Novosti.OrderByDescending(o => o.Date).ToList())
                {
                    j++;
                    Label topic = new Label();
                    topic.AutoSize = true;
                    topic.Text = key.Date.ToShortTimeString();
                    //topic.BackColor = Color.DarkSeaGreen;
                    topic.ForeColor = Color.White;
                    //topic.Width = 40;
                    //topic.MaximumSize = new Size(600, 0);
                    //SizeF textSize = TextRenderer.MeasureText(topic.Text, topic.Font);
                    //topic.Height=(int)(topic.Padding.Vertical + textSize.Height);
                    topic.Location = new Point(3, i);
                    this.Controls.Add(topic);
                    //-----------------------------------------------
                    if (key.ImgLink != null && key.ImgLink != "")
                    {
                        try
                        {
                            var request = WebRequest.Create(key.ImgLink);
                            using (var response = request.GetResponse())
                            using (var stream = response.GetResponseStream())
                            {
                                Image originalImage = System.Drawing.Image.FromStream(stream, true, true);
                                Image resizedImage = originalImage.GetThumbnailImage(60, (60 * originalImage.Height) / originalImage.Width, null, IntPtr.Zero);
                                PictureBox pic1 = new PictureBox();
                                //pic1.BorderStyle = BorderStyle.FixedSingle;
                                pic1.Width = 60;
                                pic1.Height = 40;

                                var Dog = rssFeed.NewsDatabase.Novosti.First(w => w.ImgLink == key.ImgLink);
                                Dog.image = new Bitmap(resizedImage);
                                //ImageConverter conv = new ImageConverter();
                                //Byte[] bytes = (Byte[])conv.ConvertTo(Dog.image, typeof(byte[]));

                                //ImageConverter conv2 = new ImageConverter();
                                //MemoryStream mStream = new MemoryStream(bytes);
                                //Bitmap bimp = new Bitmap(mStream); 
                                pic1.Image = resizedImage;
                                //pic1.Image = resizeImage(originalImage, new Size(60, 40));
                                pic1.Location = new Point(45 + 2, i);
                                this.Controls.Add(pic1);
                                _imgsize = 65;
                            }
                        }
                        catch (Exception e)
                        {
                            //GetOtherFormTextBox("\n ImgLink: " + key.ImgLink +
                            //    "\n Source: " + e.Source +
                            //    "\n Message: " + e.Message +
                            //    "\n Data: " + e.Data +
                            //    "\n InnerException: " + e.InnerException +
                            //    "\n StackTrace: " + e.StackTrace +
                            //    "\n HelpLink: " + e.HelpLink +
                            //    "\n ToString: " + e.ToString());
                        }

                    }
                    else _imgsize = 0;
                    //-----------------------------------------------
                    LinkLabel topic2 = new LinkLabel();
                    topic2.LinkClicked += new LinkLabelLinkClickedEventHandler(topic2_LinkClicked);
                    topic2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                    topic2.AutoSize = true;
                    topic2.Text = key.Title + " (" + key.reSource + ")";

                    topic2.MaximumSize = new Size(this.Width - 45 - 10 - _imgsize, 0);
                    //topic2.BackColor = Color.DarkSeaGreen;
                    topic2.ForeColor = Color.White;
                    //topic2.Font = new Font("Georgia", 16);
                    topic2.Font = new Font(this.Font.Name, this.Font.Size + 2, FontStyle.Bold);
                    //SizeF textSize2 = TextRenderer.MeasureText(topic2.Text, topic2.Font);
                    //topic2.Width = (int)(topic2.Padding.Horizontal + textSize2.Width);
                    //topic2.Height = (int)(topic2.Padding.Vertical + textSize2.Height) ;
                    topic2.Location = new Point(45 + _imgsize, i - 3);
                    topic2.ActiveLinkColor = Color.Orange;
                    topic2.VisitedLinkColor = Color.Gray;
                    topic2.LinkColor = Color.White;
                    topic2.DisabledLinkColor = Color.Black;
                    //topic2.LinkArea = new LinkArea(0, key.Link.Length);
                    topic2.Links.Add(0, topic2.Text.Length, key.Link);
                    i += topic2.PreferredHeight + 3;
                    this.Controls.Add(topic2);
                    //-----------------------------------------------
                    Label topic3 = new Label();
                    topic3.AutoSize = true;
                    if (key.Description.Length > 348)
                    {
                        topic3.Text = key.Description.Remove(348) + "...";
                    }
                    else
                    {
                        topic3.Text = key.Description;
                    }

                    topic3.MaximumSize = new Size(this.Width - 45 - 10 - _imgsize, 0);
                    //topic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    //topic3.BackColor = Color.DarkSeaGreen;
                    topic3.ForeColor = Color.White;
                    SizeF textSize3 = TextRenderer.MeasureText(topic3.Text, topic3.Font);
                    topic3.Width = this.Width - 45 - 10 - _imgsize;
                    //topic3.Height = (int)(topic3.Padding.Vertical + textSize3.Height);
                    topic3.Location = new Point(45 + _imgsize, i - 3);
                    if (topic2.PreferredHeight + 3 + topic3.PreferredHeight < 40 && _imgsize == 65)
                    {
                        i += (40 - topic2.PreferredHeight);
                    }
                    else
                    {
                        i += topic3.PreferredHeight + 4;
                    }

                    this.Controls.Add(topic3);
                    _imgsize = 0;
                    //-----------------------------------------------
                    if (topic.Width + topic2.Width > maxwidth) maxwidth = topic.Width + topic2.Width;
                    if (j >= 20)
                    {
                        this.Text = this.Height.ToString();
                        //this.Width = maxwidth + 10;
                    }
                    else
                    {
                        this.Height = i + 20;
                        //this.Width = maxwidth  + 10;
                    }
                    if (this.Height > hgtDisplay) this.Height = hgtDisplay;
                    if (this.Location.Y < 0) this.Location = new Point(this.Location.X, 0);
                    if (i + 12 > hgtDisplay - 70)
                    {
                        //_header = String.Format(" i={0}, this.top={1}, height of display={2} ", i, this.Top, hgtDisplay);
                        break;
                    }
                }
                
                this.Location = new Point(wdtDisplay - 20 - this.Width, hgtDisplay - 50 - this.Height);

                GoVisible();
                //try
                //{
                    //SqlConnection cn = new SqlConnection(@"Data Source=S445\SQLEXPRESS;Initial Catalog=tovar;Integrated Security=True");
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandType = System.Data.CommandType.Text;
                    //cmd.Connection = cn;
                    //if (cn.State == ConnectionState.Open) cn.Close();
                    //cn.Open();

                    //foreach (News key in rssFeed.NewsDatabase.Novosti.OrderByDescending(o => o.Date).ToList())
                    //{
                    //    if (key.ImgLink != null && key.ImgLink != "")
                    //    {
                            //        cmd.Parameters.Clear();
                            //        strWithParam = "";
                            //        cmd.CommandText = "";
                            //        try
                            //        {
                            //var request = (HttpWebRequest)WebRequest.Create(key.ImgLink);
                            //using (var response = (HttpWebResponse)request.GetResponse())
                            //using (var stream = response.GetResponseStream())
                            //{
                            //    int w = 0;
                            //    Image originalImage = System.Drawing.Image.FromStream(stream, true, true);
                            //    if (originalImage.Width > 300 || originalImage.Height > 300) w = 200;
                            //    else w = originalImage.Width;
                            //    Image resizedImage = originalImage.GetThumbnailImage(w, (w * originalImage.Height) / originalImage.Width, null, IntPtr.Zero);
                            //    ImageConverter conv = new ImageConverter();
                            //    Byte[] bytes = (Byte[])conv.ConvertTo(resizedImage, typeof(byte[]));

                            //    strWithParam = "USE tovar;INSERT INTO NewsDay (data1, title1,description1,description2,link1,image1,imglink1,source1) VALUES ('" +
                            //   key.Date.ToString("yyyy-MM-dd HH:mm") + "','" +
                            //   (Regex.Replace(Regex.Replace(key.Title, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim() + "','" +
                            //   (Regex.Replace(Regex.Replace(key.Description, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim() + "','" +
                            //   (Regex.Replace(Regex.Replace(key.Description2, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim() + "','" +
                            //   (key.Link).Trim() + "',@photo,'" +
                            //   (key.ImgLink).Trim() + "','" +
                            //   Regex.Replace(key.reSource, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty) + "')";
                            //    cmd.Parameters.AddWithValue("@photo", bytes);
                            //}

                            //}
                            //catch (WebException ex1)
                            //{
                            //var status1 = ((HttpWebResponse)ex1.Response).StatusCode;
                            //if ((int)status1 == 404) continue;
                            //MessageBox.Show("status1" + status1 + "\n Source:" + ex1.Source +
                            //"\n Message" + ex1.Message +
                            //"\n Data" + ex1.Data +
                            //"\n InnerException" + ex1.InnerException +
                            //"\n StackTrace" + ex1.StackTrace +
                            //"\n HelpLink" + ex1.HelpLink +
                            //"\n ToString" + ex1.ToString(), "Pictures");

                            //GetOtherFormTextBox("\nGet Images: " + ex1.Message+"\n");
                            //MessageBox.Show(ex1.Message);
                            //continue;
                            //}
                            //catch (Exception ex2)
                            //{

                            //MessageBox.Show("\n Source:" + ex2.Source +
                            //  "\n Message" + ex2.Message +
                            //  "\n Data" + ex2.Data +
                            //  "\n InnerException" + ex2.InnerException +
                            //  "\n StackTrace" + ex2.StackTrace +
                            //  "\n HelpLink" + ex2.HelpLink +
                            //  "\n ToString" + ex2.ToString(), "Pictures");
                            //GetOtherFormTextBox("\nGet Images: " + ex2.Message+" \n");
                            //MessageBox.Show(ex2.Message);
                            //            continue;}

                        //}
                        //else
                        //{
                            //        cmd.Parameters.Clear();
                            //        strWithParam = "";
                            //        cmd.CommandText = "";
                            //        //-------------------------------newcode------------------------

                            //        strWithParam = "USE tovar;INSERT INTO NewsDay (data1, title1,description1,description2,link1,imglink1,source1) VALUES ('" +
                            //           key.Date.ToString("yyyy-MM-dd HH:mm") + "','" +
                            //           (Regex.Replace(Regex.Replace(key.Title, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim() + "','" +
                            //           (Regex.Replace(Regex.Replace(key.Description, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim() + "','" +
                            //           (Regex.Replace(Regex.Replace(key.Description2, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim() + "','" +
                            //           (key.Link).Trim() + "','" +
                            //           (key.ImgLink).Trim() + "','" +
                            //           Regex.Replace(key.reSource, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty) + "')";
                        //}
                        //    cmd.CommandText = strWithParam;

                        //    //--------------------Testing------------

                        //    p1 = key.Date.ToString("yyyy-MM-dd HH:mm");
                        //    p2 = (Regex.Replace(Regex.Replace(key.Title, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim();
                        //    p3 = (Regex.Replace(Regex.Replace(key.Description, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty), "['`]", String.Empty)).Trim();
                        //    p4 = (key.Link).Trim();
                        //    p5 = (key.ImgLink).Trim();


                        //    cmd.ExecuteNonQuery();
                        //    String _title = key.Title;
                        //    if (_title.Length > maxtitle) maxtitle = _title.Length;
                        //    String _description = key.Description;
                        //    if (_description.Length > maxdescription) maxdescription = _description.Length;
                        //    String _link = key.Link;
                        //    if (_link.Length > maxlink) maxlink = _link.Length;
                        //    String _imglink = key.ImgLink;
                        //    if (_imglink.Length > maximglink) maximglink = _imglink.Length;
                    //}
                    //--------------------Testing------------
                    //cn.Close();
                    rssFeed.NewsDatabase.Novosti.Clear();
                    _header += "X";

                    //cn.Dispose();
                    //if (cn.State == ConnectionState.Open) cn.Close();
                //}
                //catch (Exception e)
                //{
                    //if (errorForm != null)
                    //{
                    //    errorForm.Visible = true;/////<--
                    //    Label lbl1 = new Label();
                    //    lbl1.Text += strWithParam;
                    //    //lbl1.Text += "\nDate:" + p1 + "(" + p1.Length + ")\nTitle:" + p2 + "(" + p2.Length + ")\nDescription:" + p3 + "(" + p3.Length + ")\nLink:" + p4 + "(" + p4.Length + ")\nImgLink:" + p5 + "(" + p5.Length + ")\n";
                    //    lbl1.Text += " Source=" + e.Source;
                    //    lbl1.Text += " Data=" + e.Data;
                    //    lbl1.Text += " Message=" + e.Message;
                    //    lbl1.Text += " InnerException=" + e.InnerException;
                    //    lbl1.Text += " StackTrace=" + e.StackTrace;
                    //    lbl1.Text += " Source=" + e.Source;
                    //    lbl1.AutoSize = true;
                    //    errorForm.Controls.Add(lbl1);
                    //}
                    //else errorForm = new Form();

                    // MessageBox.Show("\nDate:" + p1 + "(" + p1.Length + ")\nTitle:" + p2 + "(" + p2.Length + ")\nDescription:" + p3 + "(" + p3.Length + ")\nLink:" + p4 + "(" + p4.Length + ")\nImgLink:" + p5 + "(" + p5.Length + ")\n");
                    // GetOtherFormTextBox("\nAdd To DB " + "\nDate:" + p1 + "(" + p1.Length + ")\nTitle:" + p2 + "(" + p2.Length + ")\nDescription:" + p3 + "(" + p3.Length + ")\nLink:" + p4 + "(" + p4.Length + ")\nImgLink:" + p5 + "(" + p5.Length + ")\n");
                //}
                //------------------------------------------------------------------
            }
            else
            {
                GoInvisible();
        
            }

        }

        private void GoVisible()
        {
            this.Visible = true;
            this.TopMost = true;
            for (double mi = 0.0f; mi < 0.9f; mi += 0.0001f)
            {
                this.Opacity = mi;
            }

            this.TopMost = false;
            this.AllowTransparency = false;
        }

        private void GoInvisible()
        {
            for (double mi = 0.9f; mi > 0.0f; mi -= 0.001f)
            {
                this.Opacity = mi;
            }
            this.TopMost = false;
            this.AllowTransparency = false;
            this.Visible = false;
        }


        void topic2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            //Process.Start(sInfo);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            //if (sec == 30) _header = " maxtitle" + maxtitle + " maxdescr=" + maxdescription + " maxlink=" + maxlink + " img=" + maximglink;
            if (sec >= 60)
            {
                sec = 0;
                min++;
                _header = "";
            }
            if (min >= 60)
            {
                min = 0;
                hur++;
            }
            //otklyuchenie taimera pri navedenii mishki
            //if (lock_form == true && timer2.Enabled == true)
            //{
            //    _header = "lock " + mouse_x + "x" + mouse_y + " ";
            //    timer2.Stop();
            //}
            //else
            //{
            //    if (lock_form == false && timer2.Enabled == false)
            //    {
            //        timer2.Start();
            //        _header = "Unlock " + mouse_x + "x" + mouse_y + " ";
            //        lock_form = false;
            //        rss();
            //    }
            //}
            this.Text = " " + hur + ":" + min.ToString() + ":" + sec.ToString() + " " + _header;
            if (_header.Length > 27) _header.Remove(0, _header.Length - 26);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            rss();
        }

        private Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)//<-erroro
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //mouse_x = e.Location.X;
            //mouse_y = e.Location.Y;
            //if (mouse_x > this.Location.X && mouse_y > this.Location.Y && this.Visible == true)
            //{
            //    if ((this.Location.X + this.Width) < mouse_x && (this.Location.Y + this.Height) < mouse_y)
            //    {
            //        lock_form = true;
            //    }
            //    else
            //    {
            //        lock_form = false;
            //    }
            //}
        }

    }
}
