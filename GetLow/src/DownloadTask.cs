using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Rental;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace GetLow
{
    class DownloadTask
    {
        public int position;

        public string doc_name;

        public bool is_loaded = false;

        public string url;

        public string parent_site_id;

        public long parent_id;

        public string dir;

        public string file_name;

        public string doc_id;

        public UpdateTextCallback callback;

        private void log(string msg)
        {
            if (callback != null)
            {
                callback(msg);
            }
        }

        public DownloadTask(string pDocId, string pDocName, string pParentSiteId, long pParentId, int pPosition, UpdateTextCallback pCallback)
        {
            position = pPosition;
            parent_id = pParentId;
            doc_id = pDocId;
            doc_name = pDocName;

            url = "http://online.zakon.kz/Document/Word.aspx?topic_id=" + doc_id;

            parent_site_id = pParentSiteId;

            string dir = "doc/" + parent_site_id + "/";
            if (!Directory.Exists(dir)) ;
            Directory.CreateDirectory(dir);

            file_name = dir + doc_id + ".doc";

            is_loaded = File.Exists(file_name) && new FileInfo(file_name).Length > 0;

            if (!is_loaded)
            {
                int i = 1;
                while (File.Exists(file_name))
                {
                    file_name = dir + doc_id + String.Format("({0}).doc", i);
                    i++;
                }
            }

            callback = pCallback;
        }

        public void Execute()
        {
            var d_indb = DAL.TreeManager.GetId(doc_id, parent_site_id, parent_id);
            if (d_indb > 0)
            {
                log("doc_id =" + doc_id + " redy");
                return;
            }





            Stopwatch sw = Stopwatch.StartNew();
            WebPage.DownloadFile(url, file_name, callback);
            sw.Stop();
            var timeLoad = sw.ElapsedMilliseconds / 1000;
            var fileSize = (new FileInfo(file_name).Length);
            if (fileSize > 0)
            {
                using (var context = new dataEntities())
                {
                    //var d_indb = context.data.Where(t => t.site_id == doc_id && t.parent_site_id == parent_site_id && parent_id == this.parent_id).FirstOrDefault();
                    string data_rtf, data_text;

                    sw.Reset();
                    sw.Start();
                    string doc_info;
                    GetText(Path.GetFullPath(file_name), out data_rtf, out data_text, out doc_info);
                    sw.Stop();
                    var time_text = sw.ElapsedMilliseconds / 1000;

                    sw.Reset();
                    sw.Start();
                    var d = new data()
                    {
                        id = -1,
                        site_id = this.doc_id,
                        name = doc_name,
                        parent_id = parent_id,
                        parent_site_id = parent_site_id,
                        position = position,
                        is_doc = true,
                        is_loaded = true,
                        data_rtf = data_rtf,
                        data_text = data_text
                    };
                    context.data.AddObject(d);
                    context.SaveChanges();
                    sw.Stop();
                    var time_save = sw.ElapsedMilliseconds / 1000;


                    var milliSec = timeLoad + time_text + time_save;
                    var str = String.Empty;
                    if (milliSec > 3)
                        str += "all:" + milliSec + "\t\tload:" + timeLoad + "\t\ttext:" + time_text + "\t\tLENGTH:" + fileSize + "(" + doc_info + ")";
                    log("doc_id =" + doc_id + "\t" + str);

                }
            }
            else log("Leaf: doc file length is 0");
        }

        private void GetText(string filePath, out string rtfData, out string txtData, out string loginfo)
        {
            loginfo = String.Empty;
            txtData = String.Empty;
            rtfData = String.Empty;
            object Source = filePath;
            object Target = filePath + ".rtf";

            if (!File.Exists(Target.ToString()) || new FileInfo(Target.ToString()).Length == 0)
            {
                int i = 1;
                while (File.Exists(Target.ToString()))
                {
                    Target = filePath + "_(" + i + ").rtf";
                    i++;
                }

                // string html = File.ReadAllText(dialog.FileName);

              //  Stopwatch sw = Stopwatch.StartNew();

                Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();

                // specifying the Source & Target file names


                // Use for the parameter whose type are not known or  
                // say Missing
                object Unknown = Type.Missing;

                try
                {
                    // Source document open here
                    // Additional Parameters are not known so that are  
                    // set as a missing type
                    newApp.Documents.Open(ref Source, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                }
                catch (Exception ex)
                {

                    Log.Append("ERROR on open doc: " + filePath  + "\r\n" + ex.Message);
                }

              
              //  sw.Stop();
              //  var time_open = sw.ElapsedMilliseconds / 1000;

             //   sw.Restart();
                txtData = newApp.ActiveDocument.Content.Text;
                if (!String.IsNullOrWhiteSpace(txtData))
                    txtData = Regex.Replace(txtData, @"(Источник:[\s]ИС[\s]Параграф[\s]WWW[\s][<]*http://online\.zakon\.kz[>]*[\n-\x0D\s]*|http://online\.zakon\.kz[\n-\x0D\s]*)", "", RegexOptions.Singleline);
             //   sw.Stop();
             //   var time_text = sw.ElapsedMilliseconds / 1000;

            //    sw.Restart();
                // Specifying the format in which you want the output file 
                object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;



                //Changing the format of the document
                newApp.ActiveDocument.SaveAs(ref Target, ref format,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown);

                int c = 0;
                while (c < 2000)
                {
                    System.Windows.Forms.Application.DoEvents();
                    Thread.Sleep(1);
                    c++;
                }

                //Thread.Sleep(7000);
                // for closing the application
                try
                {
                    newApp.Quit(ref Unknown, ref Unknown, ref Unknown);
                    newApp = null;
                }
                catch (Exception ex)
                {
                    
                    log("ERROR on close WORD");
                }
            
             //   sw.Stop();
             //   var time_savertf = sw.ElapsedMilliseconds / 1000;

               // loginfo += "\t\topen doc: " + time_open + "\t\traplace txt: " + time_text + "\t\tsave rtf: " + time_savertf;
            }

            if (File.Exists(Target.ToString()))
                try
                {
                    int i = 1;

                    var fileNameAfterCopy = Target.ToString().Replace(".doc", ".doc2");

                    while (File.Exists(fileNameAfterCopy))
                    {
                        fileNameAfterCopy = Target.ToString().Replace(".doc", ".doc2(" + i + ")");
                        i++;
                    }

                    Stopwatch sw = Stopwatch.StartNew();
                    File.Copy(Target.ToString(), fileNameAfterCopy);
                    rtfData = File.ReadAllText(fileNameAfterCopy);
                    sw.Stop();
                    var time_readrtf = sw.ElapsedMilliseconds / 1000;

                    sw.Restart();
                    {
                        var index = rtfData.IndexOf(@"http://online.zakon.kz}}}\sectd");
                        if (index == -1)
                            index = rtfData.IndexOf(@"http://online.prg.kz}}}\sectd");
                        if (index == -1)
                            index = rtfData.IndexOf(@"http://www.zakon.kz}}}\sectd");

                        if (index > 0)
                        {
                            var cint = index + @"http://online.zakon.kz}}}\sectd".Length;
                            string substr = rtfData.Substring(0, cint);
                            string newsubst = Regex.Replace(substr, @"\{\\rtlch\\.*?WWW[\s]\}[\s]*\{.*?\\sectd", @"\sectd", RegexOptions.Singleline);
                            rtfData = rtfData.Replace(substr, newsubst);
                            //rtfData = Regex.Replace(rtfData, @"\{\\rtlch\\.*?WWW[\s]\}[\s]*\{.*?\\sectd", @"\sectd", RegexOptions.Singleline);
                        }
                        else
                        {
                            Log.Append("ERROR: index = -1: " + filePath);
                            log("ERROR: index = -1");
                        }
                    }
                    if (txtData.Length == 0)
                    {
                        var rt = new System.Windows.Forms.RichTextBox(); rt.LoadFile(fileNameAfterCopy);
                        txtData = rt.Text;
                        if (!String.IsNullOrWhiteSpace(txtData))
                            txtData = Regex.Replace(txtData, @"(Источник:[\s]ИС[\s]Параграф[\s]WWW[\s][<]*http://online\.zakon\.kz[>]*[\n-\x0D\s]*|http://online\.zakon\.kz[\n-\x0D\s]*)", "", RegexOptions.Singleline);

                    }
                    sw.Stop();
                    var time_replasertf = sw.ElapsedMilliseconds / 1000;

                    loginfo += "\t\tread rtf: " + time_readrtf + "\t\treplace rtfc: " + time_replasertf;
                }
                catch (Exception)
                {
                    var fileNameAfterCopy = Target.ToString().Replace(".doc", ".doc3");
                    File.Copy(Target.ToString(), fileNameAfterCopy);
                    rtfData = File.ReadAllText(fileNameAfterCopy);
                    if (!String.IsNullOrWhiteSpace(rtfData) && rtfData.Length < 42850614)
                        rtfData = Regex.Replace(rtfData, @"\{\\rtlch\\.*?WWW[\s]\}[\s]*\{.*?\\sectd", @"\sectd", RegexOptions.Singleline);
                    if (txtData.Length == 0)
                    {
                        var rt = new System.Windows.Forms.RichTextBox(); rt.LoadFile(fileNameAfterCopy);
                        txtData = rt.Text;
                        if (!String.IsNullOrWhiteSpace(txtData))
                            txtData = Regex.Replace(txtData, @"(Источник:[\s]ИС[\s]Параграф[\s]WWW[\s]http://online\.zakon\.kz[\n-\x0D\s]*|http://online\.zakon\.kz[\n-\x0D\s]*)", "", RegexOptions.Singleline);

                    }
                }



        }


    }
}
