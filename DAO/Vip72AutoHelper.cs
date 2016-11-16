using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoItX3Lib;
using TestGecko45.Common;
namespace TestGecko45.DAO
{
    class Vip72AutoHelper
    {
        String hwndSTR="";
        AutoItX3 au3 = new AutoItX3();
        private Boolean waitText(String title, String control, String[] arrSText, String fText, int maxWait)
        {
            String textTmp = "";
            int countWait = 0;
            while (true)
            {
                countWait++;
                if (countWait > maxWait)
                {
                    return false;
                }
                textTmp = au3.ControlGetText(title, "", control);
                foreach (String sText in arrSText)
                {
                    if (textTmp.Contains(sText))
                    {
                        return true;
                    }

                }


                if (textTmp.Contains(fText))
                {
                    return false;
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
        private Boolean waitText(String title, String control, String sText, String fText, int maxWait)
        {
            String textTmp = "";
            int countWait = 0;
            while (true)
            {
                countWait++;
                if (countWait > maxWait)
                {
                    return false;
                }
                textTmp = au3.ControlGetText(title, "", control);
                if (textTmp.Contains(sText))
                {
                    return true;
                }
                if (textTmp.Contains(fText))
                {
                    return false;
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void init()
        {
            au3.Run(Config.pathVip72);
            au3.WinWaitActive("[TITLE:VIP72 Socks Client]", "", 10);
            String hWnd = au3.WinGetHandle("[TITLE:VIP72 Socks Client]");
            hwndSTR = "[HANDLE:" + hWnd.ToString() + "]";
            au3.ControlSetText(hwndSTR, "", "[ID:303]", Config.userVip72);
            au3.ControlSetText(hwndSTR, "", "[ID:301]", Config.passVip72);
            au3.ControlClick(hwndSTR, "", "[ID:119]");
            waitText(hwndSTR, "[ID:131]", "System ready", "ERROR", 30);
        }
        public void clearAllProxy()
        {
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x = au3.WinGetPosX(hwndSTR, "") + 8;
            int y = au3.WinGetPosY(hwndSTR, "") + 30;
            x += au3.ControlGetPosX(hwndSTR, "", "[ID:117]");
            y += au3.ControlGetPosY(hwndSTR, "", "[ID:117]");
            au3.ControlClick(hwndSTR, "", "[ID:7303]");
            au3.MouseClick("LEFT", x + 11, y + 30);
            for (int i = 0; i < 50; i++)
            {
                au3.ControlSend(hwndSTR, "", "[ID:117]", "{DEL}");
            }
            au3.WinSetOnTop(hwndSTR, "", 0);
        }
    }
}
