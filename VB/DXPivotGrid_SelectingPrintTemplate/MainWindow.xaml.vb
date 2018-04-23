Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid.Internal
Imports DevExpress.Xpf.Printing

Namespace DXPivotGrid_SelectingPrintTemplate
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
            picotGridControl1.DataSource = _
				New nwindDataSetTableAdapters.SalesPersonTableAdapter().GetData()
        End Sub
        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            PrintHelper.ShowPrintPreview(Me, picotGridControl1)
        End Sub
    End Class
    Public Class CellTemplateSelector
        Inherits DataTemplateSelector
        Public Overrides Function SelectTemplate(ByVal item As Object, _
			ByVal container As DependencyObject) As DataTemplate
            Dim mainWindow As Window = Application.Current.MainWindow
            Dim cell As CellsAreaItem = CType(item, CellsAreaItem)

            ' Calculates the share of a cell value in the Column Grand Total value.
            Dim share As Double = Convert.ToDouble(cell.Value) / Convert.ToDouble(cell.ColumnTotalValue)

            ' Applies the Normal template to the Column Grand Total cells.
            If cell.ColumnValue Is Nothing Then
                Return TryCast(mainWindow.FindResource("NormalCellTemplate"), DataTemplate)
            End If

            ' If the share is too far from 50%, the Highlighted template is selected.
            ' Otherwise, the Normal template is applied to the cell.
            If share > 0.8 OrElse share < 0.2 Then
                Return TryCast(mainWindow.FindResource("HighlightedCellTemplate"), DataTemplate)
            Else
                Return TryCast(mainWindow.FindResource("NormalCellTemplate"), DataTemplate)
            End If
        End Function
    End Class
End Namespace