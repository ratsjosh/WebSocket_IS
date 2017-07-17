using System;

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
