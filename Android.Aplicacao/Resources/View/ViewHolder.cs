using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Android.View
{
    public class ViewHolder : Java.Lang.Object
    {
        public ImageView Photo { get; set; }
        public TextView Name { get; set; }
        public TextView Price { get; set; }
        public TextView Unit { get; set; }
        public AppCompatImageButton btnPlus { get; set; }
        public AppCompatImageButton btnLess { get; set; }
        public Button btnBuy { get; set; }
    }
}