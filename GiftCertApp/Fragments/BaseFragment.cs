using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GiftCert.Core.Model;
using GiftCert.Core.Service;

namespace GiftCertApp.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected GcPurchaseDataService gcPurchaseDataService;
        protected List<GcPurchase> gcPurchases;

        public BaseFragment()
        {
            gcPurchaseDataService = new GcPurchaseDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.gcPurchaseListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var gcPurchase = gcPurchases[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(GcPurchaseDetailActivity));
            intent.PutExtra("selectedGcPurchaseId", gcPurchase.Id);

            StartActivityForResult(intent, 100);
        }

      
    }
}