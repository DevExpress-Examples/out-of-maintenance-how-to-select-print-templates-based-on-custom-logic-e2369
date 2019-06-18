Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.Xpf.Printing

Namespace DXPivotGrid_SelectingPrintTemplate
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			picotGridControl1.DataSource = (New nwindDataSetTableAdapters.SalesPersonTableAdapter()).GetData()
		End Sub
		Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			PrintHelper.ShowPrintPreview(Me, picotGridControl1)
		End Sub
	End Class
	Public Class CellTemplateSelector
		Inherits DataTemplateSelector

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
'INSTANT VB NOTE: The variable mainWindow was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
			Dim mainWindow_Renamed As Window = Application.Current.MainWindow
			Dim cell As CellElementData = DirectCast(item, CellElementData)
			' Calculates the share of a cell value in the Column Grand Total value.
			Dim share As Double = Convert.ToDouble(cell.Value) / Convert.ToDouble(cell.ColumnTotalValue)

			' Applies the Normal template to the Column Grand Total cells.
			If cell.ColumnValue Is Nothing Then
				Return TryCast(mainWindow_Renamed.FindResource("NormalCellTemplate"), DataTemplate)
			End If

			' If the share is too far from 50%, the Highlighted template is selected.
			' Otherwise, the Normal template is applied to the cell.
			If share > 0.8 OrElse share < 0.2 Then
				Return TryCast(mainWindow_Renamed.FindResource("HighlightedCellTemplate"), DataTemplate)
			Else
				Return TryCast(mainWindow_Renamed.FindResource("NormalCellTemplate"), DataTemplate)
			End If
		End Function
	End Class
End Namespace
