using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Core;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Android.Aplicacao
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView myList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource  
            SetContentView(Aplicacao.Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            myList = FindViewById<ListView>(Aplicacao.Resource.Id.listView);
            myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuItem1:
                    {
                        CatalogData.categoria = 0;
                        myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
                        return true;
                    }
                case Resource.Id.menuItem2:
                    {
                        CatalogData.categoria = 5;
                        myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        CatalogData.categoria = 3;
                        myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
                        return true;
                    }
                case Resource.Id.menuItem4:
                    {
                        CatalogData.categoria = 4;
                        myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
                        return true;
                    }
                case Resource.Id.menuItem5:
                    {
                        CatalogData.categoria = 2;
                        myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
                        return true;
                    }
                case Resource.Id.menuItem6:
                    {
                        CatalogData.categoria = 1;
                        myList.Adapter = new CustomListAdpter(CatalogData.PopuleModel());
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

