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
using HtmlAgilityPack;
using System.Net.Http;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace rssFeed
{
    public partial class Form2 : Form
    {
        //SqlConnection cn2;
        public Form2()
        {
            InitializeComponent();
            //cn2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=weeknews;Integrated Security=SSPI");
            this.Visible=true;
            //this.TopMost = true;
            this.Size = new Size(500, 500);
            this.Location = new Point(0, 0);
            //this.Location=new Point(Form1.ActiveForm.Location.X-20,Form1.ActiveForm.Location.Y+20);
            label1.Width = 450;
            label2.Width = 450;
            //this.WindowState = FormWindowState.Minimized;
        }
        public string TextInput
        {
            get
            {
                return textBox3.Text;
            }
            set
            {
                textBox3.Text=value;
            }
        }
       
        //public static string GetHtmlPageText(string url)
        //{
            //WebClient client = new WebClient();
            //using (Stream data = client.OpenRead(url))
            //{
            //    using (StreamReader reader = new StreamReader(data))
            //    {
            //        return reader.ReadToEnd();
            //    }
            //}
        //}
        private void button1_Click(object sender, EventArgs e)
        {


            //HttpClient httpC = new HttpClient();
            //var response = httpC.GetByteArrayAsync(textBox1.Text);
            //Byte[] dataB= response.Result;
            //String source = Encoding.GetEncoding("utf-8").GetString(dataB, 0, dataB.Length - 1);
            // source = WebUtility.HtmlDecode(source);
            //HtmlAgilityPack.HtmlDocument resultat = new HtmlAgilityPack.HtmlDocument();
            //resultat.LoadHtml(source);
            //List<HtmlNode> toftitle = resultat.DocumentNode.Descendants().Where
            //(x => (x.Name == "div" && x.Attributes["class"] != null &&
            // x.Attributes["class"].Value.Contains("left_colum"))).ToList();
            //for(int i =0;i<toftitle.Count;i++)
            //{
            //var li = toftitle[i].Descendants("p").ToList();
            //foreach (HtmlNode item in li)
            //{
               
            //   textBox3.Text += item.FirstChild.OuterHtml;
            //    if(item.Descendants("a").ToList()[0]!=null)
            //    textBox3.Text +=  item.Descendants("a").ToList()[0].GetAttributeValue("href", null);
            //    if (item.Descendants("strong").ToList()[0] != null)
            //    textBox3.Text += item.Descendants("strong").ToList()[0].InnerText.Trim();
            //    if (item.Descendants("img").ToList()[0] != null)
            //   textBox3.Text +=  item.Descendants("img").ToList()[0].GetAttributeValue("src", null);
            //    if (item.Descendants("em").ToList()[0] != null)
            //   textBox3.Text += item.Descendants("em").ToList()[0].InnerText.Trim();
            //    textBox3.Text += item.FirstChild.InnerText.Trim();
            //}
        //}
            //textBox3.Text= GetEasylabViews(textBox1.Text, textBox2.Text);
            //string data = GetHtmlPageText(textBox1.Text);
            //for (int i = 1; i < 100; i++)
            //{
            //    string expr = textBox2.Text +@"[^>]*?>((.|\s)*?(<\/div>)){"+i.ToString() + @"}";
            //    Regex rgx1 = new Regex(expr, RegexOptions.Compiled);
            //    Match mc1 = rgx1.Match(data);
            //    Regex rgx2 = new Regex(@"<div[^>]*?>", RegexOptions.Compiled);
            //    MatchCollection mc2 = rgx2.Matches(mc1.Value);
            //    if ((i - mc2.Count) == 0)
            //    {
            //        textBox3.Text+= mc1.Value;
            //    }
            //}

            ////////////////////////////////////////////////////////////////
            //using(SqlConnection connection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=weeknews;Integrated Security=SSPI"))
            //{
            //    connection1.Open();
            //     using(SqlCommand cmd = connection1.CreateCommand())
            //     {
            //        List<News> key2 = rssFeed.NewsDatabase.Novosti.OrderByDescending(o => o.Date).ToList();
            //        cmd.CommandText =  "INSERT INTO NewsDay([title],[description],[link],[source]) VALUES(@param1,@param2,@param3,@param4)";
                    
            //        cmd.Parameters.AddWithValue("@param1", key2[0].Title);
            //        cmd.Parameters.AddWithValue("@param2", key2[0].Description);
            //        cmd.Parameters.AddWithValue("@param3", key2[0].Link);
            //        cmd.Parameters.AddWithValue("@param4", key2[0].reSource);
            //        cmd.CommandType = CommandType.Text;
            //        cmd.ExecuteNonQuery();
            //     }
            //}
            
            //using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tovar;Integrated Security=True"))
            //{
            //    List<News> key2 = rssFeed.NewsDatabase.Novosti.OrderByDescending(o => o.Date).ToList();
            //    using (SqlCommand cmds = new SqlCommand())
            //    {
            //        cmds.Connection = conn;
            //        label2.Text = conn.Database;
            //        cmds.CommandType = CommandType.Text;
            //        cmds.CommandText = @"USE tovar;INSERT INTO NewsDay(data1,title1,description1,link1,source1) VALUES(@param1,@param2,@param3,@param4,@param5)";
            //        String param1 = key2[0].Date.ToString("yyyy-MM-dd HH:mm");
            //        cmds.Parameters.AddWithValue("@param1", param1);
            //        String param2 = Regex.Replace(key2[0].Title.ToString(), @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty);
            //        cmds.Parameters.AddWithValue("@param2", param2);
            //        String param3 = Regex.Replace(key2[0].Description.ToString(), @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty);
            //        cmds.Parameters.AddWithValue("@param3", param3);
            //        String param4 = Regex.Replace(key2[0].Link.ToString(), @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty);
            //        cmds.Parameters.AddWithValue("@param4", param4);
            //        String param5 = Regex.Replace(key2[0].reSource.ToString(), @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty);
            //        cmds.Parameters.AddWithValue("@param5", param5);
            //        label2.Text += "<br>"+param1 + param2 + param3 + param4 + param5;
            //        //cmds.Parameters.AddWithValue("@param1", Convert.ToDateTime("2014-12-12 14:34"));
            //        //cmds.Parameters.AddWithValue("@param2", "Title");
            //        //cmds.Parameters.AddWithValue("@param3", "descr");
            //        //cmds.Parameters.AddWithValue("@param4", "link");
            //        //cmds.Parameters.AddWithValue("@param5", "source");
            //        try
            //        {
            //            label2.Text += cmds.CommandText;
            //            conn.Open();
            //            label2.Text += cmds.ExecuteNonQuery();
            //        }
            //        catch (SqlException e3)
            //        {
            //            label2.Text+=e3.Message.ToString();
            //            label2.Text += e3.InnerException;
            //            label2.Text += e3.StackTrace.ToString();
            //            label2.Text += cmds.CommandText;
            //        }

            //    }
            //}
            ////////////////////////////////////////////////////////////////

            //try
            //{
                
            //    SqlCommand cmd2 = new SqlCommand();
            //    List<News> key2 = rssFeed.NewsDatabase.Novosti.OrderByDescending(o => o.Date).ToList();
            //    cmd2.CommandType = System.Data.CommandType.Text;
            //    cmd2.Connection = cn2;
            //    cmd2.CommandText = "INSERT INTO NewsDay ([title],[description],[link],[source]) VALUES ('" + key2[0].Title + "','" + key2[0].Description + "','" + key2[0].Link + "','" + key2[0].reSource + "')";
            //    label1.Text = cmd2.CommandText;
            //    cn2.Open();
            //    cmd2.ExecuteNonQuery();
            //    cn2.Close();
            //}
            //catch (Exception e1)
            //{
            //    label2.Text = e1.Message;
            //    label2.Text += e1.InnerException;
            //    label2.Text += e1.StackTrace;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using(SqlConnection cn2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tovar;Integrated Security=True"))
            //{
            //    SqlCommand cmd2 = new SqlCommand();
            //    cmd2.CommandType = System.Data.CommandType.Text;    
            //    cmd2.Connection = cn2;
            //    cmd2.CommandText = "USE tovar;CREATE TABLE NewsDay(ID int IDENTITY(1,1) NOT NULL PRIMARY KEY, data1 datetime NULL, title1 nvarchar(200) NULL, description1 nvarchar(400) NULL,link1 nvarchar(200) NULL,imglink1 nvarchar(200) NULL,source1 nvarchar(50) NULL)";
            //    label1.Text = cmd2.CommandText;
            //    cn2.Open();
            //    label1.Text+=cmd2.ExecuteNonQuery();
            //    cn2.Close();
            //}
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //((Form1)Application.OpenForms["Form1"]).Close();
            //this.Close();
        }


        
        
    }
}
