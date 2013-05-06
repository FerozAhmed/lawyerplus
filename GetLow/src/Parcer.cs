using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;

namespace Rental
{
    /// <summary>
    /// Iterator
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// get page content by url
        /// </summary>
        /// <param name="url">lint to page</param>
        /// <returns>page content</returns>
        string GetPage(string url);
    }


    static class WebPage
    {
        public static CookieCollection Cookies = new CookieCollection();

        public static string LoadPage(string AUrl, out string error)
        {
            return LoadPage(AUrl, null, out error);
        }


        //Загружает страницу - результат = исходный код страницы
        public static string LoadPage(string AUrl, Encoding encoding, out string error)
        {
            

            string res = String.Empty;
            error = String.Empty;
            HttpWebResponse WebResponse = null;

            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(AUrl);
                Request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.8.131 Version/11.10";
                Request.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/webp, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1";
                Request.Timeout = 20000;
                Request.ReadWriteTimeout = 20000;
                Request.Headers.Add("Accept-Language", "ru");
                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.MaximumAutomaticRedirections = 60;
                Request.KeepAlive = true;

                Request.CookieContainer = new CookieContainer();
                if (Cookies != null)
                    Request.CookieContainer.Add(Cookies);

                WebResponse = (HttpWebResponse)Request.GetResponse();

                if (WebResponse.Cookies != null && WebResponse.Cookies.Count > 0)
                {
                   // Cookies = new CookieCollection();
                    Cookies.Add(WebResponse.Cookies);
                }

                StreamReader Reader;
                if (encoding != null)
                    Reader = new StreamReader(WebResponse.GetResponseStream(), encoding);
                else
                    Reader = new StreamReader(WebResponse.GetResponseStream());
                res = Reader.ReadToEnd();
                Reader.Close();

            }
            catch (Exception ex)
            {
                error = "ERROR on get page " + AUrl + ". Exception: " + ex.Message;
                res = "";
            }
            finally
            {
                if (WebResponse != null)
                    WebResponse.Close();
            }
            return res;
        }

        static string CreatePostString(NameValueCollection nvc)
        {
            string postString = "";
            string tt = "";
            foreach (string key in nvc.Keys)
            {
                if (key == "images[]")
                {
                    string val = nvc[key];
                    string[] images = val.Split(',');
                    val = "";
                    string t = "";
                    foreach (string image in images)
                    {
                        val = val + t + key + "=" + image;
                        t = "&";
                    }
                    postString = postString + tt + val;
                    continue;
                }

                postString = postString + tt + key + "=" + nvc[key];
                tt = "&";
            }
            return postString;
        }


        public static int DownloadFile(String remoteFilename,
                               String localFilename, GetLow.UpdateTextCallback log = null)
        {
            // Function will return the number of bytes processed
            // to the caller. Initialize to 0 here.
            int bytesProcessed = 0;

            // Assign values to these objects here so that they can
            // be referenced in the finally block
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;

            // Use a try/catch/finally block as both the WebRequest and Stream
            // classes throw exceptions upon error
            try
            {
                // Create a request for the specified remote file name
                //WebRequest request = WebRequest.Create(remoteFilename);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(remoteFilename);
                request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.8.131 Version/11.10";
                request.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/webp, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1";
                request.Timeout = 30000;
                request.ReadWriteTimeout = 30000;
                request.Headers.Add("Accept-Language", "ru");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.MaximumAutomaticRedirections = 60;
                request.KeepAlive = true;

                request.CookieContainer = new CookieContainer();
                if (Cookies != null)
                    request.CookieContainer.Add(Cookies);

                if (request != null)
                {
                    // Send the request to the server and retrieve the
                    // WebResponse object 
                    response = request.GetResponse();
                    if (response != null)
                    {

                        if (((HttpWebResponse)response).Cookies != null && ((HttpWebResponse)response).Cookies.Count > 0)
                        {
                           // Cookies = new CookieCollection();
                            Cookies.Add(((HttpWebResponse)response).Cookies);
                        }

                        // Once the WebResponse object has been retrieved,
                        // get the stream object associated with the response's data
                        remoteStream = response.GetResponseStream();

                        // Create the local file
                        localStream = File.Create(localFilename);

                        // Allocate a 1k buffer
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        // Simple do/while loop to read from stream until
                        // no bytes are returned
                        do
                        {
                            // Read data (up to 1k) from the stream
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);

                            // Write the data to the local file
                            localStream.Write(buffer, 0, bytesRead);

                            // Increment total bytes processed
                            bytesProcessed += bytesRead;
                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception e)
            {
                if (log != null)
                    log("ERROR on load file " + remoteFilename + "\n"+ e.Message);
            }
            finally
            {
                // Close the response and streams objects here 
                // to make sure they're closed even if an exception
                // is thrown at some point
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }

            // Return total bytes processed to caller.
            return bytesProcessed;
        }

        public static void DownloadFile111(string AUrl, string fileName)
        {
            Stream stream = null;
            int bytesToRead = 10000;
            byte[] buffer = new Byte[bytesToRead];
            try
            {
                HttpWebRequest fileReq = (HttpWebRequest)WebRequest.Create(AUrl);
                fileReq.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.8.131 Version/11.10";
                fileReq.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/webp, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1";
                fileReq.Timeout = 20000;
                fileReq.ReadWriteTimeout = 20000;
                fileReq.Headers.Add("Accept-Language", "ru");
                fileReq.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                fileReq.MaximumAutomaticRedirections = 60;
                fileReq.KeepAlive = true;

                fileReq.CookieContainer = new CookieContainer();
                if (Cookies != null)
                    fileReq.CookieContainer.Add(Cookies);

                HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                if (fileReq.ContentLength > 0)
                    fileResp.ContentLength = fileReq.ContentLength;

                //Get the Stream returned from the response
                stream = fileResp.GetResponseStream();

                // prepare the response to the client. resp is the client Response
                var resp = System.Web.HttpContext.Current.Response;

                //Indicate the type of data being sent
                resp.ContentType = "application/octet-stream";

                //Name the file 
                resp.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                resp.AddHeader("Content-Length", fileResp.ContentLength.ToString());

                int length;
                do
                {
                    // Verify that the client is connected.
                    if (resp.IsClientConnected)
                    {
                        // Read data into the buffer.
                        length = stream.Read(buffer, 0, bytesToRead);

                        // and write it out to the response's output stream
                        resp.OutputStream.Write(buffer, 0, length);

                        // Flush the data
                        resp.Flush();

                        //Clear the buffer
                        buffer = new Byte[bytesToRead];
                    }
                    else
                    {
                        // cancel the download if client has disconnected
                        length = -1;
                    }
                } while (length > 0); //Repeat until no data is read
            }
            finally
            {
                if (stream != null)
                {
                    //Close the input stream
                    stream.Close();
                }
            }
        }

        public static string LoadPage(string AUrl, NameValueCollection nvc, Encoding encoding, out string error)
        {
            string post_string = CreatePostString(nvc);
            string res = String.Empty;
            error = String.Empty;
            HttpWebResponse WebResponse = null;

            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(AUrl);
                Request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.8.131 Version/11.10";
                Request.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/webp, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1";
                Request.Timeout = 20000;
                Request.ReadWriteTimeout = 20000;
                Request.Headers.Add("Accept-Language", "ru");
                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.MaximumAutomaticRedirections = 60;
                Request.KeepAlive = true;
                Request.Method = "POST";

                Request.CookieContainer = new CookieContainer();
                if (Cookies != null)
                    Request.CookieContainer.Add(Cookies);

                byte[] byteQuery = System.Text.Encoding.UTF8.GetBytes(post_string);
                Request.AllowAutoRedirect = true;
                Request.Method = "POST";
                Request.ContentType = "application/x-www-form-urlencoded";
                Request.ContentLength = byteQuery.Length;
                Request.ServicePoint.Expect100Continue = false;


                Stream QStream =  Request.GetRequestStream();
                QStream.Write(byteQuery, 0, byteQuery.Length);
                QStream.Close();
               
                WebResponse = (HttpWebResponse)Request.GetResponse();

                if (WebResponse.Cookies != null && WebResponse.Cookies.Count > 0)
                {
                    Cookies = new CookieCollection();
                    Cookies.Add(WebResponse.Cookies);
                }

                StreamReader Reader;
                if (encoding != null)
                    Reader = new StreamReader(WebResponse.GetResponseStream(), encoding);
                else
                    Reader = new StreamReader(WebResponse.GetResponseStream());
                res = Reader.ReadToEnd();
                Reader.Close();

            }
            catch (Exception ex)
            {
                error = "ERROR on get page " + AUrl + ". Exception: " + ex.Message;
                res = "";
            }
            finally
            {
                if (WebResponse != null)
                    WebResponse.Close();
            }
            return res;
        }

    }
}
