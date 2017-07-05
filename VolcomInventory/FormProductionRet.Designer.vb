<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionRet
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
        Me.XTCReturn = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRetOut = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetOut = New DevExpress.XtraGrid.GridControl()
        Me.GVRetOut = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdSampleRetOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRetOutNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPSONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatusOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPRetIn = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetIn = New DevExpress.XtraGrid.GridControl()
        Me.GVRetIn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatusIn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCReturn.SuspendLayout()
        Me.XTPRetOut.SuspendLayout()
        CType(Me.GCRetOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPRetIn.SuspendLayout()
        CType(Me.GCRetIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCReturn
        '
        Me.XTCReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCReturn.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCReturn.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCReturn.Location = New System.Drawing.Point(0, 0)
        Me.XTCReturn.LookAndFeel.SkinName = "Xmas 2008 Blue"
        Me.XTCReturn.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCReturn.Name = "XTCReturn"
        Me.XTCReturn.SelectedTabPage = Me.XTPRetOut
        Me.XTCReturn.Size = New System.Drawing.Size(803, 424)
        Me.XTCReturn.TabIndex = 1
        Me.XTCReturn.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRetOut, Me.XTPRetIn})
        '
        'XTPRetOut
        '
        Me.XTPRetOut.Controls.Add(Me.GCRetOut)
        Me.XTPRetOut.Name = "XTPRetOut"
        Me.XTPRetOut.Size = New System.Drawing.Size(732, 419)
        Me.XTPRetOut.Text = "Return Out"
        '
        'GCRetOut
        '
        Me.GCRetOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetOut.Location = New System.Drawing.Point(0, 0)
        Me.GCRetOut.MainView = Me.GVRetOut
        Me.GCRetOut.Name = "GCRetOut"
        Me.GCRetOut.Size = New System.Drawing.Size(732, 419)
        Me.GCRetOut.TabIndex = 3
        Me.GCRetOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetOut})
        '
        'GVRetOut
        '
        Me.GVRetOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleRetOut, Me.ColSeason, Me.ColRetOutNumber, Me.ColShipFrom, Me.ColShipTo, Me.ColRecDate, Me.ColDueDate, Me.ColPSONumber, Me.GridColumnStatusOut, Me.GridColumn7, Me.GridColumn9, Me.GridColumn10})
        Me.GVRetOut.GridControl = Me.GCRetOut
        Me.GVRetOut.GroupCount = 1
        Me.GVRetOut.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumn10, "{0:n0}")})
        Me.GVRetOut.Name = "GVRetOut"
        Me.GVRetOut.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRetOut.OptionsBehavior.Editable = False
        Me.GVRetOut.OptionsView.ShowFooter = True
        Me.GVRetOut.OptionsView.ShowGroupPanel = False
        Me.GVRetOut.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdSampleRetOut, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdSampleRetOut
        '
        Me.ColIdSampleRetOut.Caption = "ID Sample Ret Out"
        Me.ColIdSampleRetOut.FieldName = "id_prod_order_ret_out"
        Me.ColIdSampleRetOut.Name = "ColIdSampleRetOut"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColRetOutNumber
        '
        Me.ColRetOutNumber.Caption = "Number"
        Me.ColRetOutNumber.FieldName = "prod_order_ret_out_number"
        Me.ColRetOutNumber.Name = "ColRetOutNumber"
        Me.ColRetOutNumber.Visible = True
        Me.ColRetOutNumber.VisibleIndex = 0
        Me.ColRetOutNumber.Width = 78
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "From"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 4
        Me.ColShipFrom.Width = 139
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 5
        Me.ColShipTo.Width = 139
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Create Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "prod_order_ret_out_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 7
        Me.ColRecDate.Width = 136
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Est. Return In Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "prod_order_ret_out_due_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 8
        Me.ColDueDate.Width = 148
        '
        'ColPSONumber
        '
        Me.ColPSONumber.Caption = "Prod No."
        Me.ColPSONumber.FieldName = "prod_order_number"
        Me.ColPSONumber.Name = "ColPSONumber"
        Me.ColPSONumber.Visible = True
        Me.ColPSONumber.VisibleIndex = 1
        Me.ColPSONumber.Width = 80
        '
        'GridColumnStatusOut
        '
        Me.GridColumnStatusOut.Caption = "Status"
        Me.GridColumnStatusOut.FieldName = "report_status"
        Me.GridColumnStatusOut.Name = "GridColumnStatusOut"
        Me.GridColumnStatusOut.Visible = True
        Me.GridColumnStatusOut.VisibleIndex = 9
        Me.GridColumnStatusOut.Width = 89
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Code"
        Me.GridColumn7.FieldName = "code"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 80
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Name"
        Me.GridColumn9.FieldName = "name"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 139
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Qty"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "qty"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 6
        Me.GridColumn10.Width = 50
        '
        'XTPRetIn
        '
        Me.XTPRetIn.Controls.Add(Me.GCRetIn)
        Me.XTPRetIn.Name = "XTPRetIn"
        Me.XTPRetIn.Size = New System.Drawing.Size(732, 419)
        Me.XTPRetIn.Text = "Return In"
        '
        'GCRetIn
        '
        Me.GCRetIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetIn.Location = New System.Drawing.Point(0, 0)
        Me.GCRetIn.MainView = Me.GVRetIn
        Me.GCRetIn.Name = "GCRetIn"
        Me.GCRetIn.Size = New System.Drawing.Size(732, 419)
        Me.GCRetIn.TabIndex = 4
        Me.GCRetIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetIn})
        '
        'GVRetIn
        '
        Me.GVRetIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn8, Me.GridColumnStatusIn, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GVRetIn.GridControl = Me.GCRetIn
        Me.GVRetIn.GroupCount = 1
        Me.GVRetIn.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumn13, "{0:n0}")})
        Me.GVRetIn.Name = "GVRetIn"
        Me.GVRetIn.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRetIn.OptionsBehavior.Editable = False
        Me.GVRetIn.OptionsView.ShowFooter = True
        Me.GVRetIn.OptionsView.ShowGroupPanel = False
        Me.GVRetIn.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Sample Ret Out"
        Me.GridColumn1.FieldName = "id_prod_order_ret_in"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Season"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.FieldNameSortGroup = "id_season"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Number"
        Me.GridColumn3.FieldName = "prod_order_ret_in_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 91
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "From"
        Me.GridColumn4.FieldName = "comp_from"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 148
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Received By"
        Me.GridColumn5.FieldName = "comp_to"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 148
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Create Date"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "prod_order_ret_in_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 7
        Me.GridColumn6.Width = 164
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Prod No."
        Me.GridColumn8.FieldName = "prod_order_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 93
        '
        'GridColumnStatusIn
        '
        Me.GridColumnStatusIn.Caption = "Status"
        Me.GridColumnStatusIn.FieldName = "report_status"
        Me.GridColumnStatusIn.Name = "GridColumnStatusIn"
        Me.GridColumnStatusIn.Visible = True
        Me.GridColumnStatusIn.VisibleIndex = 8
        Me.GridColumnStatusIn.Width = 93
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Code"
        Me.GridColumn11.FieldName = "code"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        Me.GridColumn11.Width = 99
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Name"
        Me.GridColumn12.FieldName = "name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        Me.GridColumn12.Width = 186
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Qty"
        Me.GridColumn13.DisplayFormat.FormatString = "N0"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "qty"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 6
        Me.GridColumn13.Width = 56
        '
        'FormProductionRet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 424)
        Me.Controls.Add(Me.XTCReturn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionRet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Finished Goods to Vendor"
        CType(Me.XTCReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCReturn.ResumeLayout(False)
        Me.XTPRetOut.ResumeLayout(False)
        CType(Me.GCRetOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPRetIn.ResumeLayout(False)
        CType(Me.GCRetIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCReturn As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRetOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRetOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleRetOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRetOutNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPRetIn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRetIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatusOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatusIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
End Class
