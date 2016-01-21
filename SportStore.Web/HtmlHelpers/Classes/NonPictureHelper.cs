using System.Drawing;
using System.IO;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public static class NonPictureHelper
    {
        public static byte[] NoImageArray { get; set; }

        //TODO: Zmienić na resouces!
        private static Image _noImage = Image.FromFile(@"D:\Projekty\SportStore\branches\release0.2\SportStore.Web\Content\Images\no-image.png");

        public static void GetNoImage()
        {
            MemoryStream memoryStream = new MemoryStream();
            _noImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            NoImageArray = memoryStream.ToArray();
        }
    }
}