using System.IO;
using CoreHtmlToImage;

namespace TicketSystem.Utitilies
{
    public class Utitilies
    {
        public static string ConvertHtmlTOImage(string html, string imageName, string imageFormat)
        {
            var converter = new HtmlConverter();
            var bytes = converter.FromHtmlString(html, 400, ImageFormat.Jpg);
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var path = $"{projectDirectory}/Images/{imageName}.{imageFormat}";
            File.WriteAllBytes(path, bytes);

            return path;
        }
    }
}
