using System;   

namespace PersonalPaymentsAndroid {
    class PaymentRecord {   
        public int id {
            get; set;
        }

        public int idUser {
            get; set;
        }
                                                        
        public string detail {
            get; set;
        }                                              
        public double amount {
            get; set;
        }                                   
        public bool recurrence {
            get; set;
        }                                      
        public int recurrenciaTypeId {
            get; set;
        }                                                    
        public DateTime paymentDate {
            get; set;
        }                                     
        public int providerId {
            get; set;
        }                                             
        public int expenseCategoryId {
            get; set;
        }

        public DateTime Now {
            get;
        }
        public static explicit operator PaymentRecord(Java.Lang.Object v) {
            throw new NotImplementedException();
        }
    }
}