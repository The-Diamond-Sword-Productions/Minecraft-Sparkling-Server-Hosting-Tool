using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public class SpigotVersion
    {
        public string URL;
        public string Version;

        public SpigotVersion(string version, string url)
        {
            Version = version;
            URL = url;
        }

        public static SpigotVersion SixteenOne = new SpigotVersion("1.15.2", "https://cdn.getbukkit.org/spigot/spigot-1.16.1.jar");
        public static SpigotVersion FifteenTwo = new SpigotVersion("1.15.1", "https://cdn.getbukkit.org/spigot/spigot-1.15.2.jar");
        public static SpigotVersion FifteenOne = new SpigotVersion("1.16.1", "https://cdn.getbukkit.org/spigot/spigot-1.15.1.jar");
        public static SpigotVersion Fifteen = new SpigotVersion("1.15", "https://cdn.getbukkit.org/spigot/spigot-1.15.jar");
        public static SpigotVersion FourteenFour = new SpigotVersion("1.14.4", "https://cdn.getbukkit.org/spigot/spigot-1.14.4.jar");
        public static SpigotVersion FourteenThree = new SpigotVersion("1.14.3", "https://cdn.getbukkit.org/spigot/spigot-1.14.3.jar");
        public static SpigotVersion FourteenTwo = new SpigotVersion("1.14.2", "https://cdn.getbukkit.org/spigot/spigot-1.14.2.jar");
        public static SpigotVersion FourteenOne = new SpigotVersion("1.14.1", "https://cdn.getbukkit.org/spigot/spigot-1.14.1.jar");
        public static SpigotVersion Fourteen = new SpigotVersion("1.14", "https://cdn.getbukkit.org/spigot/spigot-1.14.jar");
        public static SpigotVersion ThirteenTwo = new SpigotVersion("1.13.2", "https://cdn.getbukkit.org/spigot/spigot-1.13.2.jar");
        public static SpigotVersion ThirteenOne = new SpigotVersion("1.13.1", "https://cdn.getbukkit.org/spigot/spigot-1.13.1.jar");
        public static SpigotVersion Thirteen = new SpigotVersion("1.13", "https://cdn.getbukkit.org/spigot/spigot-1.13.jar");
        public static SpigotVersion TwelveTwo = new SpigotVersion("1.12.2", "https://cdn.getbukkit.org/spigot/spigot-1.12.2.jar");
        public static SpigotVersion TwelveOne = new SpigotVersion("1.12.1", "https://cdn.getbukkit.org/spigot/spigot-1.12.1.jar");
        public static SpigotVersion Twelve = new SpigotVersion("1.12", "https://cdn.getbukkit.org/spigot/spigot-1.12.jar");
        public static SpigotVersion ElevenTwo = new SpigotVersion("1.11.2", "https://cdn.getbukkit.org/spigot/spigot-1.11.2.jar");
        public static SpigotVersion ElevenOne = new SpigotVersion("1.11.1", "https://cdn.getbukkit.org/spigot/spigot-1.11.1.jar");
        public static SpigotVersion Eleven = new SpigotVersion("1.11", "https://cdn.getbukkit.org/spigot/spigot-1.11.jar");
        public static SpigotVersion TenTwo = new SpigotVersion("1.10.2", "https://cdn.getbukkit.org/spigot/spigot-1.10.2-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion TenOne = new SpigotVersion("1.10", "https://cdn.getbukkit.org/spigot/spigot-1.10-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion NineFour = new SpigotVersion("1.9.4", "https://cdn.getbukkit.org/spigot/spigot-1.9.4-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion NineTwo = new SpigotVersion("1.9.2", "https://cdn.getbukkit.org/spigot/spigot-1.9.2-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion Nine = new SpigotVersion("1.9", "https://cdn.getbukkit.org/spigot/spigot-1.9-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion EightEight = new SpigotVersion("1.8.8", "https://cdn.getbukkit.org/spigot/spigot-1.8.8-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion Eight = new SpigotVersion("1.8", "https://cdn.getbukkit.org/spigot/spigot-1.8-R0.1-SNAPSHOT-latest.jar");
        public static SpigotVersion SevenTen = new SpigotVersion("1.7.10", "https://cdn.getbukkit.org/spigot/spigot-1.7.10-SNAPSHOT-b1657.jar");
    }
}
