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
        //tzutil /s 
        //tzutil /l
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
        private Boolean isUniqueeIp(String ip){
            return true;
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
        public Boolean chooseIp(int indexIp){
            //max 15
            Boolean isChoose=false;
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x=au3.WinGetPosX(hwndSTR, "")+8;
            int y=au3.WinGetPosY(hwndSTR, "")+30;
            x += au3.ControlGetPosX(hwndSTR, "", "[ID:116]");
            y += au3.ControlGetPosY(hwndSTR, "", "[ID:116]");
            au3.ControlClick(hwndSTR, "", "[ID:7301]");
            au3.MouseClick("LEFT", x + 11, y + 30);
            au3.MouseClick("RIGHT", x + 11, y + 30 + indexIp * 17);
            au3.Send("{DOWN}");
            au3.Send("{ENTER}");
            String ip = Clipboard.GetText();
            if(isUniqueeIp(ip)){
                au3.MouseClick("RIGHT", x + 11, y + 30 + indexIp * 17);
                au3.Send("{DOWN}");
                au3.Send("{DOWN}");
                au3.Send("{DOWN}");
                au3.Send("{DOWN}");
                au3.Send("{ENTER}");
                Boolean checkNotBlackist = waitText(au3, "[ACTIVE]", "[ID:33]", "is NOT black", "is BLACKLISTED", 30);
                au3.ControlClick("[ACTIVE]", "", "[ID:99]");
                if (checkNotBlackist)
                {
                    au3.MouseClick("LEFT", x + 11, y + 30 + maxRand * 17,2);
                    isChoose=true;
                    System.Threading.Thread.Sleep(2000);
                }
            }
            au3.WinSetOnTop(hwndSTR, "", 0);
            System.Threading.Thread.Sleep(1000);
            return isChoose;
        }
        public Boolean setPort(String ip, String port){
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x = au3.WinGetPosX(hwndSTR, "") + 8;
            int y = au3.WinGetPosY(hwndSTR, "") + 30;
            x += au3.ControlGetPosX(hwndSTR, "", "[ID:116]");
            y += au3.ControlGetPosY(hwndSTR, "", "[ID:116]");
            au3.ControlClick(hwndSTR, "", "[ID:7303]");
            au3.MouseClick("LEFT", x + 11, y + 30);
            int indexIpPort=0;
            String lastIp="";
            while (i<15)
            {
                au3.MouseClick("RIGHT", x + 11, y + 30 + 17*i);
                System.Threading.Thread.Sleep(500);
                au3.Send("{DOWN}");
                System.Threading.Thread.Sleep(500);
                au3.Send("{ENTER}");
                System.Threading.Thread.Sleep(500);
                String tmpIp = Clipboard.GetText();
                if(tmpIp==lastIp){
                    return false;
                    }else{
                        lastIp=tmpIp;
                    }
                if (tmpIp.Contains(txtIp.Text))
                {
                    au3.MouseClick("RIGHT", x + 11, y + 30 + 17 * i);
                    System.Threading.Thread.Sleep(500);
                    au3.Send("{UP}");
                    System.Threading.Thread.Sleep(500);
                    au3.Send("{ENTER}");
                    System.Threading.Thread.Sleep(500);
                    au3.Send("{DOWN}");
                    System.Threading.Thread.Sleep(500);
                    au3.Send("{ENTER}");
                    System.Threading.Thread.Sleep(500);
                    au3.Send(port);
                    au3.ControlClick("[ACTIVE]", "", "[ID:5675]");
                    return true;
                }
                if(i==14){
                    au3.MouseWheel("down",1);
                    }else{
                         i++;
                    }   
            }
            return false;
        }
        public void autoSetPort(){

        }
        public String getRandomIp(){
            String ip="";
            Random rand = new Random();
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x = au3.WinGetPosX(hwndSTR, "");
            int y = au3.WinGetPosY(hwndSTR, "");
            au3.MouseClick("LEFT", x, y);
             //click select country
            au3.ControlClick(hwndSTR, "", "[ID:7811]");
            System.Threading.Thread.Sleep(1000);
            waitText(au3, hwndSTR, "[ID:131]", "Total proxies online", "ERROR", 30);
            //click Country
            int maxRand = rand.Next(11);
            au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 30 + maxRand * 17);

            //click select Region
            au3.ControlClick(hwndSTR, "", "[ID:7813]");
            System.Threading.Thread.Sleep(2000);
            //click Region
            maxRand = rand.Next(11);
            au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 30 + maxRand * 17);

            //click Select City
            au3.ControlClick(hwndSTR, "", "[ID:7815]");
            System.Threading.Thread.Sleep(2000);
            //click City
            maxRand = rand.Next(11);
            au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 30 + maxRand * 17);

            //search IP
            au3.ControlClick(hwndSTR, "", "[ID:127]");
            System.Threading.Thread.Sleep(1000);
            au3.WinSetOnTop(hwndSTR, "", 0);
            return ip;
        }
    }
}
