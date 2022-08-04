<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/357658108/22.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T990012)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Dashboard for Blazor WebAssembly - Configuration

This example shows how you can configure the `DxDashboard` component in a Blazor WebAssembly application:

- The combo box changes the [DxDashboard.DashboardId](https://docs.devexpress.com/Dashboard/DevExpress.DashboardBlazor.DxDashboard.DashboardId?v=21.1) property that specifies the currently displayed dashboard.
- The button switches the [DxDashboard.WorkingMode](https://docs.devexpress.com/Dashboard/DevExpress.DashboardBlazor.DxDashboard.WorkingMode?v=21.1) property that specifies whether `DxDashboard` works in Designer or Viewer mode. 
- The [DxBackendOptions.RequestHttpHeaders](https://docs.devexpress.com/Dashboard/DevExpress.DashboardBlazor.DxBackendOptions.RequestHttpHeaders?v=21.1) property adds the `Authorization` header.
- The [Data Inspector](https://docs.devexpress.com/Dashboard/DevExpress.DashboardBlazor.DxDataInspector?v=21.1) is enabled and displays raw and aggregated data.

## Files to Look At

* [Dashboard.razor](./CS/BlazorDashboardApp/BlazorDashboardApp.Client/Pages/Dashboard.razor)

## Documentation

- [DxDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardBlazor.DxDashboard?v=21.1)
- [Create a Blazor WebAssembly Dashboard Application](https://docs.devexpress.com/Dashboard/401892?v=21.1)

## More Examples

- [Get Started - Dashboard Component in Blazor WebAssembly Application](https://github.com/DevExpress-Examples/dashboard-blazor-webassembly-app)
- [Dashboard Blazor WebAssembly App - JavaScript Customization](https://github.com/DevExpress-Examples/dashboard-blazor-webassembly-js-customization)
- [Dashboard Blazor Server App - Configuration](https://github.com/DevExpress-Examples/dashboard-blazor-server-configuration)
