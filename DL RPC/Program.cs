using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using DiscordRPC;

namespace DL_RPC
{
    class Program
    {
        static map currentMap = map.none;
        static int playerCount = 1;
        static DiscordRpcClient client;
        static DateTime time = DateTime.UtcNow;

        static void Main(string[] args)
        {
            functions.findDuplicate();
            functions.waitfordl();
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("Please wait...");
            functions.hide();
            client = new DiscordRpcClient("1013441050225950852");
            client.Initialize();
            client.UpdateStartTime();
            Thread readthread = new Thread(readlogs);
            Thread updatethread = new Thread(update);
            Thread.Sleep(30000);
            readthread.Start();
            updatethread.Start();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Player count: " + playerCount + "                        ");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Current map: " + currentMap.ToString() + "                        ");
            }
        }

        private static void readlogs()
        {
            var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DyingLight\out\logs");
            var log = (from f in directory.GetFiles() orderby f.LastWriteTime descending select f).First();
            using (var fs = new FileStream(log.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                while (functions.isGameOpen())
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
                    Thread.Sleep(100);
                }
            }
            Environment.Exit(0);
        }

        private static void update()
        {
            string details = string.Empty;
            string state = string.Empty;
            string largeimagekey = string.Empty;
            string largeimagetext = string.Empty;

            while (client.IsInitialized)
            {
                if (currentMap == map.slums_btz_tutorial)
                {
                    state = "";
                }
                else if (playerCount == 1)
                {
                    state = "Playing in singleplayer";
                }
                else
                {
                    state = $"Playing in coop ({playerCount}/5)";
                }

                switch (currentMap)
                {
                    case map.none:
                        details = "In Main Menu";
                        state = "";
                        break;
                    case map.slums:
                        details = "In Slums";
                        break;
                    case map.old_town:
                        details = "In Old Town";
                        break;
                    case map.countryside:
                        details = "In Countryside";
                        break;
                    case map.hellraid:
                        details = "In Hellraid";
                        break;
                    case map.prison:
                        details = "Playing Harran Prison";
                        break;
                    case map.stadium:
                        details = "Playing Bozak Horde";
                        break;
                    case map.turtle:
                        details = "In Stuffed Turtle";
                        break;
                    case map.slums_btz_tutorial:
                        details = "In BTZ Lobby";
                        break;
                    case map.custom:
                        details = "Playing on a custom map";
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
        }
    }

    enum map
    {
        none,
        slums,
        old_town,
        countryside,
        hellraid,
        stadium,
        prison,
        turtle,
        slums_btz_tutorial,
        custom,
    }
}
