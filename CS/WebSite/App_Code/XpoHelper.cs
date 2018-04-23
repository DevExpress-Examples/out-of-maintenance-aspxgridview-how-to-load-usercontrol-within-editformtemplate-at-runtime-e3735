using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using MasterDetailWithXPO;

/// <summary>
/// Summary description for XpoHelper
/// </summary>
public static class XpoHelper {
    static XpoHelper () {
        CreateDefaultObjects();
    }

    public static Session GetNewSession () {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork () {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object lockObject = new object();

    static volatile IDataLayer fDataLayer;
    static IDataLayer DataLayer {
        get {
            if (fDataLayer == null) {
                lock (lockObject) {
                    if (fDataLayer == null) {
                        fDataLayer = GetDataLayer();
                    }
                }
            }
            return fDataLayer;
        }
    }

    private static IDataLayer GetDataLayer () {
        XpoDefault.Session = null;

        InMemoryDataStore provider = new InMemoryDataStore();
        // For demo purposes only! Create a ThreadSafeDataLayer in production!
        IDataLayer dl = new SimpleDataLayer(provider);

        return dl;
    }

    private static void CreateDefaultObjects () {
        using (UnitOfWork uow = GetNewUnitOfWork()) {
            Customer c1 = new Customer(uow);
            c1.Name = "Ann";
            Order o1 = new Order(uow);
            o1.Date = DateTime.Today;
            o1.Totals = 10.25m;
            c1.Orders.Add(o1);
            Order o2 = new Order(uow);
            o2.Date = DateTime.Today.AddDays(-2);
            o2.Totals = 7.75m;
            c1.Orders.Add(o2);

            Customer c2 = new Customer(uow);
            c2.Name = "Bill";
            Order o3 = new Order(uow);
            o3.Date = DateTime.Today;
            o3.Totals = 9.98m;
            c2.Orders.Add(o3);

            uow.CommitChanges();
        }
    }
}
