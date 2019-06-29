using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            imageProcess.Clean(destinationPath);
            sw.Stop();
            Console.WriteLine($"Clean花費時間: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            imageProcess.Clean(destinationPath);
            sw.Stop();
            Console.WriteLine($"Clean花費時間: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw.Stop();
            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
        }
    }
}
