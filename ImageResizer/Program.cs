using System;
using System.Diagnostics;
using System.IO;

namespace ImageResizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            //未調整前
            imageProcess.Clean(destinationPath);

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            imageProcess.OldResizeImages(sourcePath, destinationPath, 2.0);
            sw1.Stop();

            Console.WriteLine($"舊方法花費時間: {sw1.ElapsedMilliseconds} ms");

            //調整後
            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
        }
    }
}