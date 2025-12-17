using System.Drawing;
using System.IO;

namespace LOGIN
{
    internal static class ImageLoader
    {
        public static Image LoadUnlocked(string path)
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var tmp = Image.FromStream(fs);
            return new Bitmap(tmp); // clone để không lock file
        }
    }
}
