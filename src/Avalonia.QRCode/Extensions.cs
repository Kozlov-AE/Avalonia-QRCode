using Avalonia.Media;
using Avalonia.Media.Imaging;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;

namespace Avalonia.QRCode
{
    public static class Extensions
    {

        public static string ToHex(this IBrush brush)
        {            
            var scb = brush as ISolidColorBrush;            
            var c = scb.Color;
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");      
        }
        public static byte[] ToBytesArray(this IBrush brush)
        {            
            var scb = brush as ISolidColorBrush;            
            var c = scb.Color;
            return c.ToBytesArray();
        }

        public static string ToHex(this Media.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        
        public static byte[] ToBytesArray(this Media.Color c)
        {
            var hex = c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            var bytes = new byte[hex.Length / 2];
            var span = hex.AsSpan();
            for (int i = 0; i < bytes.Length; i++)
            {
                //bytes[i] = byte.Parse(span.Slice(i * 2, 2), NumberStyles.HexNumber);
                bytes[i] = byte.Parse(span.Slice(i * 2, 2).ToString(), NumberStyles.HexNumber);
            }
            return bytes;
        }
        
        public static System.Drawing.Color FromNative(this IBrush brush)
        {
            var scb = brush as ISolidColorBrush;
            return scb.Color.FromNative();
        }

        public static System.Drawing.Color FromNative(this Avalonia.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static Avalonia.Media.Color ToNative(this System.Drawing.Color color)
        {
            return Avalonia.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }


        /// <summary>
        /// Converts a System.Drawing.Bitmap to Avalonia.Media.Imaging.Bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Avalonia.Media.Imaging.Bitmap ToNative(this System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                return new Avalonia.Media.Imaging.Bitmap(memory);
            }
        }

        /// <summary>
        /// Converts a Avalonia.Media.Imaging.Bitmap to System.Drawing.Bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static System.Drawing.Bitmap FromNative(this Avalonia.Media.Imaging.IBitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory);
                memory.Position = 0;
                return new System.Drawing.Bitmap(memory);
            }
        }
    }
}
