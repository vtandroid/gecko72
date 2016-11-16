using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gecko;
using System.IO;
using AutoItX3Lib;
using TestGecko45.DAO;
namespace TestGecko45
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            string profileDir = "2x";
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.Combine("Geckofx", profileDir));
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            Gecko.Xpcom.ProfileDirectory = directory;
            Xpcom.Initialize("Firefox");
            InitializeComponent();
        }
        private Boolean waitText(AutoItX3 au3, String title, String control, String[] arrSText, String fText, int maxWait)
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
                foreach(String sText in arrSText){
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
        private Boolean waitText(AutoItX3 au3, String title, String control, String sText, String fText, int maxWait)
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            //GeckoPreferences.User["network.proxy.type"] = 1;
            //GeckoPreferences.User["network.proxy.socks"] = "127.0.0.1";
            //GeckoPreferences.User["network.proxy.socks_port"] = 9951;
            //GeckoPreferences.User["network.proxy.socks_version"] = 5;
            // GeckoPreferences.User["network.proxy.socks_remote_dns"] = true;
            // GeckoPreferences.User["media.peerconnection.enabled"] = false;
             //GeckoPreferences.User["network.http.max-connections"] = 32;
             //GeckoPreferences.User["network.http.max-persistent-connections-per-proxy"] = 16;
            AutoItX3 au3 = new AutoItX3();
            int hwnd1=au3.Run(@"C:\Users\longthanh\Downloads\Compressed\vip72socks\vip72socks.exe");
            au3.WinWaitActive("[TITLE:VIP72 Socks Client]","",10);
            String hWnd = au3.WinGetHandle("[TITLE:VIP72 Socks Client]");
            String hwndSTR="[HANDLE:" + hWnd.ToString() + "]";
           // int hWnd = au3.WinWait("[TITLE:VIP72 Socks Client]", "", 10);
            int tmp = au3.ControlClick(hwndSTR, "", "[ID:119]");
            waitText(au3, hwndSTR, "[ID:131]", "System ready", "ERROR",30);
            //click select country
            au3.ControlClick(hwndSTR, "", "[ID:7811]");
            waitText(au3, hwndSTR, "[ID:131]", "Total proxies online", "ERROR", 30);
            //click Country
            au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 58);

            //click select Region
            au3.ControlClick(hwndSTR, "", "[ID:7813]");
            System.Threading.Thread.Sleep(2000);
            //click Region
            au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 50);
            //click search
            au3.ControlClick(hwndSTR, "", "[ID:127]");
            waitText(au3, hwndSTR, "[ID:131]", new String[] { "Only", "Ok" }, "ERROR", 30);
            au3.ControlClick(hwndSTR, "", "[ID:116]", "right", 1, 57, 35);
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{DOWN}");
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{ENTER}");
            System.Threading.Thread.Sleep(10);
            String s = Clipboard.GetText();
            au3.ControlClick(hwndSTR, "", "[ID:116]", "right", 1, 57, 35);
            System.Threading.Thread.Sleep(1);
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{DOWN}");
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{DOWN}");
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{DOWN}");
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{DOWN}");
            au3.ControlSend(hwndSTR, "", "[ID:116]", "{ENTER}");
            Boolean checkNotBlackist = waitText(au3, "[ACTIVE]", "[ID:33]", "is NOT black", "is BLACKLISTED", 30);
            au3.ControlClick("[ACTIVE]", "", "[ID:99]");
            MessageBox.Show("Login Success: " + s + " "+ checkNotBlackist);
           // webBrowser1.Navigate("youtube.com");
        }

        private void clearProxy_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            AutoItX3 au3 = new AutoItX3();
            String hWnd = au3.WinGetHandle("[TITLE:VIP72 Socks Client]");
            au3.MouseMove(0, 0);
            String hwndSTR = "[HANDLE:" + hWnd.ToString() + "]";
            au3.WinSetOnTop(hwndSTR, "", 1);
            au3.ControlClick(hwndSTR, "", "[ID:7303]");
            au3.ControlClick(hwndSTR, "", "[ID:117]", "menu", 1, 57, 35); 
            //System.Threading.Thread.Sleep(2000);
            au3.ControlSend(hwndSTR, "", "[ID:117]", "{DOWN}"); System.Threading.Thread.Sleep(2000);
            //au3.ControlSend(hwndSTR, "", "[ID:117]", "{DOWN}"); System.Threading.Thread.Sleep(2000);
            //au3.ControlSend(hwndSTR, "", "[ID:117]", "{DOWN}"); System.Threading.Thread.Sleep(2000);
            //au3.ControlSend(hwndSTR, "", "[ID:117]", "{DOWN}"); System.Threading.Thread.Sleep(2000);
            //au3.ControlSend(hwndSTR, "", "[ID:117]", "{DOWN}"); System.Threading.Thread.Sleep(2000);
            //au3.ControlSend(hwndSTR, "", "[ID:117]", "{DOWN}"); System.Threading.Thread.Sleep(2000);
            //au3.ControlSend(hwndSTR, "", "[ID:117]", "{ENTER}"); System.Threading.Thread.Sleep(2000);
        }
        AutoItX3 au3 = new AutoItX3();
        private void btnCheckBlackList_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            String hWnd = au3.WinGetHandle("[TITLE:VIP72 Socks Client]");
            String hwndSTR = "[HANDLE:" + hWnd.ToString() + "]";
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x=au3.WinGetPosX(hwndSTR, "")+8;
            int y=au3.WinGetPosY(hwndSTR, "")+30;
            x += au3.ControlGetPosX(hwndSTR, "", "[ID:116]");
            y += au3.ControlGetPosY(hwndSTR, "", "[ID:116]");
            int maxRand = rand.Next(14);
            au3.MouseClick("LEFT", x + 11, y + 30);
            au3.MouseClick("RIGHT", x + 11, y + 30 + maxRand * 17);
            //au3.MouseClick("RIGHT", x + 11, y + 30 + maxRand * 20);
            //au3.ControlClick(hwndSTR, "", "[ID:116]", "left", 1, 57, 35);
            //au3.ControlClick(hwndSTR, "", "[ID:116]", "right", 1, 11,  30 + maxRand * 18);
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
            }
          
           // MessageBox.Show("Login Success: " + checkNotBlackist);
            au3.WinSetOnTop(hwndSTR, "", 0);
             
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            String hWnd = au3.WinGetHandle("[TITLE:VIP72 Socks Client]");
            String hwndSTR = "[HANDLE:" + hWnd.ToString() + "]";
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x = au3.WinGetPosX(hwndSTR, "");
            int y = au3.WinGetPosY(hwndSTR, "");
            au3.MouseClick("LEFT", x, y);
            for (int i = 0; i < 10; i++)
            {
                //click select country
                au3.ControlClick(hwndSTR, "", "[ID:7811]");
                System.Threading.Thread.Sleep(1000);
                waitText(au3, hwndSTR, "[ID:131]", "Total proxies online", "ERROR", 30);
                //click Country
                int maxRand = rand.Next(11);
                au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 30 + maxRand * 17);
                //click select Region
                au3.ControlClick(hwndSTR, "", "[ID:7813]");
                System.Threading.Thread.Sleep(1000);
                //click Region
                maxRand = rand.Next(11);
                au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 30 + maxRand * 17);

                au3.ControlClick(hwndSTR, "", "[ID:7815]");
                System.Threading.Thread.Sleep(1000);
                maxRand = rand.Next(11);
                au3.ControlClick(hwndSTR, "", "[ID:7809]", "left", 2, 11, 30 + maxRand * 17);
                au3.ControlClick(hwndSTR, "", "[ID:127]");
                System.Threading.Thread.Sleep(1000);
                btnCheckBlackList_Click(null, null);
            }
            au3.WinSetOnTop(hwndSTR, "", 0);
        }

        private void btnSetPort_Click(object sender, EventArgs e)
        {
            String hWnd = au3.WinGetHandle("[TITLE:VIP72 Socks Client]");
            String hwndSTR = "[HANDLE:" + hWnd.ToString() + "]";
            au3.WinSetOnTop(hwndSTR, "", 1);
            int x = au3.WinGetPosX(hwndSTR, "") + 8;
            int y = au3.WinGetPosY(hwndSTR, "") + 30;
            x += au3.ControlGetPosX(hwndSTR, "", "[ID:116]");
            y += au3.ControlGetPosY(hwndSTR, "", "[ID:116]");
            au3.ControlClick(hwndSTR, "", "[ID:7303]");
            au3.MouseClick("LEFT", x + 11, y + 30);
            //au3.MouseClick("RIGHT", x + 11, y + 30);
            //au3.Send("{DOWN}");
            //au3.Send("{ENTER}");
            //String firstIp = Clipboard.GetText();
            for (int i = 0; i < 15; i++)
            {
                au3.MouseClick("RIGHT", x + 11, y + 30 + 17*i);
                System.Threading.Thread.Sleep(500);
                au3.Send("{DOWN}");
                System.Threading.Thread.Sleep(500);
                au3.Send("{ENTER}");
                System.Threading.Thread.Sleep(500);
                String tmpIp = Clipboard.GetText();
                //if (tmpIp == firstIp)
                //{
                //    break;
                //}
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
                    au3.Send(txtPort.Text);
                    au3.ControlClick("[ACTIVE]", "", "[ID:5675]");
                    break;
                }
            }
           
        }
        Vip72AutoHelper vip72Helper = new Vip72AutoHelper();
        private void btnTestStartVip72_Click(object sender, EventArgs e)
        {
            vip72Helper.init();
        }

        private void btnClearProxy_Click(object sender, EventArgs e)
        {
           
            //vip72Helper.clearAllProxy();
            MessageBox.Show(""+DateTimeHelper.ChangeSystemDateTime());
        }
    }
}
