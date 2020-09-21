<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcOrderCloseReceivingList
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
        Me.GCPO = New DevExpress.XtraGrid.GridControl()
        Me.GVPO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecAmo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RPBRec = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEIsCheckPO = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPBRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEIsCheckPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCPO
        '
        Me.GCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPO.Location = New System.Drawing.Point(0, 0)
        Me.GCPO.MainView = Me.GVPO
        Me.GCPO.Name = "GCPO"
        Me.GCPO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEIsCheckPO, Me.RPBRec})
        Me.GCPO.Size = New System.Drawing.Size(784, 561)
        Me.GCPO.TabIndex = 2
        Me.GCPO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPO})
        '
        'GVPO
        '
        Me.GVPO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn1, Me.GridColumn35, Me.GridColumn3, Me.GridColumn2, Me.GridColumnTotPO, Me.GridColumn4, Me.GridColumnRecAmo, Me.GridColumn53, Me.GridColumn54, Me.GridColumn58})
        Me.GVPO.GridControl = Me.GCPO
        Me.GVPO.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_po", Me.GridColumnTotPO, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", Me.GridColumnRecAmo, "{0:N2}")})
        Me.GVPO.Name = "GVPO"
        Me.GVPO.OptionsView.ColumnAutoWidth = False
        Me.GVPO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPO.OptionsView.ShowFooter = True
        Me.GVPO.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID PO"
        Me.GridColumn7.FieldName = "id_purc_order"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PO Number"
        Me.GridColumn1.FieldName = "purc_order_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Vendor Code"
        Me.GridColumn35.FieldName = "comp_number"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Vendor"
        Me.GridColumn3.FieldName = "comp_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumnTotPO
        '
        Me.GridColumnTotPO.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotPO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotPO.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotPO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotPO.Caption = "PO Amount"
        Me.GridColumnTotPO.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotPO.FieldName = "total_po"
        Me.GridColumnTotPO.Name = "GridColumnTotPO"
        Me.GridColumnTotPO.OptionsColumn.AllowEdit = False
        Me.GridColumnTotPO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_po", "{0:N2}")})
        Me.GridColumnTotPO.Visible = True
        Me.GridColumnTotPO.VisibleIndex = 4
        '
        'GridColumnRecAmo
        '
        Me.GridColumnRecAmo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRecAmo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecAmo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRecAmo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecAmo.Caption = "Receive Amount"
        Me.GridColumnRecAmo.DisplayFormat.FormatString = "N2"
        Me.GridColumnRecAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRecAmo.FieldName = "total_rec"
        Me.GridColumnRecAmo.Name = "GridColumnRecAmo"
        Me.GridColumnRecAmo.OptionsColumn.AllowEdit = False
        Me.GridColumnRecAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", "{0:N2}")})
        Me.GridColumnRecAmo.Visible = True
        Me.GridColumnRecAmo.VisibleIndex = 6
        Me.GridColumnRecAmo.Width = 88
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Receive Progress"
        Me.GridColumn53.ColumnEdit = Me.RPBRec
        Me.GridColumn53.FieldName = "rec_progress"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.AllowEdit = False
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 7
        Me.GridColumn53.Width = 93
        '
        'RPBRec
        '
        Me.RPBRec.EndColor = System.Drawing.Color.LawnGreen
        Me.RPBRec.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.RPBRec.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RPBRec.Name = "RPBRec"
        Me.RPBRec.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.RPBRec.ShowTitle = True
        Me.RPBRec.Step = 1
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "Receive Status"
        Me.GridColumn54.FieldName = "rec_status"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.OptionsColumn.AllowEdit = False
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 9
        Me.GridColumn54.Width = 82
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "Est. Receive Date"
        Me.GridColumn58.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn58.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn58.FieldName = "est_date_receive"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.OptionsColumn.AllowEdit = False
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 8
        Me.GridColumn58.Width = 96
        '
        'RICEIsCheckPO
        '
        Me.RICEIsCheckPO.AutoHeight = False
        Me.RICEIsCheckPO.Name = "RICEIsCheckPO"
        Me.RICEIsCheckPO.ValueChecked = "yes"
        Me.RICEIsCheckPO.ValueUnchecked = "no"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "PO Qty"
        Me.GridColumn2.DisplayFormat.FormatString = "N0"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "po_qty"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "po_qty", "{0:N0}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Receive Qty"
        Me.GridColumn4.DisplayFormat.FormatString = "N0"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "rec_qty"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rec_qty", "{0:N0}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        '
        'FormPurcOrderCloseReceivingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCPO)
        Me.Name = "FormPurcOrderCloseReceivingList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order List"
        CType(Me.GCPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPBRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEIsCheckPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCPO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecAmo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RPBRec As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEIsCheckPO As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
