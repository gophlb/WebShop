using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProductXmlGenerator
{
    public class Program
    {
        private const int MAX_PRICE = 50;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            Dictionary<int, string> categories = new Dictionary<int, string>()
            {
                { 1, "Colors for a better world Series" },
                { 2, "In color we trust Series" },
                { 3, "Color of your life Series" },
                { 4, "Nature is color Series" },
            };

            Dictionary<int, double> categoryVAT = new Dictionary<int, double>()
            {
                { 1, 1.0 },
                { 2, 12.0 },
                { 3, 15.0 },
                { 4, 21.0 }
            };

            // Need ordered access (ie: marketing strategy), avoid StringDictionary
            Dictionary<string, string> products = new Dictionary<string, string>()
            {
                {"Light Golden Rod Yellow","#FAFAD2"}
                ,{"Antique White","#FAEBD7"}
                ,{"Aqua","#00FFFF"}
                ,{"Deep Pink","#FF1493"}
                ,{"Aquamarine","#7FFFD4"}
                ,{"Azure","#F0FFFF"}
                ,{"Black","#000000"}
                ,{"Medium Spring Green","#00FA9A"}
                ,{"Blue Violet","#8A2BE2"}
                ,{"Brown","#A52A2A"}
                ,{"Burly Wood","#DEB887"}
                ,{"Dark Slate Blue","#483D8B"}
                ,{"Dark Slate Gray","#2F4F4F"}
                ,{"Dark Turquoise","#00CED1"}
                ,{"Chocolate","#D2691E"}
                ,{"Coral","#FF7F50"}
                ,{"Plum","#DDA0DD"}
                ,{"Crimson","#DC143C"}
                ,{"Light Cyan","#E0FFFF"}
                ,{"Dark Cyan","#008B8B"}
                ,{"Dark Golden Rod","#B8860B"}
                ,{"Dark Gray","#A9A9A9"}
                ,{"Light Salmon","#FFA07A"}
                ,{"Cadet Blue","#5F9EA0"}
                ,{"Dark SeaGreen","#8FBC8F"}
                ,{"Dark Violet","#9400D3"}
                ,{"Deep Sky Blue","#00BFFF"}
                ,{"Dim Gray","#696969"}
                ,{"Dodger Blue","#1E90FF"}
                ,{"Fire Brick","#B22222"}
                ,{"Floral White","#FFFAF0"}
                ,{"Gainsboro","#DCDCDC"}                
                ,{"Light Coral","#F08080"}
                ,{"Mint Cream","#F5FFFA"}
                ,{"Gold","#FFD700"}
                ,{"Beige","#F5F5DC"}
                ,{"Bisque","#FFE4C4"}
                ,{"Peach Puff","#FFDAB9"}
                ,{"Misty Rose","#FFE4E1"}
                ,{"Moccasin","#FFE4B5"}
                ,{"Indigo","#4B0082"}
                ,{"Old Lace","#FDF5E6"}
                ,{"Yellow","#FFFF00"}
                ,{"Navajo White","#FFDEAD"}
                ,{"Cornflower Blue","#6495ED"}
                ,{"Cornsilk","#FFF8DC"}
                ,{"Cyan","#00FFFF"}
                ,{"Dark Blue","#00008B"}
                ,{"Dark Salmon","#E9967A"}
                ,{"Chartreuse","#7FFF00"}
                ,{"Light Blue","#ADD8E6"}
                ,{"Alice Blue","#F0F8FF"}
                ,{"Fuchsia","#FF00FF"}
                ,{"Pale Violet Red","#DB7093"}
                ,{"Papaya Whip","#FFEFD5"}
                ,{"Light Green","#90EE90"}
                ,{"Dark Orchid","#9932CC"}
                ,{"Dark Red","#8B0000"}
                ,{"Light Gray","#D3D3D3"}
                ,{"Yellow Green","#9ACD32"}
                ,{"Turquoise","#40E0D0"}
                ,{"Ivory","#FFFFF0"}
                ,{"Khaki","#F0E68C"}
                ,{"Olive","#808000"}
                ,{"Ghost White","#F8F8FF"}
                ,{"Orange Red","#FF4500"}
                ,{"Pale Green","#98FB98"}
                ,{"Pale Turquoise","#AFEEEE"}
                ,{"Forest Green","#228B22"}
                ,{"Dark Khaki","#BDB76B"}
                ,{"Dark Magenta","#8B008B"}
                ,{"Sky Blue","#87CEEB"}
                ,{"Dark Green","#006400"}
                ,{"Golden Rod","#DAA520"}
                ,{"Gray","#808080"}
                ,{"Green","#008000"}
                ,{"Dark Olive Green","#556B2F"}
                ,{"Dark Orange","#FF8C00"}
                ,{"Green Yellow","#ADFF2F"}
                ,{"Honey Dew","#F0FFF0"}
                ,{"Hot Pink","#FF69B4"}
                ,{"Indian Red","#CD5C5C"}
                ,{"Silver","#C0C0C0"}
                ,{"Light Sea Green","#20B2AA"}
                ,{"Slate Blue","#6A5ACD"}
                ,{"Teal","#008080"}
                ,{"Lawn Green","#7CFC00"}
                ,{"Purple","#800080"}
                ,{"Rebecca Purple","#663399"}
                ,{"Red","#FF0000"}
                ,{"Rosy Brown","#BC8F8F"}
                ,{"Lemon Chiffon","#FFFACD"}
                ,{"Peru","#CD853F"}
                ,{"Pink","#FFC0CB"}
                ,{"Orchid","#DA70D6"}
                ,{"Pale Golden Rod","#EEE8AA"}
                ,{"Thistle","#D8BFD8"}
                ,{"Tomato","#FF6347"}
                ,{"Lavender","#E6E6FA"}
                ,{"Lavender Blush","#FFF0F5"}
                ,{"Light Sky Blue","#87CEFA"}
                ,{"Light Slate Gray","#778899"}
                ,{"Lime","#00FF00"}
                ,{"Sienna","#A0522D"}
                ,{"Light Steel Blue","#B0C4DE"}
                ,{"Medium Blue","#0000CD"}
                ,{"Spring Green","#00FF7F"}
                ,{"Steel Blue","#4682B4"}
                ,{"Tan","#D2B48C"}
                ,{"Blue","#0000FF"}
                ,{"Medium Violet Red","#C71585"}
                ,{"Wheat","#F5DEB3"}
                ,{"White","#FFFFFF"}
                ,{"Medium Slate Blue","#7B68EE"}
                ,{"Medium Turquoise","#48D1CC"}
                ,{"Midnight Blue","#191970"}
                ,{"Navy","#000080"}
                ,{"Olive Drab","#6B8E23"}
                ,{"Orange","#FFA500"}
                ,{"Powder Blue","#B0E0E6"}
                ,{"Royal Blue","#4169E1"}
                ,{"Saddle Brown","#8B4513"}
                ,{"Salmon","#FA8072"}
                ,{"Sandy Brown","#F4A460"}
                ,{"Light Yellow","#FFFFE0"}
                ,{"Light Pink","#FFB6C1"}
                ,{"Medium Orchid","#BA55D3"}
                ,{"Maroon","#800000"}
                ,{"Medium Aqua Marine","#66CDAA"}
                ,{"Sea Green","#2E8B57"}
                ,{"Sea Shell","#FFF5EE"}
                ,{"Medium Purple","#9370DB"}
                ,{"Medium Sea Green","#3CB371"}
                ,{"Blanched Almond","#FFEBCD"}
                ,{"Slate Gray","#708090"}
                ,{"Snow","#FFFAFA"}
                ,{"Lime Green","#32CD32"}
                ,{"Linen","#FAF0E6"}
                ,{"Magenta","#FF00FF"}
                ,{"Violet","#EE82EE"}
                ,{"White Smoke","#F5F5F5"}
            };

            StringBuilder xml = new StringBuilder();

            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?><root>");

            xml.Append("<categories>");
            foreach (KeyValuePair<int, string> category in categories)
            {
                xml.Append(string.Format("<category id=\"{0}\" name=\"{1}\"></category>", category.Key, category.Value));
            }
            xml.Append("</categories>");

            xml.Append("<products>");
            int productId = 1;
            int categoryId = 1;
            string colorPrice = "";

            var rnd = new Random(DateTime.Now.Millisecond);
            foreach (KeyValuePair<string, string> product in products)
            {                
                colorPrice = Math.Round(rnd.NextDouble() * MAX_PRICE, 2).ToString();

                xml.Append(
                    string.Format("<product id=\"{0}\" categoryId=\"{1}\" reference=\"{2}\" name=\"{3}\" vat=\"{4}\" priceExcVAT=\"{5}\" backgroundColor=\"{6}\"><description><![CDATA[{7}]]></description></product>",
                        productId,
                        categoryId,
                        Guid.NewGuid().ToString(),
                        product.Key,
                        categoryVAT[categoryId],
                        colorPrice,
                        product.Value,
                        "This is the description for the color " + product.Key + " (" + product.Value + ") in " + categories[categoryId]
                        )
                );

                productId++;
                categoryId = ((categoryId) % categories.Count()) + 1;
            }
            xml.Append("</products>");

            xml.Append("</root>");

            File.WriteAllText("../../../webshop/app_data/webshop.xml", xml.ToString(), Encoding.UTF8);
        }
    }
}