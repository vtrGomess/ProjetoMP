using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android.Core
{
    public class CatalogData
    {
        //catalogdata
        public static int categoria = 0;
        public static List<ItemCatalago> PopuleModel()
        {
            List<ItemCatalago> ItemsCatalog = new List<ItemCatalago>();
            Requisicao catalagoViewModel = new Requisicao();
            List<Catalago> catalagos = catalagoViewModel.RequestJsonFromURL("https://pastebin.com/raw/eVqp7pfX");

            foreach (Catalago item in catalagos)
            {
                ItemsCatalog.Add(new ItemCatalago()
                {
                    id = item.id,
                    name = item.name,
                    description = item.description,
                    photo = item.photo,
                    category_id = item.category_id,
                    price = item.price
                });
            }

            if (categoria != 0)
                ItemsCatalog = ItemsCatalog.Where(x => x.category_id == categoria.ToString()).ToList();

            return ItemsCatalog.OrderBy(i => i.name).ToList();
        }
    }
}