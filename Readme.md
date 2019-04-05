<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/SilverlightApplication1/MainPage.xaml) (VB: [MainPage.xaml](./VB/SilverlightApplication1/MainPage.xaml))
* [MainPage.xaml.cs](./CS/SilverlightApplication1/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/SilverlightApplication1/MainPage.xaml.vb))
<!-- default file list end -->
# How to set end-user restrictions


<p>This example demonstrates how to prevent end-users from having appointments within a certain time interval.</p>


<h3>Description</h3>

<p>To implement end-user restrictions, you should do the following: <br /> 1. Handle the <strong>SchedulerControl.AllowAppointmentCreate</strong> event to prevent end-users from creating appointments within a certain time interval; <br /> 2. Handle the <strong>SchedulerControl.AllowAppointmentConflicts</strong> event to prevent an existing appointment from being dragged to a certain time interval.</p>

<br/>


