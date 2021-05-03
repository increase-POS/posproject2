using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace POS.Classes
{
    class SectionData
    {
        public static bool iscodeExist = false;

        public static Agent agentModel = new Agent();

        public static string code;
        public static void popUpResponse(string title, string content)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.ContentText = content;
            //popup.ContentPadding = new Padding(0);
            //popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Popup();// show  
        }

        public static long genRandomCode(string type)
        {
            Random rnd = new Random();
            long randomNum = rnd.Next(0, 999999999);
            isCodeExist(randomNum.ToString() , type);
            if (!iscodeExist)
                code = randomNum.ToString();
            else genRandomCode(type);

            return randomNum;

        }

        public static async void isCodeExist(string randomNum , string type)
        {
            try
            {
                List<Agent> agents = await agentModel.GetAgentsAsync(type);
                Agent agent = new Agent();
                List<string> codes = new List<string>();
                for (int i = 0; i < agents.Count; i++)
                {
                    agent = agents[i];
                    codes.Add(agent.code.Trim());
                }
                if (codes.Contains(randomNum.Trim()))
                    iscodeExist = true;
                else
                    iscodeExist = false;
            }
            catch { }
        }
    }
}
