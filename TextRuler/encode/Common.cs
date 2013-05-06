using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using BlowFishCS;

namespace TextRuler
{
    public static class Common
    {
        private static string GetHDDID()
        {
            string serial = String.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject hdd in searcher.Get())
            {
                try
                {
                    serial += hdd["SerialNumber"].ToString();
                }
                catch
                {
                    continue;
                }
            }
            return serial.Trim();
        }

        private static string GetCRUID()
        {
            string str = "";
            ManagementObjectSearcher searcher =
                   new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_Processor");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                str = queryObj["ProcessorId"].ToString();
            }
            return str.Trim();
        }

        public static string GetUniqID()
        {
            return GetCRUID() + GetHDDID() + "#4#2%^";
        }

        public static string Encode(string input, string key)
        {
            var b = new BlowFish(key);
            return b.Encrypt_ECB(input);
        }

        public static string Decode(string input, string key)
        {
            var b = new BlowFish(key);
            return b.Decrypt_ECB(input);
        }
    }
}
