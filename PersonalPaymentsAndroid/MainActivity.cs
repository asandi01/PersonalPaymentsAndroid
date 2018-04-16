using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace PersonalPaymentsAndroid {
    [Activity(Label = "PersonalPaymentsAndroid", MainLauncher = true)]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnIngresar = FindViewById<Button>(Resource.Id.btningresar);

            btnIngresar.Click+=delegate {
                var activityPersona = new Intent(this, typeof(Dashboard));
                StartActivity(activityPersona);
            };   
        }
    }
}

