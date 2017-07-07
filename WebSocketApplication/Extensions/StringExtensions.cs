using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocketApplication.Extensions
{
    public static class StringExtensions
    {
        public static string[] ExtractFeatures(this String text)
        {
            return text.Split(new string[] { " " }, StringSplitOptions.None);
        }
    }
}
