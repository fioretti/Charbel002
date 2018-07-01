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

namespace GiftCertApp
{
    [Activity(Label = "Gift Cert", MainLauncher = true, Icon ="@drawable/smallIcon")]
    public class MenuActivity : Activity
    {
        private Button purchaseButton;
        private Button redeemButton;
        private Button viewPurchaseGcButton;
        private Button viewRedeemGcButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            purchaseButton = FindViewById<Button>(Resource.Id.purchaseButton);
            redeemButton = FindViewById<Button>(Resource.Id.redeemButton);
            viewPurchaseGcButton = FindViewById<Button>(Resource.Id.viewPurchaseGcButton);
            viewRedeemGcButton = FindViewById<Button>(Resource.Id.viewRedeemGcButton);
        }

        private void HandleEvents()
        {
            purchaseButton.Click += PurchaseButton_Click;
            redeemButton.Click += RedeemButton_Click;
            viewPurchaseGcButton.Click += ViewPurchaseGcButton_Click;
            viewRedeemGcButton.Click += ViewRedeemGcButton_Click;
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        private void RedeemButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void ViewPurchaseGcButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ViewGctMenuActivity));
            StartActivity(intent);
       
        }
        private void ViewRedeemGcButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ViewGctMenuActivity));
            StartActivity(intent);

        }
    }
}