using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;  
using Android.Database;
                
using System.Xml;
using System.Net.Http;

namespace PersonalPaymentsAndroid {
    class PaymentRecordDbHelper {        

        //Retrive All Details
        public IList<PaymentRecord> GetAllPaymentRecord(string idPersonal) {  

            var sServiceURL = $"/PaymentRecord.asmx/Get";

            using (var client = new HttpClient()) {
                try {
                    client.BaseAddress=new Uri("http://172.22.214.81:8090");
                    //var response = await client.GetAsync(sServiceURL);
                    //response.EnsureSuccessStatusCode();

                    //var stringResult = await response.Content.ReadAsStringAsync();

                    XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(stringResult);
                    doc.RemoveChild(doc.FirstChild);

                    XmlDocument exchangeRateData = new XmlDocument();
                    exchangeRateData.LoadXml(doc.FirstChild.FirstChild.Value);

                    var paymentRecord = new List<PaymentRecord>();

                    foreach (XmlNode node in exchangeRateData.FirstChild.ChildNodes) {                        
                        paymentRecord.Add(new PaymentRecord() {
                            id = Int32.Parse(node.ChildNodes[0].InnerText),
                            idUser=Int32.Parse(node.ChildNodes[1].InnerText),
                            detail=node.ChildNodes[2].InnerText,
                            amount= Double.Parse(node.ChildNodes[3].InnerText),
                            recurrence=Convert.ToBoolean(node.ChildNodes[4].InnerText),
                            recurrenciaTypeId=Int32.Parse(node.ChildNodes[5].InnerText),
                            paymentDate=Convert.ToDateTime(node.ChildNodes[6].InnerText),
                            providerId=Int32.Parse(node.ChildNodes[7].InnerText),
                            expenseCategoryId=Int32.Parse(node.ChildNodes[7].InnerText)
                        });
                    }
                    return paymentRecord;

                } catch (HttpRequestException httpRequestException) {
                    return null;
                }
            }             
        }


        /*
        //Add New Contact
        public void AddNewPaymentRecord(PaymentRecord PaymentRecord) {
            SQLiteDatabase db = this.WritableDatabase;
            ContentValues vals = new ContentValues();

            vals.Put("idPersona", PaymentRecord.idPersona);
            vals.Put("identificacion", PaymentRecord.identificacion);
            vals.Put("peso", PaymentRecord.peso);
            vals.Put("altura", PaymentRecord.altura);
            vals.Put("presionArterial", PaymentRecord.presionArterial);
            vals.Put("frecuenciaCardiaca", PaymentRecord.frecuenciaCardiaca);
            vals.Put("detalle", PaymentRecord.detalle);

            db.Insert("PaymentRecord", null, vals);
        }

        //Get details by Id
        public ICursor getPaymentRecordById(int id) {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor res = db.RawQuery("select * from PaymentRecord where id="+id+"", null);
            return res;
        }

        //Update Existing contact
        public void UpdatePaymentRecord(PaymentRecord PaymentRecord) {
            if (PaymentRecord==null) {
                return;
            }

            //Obtain writable database
            SQLiteDatabase db = this.WritableDatabase;

            //Prepare content values
            ContentValues vals = new ContentValues();
            vals.Put("idPersona", PaymentRecord.idPersona);
            vals.Put("identificacion", PaymentRecord.identificacion);
            vals.Put("peso", PaymentRecord.peso);
            vals.Put("altura", PaymentRecord.altura);
            vals.Put("presionArterial", PaymentRecord.presionArterial);
            vals.Put("frecuenciaCardiaca", PaymentRecord.frecuenciaCardiaca);
            vals.Put("detalle", PaymentRecord.detalle);

            ICursor cursor = db.Query("PaymentRecord",
                    new String[] { "id", "idPersona", "identificacion", "peso", "altura", "presionArterial", "frecuenciaCardiaca", "detalle" }, "id=?", new string[] { PaymentRecord.id.ToString() }, null, null, null, null);

            if (cursor!=null) {
                if (cursor.MoveToFirst()) {
                    // update the row
                    db.Update("PaymentRecord", vals, "id=?", new String[] { cursor.GetString(0) });
                }

                cursor.Close();
            }

        }

        //Delete Existing contact
        public void DeletePaymentRecord(string PaymentRecordId) {
            if (PaymentRecordId==null) {
                return;
            }

            //Obtain writable database
            SQLiteDatabase db = this.WritableDatabase;

            ICursor cursor = db.Query("PaymentRecord",
                    new String[] { "id", "idPersona", "identificacion", "peso", "altura", "presionArterial", "frecuenciaCardiaca", "detalle" }, "id=?", new string[] { PaymentRecordId }, null, null, null, null);

            if (cursor!=null) {
                if (cursor.MoveToFirst()) {
                    // update the row
                    db.Delete("PaymentRecord", "id=?", new String[] { cursor.GetString(0) });
                }

                cursor.Close();
            }
        }  */
    }
}