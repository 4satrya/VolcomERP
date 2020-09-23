<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutHistoryDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutHistoryDetail))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnno = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncheckout_id = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncustomer_name = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsettlement_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnpay_type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandPaymentGate = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnpayment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntrans_fee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandERP = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumninvoice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnship_invoice_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumninvoice_amount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncalculate_fee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnother_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnreconcile_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnid_order = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnMark)
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 397)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(771, 50)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnMark
        '
        Me.BtnMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMark.Image = CType(resources.GetObject("BtnMark.Image"), System.Drawing.Image)
        Me.BtnMark.Location = New System.Drawing.Point(2, 2)
        Me.BtnMark.Name = "BtnMark"
        Me.BtnMark.Size = New System.Drawing.Size(90, 46)
        Me.BtnMark.TabIndex = 2
        Me.BtnMark.Text = "Mark"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(589, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(90, 46)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(679, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 46)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(313, 12)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(201, 20)
        Me.DECreated.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(242, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Created Date"
        '
        'TxtNumber
        '
        Me.TxtNumber.Location = New System.Drawing.Point(95, 12)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Properties.ReadOnly = True
        Me.TxtNumber.Size = New System.Drawing.Size(141, 20)
        Me.TxtNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Payout Number"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 45)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1})
        Me.GCData.Size = New System.Drawing.Size(771, 352)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBandPaymentGate, Me.gridBandERP, Me.gridBand2})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnsettlement_date, Me.BandedGridColumnpay_type, Me.BandedGridColumnbank, Me.BandedGridColumnid_order, Me.BandedGridColumnsales_order_ol_shop_number, Me.BandedGridColumncustomer_name, Me.BandedGridColumncheckout_id, Me.BandedGridColumnpayment, Me.BandedGridColumntrans_fee, Me.BandedGridColumninvoice, Me.BandedGridColumninvoice_amount, Me.BandedGridColumncalculate_fee, Me.BandedGridColumnno, Me.BandedGridColumnship_invoice_number, Me.BandedGridColumnother_price, Me.BandedGridColumnreconcile_number})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumnno)
        Me.GridBand1.Columns.Add(Me.BandedGridColumncheckout_id)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsales_order_ol_shop_number)
        Me.GridBand1.Columns.Add(Me.BandedGridColumncustomer_name)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsettlement_date)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnpay_type)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnbank)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 579
        '
        'BandedGridColumnno
        '
        Me.BandedGridColumnno.Caption = "No"
        Me.BandedGridColumnno.FieldName = "no"
        Me.BandedGridColumnno.Name = "BandedGridColumnno"
        Me.BandedGridColumnno.Visible = True
        Me.BandedGridColumnno.Width = 45
        '
        'BandedGridColumncheckout_id
        '
        Me.BandedGridColumncheckout_id.Caption = "Checkout Id"
        Me.BandedGridColumncheckout_id.FieldName = "checkout_id"
        Me.BandedGridColumncheckout_id.Name = "BandedGridColumncheckout_id"
        Me.BandedGridColumncheckout_id.Visible = True
        '
        'BandedGridColumnsales_order_ol_shop_number
        '
        Me.BandedGridColumnsales_order_ol_shop_number.Caption = "Order No"
        Me.BandedGridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.BandedGridColumnsales_order_ol_shop_number.Name = "BandedGridColumnsales_order_ol_shop_number"
        Me.BandedGridColumnsales_order_ol_shop_number.Visible = True
        Me.BandedGridColumnsales_order_ol_shop_number.Width = 90
        '
        'BandedGridColumncustomer_name
        '
        Me.BandedGridColumncustomer_name.Caption = "Cust."
        Me.BandedGridColumncustomer_name.FieldName = "customer_name"
        Me.BandedGridColumncustomer_name.Name = "BandedGridColumncustomer_name"
        Me.BandedGridColumncustomer_name.Visible = True
        '
        'BandedGridColumnsettlement_date
        '
        Me.BandedGridColumnsettlement_date.Caption = "Settle. Date"
        Me.BandedGridColumnsettlement_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BandedGridColumnsettlement_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnsettlement_date.FieldName = "settlement_date"
        Me.BandedGridColumnsettlement_date.Name = "BandedGridColumnsettlement_date"
        Me.BandedGridColumnsettlement_date.Visible = True
        Me.BandedGridColumnsettlement_date.Width = 144
        '
        'BandedGridColumnpay_type
        '
        Me.BandedGridColumnpay_type.Caption = "Pay Type"
        Me.BandedGridColumnpay_type.FieldName = "pay_type"
        Me.BandedGridColumnpay_type.Name = "BandedGridColumnpay_type"
        Me.BandedGridColumnpay_type.Visible = True
        '
        'BandedGridColumnbank
        '
        Me.BandedGridColumnbank.Caption = "Bank"
        Me.BandedGridColumnbank.FieldName = "bank"
        Me.BandedGridColumnbank.Name = "BandedGridColumnbank"
        Me.BandedGridColumnbank.Visible = True
        '
        'gridBandPaymentGate
        '
        Me.gridBandPaymentGate.Caption = "Payment Gateway"
        Me.gridBandPaymentGate.Columns.Add(Me.BandedGridColumnpayment)
        Me.gridBandPaymentGate.Columns.Add(Me.BandedGridColumntrans_fee)
        Me.gridBandPaymentGate.Name = "gridBandPaymentGate"
        Me.gridBandPaymentGate.VisibleIndex = 1
        Me.gridBandPaymentGate.Width = 270
        '
        'BandedGridColumnpayment
        '
        Me.BandedGridColumnpayment.Caption = "Amount"
        Me.BandedGridColumnpayment.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnpayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnpayment.FieldName = "payment"
        Me.BandedGridColumnpayment.Name = "BandedGridColumnpayment"
        Me.BandedGridColumnpayment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "payment", "{0:N2}")})
        Me.BandedGridColumnpayment.Visible = True
        Me.BandedGridColumnpayment.Width = 135
        '
        'BandedGridColumntrans_fee
        '
        Me.BandedGridColumntrans_fee.Caption = "Transaction Fee"
        Me.BandedGridColumntrans_fee.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumntrans_fee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumntrans_fee.FieldName = "trans_fee"
        Me.BandedGridColumntrans_fee.Name = "BandedGridColumntrans_fee"
        Me.BandedGridColumntrans_fee.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "trans_fee", "{0:N2}")})
        Me.BandedGridColumntrans_fee.Visible = True
        Me.BandedGridColumntrans_fee.Width = 135
        '
        'gridBandERP
        '
        Me.gridBandERP.Caption = "ERP"
        Me.gridBandERP.Columns.Add(Me.BandedGridColumninvoice)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumnship_invoice_number)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumninvoice_amount)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumncalculate_fee)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumnother_price)
        Me.gridBandERP.Name = "gridBandERP"
        Me.gridBandERP.VisibleIndex = 2
        Me.gridBandERP.Width = 483
        '
        'BandedGridColumninvoice
        '
        Me.BandedGridColumninvoice.Caption = "Invoice No."
        Me.BandedGridColumninvoice.FieldName = "invoice_number"
        Me.BandedGridColumninvoice.Name = "BandedGridColumninvoice"
        Me.BandedGridColumninvoice.Visible = True
        Me.BandedGridColumninvoice.Width = 102
        '
        'BandedGridColumnship_invoice_number
        '
        Me.BandedGridColumnship_invoice_number.Caption = "Invoice Ship"
        Me.BandedGridColumnship_invoice_number.FieldName = "ship_invoice_number"
        Me.BandedGridColumnship_invoice_number.Name = "BandedGridColumnship_invoice_number"
        Me.BandedGridColumnship_invoice_number.Visible = True
        Me.BandedGridColumnship_invoice_number.Width = 86
        '
        'BandedGridColumninvoice_amount
        '
        Me.BandedGridColumninvoice_amount.Caption = "Amount (Include Other Income/Expense)"
        Me.BandedGridColumninvoice_amount.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumninvoice_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumninvoice_amount.FieldName = "invoice_amount"
        Me.BandedGridColumninvoice_amount.Name = "BandedGridColumninvoice_amount"
        Me.BandedGridColumninvoice_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "invoice_amount", "{0:N2}")})
        Me.BandedGridColumninvoice_amount.Visible = True
        Me.BandedGridColumninvoice_amount.Width = 102
        '
        'BandedGridColumncalculate_fee
        '
        Me.BandedGridColumncalculate_fee.Caption = "Transaction Fee"
        Me.BandedGridColumncalculate_fee.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumncalculate_fee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumncalculate_fee.FieldName = "calculate_fee"
        Me.BandedGridColumncalculate_fee.Name = "BandedGridColumncalculate_fee"
        Me.BandedGridColumncalculate_fee.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "calculate_fee", "{0:N2}")})
        Me.BandedGridColumncalculate_fee.Visible = True
        Me.BandedGridColumncalculate_fee.Width = 104
        '
        'BandedGridColumnother_price
        '
        Me.BandedGridColumnother_price.Caption = "Other Income/Expense"
        Me.BandedGridColumnother_price.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnother_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnother_price.FieldName = "other_price"
        Me.BandedGridColumnother_price.Name = "BandedGridColumnother_price"
        Me.BandedGridColumnother_price.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "other_price", "{0:N2}")})
        Me.BandedGridColumnother_price.Visible = True
        Me.BandedGridColumnother_price.Width = 89
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.BandedGridColumnreconcile_number)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 3
        Me.gridBand2.Width = 108
        '
        'BandedGridColumnreconcile_number
        '
        Me.BandedGridColumnreconcile_number.Caption = "Reconcile No."
        Me.BandedGridColumnreconcile_number.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.BandedGridColumnreconcile_number.FieldName = "reconcile_number"
        Me.BandedGridColumnreconcile_number.Name = "BandedGridColumnreconcile_number"
        Me.BandedGridColumnreconcile_number.Visible = True
        Me.BandedGridColumnreconcile_number.Width = 108
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'BandedGridColumnid_order
        '
        Me.BandedGridColumnid_order.Caption = "id_order"
        Me.BandedGridColumnid_order.FieldName = "id_order"
        Me.BandedGridColumnid_order.Name = "BandedGridColumnid_order"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DECreated)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TxtNumber)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(771, 45)
        Me.PanelControl2.TabIndex = 2
        '
        'FormPayoutHistoryDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 447)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPayoutHistoryDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payout Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnsettlement_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnpay_type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_order As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncustomer_name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnpayment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntrans_fee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumninvoice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumninvoice_amount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncalculate_fee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncheckout_id As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnno As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnship_invoice_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnother_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandPaymentGate As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandERP As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnreconcile_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
