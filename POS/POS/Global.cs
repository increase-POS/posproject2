using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Global
    {
        public const string APIKey = "1234";
        //public const string APIUri = "http://localhost:44370/api/";
        public const string APIUri = "http://192.168.1.10:44370/api/";
        //public const string APIUri = "http://192.168.1.4:44370/api/";

        public static string ScannedImageLocation = "Thumb/Scan/scan.jpg";
        public const string TMPFolder = "Thumb";
    }
}
