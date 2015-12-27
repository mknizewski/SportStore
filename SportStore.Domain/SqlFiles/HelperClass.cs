using System.Drawing;
using System.IO;

namespace SportStore.Domain.SqlFiles
{
    public static class HelperClass
    {
        public static byte[] Img2Byte(string path)
        {
            var image = Image.FromFile(path);
            var memoryStream = new MemoryStream();

            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            return memoryStream.ToArray();
        }
    }
}