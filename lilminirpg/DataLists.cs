using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lilminirpg
{
    public class DataLists
    {
        public static string[,] MenuMain =
        {
                    {"Play Game"},
                    {"Make New Character"},
                    {"Load Character"},
                    {"Edit Character & Equipment"},
                    {"Exit"},
                    {"Debug Menu"}
        };

        public static string[,] MenuTest =
        {
                    {"InitStageArray"},
                    {"Check Player Status"},
                    {"PrintLists"},
                    {"PrintColorList"},
                    {"Exit to Main Menu"}
        };

        public static string[,] MenuEdit =
        {   
                    {"Change Character Name"},
                    {"Change Job"},
                    {"Change Weapon"},
                    {"Change Accessory"},
                    {"Exit to Main Menu"}
        };


        public class Clothing
        {
            // coming soon
        }
    }
}
