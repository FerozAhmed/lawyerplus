using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Diagnostics;


namespace SpiderCore.Utils
{
    public class FileUtils
    {
        /// <summary>
        /// returns a file checksum
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string CalculateChecksum(String filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(fs);
                    fs.Close();

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < retVal.Length; i++)
                    {
                        sb.Append(retVal[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// returns the specified file's size
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static long GetFilesize(String filename)
        {
            try
            {
                var f = new FileInfo(filename);
                return f.Length;
            }
            catch
            {
                return 0;
            }
        }


        public static string ReadFile(string fileName, int pos, int count)
        {
            string result = String.Empty;
            using (BinaryReader b = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                // 2.
                // Important variables:
                int length = (int)b.BaseStream.Length;
                // 3.
                // Seek the required index.
                b.BaseStream.Seek(pos, SeekOrigin.Begin);
                // 4.
                // Slow loop through the bytes.
                byte[] bytes = b.ReadBytes(count);
                char[] c = System.Text.Encoding.ASCII.GetString(bytes).ToCharArray();
                result = (new string(c)).Replace("\0", "");
            }
            return result;
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static void WriteFile(string fileName, int pos, string input)
        {
            string result = String.Empty;
            Stream outStream = File.Open(fileName, FileMode.Open);
            outStream.Seek(pos, SeekOrigin.Begin);
            byte[] bb = GetBytes(input);
            foreach (byte b in bb)
            {
                outStream.WriteByte(b);
            }
            outStream.Close();
        }

    }
}