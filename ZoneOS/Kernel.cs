using Cosmos.System.Graphics;
using Cosmos.System;
using IL2CPU.API.Attribs;
using Sys = Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;

using ZoneOS.WM;

namespace ZoneOS
{
    public class Kernel : Sys.Kernel
    {
        public Canvas canvas;
        [ManifestResourceStream(ResourceName = "ZoneOS.Cursor.bmp")] public static byte[] cursor;
        public static Bitmap curs = new Bitmap(cursor);

        protected override void BeforeRun()
        {
            //Setting the max cursor x and y position
            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            //Set the cursor to the middle of the screen
            MouseManager.X = 1920 / 2;
            MouseManager.Y = 1080 / 2;
        }

        public static int bmp_x = 50;
        public static int bmp_y = 50;
        public static bool movable = false;

        protected override void Run()
        {
            // Background
            canvas.Clear(Color.FromArgb(47, 66, 74));

            // Taskbar
            canvas.DrawFilledRectangle(Color.FromArgb(255, 217, 217, 217), 0, 1044, 1920, 36);

            WindowManager windowManager = new WindowManager();
            // windowManager.LoadWindow();

            //Drawing the cursor
            canvas.DrawImageAlpha(curs, (int)MouseManager.X, (int)MouseManager.Y); //DrawImageAlpha is drwaing transparent bitmaps
            //Calling the memory managger
            Heap.Collect();

            canvas.Display();
        }
    }
}
