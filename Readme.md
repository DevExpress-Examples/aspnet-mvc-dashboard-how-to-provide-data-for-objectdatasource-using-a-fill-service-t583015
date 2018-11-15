<!-- default file list -->
*Files to look at*:

* [DashboardConfig.cs](./CS/MVCxDashboard_CustomFillService/App_Start/DashboardConfig.cs) (VB: [DashboardConfig.vb](./VB/MVCxDashboard_CustomFillService/App_Start/DashboardConfig.vb))
* [FilterConfig.cs](./CS/MVCxDashboard_CustomFillService/App_Start/FilterConfig.cs) (VB: [FilterConfig.vb](./VB/MVCxDashboard_CustomFillService/App_Start/FilterConfig.vb))
* [RouteConfig.cs](./CS/MVCxDashboard_CustomFillService/App_Start/RouteConfig.cs) (VB: [RouteConfig.vb](./VB/MVCxDashboard_CustomFillService/App_Start/RouteConfig.vb))
* [HomeController.cs](./CS/MVCxDashboard_CustomFillService/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/MVCxDashboard_CustomFillService/Controllers/HomeController.vb))
* [Global.asax.cs](./CS/MVCxDashboard_CustomFillService/Global.asax.cs) (VB: [Global.asax.vb](./VB/MVCxDashboard_CustomFillService/Global.asax.vb))
<!-- default file list end -->
# ASP.NET MVC Dashboard - How to provide data for ObjectDataSource using a fill service


This example shows how to bind the <a href="https://documentation.devexpress.com/#Dashboard/CustomDocument16977">ASP.NET MVC Dashboard extension</a> to the <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardCommonDashboardObjectDataSourcetopic">Object Data Source</a> and supply it with data using a custom fill service by implementing a <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.IObjectDataSourceCustomFillService.class">IObjectDataSourceCustomFillService</a> interface. In this example, the <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.ObjectDataSourceFillParameters.DataFields.property">ObjectDataSourceFillParameters.DataFields</a> parameter is used to load data only for required fields.

<br/>


