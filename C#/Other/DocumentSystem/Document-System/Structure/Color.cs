using System;
using System.IO;
using DocumentSystem.Renderers;

namespace DocumentSystem.Structure
{
    public class Color 
    {
        public static Color Black { get { return new Color(0, 0, 0); } }
        public static Color Red { get { return new Color(255, 50, 50); } }
        public static Color Green { get { return new Color(50, 255, 50); } }
        public static Color Blue { get { return new Color(50, 50, 255); } }
        public static Color White { get { return new Color(255, 255, 255); } }

        public byte RedValue { get; set; }
        public byte GreenValue { get; set; }
        public byte BlueValue { get; set; }

        public Color(byte red, byte green, byte blue)
        {
            this.RedValue = red;
            this.GreenValue = green;
            this.BlueValue = blue;
        }

    }
}
