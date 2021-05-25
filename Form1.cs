using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid;
using System.Globalization;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.ListView;
using Syncfusion.Windows.Forms.Tools;
using System.Collections;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Helpers;
using Syncfusion.WinForms.DataGrid.Interactivity;

namespace ComboBoxColumn
{
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            sfDataGrid.AutoGenerateColumns = false;
            sfDataGrid.DataSource = new CountryInfoRepository().OrderDetails;
            GridSettings();
        }

        private void GridSettings()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };


            sfDataGrid.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ProductName", HeaderText = "Product Name" });
            sfDataGrid.Columns.Add(new GridNumericColumn() { MappingName = "NoOfOrders", HeaderText = "No Of Orders", NumberFormatInfo = nfi });

            this.sfDataGrid.CellRenderers.Add("DropDownDataGrid", new GridDropDownDataGridCellRenderer(this.sfDataGrid));

            sfDataGrid.Columns.Add(new GridDropDownDataGridColumn() { MappingName = "ShipCityID", HeaderText = "Ship City", DataSource = new CountryInfoRepository().Cities });

            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ShipCountry", HeaderText = "Ship Country" });

        }

        #endregion

    }

    public class GridDropDownDataGridColumn : GridColumn
    {

        public GridDropDownDataGridColumn()
        {
            SetCellType("DropDownDataGrid");
        }

        public IEnumerable DataSource { get; set; }
    }

    public class GridDropDownDataGridCellRenderer : GridVirtualizingCellRendererBase<ComboDropDown>
    {
        SfDataGrid DataGrid { get; set; }
        public GridDropDownDataGridCellRenderer(SfDataGrid dataGrid)
        {
            DataGrid = dataGrid;
        }
        protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {
            base.OnRender(paint, cellRect, cellValue, style, column, rowColumnIndex);
        }

        

        protected override void OnInitializeEditElement(DataColumnBase column, RowColumnIndex rowColumnIndex, ComboDropDown uiElement)
        {
            Rectangle editorRectangle = GetEditorUIElementBounds();
            uiElement.Size = editorRectangle.Size;
            uiElement.Location = editorRectangle.Location;
            uiElement.DropDownWidth = 200;

            SfDataGrid dropDownDataGrid = new SfDataGrid()
            {
                DataSource = (column.GridColumn as GridDropDownDataGridColumn).DataSource,
            };

            uiElement.PopupControl = dropDownDataGrid;
            uiElement.DropDownStyle = ComboBoxStyle.DropDownList;

            this.TableControl.Controls.Add(uiElement);
            uiElement.Focus();

            base.OnInitializeEditElement(column, rowColumnIndex, uiElement);

            dropDownDataGrid.SelectionChanged += DropDownDataGrid_SelectionChanged;


        }

        private void DropDownDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataGrid.View.GetPropertyAccessProvider().SetValue(this.DataGrid.SelectedItem, this.DataGrid.CurrentCell.Column.MappingName, (e.AddedItems[0] as ShipCityDetails).ShipCityID);
            (this.DataGrid.CurrentCell.CellRenderer.CurrentCellRendererElement as ComboDropDown).Text = (e.AddedItems[0] as ShipCityDetails).ShipCityID.ToString();
            (this.DataGrid.CurrentCell.CellRenderer.CurrentCellRendererElement as ComboDropDown).DroppedDown = false;
        }
    }
}