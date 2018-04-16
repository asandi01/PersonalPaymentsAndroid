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
    [Activity(Label = "PaymentRecord")]
    public class PaymentRecordActivity : Activity {

        string personaId, personaNombre, personaIdentificacion;
        Button btnAdd;
        ListView lv;
        TextView nombre;
        IList<PaymentRecord> listItsms = null;
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PaymentRecord);

            //Optener el dato de la persona
            personaId=Intent.GetStringExtra("PersonaId")??string.Empty;
            personaNombre=Intent.GetStringExtra("PersonaNombre")??string.Empty;
            personaIdentificacion=Intent.GetStringExtra("PersonaIdentificacion")??string.Empty;

            btnAdd=FindViewById<Button>(Resource.Id.paymentRecordListBtnAdd);
            lv=FindViewById<ListView>(Resource.Id.paymentRecordListListView);
            nombre=FindViewById<TextView>(Resource.Id.lr_nombre);
            nombre.Text=personaNombre;

            btnAdd.Click+=delegate {
                var activityAddEdit = new Intent(this, typeof(AddEditPaymentRecordActivity));
                activityAddEdit.PutExtra("PersonaId", personaId);
                activityAddEdit.PutExtra("PersonaNombre", personaNombre);
                activityAddEdit.PutExtra("PersonaIdentificacion", personaIdentificacion);
                StartActivity(activityAddEdit);
            };

            LoadPaymentRecordInList();

        }

        private void LoadPaymentRecordInList() {
            PaymentRecordDbHelper dbVals = new PaymentRecordDbHelper();
            dbVals.GetAllPaymentRecord();
            
            listItsms=dbVals.getListPayment();

            lv.Adapter=new PaymentRecordListBaseAdapter(this, listItsms);

            lv.ItemLongClick+=lv_ItemLongClick;
        }

        private void lv_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e) {
            PaymentRecord o = listItsms[e.Position];

            var activityAddEdit = new Intent(this, typeof(AddEditPaymentRecordActivity));
            activityAddEdit.PutExtra("PaymentRecordId", o.id.ToString());
            activityAddEdit.PutExtra("PersonaId", personaId);
            activityAddEdit.PutExtra("PersonaName", personaNombre);
            activityAddEdit.PutExtra("PersonaIdentificacion", personaIdentificacion);
            StartActivity(activityAddEdit);
        }
    }
}