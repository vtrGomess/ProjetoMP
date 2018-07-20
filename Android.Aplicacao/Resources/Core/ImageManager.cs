using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android.Core
{
    class ImageManager
    {
        static Dictionary<string, Drawable> cache = new Dictionary<string, Drawable>();

        public static Drawable Get(Context context, string url)
        {
            if (!cache.ContainsKey(url))
            {
                var drawable = Drawable.CreateFromStream(context.Assets.Open(url), null);

                cache.Add(url, drawable);
            }

            return cache[url];
        }

        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}