using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid.Internal;
using DevExpress.Xpf.Printing;

namespace DXPivotGrid_SelectingPrintTemplate {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            picotGridControl1.DataSource =
                new nwindDataSetTableAdapters.SalesPersonTableAdapter().GetData();
        }
        private void btnPrint_Click(object sender, RoutedEventArgs e) {
            PrintHelper.ShowPrintPreview(this, picotGridControl1);
        }
    }
    public class CellTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            Window mainWindow = Application.Current.MainWindow;
            CellsAreaItem cell = (CellsAreaItem)item;
            
            // Calculates the share of a cell value in the Column Grand Total value.
            double share = Convert.ToDouble(cell.Value) / Convert.ToDouble(cell.ColumnTotalValue);

            // Applies the Normal template to the Column Grand Total cells.
            if (cell.ColumnValue == null)
                return mainWindow.FindResource("NormalCellTemplate") as DataTemplate;
            
            // If the share is too far from 50%, the Highlighted template is selected.
            // Otherwise, the Normal template is applied to the cell.
            if (share > 0.8 || share < 0.2)
                return mainWindow.FindResource("HighlightedCellTemplate") as DataTemplate;
            else
                return mainWindow.FindResource("NormalCellTemplate") as DataTemplate;
        }
    }
}
