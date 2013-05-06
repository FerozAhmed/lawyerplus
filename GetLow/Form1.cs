using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rental;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Microsoft.Office.Interop;
using System.Threading;
using log4net;
using System.Reflection;
using System.Threading.Tasks;

namespace GetLow
{
    public delegate void UpdateTextCallback(string text);
    public delegate void on_btn(bool enabled);

    public partial class Form1 : Form
    {
        internal static readonly ILog loger = LogManager.GetLogger("error.log");


        private bool stop = false;

        private string urlPattern = "http://online.zakon.kz/Controls/Tree.aspx?text=&TreeName=class&node={0}&mode=filterGetNodes";
        private Leaf[] dd = new[] { 
            new Leaf(){parent_site_id = null, id = 77, site_id = "1", Name = "Законодательство РК" },
            new Leaf(){parent_site_id = null, id = 78, site_id = "2344", Name = "Международное право"  },
            new Leaf(){parent_site_id = null,id = 79, site_id = "2704", Name = "Практика применения законодательства"  },
            new Leaf(){parent_site_id = null,id = 80, site_id = "3006", Name = "Комментарии, новости, вопросы-ответы"  },
            new Leaf(){parent_site_id = null,id = 81, site_id = "3439", Name = "Проекты нормативных правовых актов"  },
            new Leaf(){parent_site_id = null,id = 82, site_id = "5051", Name = "Нормативные и технические документы"  },
            new Leaf(){parent_site_id = null,id = 83, site_id = "3572", Name = "Примерные формы правовых документов"  },
            new Leaf(){parent_site_id = null,id = 84, site_id = "10641", Name = "Справочная и экономическая информация"  },
            new Leaf(){parent_site_id = null,id = 85, site_id = "13806", Name = "Словари"  }};




        public Form1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log("Click login");
            new Thread(ExecuteParsing).Start();
        }





        private void UpdateText(string text)
        {
            // Set the textbox text.
            listBox1.Items.Insert(0, listBox1.Items.Count + "\t" + DateTime.Now + "\t" + text);
        }

