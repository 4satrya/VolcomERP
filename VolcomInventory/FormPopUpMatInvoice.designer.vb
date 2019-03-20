<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMatInvoice
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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.GCProdInvoice = New DevExpress.XtraGrid.GridControl()
        Me.GVProdInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdInv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnInvNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDatex = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWONo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl()
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPRDetSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQtyRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.COlUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdMatDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPlMRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCProdInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 415)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 42)
        Me.PanelControl2.TabIndex = 30
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(663, 10)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(739, 10)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Choose"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCListPurchase)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 415)
        Me.SplitContainerControl1.SplitterPosition = 225
        Me.SplitContainerControl1.TabIndex = 29
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCProdInvoice)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 225)
        Me.GroupGeneral.TabIndex = 15
        Me.GroupGeneral.Text = "Invoice"
        '
        'GCProdInvoice
        '
        Me.GCProdInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdInvoice.Location = New System.Drawing.Point(2, 20)
        Me.GCProdInvoice.MainView = Me.GVProdInvoice
        Me.GCProdInvoice.Name = "GCProdInvoice"
        Me.GCProdInvoice.Size = New System.Drawing.Size(810, 203)
        Me.GCProdInvoice.TabIndex = 2
        Me.GCProdInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdInvoice})
        '
        'GVProdInvoice
        '
        Me.GVProdInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdInv, Me.GridColumnInvNo, Me.GridColumnCompTo, Me.GridColumnDatex, Me.GridColumnDueDate, Me.GridColumnIdCompTo, Me.GridColumnIdWO, Me.GridColumnWONo, Me.GridColumnDesign, Me.GridColumnIdReportStatus, Me.GridColumnReportStatus, Me.GridColumnPONO, Me.GridColumnIdCurrency})
        Me.GVProdInvoice.GridControl = Me.GCProdInvoice
        Me.GVProdInvoice.Name = "GVProdInvoice"
        Me.GVProdInvoice.OptionsBehavior.Editable = False
        Me.GVProdInvoice.OptionsFind.AlwaysVisible = True
        Me.GVProdInvoice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdInv
        '
        Me.GridColumnIdInv.Caption = "Id Invoice"
        Me.GridColumnIdInv.FieldName = "id_inv_pl_mrs"
        Me.GridColumnIdInv.Name = "GridColumnIdInv"
        '
        'GridColumnInvNo
        '
        Me.GridColumnInvNo.Caption = "Number"
        Me.GridColumnInvNo.FieldName = "inv_pl_mrs_number"
        Me.GridColumnInvNo.Name = "GridColumnInvNo"
        Me.GridColumnInvNo.Visible = True
        Me.GridColumnInvNo.VisibleIndex = 0
        '
        'GridColumnCompTo
        '
        Me.GridColumnCompTo.Caption = "To"
        Me.GridColumnCompTo.FieldName = "comp_name_to"
        Me.GridColumnCompTo.Name = "GridColumnCompTo"
        Me.GridColumnCompTo.Visible = True
        Me.GridColumnCompTo.VisibleIndex = 4
        '
        'GridColumnDatex
        '
        Me.GridColumnDatex.Caption = "Date"
        Me.GridColumnDatex.FieldName = "inv_pl_mrs_date"
        Me.GridColumnDatex.Name = "GridColumnDatex"
        Me.GridColumnDatex.Visible = True
        Me.GridColumnDatex.VisibleIndex = 5
        '
        'GridColumnDueDate
        '
        Me.GridColumnDueDate.Caption = "Due Date"
        Me.GridColumnDueDate.FieldName = "inv_pl_mrs_top"
        Me.GridColumnDueDate.Name = "GridColumnDueDate"
        Me.GridColumnDueDate.Visible = True
        Me.GridColumnDueDate.VisibleIndex = 6
        '
        'GridColumnIdCompTo
        '
        Me.GridColumnIdCompTo.Caption = "Id Comp To"
        Me.GridColumnIdCompTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompTo.Name = "GridColumnIdCompTo"
        '
        'GridColumnIdWO
        '
        Me.GridColumnIdWO.Caption = "Id WO"
        Me.GridColumnIdWO.FieldName = "id_prod_order_wo"
        Me.GridColumnIdWO.Name = "GridColumnIdWO"
        '
        'GridColumnWONo
        '
        Me.GridColumnWONo.Caption = "PL Number"
        Me.GridColumnWONo.FieldName = "prod_order_wo_number"
        Me.GridColumnWONo.Name = "GridColumnWONo"
        Me.GridColumnWONo.Visible = True
        Me.GridColumnWONo.VisibleIndex = 1
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 3
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 7
        '
        'GridColumnPONO
        '
        Me.GridColumnPONO.Caption = "PDO Number"
        Me.GridColumnPONO.FieldName = "prod_order_number"
        Me.GridColumnPONO.Name = "GridColumnPONO"
        Me.GridColumnPONO.Visible = True
        Me.GridColumnPONO.VisibleIndex = 2
        '
        'GridColumnIdCurrency
        '
        Me.GridColumnIdCurrency.Caption = "Id Currency"
        Me.GridColumnIdCurrency.FieldName = "id_currency"
        Me.GridColumnIdCurrency.Name = "GridColumnIdCurrency"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(814, 185)
        Me.GCListPurchase.TabIndex = 2
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase, Me.GridView1})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPRDetSample, Me.ColIdPurcDet, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQtyRec, Me.COlUOM, Me.ColNote, Me.GridColumnTotal, Me.GridColumnIdMatDet, Me.GridColumnPLNumber, Me.GridColumnIdPlMRS})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListPurchase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPRDetSample
        '
        Me.ColIdPRDetSample.Caption = "ID Rec Det"
        Me.ColIdPRDetSample.FieldName = "id_pl_mrs_det"
        Me.ColIdPRDetSample.Name = "ColIdPRDetSample"
        Me.ColIdPRDetSample.OptionsColumn.AllowEdit = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Detail"
        Me.ColIdPurcDet.FieldName = "id_inv_pl_mrs_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        Me.ColIdPurcDet.OptionsColumn.AllowEdit = False
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 28
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 2
        Me.ColCode.Width = 79
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 3
        Me.ColName.Width = 165
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 4
        Me.ColPrice.Width = 110
        '
        'ColQtyRec
        '
        Me.ColQtyRec.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyRec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyRec.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyRec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyRec.Caption = "Qty"
        Me.ColQtyRec.DisplayFormat.FormatString = "N2"
        Me.ColQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQtyRec.FieldName = "qty"
        Me.ColQtyRec.Name = "ColQtyRec"
        Me.ColQtyRec.OptionsColumn.AllowEdit = False
        Me.ColQtyRec.Visible = True
        Me.ColQtyRec.VisibleIndex = 5
        Me.ColQtyRec.Width = 38
        '
        'COlUOM
        '
        Me.COlUOM.AppearanceCell.Options.UseTextOptions = True
        Me.COlUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.COlUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.COlUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.COlUOM.Caption = "UOM"
        Me.COlUOM.FieldName = "uom"
        Me.COlUOM.Name = "COlUOM"
        Me.COlUOM.OptionsColumn.AllowEdit = False
        Me.COlUOM.Visible = True
        Me.COlUOM.VisibleIndex = 6
        Me.COlUOM.Width = 51
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        Me.ColNote.Width = 66
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total_price"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.OptionsColumn.AllowEdit = False
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", "{0:N2}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 8
        '
        'GridColumnIdMatDet
        '
        Me.GridColumnIdMatDet.Caption = "Id Mat"
        Me.GridColumnIdMatDet.FieldName = "id_mat_det"
        Me.GridColumnIdMatDet.Name = "GridColumnIdMatDet"
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "PL Number"
        Me.GridColumnPLNumber.FieldName = "pl_mrs_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.OptionsColumn.ReadOnly = True
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 1
        '
        'GridColumnIdPlMRS
        '
        Me.GridColumnIdPlMRS.Caption = "Id PL"
        Me.GridColumnIdPlMRS.FieldName = "id_pl_mrs"
        Me.GridColumnIdPlMRS.Name = "GridColumnIdPlMRS"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCListPurchase
        Me.GridView1.Name = "GridView1"
        '
        'FormPopUpMatInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMatInvoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Invoice"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCProdInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProdInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdInv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnInvNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDatex As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWONo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPRDetSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents COlUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMatDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPlMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdCurrency As DevExpress.XtraGrid.Columns.GridColumn
End Class
