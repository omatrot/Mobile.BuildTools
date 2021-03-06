﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace Mobile.BuildTools.Drawing
{
    public static class IconUtils
    {
        public static bool HasTransparentBackground(this Image image)
        {
            using (var clone = image.CloneAs<Rgba32>())
            {
                for (var y = 0; y < image.Height; ++y)
                {
                    var pixelRowSpan = clone.GetPixelRowSpan(y);
                    for (var x = 0; x < image.Width; ++x)
                    {
                        if (pixelRowSpan[x].A == 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void ApplyBackground(this Image image, string hexColor)
        {
            image.Mutate(c =>
            {
                c.BackgroundColor(Color.FromHex(hexColor));
            });
        }
    }
}
