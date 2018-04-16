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
    class PaymentRecordListBaseAdapter : BaseAdapter<PaymentRecord> {
        IList<PaymentRecord> PaymentRecordListArrayList;
        private LayoutInflater mInflater;
        private Context activity;

        public PaymentRecordListBaseAdapter(Context context, IList<PaymentRecord> results) {
            this.activity=context;
            PaymentRecordListArrayList=results;
            mInflater=(LayoutInflater)activity.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count {
            get {
                return PaymentRecordListArrayList.Count;
            }
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override PaymentRecord this[int position] {
            get {
                return PaymentRecordListArrayList[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            ImageView btnDelete;
            PaymentRecordViewHolder holder = null;
            if (convertView==null) {
                convertView=mInflater.Inflate(Resource.Layout.list_row_PaymentRecord_list, null);
                holder=new PaymentRecordViewHolder();

                holder.txtid=convertView.FindViewById<TextView>(Resource.Id.lr_identificacion);
                holder.txtDetail=convertView.FindViewById<TextView>(Resource.Id.lr_peso);
                holder.txtAmount=convertView.FindViewById<TextView>(Resource.Id.lr_altura);

                btnDelete=convertView.FindViewById<ImageView>(Resource.Id.lr_deleteBtn);

                btnDelete.Click+=(object sender, EventArgs e) => {
                    var poldel = (int)((sender as ImageView).Tag);
                    string id = PaymentRecordListArrayList[poldel].id.ToString();                

                    AlertDialog.Builder builder = new AlertDialog.Builder(activity);
                    AlertDialog confirm = builder.Create();
                    confirm.SetTitle("Confirmacion de borrado");
                    confirm.SetMessage("Se va a eliminar este dato: "+id);
                    confirm.SetButton("OK", (s, ev) => {

                        PaymentRecordListArrayList.RemoveAt(poldel);

                        DeleteSelectedPersona(id);
                        NotifyDataSetChanged();

                        Toast.MakeText(activity, "Se elimino el dato", ToastLength.Short).Show();
                    });
                    confirm.SetButton2("Cancelar", (s, ev) => {

                    });

                    confirm.Show();
                };

                convertView.Tag=holder;
                btnDelete.Tag=position;
            } else {
                btnDelete=convertView.FindViewById<ImageView>(Resource.Id.lr_deleteBtn);
                holder=convertView.Tag as PaymentRecordViewHolder;
                btnDelete.Tag=position;
            }                                                                                           

            holder.txtid.Text=PaymentRecordListArrayList[position].id.ToString();
            holder.txtDetail.Text=PaymentRecordListArrayList[position].detail;
            holder.txtAmount.Text=PaymentRecordListArrayList[position].amount.ToString();   

            if (position%2==0) {
                convertView.SetBackgroundResource(Resource.Drawable.list_selector);
            } else {
                convertView.SetBackgroundResource(Resource.Drawable.list_selector_alternate);
            }

            return convertView;
        }

        public IList<PaymentRecord> GetAllData() {
            return PaymentRecordListArrayList;
        }

        public class PaymentRecordViewHolder : Java.Lang.Object {
            public TextView txtid {
                get; set;
            }
            public TextView txtDetail {
                get; set;
            }
            public TextView txtAmount {
                get; set;
            }   
        }

        private void DeleteSelectedPersona(string PaymentRecordId) {
            PaymentRecordDbHelper _db = new PaymentRecordDbHelper();
            //_db.DeletePaymentRecord(PaymentRecordId);
        }
    }
}