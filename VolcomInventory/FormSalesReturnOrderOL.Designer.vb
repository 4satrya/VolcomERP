<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnOrderOL
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
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCSalesReturnOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOLStoreNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTCROR = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRORList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPPendingList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPending = New DevExpress.XtraGrid.GridControl()
        Me.GVPending = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCROR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCROR.SuspendLayout()
        Me.XTPRORList.SuspendLayout()
        Me.XTPPendingList.SuspendLayout()
        CType(Me.GCPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(690, 39)
        Me.GCFilter.TabIndex = 6
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(317, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'GCSalesReturnOrder
        '
        Me.GCSalesReturnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnOrder.Location = New System.Drawing.Point(0, 39)
        Me.GCSalesReturnOrder.MainView = Me.GVSalesReturnOrder
        Me.GCSalesReturnOrder.Name = "GCSalesReturnOrder"
        Me.GCSalesReturnOrder.Size = New System.Drawing.Size(690, 361)
        Me.GCSalesReturnOrder.TabIndex = 7
        Me.GCSalesReturnOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnOrder, Me.GridView2})
        '
        'GVSalesReturnOrder
        '
        Me.GVSalesReturnOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumnTo, Me.GridColumnSalesTargetDate, Me.GridColumnEstDate, Me.GridColumnDSalesTargetNote, Me.GridColumnReportStatus, Me.GridColumnPrepareStatus, Me.GridColumnOLStoreNo, Me.GridColumnWH, Me.GridColumnTotal})
        Me.GVSalesReturnOrder.GridControl = Me.GCSalesReturnOrder
        Me.GVSalesReturnOrder.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", Me.GridColumnTotal, "{0:n0}")})
        Me.GVSalesReturnOrder.Name = "GVSalesReturnOrder"
        Me.GVSalesReturnOrder.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturnOrder.OptionsFind.AlwaysVisible = True
        Me.GVSalesReturnOrder.OptionsView.ShowFooter = True
        Me.GVSalesReturnOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_return_order_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        Me.GridColumnSalesTargetNumb.Width = 125
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "Store"
        Me.GridColumnTo.FieldName = "store"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 2
        Me.GridColumnTo.Width = 192
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.FieldName = "sales_return_order_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        Me.GridColumnSalesTargetDate.Visible = True
        Me.GridColumnSalesTargetDate.VisibleIndex = 4
        Me.GridColumnSalesTargetDate.Width = 178
        '
        'GridColumnEstDate
        '
        Me.GridColumnEstDate.Caption = "Estimate Return"
        Me.GridColumnEstDate.FieldName = "sales_return_order_est_date"
        Me.GridColumnEstDate.Name = "GridColumnEstDate"
        Me.GridColumnEstDate.Visible = True
        Me.GridColumnEstDate.VisibleIndex = 5
        Me.GridColumnEstDate.Width = 178
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_return_order_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        Me.GridColumnDSalesTargetNote.Visible = True
        Me.GridColumnDSalesTargetNote.VisibleIndex = 7
        Me.GridColumnDSalesTargetNote.Width = 183
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 8
        Me.GridColumnReportStatus.Width = 183
        '
        'GridColumnPrepareStatus
        '
        Me.GridColumnPrepareStatus.Caption = "WH Status"
        Me.GridColumnPrepareStatus.FieldName = "prepare_status"
        Me.GridColumnPrepareStatus.Name = "GridColumnPrepareStatus"
        Me.GridColumnPrepareStatus.Visible = True
        Me.GridColumnPrepareStatus.VisibleIndex = 9
        Me.GridColumnPrepareStatus.Width = 212
        '
        'GridColumnOLStoreNo
        '
        Me.GridColumnOLStoreNo.Caption = "OL Store Order#"
        Me.GridColumnOLStoreNo.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnOLStoreNo.Name = "GridColumnOLStoreNo"
        Me.GridColumnOLStoreNo.Visible = True
        Me.GridColumnOLStoreNo.VisibleIndex = 1
        Me.GridColumnOLStoreNo.Width = 150
        '
        'GridColumnWH
        '
        Me.GridColumnWH.Caption = "Warehouse"
        Me.GridColumnWH.FieldName = "wh"
        Me.GridColumnWH.Name = "GridColumnWH"
        Me.GridColumnWH.Visible = True
        Me.GridColumnWH.VisibleIndex = 3
        Me.GridColumnWH.Width = 178
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total Qty"
        Me.GridColumnTotal.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total_qty"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:n0}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 6
        Me.GridColumnTotal.Width = 53
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesReturnOrder
        Me.GridView2.Name = "GridView2"
        '
        'XTCROR
        '
        Me.XTCROR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCROR.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCROR.Location = New System.Drawing.Point(0, 0)
        Me.XTCROR.Name = "XTCROR"
        Me.XTCROR.SelectedTabPage = Me.XTPRORList
        Me.XTCROR.Size = New System.Drawing.Size(696, 428)
        Me.XTCROR.TabIndex = 8
        Me.XTCROR.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRORList, Me.XTPPendingList})
        '
        'XTPRORList
        '
        Me.XTPRORList.Controls.Add(Me.GCSalesReturnOrder)
        Me.XTPRORList.Controls.Add(Me.GCFilter)
        Me.XTPRORList.Name = "XTPRORList"
        Me.XTPRORList.Size = New System.Drawing.Size(690, 400)
        Me.XTPRORList.Text = "ROR List"
        '
        'XTPPendingList
        '
        Me.XTPPendingList.Controls.Add(Me.GCPending)
        Me.XTPPendingList.Name = "XTPPendingList"
        Me.XTPPendingList.Size = New System.Drawing.Size(690, 400)
        Me.XTPPendingList.Text = "Pending List"
        '
        'GCPending
        '
        Me.GCPending.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPending.Location = New System.Drawing.Point(0, 0)
        Me.GCPending.MainView = Me.GVPending
        Me.GCPending.Name = "GCPending"
        Me.GCPending.Size = New System.Drawing.Size(690, 400)
        Me.GCPending.TabIndex = 1
        Me.GCPending.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPending})
        '
        'GVPending
        '
        Me.GVPending.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnsales_order_ol_shop_number, Me.GridColumncustomer_name, Me.GridColumncomp_number, Me.GridColumncomp_name})
        Me.GVPending.GridControl = Me.GCPending
        Me.GVPending.Name = "GVPending"
        Me.GVPending.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPending.OptionsBehavior.ReadOnly = True
        Me.GVPending.OptionsFind.AlwaysVisible = True
        Me.GVPending.OptionsView.ShowGroupPanel = False
        '
        'GridColumnsales_order_ol_shop_number
        '
        Me.GridColumnsales_order_ol_shop_number.Caption = "Order Number"
        Me.GridColumnsales_order_ol_shop_number.FieldName = "order_number"
        Me.GridColumnsales_order_ol_shop_number.Name = "GridColumnsales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Visible = True
        Me.GridColumnsales_order_ol_shop_number.VisibleIndex = 0
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 1
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 2
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Account Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 3
        '
        'FormSalesReturnOrderOL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 428)
        Me.Controls.Add(Me.XTCROR)
        Me.Name = "FormSalesReturnOrderOL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Order Online Store"
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCROR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCROR.ResumeLayout(False)
        Me.XTPRORList.ResumeLayout(False)
        Me.XTPPendingList.ResumeLayout(False)
        CType(Me.GCPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSalesReturnOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnOLStoreNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCROR As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRORList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPendingList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPending As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPending As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
