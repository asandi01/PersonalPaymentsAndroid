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

namespace PersonalPaymentsAndroid {
    [Activity(Label = "Dashboard")]
    public class Dashboard : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
    
            SetContentView(Resource.Layout.Dashboard);

            Button btnPayment = FindViewById<Button>(Resource.Id.btnpayment);

            btnPayment.Click+=delegate {
                var activityPayment = new Intent(this, typeof(PaymentRecordActivity));
                StartActivity(activityPayment);
            };

            Button btnIncome = FindViewById<Button>(Resource.Id.btnincome);

            btnIncome.Click+=delegate {
                var activityPayment = new Intent(this, typeof(PaymentRecordActivity));
                StartActivity(activityPayment);
            };
        }
    }
}