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
using GiftCertApp.Adapters;
using GiftCert.Core.Model;
using GiftCert.Core.Service;
using GiftCertApp.Fragments;

namespace GiftCertApp
{
    [Activity(Label = "View Purchase")]
    public class ViewGctMenuActivity : Activity
    {
        private ListView gcPurchaseListView;
        private List<GcPurchase> allGcPurchases;
        private GcPurchaseDataService gcPurchaseDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GcPurchaseMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Favorites", Resource.Drawable.FavoritesIcon, new GcPurchaseFragment());
           // AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
            //AddTab("Veggie Lovers", Resource.Drawable.VeggieLoversIcon, new VeggieLoversFragment());
         
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        private void GcPurchaseListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var gcPurchase = allGcPurchases[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(GcPurchaseDetailActivity));
            intent.PutExtra("selectedGcPurchaseId", gcPurchase.Id);
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedGcPurchase = gcPurchaseDataService.GetGcPurchaseById(data.GetIntExtra("selectedGcPurchaseId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've added {0} time(s) the {1}", data.GetIntExtra("amount", 0), selectedGcPurchase.CcNumber));
                dialog.Show();
            }
        }
    }
}