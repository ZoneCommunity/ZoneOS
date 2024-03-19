using Cosmos.System.Graphics;
using Cosmos.System;
using IL2CPU.API.Attribs;
using Sys = Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;


namespace ZoneOS.WM
{
    public class WindowManager
    {

        public Canvas Window;
        public void LoadWindow()
        {

            Window.Clear(Color.FromArgb(47, 66, 74));
            // Window
            Window.DrawFilledRectangle(Color.FromArgb(255, 255, 255, 255), 199, 160, 440, 589); // Back of window
            Window.DrawFilledRectangle(Color.FromArgb(255, 27, 89, 249), 492, 712, 68, 27);
            Window.DrawRectangle(Color.FromArgb(255, 90, 136, 255), 492, 712, 68, 27);
            Window.DrawFilledRectangle(Color.FromArgb(255, 255, 255, 255), 564, 712, 68, 27);
            Window.DrawRectangle(Color.FromArgb(255, 172, 172, 172), 564, 712, 68, 27);
            Window.DrawString("Application", PCScreenFont.Default, Color.FromArgb(0, 0, 0), 214, 171);
            Window.DrawString("Cancel", PCScreenFont.Default, Color.FromArgb(0, 0, 0), 577, 718);
            Window.DrawString("Okay", PCScreenFont.Default, Color.FromArgb(0, 0, 0), 511, 718);
            Window.DrawFilledRectangle(Color.FromArgb(255, 255, 105, 105), 613, 172, 14, 14);
            Window.DrawFilledRectangle(Color.FromArgb(255, 255, 177, 105), 592, 172, 14, 14);
            Window.DrawFilledRectangle(Color.FromArgb(255, 96, 192, 135), 571, 172, 14, 14);
        }

    }
}
