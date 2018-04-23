using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;

namespace MasterDetailWithXPO {
    public class Customer: XPObject {
        public Customer(Session session)
            : base(session) { }

        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }

        [Association("Customer-Orders")]
        public XPCollection<Order> Orders {
            get { return GetCollection<Order>("Orders"); }
        }
    }
    public class Order: XPObject {
        public Order(Session session)
            : base(session) { }

        private Customer _Customer;
        [Association("Customer-Orders")]
        public Customer Customer {
            get { return _Customer; }
            set { SetPropertyValue("Customer", ref _Customer, value); }
        }
        private DateTime _Date;
        public DateTime Date {
            get { return _Date; }
            set { SetPropertyValue("Date", ref _Date, value); }
        }
        private decimal _Totals;
        public decimal Totals {
            get { return _Totals; }
            set { SetPropertyValue("Totals", ref _Totals, value); }
        }
        
    }
}
