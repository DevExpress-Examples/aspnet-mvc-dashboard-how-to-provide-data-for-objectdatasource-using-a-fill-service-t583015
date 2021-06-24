<!-- default file list -->
*Files to look at*:

* [DashboardConfig.cs](./CS/MVCxDashboard_CustomFillService/App_Start/DashboardConfig.cs) (VB: [DashboardConfig.vb](./VB/MVCxDashboard_CustomFillService/App_Start/DashboardConfig.vb))
* [FilterConfig.cs](./CS/MVCxDashboard_CustomFillService/App_Start/FilterConfig.cs) (VB: [FilterConfig.vb](./VB/MVCxDashboard_CustomFillService/App_Start/FilterConfig.vb))
* [RouteConfig.cs](./CS/MVCxDashboard_CustomFillService/App_Start/RouteConfig.cs) (VB: [RouteConfig.vb](./VB/MVCxDashboard_CustomFillService/App_Start/RouteConfig.vb))
* [HomeController.cs](./CS/MVCxDashboard_CustomFillService/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/MVCxDashboard_CustomFillService/Controllers/HomeController.vb))
* [Global.asax.cs](./CS/MVCxDashboard_CustomFillService/Global.asax.cs) (VB: [Global.asax.vb](./VB/MVCxDashboard_CustomFillService/Global.asax.vb))
<!-- default file list end -->
# Dashboard for MVC - How to provide data for ObjectDataSource using a fill service

This example shows how to bind the [ASP.NET MVC Dashboard extension](https://docs.devexpress.com/Dashboard/16977/web-dashboard/aspnet-mvc-dashboard-extension) to the [Object Data Source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardObjectDataSource) and supply it with data using a custom fill service by implementing an [IObjectDataSourceCustomFillService](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.IObjectDataSourceCustomFillService) interface. In this example, the [ObjectDataSourceFillParameters.DataFields](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.ObjectDataSourceFillParameters.DataFields) parameter is used to load data only for required fields.

## Documentation

- [Object Data Source](https://docs.devexpress.com/Dashboard/401435/web-dashboard/dashboard-backend/register-default-data-sources-for-the-aspnet-mvc-framework/object-data-source)

## More Examples

- [ASP.NET MVC Dashboard - How to provide data to ObjectDataSource using DataLoading](https://github.com/DevExpress-Examples/aspnet-mvc-dashboard-how-to-provide-data-to-objectdatasource-using-dataloading-t529121)
