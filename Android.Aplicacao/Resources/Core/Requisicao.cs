using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Android.Core
{
    public class Catalago
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string price { get; set; }
        public string category_id { get; set; }
    }

    public class Requisicao
    {
        public List<Catalago> catalagos = new List<Catalago>();

        //public async Task<List<Catalago>> RequestJSONFromURL(string url)
        //{
        //    try
        //    {
        //        var client = new HttpClient();
        //        var json = await client.GetStringAsync(url);
                
        //        var items = JsonConvert.DeserializeObject<List<Catalago>>(json);

        //        foreach (var item in items)
        //        {
        //            catalagos.Add(item);
        //        }

        //        return catalagos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<Catalago> RequestJsonFromURL(string url)
        {
            string response = new System.Net.WebClient().DownloadString(url);

            var items = JsonConvert.DeserializeObject<List<Catalago>>(response);

            foreach (var item in items)
            {
                catalagos.Add(item);
            }

            return catalagos;
        }

        public Bitmap ReturnImageFromURL(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new System.Net.WebClient())
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
