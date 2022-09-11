using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DiscordRPC;

namespace DL_RPC
{
    public class functions
    {
        public static map currentMap = map.none;
        public static int playerCount = 1;
        public static Thread readthread = new Thread(readlogs);
        public static Thread updatethread = new Thread(update);
        public static DiscordRpcClient client = new DiscordRpcClient("1013441050225950852");
        static ResourceManager res = new ResourceManager("DL_RPC.resources.strings.strings", Assembly.GetExecutingAssembly());

        public static string GetString(string name)
        {
            return res.GetString(name);
        }

        public static void ChangeLanguage(string language)
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }

        public static bool isGameOpen()
        {
            Process[] processes = Process.GetProcessesByName("DyingLightGame");
            if (processes.Length == 0) { return false; }
            else { return true; }
        }

        private static void waitfordl()
        {
            Console.WriteLine("Waiting for DyingLightGame.exe");
            while (!isGameOpen()){
                Thread.Sleep(1000);
            }
        }

        private static void findDuplicate()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                Environment.Exit(0);
            }
        }

        public static void start()
        {
            client = new DiscordRpcClient("1013441050225950852");
            client.Initialize();
            client.UpdateStartTime();
            readthread = new Thread(readlogs);
            updatethread = new Thread(update);
            Task.Delay(10000).ContinueWith((t) =>
            {
                readthread.Start();
                updatethread.Start();
            });
        }

        private static void update()
        {
            string details = string.Empty;
            string state = string.Empty;
            string largeimagekey = string.Empty;
            string largeimagetext = string.Empty;

            while (client.IsInitialized && isGameOpen())
            {
                if (currentMap == map.slums_btz_tutorial)
                {
                    state = "";
                }
                else if (playerCount == 1)
                {
                    state = GetString("playing_singleplayer");
                }
                else
                {
                    state = GetString("playing_coop").Replace("{x}", Convert.ToString(playerCount));
                }

                switch (currentMap)
                {
                    case map.none:
                        details = GetString(currentMap.ToString());
                        state = "";
                        break;
                    case map.slums:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.old_town:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.countryside:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.hellraid:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.prison:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.stadium:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.slums_btz_tutorial:
                        details = GetString(currentMap.ToString());
                        break;
                    case map.custom:
                        details = GetString(currentMap.ToString());
                        break;
                }

                client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = currentMap.ToString(),
                        LargeImageText = "",
                        SmallImageKey = ""
                    }
                });
            }

            client.ClearPresence();
        }

        private static void readlogs()
        {
            waitfordl();

            var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DyingLight\out\logs");
            var log = (from f in directory.GetFiles() orderby f.LastWriteTime descending select f).First();
            using (var fs = new FileStream(log.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                while (isGameOpen())
                {
                    string[] lines = sr.ReadToEnd().Split('\n');
                    foreach (string line in lines)
                    {
                        //if(line!="")
                        //Console.WriteLine(line);

                        if (line.Contains("slums") && !line.Contains("AIDataManager") && !line.Contains("Level OnDestroy") && !line.Contains("slums_btz_tutorial") && line.Contains("INFO") && !line.Contains("Changing"))
                        {
                            currentMap = map.slums;
                        }
                        else if (line.Contains("old_town") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.old_town;
                        }
                        else if (line.Contains("Level OnDestroy") && !line.Contains("Quests") && line.Contains("INFO"))
                        {
                            currentMap = map.none;
                        }
                        else if (line.Contains("wasteland") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.countryside;
                        }
                        else if (line.Contains("hellraid") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.hellraid;
                        }
                        else if (line.Contains("stadium") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.stadium;
                        }
                        else if (line.Contains("prison") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.prison;
                        }
                        else if (line.Contains("slums_btz_tutorial") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.slums_btz_tutorial;
                        }
                        else if (line.Contains("Loading level") && !line.Contains("AIDataManager") && !line.Contains("Quests") && !line.Contains("Level OnDestroy") && line.Contains("INFO"))
                        {
                            currentMap = map.custom;
                        }
                        else if (Regex.IsMatch(line.Trim(), @"\bconnected\b"))
                        {
                            playerCount++;
                        }
                        else if (Regex.IsMatch(line.Trim(), @"\bdisconnected\b"))
                        {
                            playerCount--;
                        }
                    }
                    Thread.Sleep(5000);
                    log = (from f in directory.GetFiles() orderby f.LastWriteTime descending select f).First();
                }
            }
            client.ClearPresence();
        }

        public enum map
        {
            none,
            slums,
            old_town,
            countryside,
            hellraid,
            stadium,
            prison,
            slums_btz_tutorial,
            custom,
        }
    }
}
