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
using Android.Database;

namespace PersonalPaymentsAndroid {
    [Activity(Label = "AddEditPaymentRecordActivity")]
    public class AddEditPaymentRecordActivity : Activity {

        EditText etid, etidentificacion, etidPersona, etpeso, etaltura, etpresionarterial, etfrecuenciacardiaca, etdetalle;
        Button btninsertar;
        string personaId, personaNombre, personaIdentificacion;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddEditPaymentRecord);

            //Optener el dato de la persona
            personaId=Intent.GetStringExtra("PersonaId")??string.Empty;
            personaNombre=Intent.GetStringExtra("PersonaNombre")??string.Empty;
            personaIdentificacion=Intent.GetStringExtra("PersonaIdentificacion")??string.Empty;

            etid=FindViewById<EditText>(Resource.Id.etid);
            etidPersona=FindViewById<EditText>(Resource.Id.etidPersona);
            etidentificacion=FindViewById<EditText>(Resource.Id.etidentificacion);
            etpeso=FindViewById<EditText>(Resource.Id.etpeso);
            etaltura=FindViewById<EditText>(Resource.Id.etaltura);
            etpresionarterial=FindViewById<EditText>(Resource.Id.etpresionarterial);
            etfrecuenciacardiaca=FindViewById<EditText>(Resource.Id.etfrecuenciacardiaca);
            etdetalle=FindViewById<EditText>(Resource.Id.etdetalle);
            btninsertar=FindViewById<Button>(Resource.Id.btninsertar);

            //btninsertar.Click+=buttonInsertClick;
            string editId = Intent.GetStringExtra("InfoMedicaId")??string.Empty;

            if (editId.Trim().Length>0) {
                etid.Text=editId;
                //LoadDataForEdit(editId);
            } else {
                //Cargar los datos en el formulario
                etidentificacion.Text=personaIdentificacion;
                etidPersona.Text=personaId;
            }
        }
           /*
        private void LoadDataForEdit(string contactId) {
            PaymentRecordDbHelper db = new PaymentRecordDbHelper();
            ICursor cData = db.getInfoMedicaById(int.Parse(contactId));
            if (cData.MoveToFirst()) {
                etid.Text=cData.GetString(cData.GetColumnIndex("id"));
                etidPersona.Text=cData.GetString(cData.GetColumnIndex("idPersona"));
                etidentificacion.Text=cData.GetString(cData.GetColumnIndex("identificacion"));
                etpeso.Text=cData.GetString(cData.GetColumnIndex("peso"));
                etaltura.Text=cData.GetString(cData.GetColumnIndex("altura"));
                etpresionarterial.Text=cData.GetString(cData.GetColumnIndex("presionArterial"));
                etfrecuenciacardiaca.Text=cData.GetString(cData.GetColumnIndex("frecuenciaCardiaca"));
                etdetalle.Text=cData.GetString(cData.GetColumnIndex("detalle"));
            }
        }

        void buttonInsertClick(object sender, EventArgs e) {
            PaymentRecordDbHelper db = new PaymentRecordDbHelper();
            if (etpeso.Text.Trim().Length<1) {
                Toast.MakeText(this, "Ingrese el Peso.", ToastLength.Short).Show();
                return;
            }
            if (etaltura.Text.Trim().Length<1) {
                Toast.MakeText(this, "Ingrese el altura.", ToastLength.Short).Show();
                return;
            }

            if (etpresionarterial.Text.Trim().Length<1) {
                Toast.MakeText(this, "Ingrese La presion arterial.", ToastLength.Short).Show();
                return;
            }

            PaymentRecord im = new PaymentRecord();

            if (etid.Text.Trim().Length>0) {
                im.id=int.Parse(etid.Text);
            }
            im.identificacion=etidentificacion.Text;
            im.idPersona=Int32.Parse(etidPersona.Text);
            im.peso=Double.Parse(etpeso.Text);
            im.altura=Double.Parse(etaltura.Text);
            im.presionArterial=etpresionarterial.Text;
            im.frecuenciaCardiaca=etfrecuenciacardiaca.Text;
            im.detalle=etdetalle.Text;

            try {

                if (etid.Text.Trim().Length>0) {
                    db.UpdateInfoMedica(im);
                    Toast.MakeText(this, "Se actualizo correctamente.", ToastLength.Short).Show();
                } else {
                    db.AddNewInfoMedica(im);
                    Toast.MakeText(this, "Se agrego correctamente.", ToastLength.Short).Show();
                }

                Finish();

                //Go to main activity after save/edit
                var mainActivity = new Intent(this, typeof(PaymentRecordActivity));
                mainActivity.PutExtra("PersonaId", personaId);
                mainActivity.PutExtra("PersonaName", personaNombre);
                mainActivity.PutExtra("PersonaIdentificacion", personaIdentificacion);
                StartActivity(mainActivity);

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }   */
    }
}