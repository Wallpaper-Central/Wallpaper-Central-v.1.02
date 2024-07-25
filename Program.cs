using System;
using System.Runtime.InteropServices;
using System.IO;

namespace WallpaperChanger
{
    class Program
    {
        // Importa a função SystemParametersInfo da User32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        static void Main(string[] args)
        {
            // Define o caminho da imagem embutida
            string wallpaperPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wallpaper.png");

            if (File.Exists(wallpaperPath))
            {
                SetWallpaper(wallpaperPath);
            }
            else
            {
            }
        }

        private static void SetWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}

