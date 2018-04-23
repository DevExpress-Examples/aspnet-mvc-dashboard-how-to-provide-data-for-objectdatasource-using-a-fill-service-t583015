using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web.Routing;

public class DashboardConfig {
    public static void RegisterService(RouteCollection routes) {
        routes.MapDashboardRoute();

        DashboardConfigurator.Default.SetDashboardStorage(new DashboardFileStorage(@"~/App_Data/"));
        var dataSourceStorage = new DataSourceInMemoryStorage();
        DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage);
        DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source", typeof(SalesPersonData));
        objDataSource.DataSource = typeof(SalesPersonData);
        dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml());

        DashboardConfigurator.Default.SetObjectDataSourceCustomFillService(new CustomObjectDataSourceCustomFillService());
    }
}

public class SalesPersonData {
    public string SalesPerson { get; set; }
    public int Quantity { get; set; }
}

public class CustomObjectDataSourceCustomFillService : IObjectDataSourceCustomFillService {
    public object GetData(DashboardObjectDataSource dataSource, ObjectDataSourceFillParameters fillParameters) {
        if (fillParameters.DataFields == null || fillParameters.DataFields.Length == 0) {
            return null;
        }

        List<SalesPersonData> data = DataGenerator.CreateSourceData();

        DataTable table = new DataTable();
        foreach(string field in fillParameters.DataFields) {
            table.Columns.Add(field);
        }
        for (int i = 0; i < data.Count; i++) {
            object[] row = new object[fillParameters.DataFields.Length];
            for (int j = 0; j < fillParameters.DataFields.Length; j++) {
                row[j] = GetPropertyValue(data[i], fillParameters.DataFields[j]);
            }
            table.Rows.Add(row);
        }
        return table.DefaultView;
    }
    object GetPropertyValue(SalesPersonData obj, string propName) {
        return propName == "SalesPerson" ? (object)obj.SalesPerson : (object)obj.Quantity;
    }
}

public static class DataGenerator {
    public static List<SalesPersonData> CreateSourceData() {
        List<SalesPersonData> data = new List<SalesPersonData>();
        string[] salesPersons = { "Andrew Fuller", "Michael Suyama",
                                    "Robert King", "Nancy Davolio",
                                    "Margaret Peacock", "Laura Callahan",
                                    "Steven Buchanan", "Janet Leverling" };

        for (int i = 0; i < 100; i++) {
            SalesPersonData record = new SalesPersonData();
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            record.SalesPerson = salesPersons[new Random(seed).Next(0, salesPersons.Length)];
            record.Quantity = new Random(seed).Next(0, 100);
            data.Add(record);
            Thread.Sleep(3);
        }
        return data;
    }
}