        private void log(string msg)
        {
            listBox1.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { msg });
        }


        private void GetNodes(List<Leaf> nodes)
        {
            loger.Error("GetNodes");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var node in nodes)
                {
                    if (stop) return;
                    bool loaded = DAL.TreeManager.IsLoaded(node.site_id, node.parent_site_id);
                    //using (var context = new dataEntities())
                    //    loaded = context.data.Any(d => d.site_id == node.site_id &&
                    //        (d.parent_site_id == node.parent_site_id || (node.parent_site_id == null && d.parent_site_id == null)) &&
                    //        d.is_loaded == true);
                    if (loaded)
                    {
                        log(node.site_id + " - done");
                        continue;
                    }

                    string error;
                    string html;
                    html = WebPage.LoadPage(String.Format(urlPattern, node.site_id), Encoding.UTF8, out error);
                    if (String.IsNullOrWhiteSpace(error))
                    {
                        if (!String.IsNullOrWhiteSpace(html))
                        {
                            foreach (var item in html.Split('$'))
                                if (!String.IsNullOrWhiteSpace(item))
                                {
                                    if (stop) return;
                                    string[] obj = item.Split(':');
                                    long id;
                                    if (long.TryParse(obj[0], out id))
                                    {
                                        var node_name = System.Web.HttpUtility.HtmlDecode(obj[3]);
                                        var n = new Leaf() { site_id = obj[0], Name = node_name, parent_site_id = node.site_id, parent_id = node.id };
                                        node.Nodes.Add(n);
                                        using (var context = new dataEntities())
                                        {
                                            //var d_indb = context.data.Where(t => t.site_id == n.site_id && t.parent_site_id == n.parent_site_id && t.parent_id == n.parent_id).FirstOrDefault();
                                            var d_indb = DAL.TreeManager.GetId(n.site_id, n.parent_site_id, (long)n.parent_id);
                                            if (d_indb == -1)
                                            {

                                                var d = new data()
                                                {
                                                    id = -1,
                                                    site_id = n.site_id,
                                                    name = n.Name,
                                                    parent_id = n.parent_id,
                                                    parent_site_id = n.parent_site_id,
                                                    position = node.Nodes.Count,
                                                    is_doc = false,
                                                    is_loaded = false
                                                };
                                                context.data.AddObject(d);
                                                context.SaveChanges();
                                                n.id = d.id;
                                            }
                                            else
                                                n.id = d_indb;
                                        }

                                    }
                                };
                            GetNodes(node.Nodes);
                        }
                        else //if doc
                        {
                            if (stop) return;
                            string urld = "http://online.zakon.kz/Search.aspx";
                            int max = 30;

                            int maxThread = 5;

                            var taskList = new List<DownloadTask>();
                            int posiont = 1;

                            for (int i = 1; i <= max; i++)
                            {
                                html = WebPage.LoadPage(urld, CreateNVC22(node.site_id, i.ToString()), Encoding.UTF8, out error);
                                Match m = Regex.Match(html, @"<a[\s]href='http://online\.zakon\.kz/Document/\?doc_id=([\d]*?)'.*?>(.*?)<", RegexOptions.Singleline);
                                if (!m.Success)
                                    break;
                                while (m.Success && m.Groups.Count > 1)
                                {
                                    if (stop) return;
                                    var dt = (new DownloadTask(m.Groups[1].ToString(), m.Groups[2].ToString(), node.site_id, node.id, posiont, log));
                                    dt.Execute();
                                    GC.Collect();
                                    //  Queue.Enqueue(dt);
                                    //taskList.Add(dt);
                                    posiont++;
                                    m = m.NextMatch();
                                }
                            }

                            //var tList = new List<Thread>();
                            //foreach (var item in taskList)
                            //{
                            //    var t = new Thread(item.Execute);
                            //    tList.Add(t);
                            //}


                            //while (tList.Count > 0)
                            //{
                            //    var qList = new List<Thread>();
                            //    for (int i = 0; i < Math.Min(maxThread, tList.Count); i++)
                            //    {
                            //        qList.Add(tList[i]);
                            //        tList[i].Start();
                            //    }

                            //    foreach (var q in qList)
                            //    {
                            //        q.Join();
                            //        tList.Remove(q);
                            //    }


                            //}




                         


                            //All related files dowloaded, let's try to set root like loaded
                            using (var context = new dataEntities())
                            {
                                var nnn = context.data.Where(d => d.id == node.id).FirstOrDefault();
                                if (nnn != null)
                                {
                                    nnn.is_loaded = true;
                                    context.SaveChanges();
                                }
                            }


                        }
                    }
                    else
                        log("Node:" + error);
                }
            }
        }

        private NameValueCollection CreateNVC22(string site_id, string page_num)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("mode", "full");
            nvc.Add("page", page_num);
            nvc.Add("com", "undefined");
            nvc.Add("sort", "0");
            nvc.Add("cl", "'" + site_id + "';");
            nvc.Add("type", "undefined");
            nvc.Add("source", "undefined");
            nvc.Add("date", "undefined");
            nvc.Add("dateMJ", "undefined");
            nvc.Add("status", "undefined");
            nvc.Add("number", "undefined");
            nvc.Add("numberValue", "undefined");
            nvc.Add("numberInput", "undefined");
            nvc.Add("numberMJ", "undefined");
            nvc.Add("numberMJValue", "undefined");
            nvc.Add("numberMJInput", "undefined");
            nvc.Add("situation", "undefined");
            nvc.Add("publication", "undefined");
            nvc.Add("ddtype", "undefined");
            nvc.Add("lang", "undefined");
            return nvc;
        }

        private string ConvertIntoUtf(string unicodeString)
        {

            // Create two different encodings.
            Encoding ascii = Encoding.UTF8;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte[].
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            // This is a slightly different approach to converting to illustrate
            // the use of GetCharCount/GetChars.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            return new string(asciiChars);
        }

        private string login, pass;

        void btn(bool enabled)
        {
            btnGo.Enabled = enabled;
        }

        void onbtn(bool enabled)
        {
            btnGo.Invoke(new on_btn(this.btn), new object[] { enabled });
        }

        private void ExecuteParsing()
        {
            stop = false;
            login = tbLogin.Text;
            pass = tbPass.Text;
            if (Login())
            {
                onbtn(false);
                btnGo.Enabled = false;
                try
                {
                    GetNodes(dd.ToList());
                    MessageBox.Show("Final"); 
                }
                finally
                {
                    onbtn(true);
                    Logout();
                    log("Stopped");
                }
            }
            else
                log("Cnn't login");
        }

        private void create()
        {
            using (var context = new dataEntities())
            {
                foreach (var n in dd)
                {
                    var d = new data() { id = -1, site_id = n.site_id, name = n.Name, parent_id = null, parent_site_id = null, data_rtf = null, data_text = null };
                    context.data.AddObject(d);
                }
                context.SaveChanges();
            }
        }

        private bool Login()
        {
            loger.Error("On login");
            string error;
            //http://online.zakon.kz/Controls/Info.aspx?mode=Login&login=
            //6915388693
            //3027895111
            string html = WebPage.LoadPage(String.Format("http://online.zakon.kz/Controls/Info.aspx?mode=Login&login={0}&password={1}", login, pass), Encoding.UTF8, out error);
            loger.Error(html);
            return !String.IsNullOrWhiteSpace(html) && !html.Contains("busy") && WebPage.Cookies != null && WebPage.Cookies.Count > 0 && String.IsNullOrWhiteSpace(error);
        }

        private bool Logout()
        {
            string error;
            WebPage.LoadPage(@"http://online.zakon.kz/Controls/Info.aspx?mode=Logout", Encoding.UTF8, out error);
            return WebPage.Cookies != null && WebPage.Cookies.Count > 0 && String.IsNullOrWhiteSpace(error);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //create();
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            stop = btnGo.Enabled = true;
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new dataEntities())
                {
                    var c = context.data.Count((t) => t.is_doc == true);
                    MessageBox.Show("Ok. count = " + c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error = " + ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout();
        }
    }
}
