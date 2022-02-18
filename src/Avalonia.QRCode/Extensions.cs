using Avalonia.Media;
using System;
using System.IO;
using System.Globalization;
using Net.Codecrete.QrCodeGenerator;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Color = SixLabors.ImageSharp.Color;

namespace Avalonia.QRCode;

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
}