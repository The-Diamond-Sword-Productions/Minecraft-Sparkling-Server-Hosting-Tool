using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public class MinecraftVersion
    {
        public string URL;
        public string Version;

        public MinecraftVersion(string version, string url)
        {
            Version = version;
            URL = url;
        }

        public static MinecraftVersion SixteenOne = new MinecraftVersion("1.16.1", "https://launcher.mojang.com/v1/objects/a412fd69db1f81db3f511c1463fd304675244077/server.jar");
        public static MinecraftVersion Sixteen = new MinecraftVersion("1.16.", "https://launcher.mojang.com/v1/objects/a0d03225615ba897619220e256a266cb33a44b6b/server.jar");
        public static MinecraftVersion FifteenTwo = new MinecraftVersion("1.15.2", "https://launcher.mojang.com/v1/objects/bb2b6b1aefcd70dfd1892149ac3a215f6c636b07/server.jar");
        public static MinecraftVersion FifteenOne = new MinecraftVersion("1.15.1", "https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar");
        public static MinecraftVersion Fifteen = new MinecraftVersion("1.15", "https://launcher.mojang.com/v1/objects/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar");
        public static MinecraftVersion FourteenFour = new MinecraftVersion("1.14.4", "https://launcher.mojang.com/v1/objects/3dc3d84a581f14691199cf6831b71ed1296a9fdf/server.jar");
        public static MinecraftVersion FourteenThree = new MinecraftVersion("1.14.3", "https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar");
        public static MinecraftVersion FourteenTwo = new MinecraftVersion("1.14.2", "https://launcher.mojang.com/v1/objects/808be3869e2ca6b62378f9f4b33c946621620019/server.jar");
        public static MinecraftVersion FourteenOne = new MinecraftVersion("1.14.1", "https://launcher.mojang.com/v1/objects/ed76d597a44c5266be2a7fcd77a8270f1f0bc118/server.jar");
        public static MinecraftVersion Fourteen = new MinecraftVersion("1.14", "https://launcher.mojang.com/v1/objects/f1a0073671057f01aa843443fef34330281333ce/server.jar");
        public static MinecraftVersion ThirteenTwo = new MinecraftVersion("1.13.2", "https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar");
        public static MinecraftVersion ThirteenOne = new MinecraftVersion("1.13.1", "https://launcher.mojang.com/v1/objects/fe123682e9cb30031eae351764f653500b7396c9/server.jar");
        public static MinecraftVersion Thirteen = new MinecraftVersion("1.13", "https://launcher.mojang.com/v1/objects/d0caafb8438ebd206f99930cfaecfa6c9a13dca0/server.jar");
        public static MinecraftVersion TwelveTwo = new MinecraftVersion("1.12.2", "https://launcher.mojang.com/v1/objects/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar");
        public static MinecraftVersion TwelveOne = new MinecraftVersion("1.12.1", "https://launcher.mojang.com/v1/objects/561c7b2d54bae80cc06b05d950633a9ac95da816/server.jar");
        public static MinecraftVersion Twelve = new MinecraftVersion("1.12", "https://launcher.mojang.com/v1/objects/8494e844e911ea0d63878f64da9dcc21f53a3463/server.jar");
    }
}
