<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreBrowseOrder
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnorder_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrec_by_store_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnphone = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaddress = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 360)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(641, 50)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnChoose.Location = New System.Drawing.Point(2, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(637, 46)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(641, 360)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnorder_number, Me.GridColumnorder_date, Me.GridColumncustomer_name, Me.GridColumnrec_by_store_date, Me.GridColumnphone, Me.GridColumnaddress})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnorder_number
        '
        Me.GridColumnorder_number.Caption = "Order Number"
        Me.GridColumnorder_number.FieldName = "order_number"
        Me.GridColumnorder_number.Name = "GridColumnorder_number"
        Me.GridColumnorder_number.Visible = True
        Me.GridColumnorder_number.VisibleIndex = 0
        '
        'GridColumnorder_date
        '
        Me.GridColumnorder_date.Caption = "Order Date"
        Me.GridColumnorder_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnorder_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnorder_date.FieldName = "order_date"
        Me.GridColumnorder_date.Name = "GridColumnorder_date"
        Me.GridColumnorder_date.Visible = True
        Me.GridColumnorder_date.VisibleIndex = 1
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 2
        '
        'GridColumnrec_by_store_date
        '
        Me.GridColumnrec_by_store_date.Caption = "Received by Customer"
        Me.GridColumnrec_by_store_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnrec_by_store_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnrec_by_store_date.FieldName = "rec_by_store_date"
        Me.GridColumnrec_by_store_date.Name = "GridColumnrec_by_store_date"
        Me.GridColumnrec_by_store_date.Visible = True
        Me.GridColumnrec_by_store_date.VisibleIndex = 3
        '
        'GridColumnphone
        '
        Me.GridColumnphone.Caption = "Phone"
        Me.GridColumnphone.FieldName = "phone"
        Me.GridColumnphone.Name = "GridColumnphone"
        '
        'GridColumnaddress
        '
        Me.GridColumnaddress.Caption = "Address"
        Me.GridColumnaddress.FieldName = "address"
        Me.GridColumnaddress.Name = "GridColumnaddress"
        '
        'FormOLStoreBrowseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 410)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreBrowseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Browse Order"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnorder_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrec_by_store_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnphone As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaddress As DevExpress.XtraGrid.Columns.GridColumn
End Class
