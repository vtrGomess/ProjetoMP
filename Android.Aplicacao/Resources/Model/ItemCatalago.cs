using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android.Model
{
    public class ItemCatalago
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string price { get; set; }
        public string category_id { get; set; }
        public int unit { get; set; }
    }
}