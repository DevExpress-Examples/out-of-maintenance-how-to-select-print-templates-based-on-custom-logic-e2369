<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DXPivotGrid_SelectingPrintTemplate/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/DXPivotGrid_SelectingPrintTemplate/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/DXPivotGrid_SelectingPrintTemplate/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXPivotGrid_SelectingPrintTemplate/MainWindow.xaml.vb))
<!-- default file list end -->
# How to select print templates based on custom logic


<p>The following example demonstrates how to select print templates for the DXPivotGrid elements based on custom logic.</p><p>In this example, the template used to print data cells is selected based on the share of the data cell value in the Column Grand Total value. If this share is bigger than 80% or less than 20%, the template selector applies a specific template that highlights the cell value and prints the warning sign near it.</p>

<br/>


