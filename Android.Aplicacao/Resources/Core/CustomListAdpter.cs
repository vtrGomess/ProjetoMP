using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Model;
using Android.OS;
using Android.Runtime;
using Android.View;
using Android.Views;
using Android.Widget;
using Android.Aplicacao;
using Android.Support.V7.Widget;

namespace Android.Core
{
    public class CustomListAdpter : BaseAdapter<ItemCatalago>
    {
        List<ItemCatalago> itemsCatalago;
        Dictionary<int, Graphics.Bitmap> cacheImagem = new Dictionary<int, Graphics.Bitmap>();
        Dictionary<int, string> valueUnit = new Dictionary<int, string>();
        public CustomListAdpter(List<ItemCatalago> users)
        {
            this.itemsCatalago = users;
        }

        public override ItemCatalago this[int position]
        {
            get
            {
                return itemsCatalago[position];
            }
        }

        public override int Count
        {
            get
            {
                return itemsCatalago.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Views.View GetView(int position, Views.View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Aplicacao.Resource.Layout.catalogList, parent, false);

                var photo = view.FindViewById<ImageView>(Aplicacao.Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Aplicacao.Resource.Id.nameTextView);
                var department = view.FindViewById<TextView>(Aplicacao.Resource.Id.departmentTextView);
                var unidade = view.FindViewById<TextView>(Aplicacao.Resource.Id.unTextView);
                var btnPlus = view.FindViewById<AppCompatImageButton>(Aplicacao.Resource.Id.btnPlus);
                var btnLess = view.FindViewById<AppCompatImageButton>(Aplicacao.Resource.Id.btnLess);
                var btnBuy = LayoutInflater.From(parent.Context).Inflate(Aplicacao.Resource.Layout.activity_main, parent, false).FindViewById<Button>(Aplicacao.Resource.Id.btnBuy);

                btnPlus.Click += (sender, e) =>
                {
                    plusUnitView(view);
                    totalValue(view, parent);
                };

                btnLess.Click += (sender, e) =>
                {
                    lessUnitView(view);
                    totalValue(view, parent);
                };

                view.Tag = new ViewHolder() { Photo = photo, Name = name, Price = department, Unit = unidade, btnPlus = btnPlus, btnLess = btnLess, btnBuy = btnBuy };
            }

            var holder = (ViewHolder)view.Tag;

            if (!cacheImagem.ContainsKey(position))
                cacheImagem.Add(position, ImageManager.GetImageBitmapFromUrl(itemsCatalago[position].photo));

            if (!valueUnit.ContainsKey(position))
                valueUnit.Add(position, holder.Unit.Text);

            holder.Photo.SetImageBitmap(cacheImagem[position]);
            holder.Name.Text = itemsCatalago[position].name;
            holder.Price.Text = string.Format("R$ {0}", itemsCatalago[position].price);
            holder.Unit.Text = string.Format("{0} un", itemsCatalago[position].unit);
            holder.btnPlus.Tag = position;
            holder.btnLess.Tag = position;
            holder.btnBuy.Text = "asdasdashjdashjdashjl";

            return view;
        }

        public void plusUnitView(Views.View view)
        {
            var unidade = view.FindViewById<TextView>(Aplicacao.Resource.Id.unTextView);
            var btnPlus = view.FindViewById<AppCompatImageButton>(Aplicacao.Resource.Id.btnLess);

            var positionButton = btnPlus.Tag;
            int positionNumber = unidade.Text.LastIndexOf(' ');
            if (positionNumber != -1)
            {
                int number = Convert.ToInt32(unidade.Text.Substring(0, positionNumber));
                unidade.Text = string.Format("{0} un", number + 1);
                itemsCatalago[Convert.ToInt32(positionButton)].unit = number;
            }

        }

        public void lessUnitView(Views.View view)
        {
            var unidade = view.FindViewById<TextView>(Aplicacao.Resource.Id.unTextView);
            var btnLess = view.FindViewById<AppCompatImageButton>(Aplicacao.Resource.Id.btnLess);

            var positionButton = btnLess.Tag;
            int positionNumber = unidade.Text.LastIndexOf(' ');
            if (positionNumber != -1)
            {
                int number = Convert.ToInt32(unidade.Text.Substring(0, positionNumber));
                if (number != 0)
                    unidade.Text = string.Format("{0} un", number - 1);
                itemsCatalago[Convert.ToInt32(positionButton)].unit = number;
            }
        }

        public void totalValue(Views.View view, ViewGroup parent)
        {
            var btnBuy = LayoutInflater.From(parent.Context).Inflate(Aplicacao.Resource.Layout.activity_main, parent, false).FindViewById<Button>(Aplicacao.Resource.Id.btnBuy);

            decimal valueTotal = 0;
            foreach (var item in itemsCatalago)
            {
                valueTotal += (item.unit * Convert.ToDecimal(item.price));
            }

            if (valueTotal != 0)
                btnBuy.Text = string.Format("Comprar - R$ {0}", valueTotal);
            else
                btnBuy.Text = string.Format("Comprar");
        }
    }
}