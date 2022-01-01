using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;

using Newtonsoft.Json.Converters;

namespace POS.Classes
{


    public class AvtivateServer
    {
      
        public string serverUri { get; set; }
        public string activateCode { get; set; }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// 





        public async Task<int> checkconn()
        {
            int id = 1;
            int item = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Activate/checkconn", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = int.Parse(c.Value) ;
                    break;
                }
            }
            return item;


         
        }

        public async Task<int> Sendserverkey(string skey)
        {
            int item = 0;
           // int res = 0;
          //  SendDetail item = new SendDetail();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("skey", skey);
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Activate/Sendserverkey", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = int.Parse(c.Value);
                  // item = JsonConvert.DeserializeObject<SendDetail>(c.Value, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                    break;
                }
            }
            return item;

        }

        // extend button start:
        //private async void next_Click(object sender, RoutedEventArgs e)
        //{

        //    int chk = 0;
        //    string activationkey = "";//get from info 
        //    try
        //    {
        //        if (activationkey.Trim() != "".Trim())
        //        {
        //            AvtivateServer ac = new AvtivateServer();

        //            chk = await ac.checkconn();

        //            chk = await ac.Sendserverkey(tb_activationkey.Text);



        //            if (chk <= 0)
        //            {
        //                string message = "inc(" + chk + ")";

        //                string messagecode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));
        //                tb_activationkey.Text = messagecode;


        //                string msg = "The Activation not complete (Error code:" + messagecode + ")";


        //                Toaster.ShowWarning(Window.GetWindow(this), message: msg, animation: ToasterAnimation.FadeIn);
        //            }

        //            else
        //            {
        //                Toaster.ShowSuccess(Window.GetWindow(this), message: "The Activation done successfuly", animation: ToasterAnimation.FadeIn);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
        //    }
        //}
        // extend buttonend



    }
}
