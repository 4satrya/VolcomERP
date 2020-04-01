<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAllocationHist
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAllocationHist))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumnid_sales_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number_from = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name_from = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number_to = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name_to = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_fg_trf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntrf_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntrf_status = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(689, 0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(95, 44)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 44)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 417)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_order, Me.GridColumnsales_order_number, Me.GridColumnorder_qty, Me.GridColumnorder_date, Me.GridColumnorder_by, Me.GridColumnorder_status, Me.GridColumncomp_number_from, Me.GridColumncomp_name_from, Me.GridColumncomp_number_to, Me.GridColumncomp_name_to, Me.GridColumnid_fg_trf, Me.GridColumntrf_number, Me.GridColumntrf_status})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(594, 0)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(95, 44)
        Me.BtnView.TabIndex = 8901
        Me.BtnView.Text = "View"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(185, 12)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8900
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(41, 12)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8899
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(158, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8898
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8897
        Me.LabelControl3.Text = "From"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.DEUntil)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.DEFrom)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(290, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(304, 44)
        Me.PanelControl2.TabIndex = 8902
        '
        'GridColumnid_sales_order
        '
        Me.GridColumnid_sales_order.Caption = "id_sales_order"
        Me.GridColumnid_sales_order.FieldName = "id_sales_order"
        Me.GridColumnid_sales_order.Name = "GridColumnid_sales_order"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "Order Number"
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        Me.GridColumnsales_order_number.Visible = True
        Me.GridColumnsales_order_number.VisibleIndex = 0
        '
        'GridColumnorder_qty
        '
        Me.GridColumnorder_qty.Caption = "Total Qty"
        Me.GridColumnorder_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnorder_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnorder_qty.FieldName = "order_qty"
        Me.GridColumnorder_qty.Name = "GridColumnorder_qty"
        Me.GridColumnorder_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", "{0:N0}")})
        Me.GridColumnorder_qty.Visible = True
        Me.GridColumnorder_qty.VisibleIndex = 1
        '
        'GridColumnorder_date
        '
        Me.GridColumnorder_date.Caption = "Created Date"
        Me.GridColumnorder_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnorder_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnorder_date.FieldName = "order_date"
        Me.GridColumnorder_date.Name = "GridColumnorder_date"
        Me.GridColumnorder_date.Visible = True
        Me.GridColumnorder_date.VisibleIndex = 2
        '
        'GridColumnorder_by
        '
        Me.GridColumnorder_by.Caption = "Created By"
        Me.GridColumnorder_by.FieldName = "order_by"
        Me.GridColumnorder_by.Name = "GridColumnorder_by"
        Me.GridColumnorder_by.Visible = True
        Me.GridColumnorder_by.VisibleIndex = 3
        '
        'GridColumnorder_status
        '
        Me.GridColumnorder_status.Caption = "Order Status"
        Me.GridColumnorder_status.FieldName = "order_status"
        Me.GridColumnorder_status.Name = "GridColumnorder_status"
        Me.GridColumnorder_status.Visible = True
        Me.GridColumnorder_status.VisibleIndex = 4
        '
        'GridColumncomp_number_from
        '
        Me.GridColumncomp_number_from.Caption = "Account From"
        Me.GridColumncomp_number_from.FieldName = "comp_number_from"
        Me.GridColumncomp_number_from.Name = "GridColumncomp_number_from"
        Me.GridColumncomp_number_from.Visible = True
        Me.GridColumncomp_number_from.VisibleIndex = 5
        '
        'GridColumncomp_name_from
        '
        Me.GridColumncomp_name_from.Caption = "From"
        Me.GridColumncomp_name_from.FieldName = "comp_name_from"
        Me.GridColumncomp_name_from.Name = "GridColumncomp_name_from"
        Me.GridColumncomp_name_from.Visible = True
        Me.GridColumncomp_name_from.VisibleIndex = 6
        '
        'GridColumncomp_number_to
        '
        Me.GridColumncomp_number_to.Caption = "Account To"
        Me.GridColumncomp_number_to.FieldName = "comp_number_to"
        Me.GridColumncomp_number_to.Name = "GridColumncomp_number_to"
        Me.GridColumncomp_number_to.Visible = True
        Me.GridColumncomp_number_to.VisibleIndex = 7
        '
        'GridColumncomp_name_to
        '
        Me.GridColumncomp_name_to.Caption = "To"
        Me.GridColumncomp_name_to.FieldName = "comp_name_to"
        Me.GridColumncomp_name_to.Name = "GridColumncomp_name_to"
        Me.GridColumncomp_name_to.Visible = True
        Me.GridColumncomp_name_to.VisibleIndex = 8
        '
        'GridColumnid_fg_trf
        '
        Me.GridColumnid_fg_trf.Caption = "id_fg_trf"
        Me.GridColumnid_fg_trf.FieldName = "id_fg_trf"
        Me.GridColumnid_fg_trf.Name = "GridColumnid_fg_trf"
        '
        'GridColumntrf_number
        '
        Me.GridColumntrf_number.Caption = "Transfer Number"
        Me.GridColumntrf_number.FieldName = "trf_number"
        Me.GridColumntrf_number.Name = "GridColumntrf_number"
        Me.GridColumntrf_number.Visible = True
        Me.GridColumntrf_number.VisibleIndex = 9
        '
        'GridColumntrf_status
        '
        Me.GridColumntrf_status.Caption = "Transfer Status"
        Me.GridColumntrf_status.FieldName = "trf_status"
        Me.GridColumntrf_status.Name = "GridColumntrf_status"
        Me.GridColumntrf_status.Visible = True
        Me.GridColumntrf_status.VisibleIndex = 10
        '
        'FormAllocationHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormAllocationHist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_sales_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number_from As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name_from As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number_to As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name_to As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_fg_trf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntrf_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntrf_status As DevExpress.XtraGrid.Columns.GridColumn
End Class
