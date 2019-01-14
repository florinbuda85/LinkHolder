using System;
using System.Net;
using System.Text.RegularExpressions;

namespace LinkHolder.Util
{
    public class TitleGetter
    {
        public static string GetTitle(string url)
        {
            try
            {
                WebClient x = new WebClient();
                string source = x.DownloadString(url);

                return Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            }
            catch (Exception)
            {
                return "Error: can't get title";
            }

        }
    }
}
