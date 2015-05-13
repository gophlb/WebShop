﻿using System;
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
                { 1, "Almost free colors" },
                { 2, "Cheap colors" },
                { 3, "Nice colors" },
                { 4, "Premium colors" },
            };

            Dictionary<int, double> categoryVAT = new Dictionary<int, double>()
            {
                { 1, 1.0 },
                { 2, 12.0 },
                { 3, 15.0 },
                { 4, 21.0 }
            };

            StringDictionary products = new StringDictionary()
            {
                {"Alice Blue","#F0F8FF"}
                ,{"Antique White","#FAEBD7"}
                ,{"Aqua","#00FFFF"}
                ,{"Aquamarine","#7FFFD4"}
                ,{"Azure","#F0FFFF"}
                ,{"Beige","#F5F5DC"}
                ,{"Bisque","#FFE4C4"}
                ,{"Black","#000000"}
                ,{"Blanched Almond","#FFEBCD"}
                ,{"Blue","#0000FF"}
                ,{"Blue Violet","#8A2BE2"}
                ,{"Brown","#A52A2A"}
                ,{"Burly Wood","#DEB887"}
                ,{"Cadet Blue","#5F9EA0"}
                ,{"Chartreuse","#7FFF00"}
                ,{"Chocolate","#D2691E"}
                ,{"Coral","#FF7F50"}
                ,{"Cornflower Blue","#6495ED"}
                ,{"Cornsilk","#FFF8DC"}
                ,{"Crimson","#DC143C"}
                ,{"Cyan","#00FFFF"}
                ,{"Dark Blue","#00008B"}
                ,{"Dark Cyan","#008B8B"}
                ,{"Dark Golden Rod","#B8860B"}
                ,{"Dark Gray","#A9A9A9"}
                ,{"Dark Green","#006400"}
                ,{"Dark Khaki","#BDB76B"}
                ,{"Dark Magenta","#8B008B"}
                ,{"Dark Olive Green","#556B2F"}
                ,{"Dark Orange","#FF8C00"}
                ,{"Dark Orchid","#9932CC"}
                ,{"Dark Red","#8B0000"}
                ,{"Dark Salmon","#E9967A"}
                ,{"Dark SeaGreen","#8FBC8F"}
                ,{"Dark Slate Blue","#483D8B"}
                ,{"Dark Slate Gray","#2F4F4F"}
                ,{"Dark Turquoise","#00CED1"}
                ,{"Dark Violet","#9400D3"}
                ,{"Deep Pink","#FF1493"}
                ,{"Deep Sky Blue","#00BFFF"}
                ,{"Dim Gray","#696969"}
                ,{"Dodger Blue","#1E90FF"}
                ,{"Fire Brick","#B22222"}
                ,{"Floral White","#FFFAF0"}
                ,{"Forest Green","#228B22"}
                ,{"Fuchsia","#FF00FF"}
                ,{"Gainsboro","#DCDCDC"}
                ,{"Ghost White","#F8F8FF"}
                ,{"Gold","#FFD700"}
                ,{"Golden Rod","#DAA520"}
                ,{"Gray","#808080"}
                ,{"Green","#008000"}
                ,{"Green Yellow","#ADFF2F"}
                ,{"Honey Dew","#F0FFF0"}
                ,{"Hot Pink","#FF69B4"}
                ,{"IndianR ed","#CD5C5C"}
                ,{"Indigo","#4B0082"}
                ,{"Ivory","#FFFFF0"}
                ,{"Khaki","#F0E68C"}
                ,{"Lavender","#E6E6FA"}
                ,{"Lavender Blush","#FFF0F5"}
                ,{"Lawn Green","#7CFC00"}
                ,{"Lemon Chiffon","#FFFACD"}
                ,{"Light Blue","#ADD8E6"}
                ,{"Light Coral","#F08080"}
                ,{"Light Cyan","#E0FFFF"}
                ,{"Light Golden Rod Yellow","#FAFAD2"}
                ,{"Light Gray","#D3D3D3"}
                ,{"Light Green","#90EE90"}
                ,{"Light Pink","#FFB6C1"}
                ,{"Light Salmon","#FFA07A"}
                ,{"Light Sea Green","#20B2AA"}
                ,{"Light Sky Blue","#87CEFA"}
                ,{"Light Slate Gray","#778899"}
                ,{"Light Steel Blue","#B0C4DE"}
                ,{"Light Yellow","#FFFFE0"}
                ,{"Lime","#00FF00"}
                ,{"Lime Green","#32CD32"}
                ,{"Linen","#FAF0E6"}
                ,{"Magenta","#FF00FF"}
                ,{"Maroon","#800000"}
                ,{"Medium Aqua Marine","#66CDAA"}
                ,{"Medium Blue","#0000CD"}
                ,{"Medium Orchid","#BA55D3"}
                ,{"Medium Purple","#9370DB"}
                ,{"Medium Sea Green","#3CB371"}
                ,{"Medium Slate Blue","#7B68EE"}
                ,{"Medium Spring Green","#00FA9A"}
                ,{"Medium Turquoise","#48D1CC"}
                ,{"Medium Violet Red","#C71585"}
                ,{"Midnight Blue","#191970"}
                ,{"Mint Cream","#F5FFFA"}
                ,{"Misty Rose","#FFE4E1"}
                ,{"Moccasin","#FFE4B5"}
                ,{"Navajo White","#FFDEAD"}
                ,{"Navy","#000080"}
                ,{"Old Lace","#FDF5E6"}
                ,{"Olive","#808000"}
                ,{"Olive Drab","#6B8E23"}
                ,{"Orange","#FFA500"}
                ,{"Orange Red","#FF4500"}
                ,{"Orchid","#DA70D6"}
                ,{"Pale Golden Rod","#EEE8AA"}
                ,{"Pale Green","#98FB98"}
                ,{"Pale Turquoise","#AFEEEE"}
                ,{"Pale Violet Red","#DB7093"}
                ,{"Papaya Whip","#FFEFD5"}
                ,{"Peach Puff","#FFDAB9"}
                ,{"Peru","#CD853F"}
                ,{"Pink","#FFC0CB"}
                ,{"Plum","#DDA0DD"}
                ,{"Powder Blue","#B0E0E6"}
                ,{"Purple","#800080"}
                ,{"Rebecca Purple","#663399"}
                ,{"Red","#FF0000"}
                ,{"Rosy Brown","#BC8F8F"}
                ,{"Royal Blue","#4169E1"}
                ,{"Saddle Brown","#8B4513"}
                ,{"Salmon","#FA8072"}
                ,{"Sandy Brown","#F4A460"}
                ,{"Sea Green","#2E8B57"}
                ,{"Sea Shell","#FFF5EE"}
                ,{"Sienna","#A0522D"}
                ,{"Silver","#C0C0C0"}
                ,{"Sky Blue","#87CEEB"}
                ,{"Slate Blue","#6A5ACD"}
                ,{"Slate Gray","#708090"}
                ,{"Snow","#FFFAFA"}
                ,{"Spring Green","#00FF7F"}
                ,{"Steel Blue","#4682B4"}
                ,{"Tan","#D2B48C"}
                ,{"Teal","#008080"}
                ,{"Thistle","#D8BFD8"}
                ,{"Tomato","#FF6347"}
                ,{"Turquoise","#40E0D0"}
                ,{"Violet","#EE82EE"}
                ,{"Wheat","#F5DEB3"}
                ,{"White","#FFFFFF"}
                ,{"White Smoke","#F5F5F5"}
                ,{"Yellow","#FFFF00"}
                ,{"Yellow Green","#9ACD32"}
            };

            StringBuilder xml = new StringBuilder();

            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?><root>");

            xml.Append("<categories>");
            foreach (var category in categories)
            {
                xml.Append(string.Format("<category id=\"{0}\" name=\"{1}\"></category>", category.Key, category.Value));
            }
            xml.Append("</categories>");

            xml.Append("<products>");
            int productId = 1;
            int categoryId = 1;
            string colorPrice = "";
            foreach (DictionaryEntry product in products)
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                colorPrice = Math.Round(rnd.NextDouble() * MAX_PRICE, 2).ToString();

                xml.Append(
                    string.Format("<product id=\"{0}\" categoryId=\"{1}\" reference=\"{2}\" name=\"{3}\" vat=\"{4}\" priceExcVAT=\"{5}\"><description><![CDATA[{6}]]></description></product>",
                        productId,
                        categoryId,
                        Guid.NewGuid().ToString(),
                        product.Value,
                        categoryVAT[categoryId],
                        colorPrice,
                        "This is the description for the color " + product.Value + " in " + categories[categoryId]
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