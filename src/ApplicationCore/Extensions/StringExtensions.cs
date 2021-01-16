namespace ApplicationCore.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string text, int length, string ellipsis = "...", bool keepFullWordAtEnd = false)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
    
            if (text.Length < length) return text;
    
            text = text.Substring(0, length);
    
            if (keepFullWordAtEnd)
            {
                text = text.Substring(0, text.LastIndexOf(' '));
            }
    
            return text + ellipsis;
        }

        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
    }
}