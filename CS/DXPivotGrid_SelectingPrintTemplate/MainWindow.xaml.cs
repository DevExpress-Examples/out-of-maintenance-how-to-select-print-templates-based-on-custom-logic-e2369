using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid;
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
            CellElementData cell = (CellElementData)item;
            // Calculate the ratio of the cell value to the grand total.
            double share = Convert.ToDouble(cell.Value) / Convert.ToDouble(cell.ColumnTotalValue);

            // Apply the Normal template to the Column Grand Total cells.
            if (cell.ColumnValue == null)
                return mainWindow.FindResource("NormalCellTemplate") as DataTemplate;
            
            // If the ratio is far from 0.5, use the Highlighted template.
            // Otherwise, use the Normal template.
            if (share > 0.8 || share < 0.2)
                return mainWindow.FindResource("HighlightedCellTemplate") as DataTemplate;
            else
                return mainWindow.FindResource("NormalCellTemplate") as DataTemplate;
        }
    }
}
