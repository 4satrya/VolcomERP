<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGLineListPrepPrice
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
        Me.BtnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMsrp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRetCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDiv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColuminStoreDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLifetime = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExport)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 280)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(665, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnExport
        '
        Me.BtnExport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExport.Location = New System.Drawing.Point(573, 2)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 36)
        Me.BtnExport.TabIndex = 0
        Me.BtnExport.Text = "Export to XLS"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(665, 280)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnId, Me.GridColumnPrice, Me.GridColumnRate, Me.GridColumnMsrp, Me.GridColumnName, Me.GridColumnColor, Me.GridColumnDel, Me.GridColumnRetCode, Me.GridColumnEOS, Me.GridColumnDiv, Me.GridColumnRetDate, Me.GridColuminStoreDate, Me.GridColumnLifetime})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        Me.GridColumnCode.Width = 141
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "id"
        Me.GridColumnId.FieldName = "id"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "est_price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "n2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "est_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 6
        Me.GridColumnPrice.Width = 148
        '
        'GridColumnRate
        '
        Me.GridColumnRate.Caption = "rate_current"
        Me.GridColumnRate.DisplayFormat.FormatString = "N2"
        Me.GridColumnRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRate.FieldName = "rate_current"
        Me.GridColumnRate.Name = "GridColumnRate"
        Me.GridColumnRate.Visible = True
        Me.GridColumnRate.VisibleIndex = 4
        Me.GridColumnRate.Width = 148
        '
        'GridColumnMsrp
        '
        Me.GridColumnMsrp.Caption = "msrp"
        Me.GridColumnMsrp.DisplayFormat.FormatString = "n2"
        Me.GridColumnMsrp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMsrp.FieldName = "msrp"
        Me.GridColumnMsrp.Name = "GridColumnMsrp"
        Me.GridColumnMsrp.Visible = True
        Me.GridColumnMsrp.VisibleIndex = 5
        Me.GridColumnMsrp.Width = 148
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        Me.GridColumnName.Width = 141
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        Me.GridColumnColor.Width = 114
        '
        'GridColumnDel
        '
        Me.GridColumnDel.Caption = "delivery"
        Me.GridColumnDel.FieldName = "delivery"
        Me.GridColumnDel.Name = "GridColumnDel"
        Me.GridColumnDel.Visible = True
        Me.GridColumnDel.VisibleIndex = 7
        Me.GridColumnDel.Width = 148
        '
        'GridColumnRetCode
        '
        Me.GridColumnRetCode.Caption = "ret_code"
        Me.GridColumnRetCode.FieldName = "ret_code"
        Me.GridColumnRetCode.Name = "GridColumnRetCode"
        Me.GridColumnRetCode.Visible = True
        Me.GridColumnRetCode.VisibleIndex = 9
        Me.GridColumnRetCode.Width = 76
        '
        'GridColumnEOS
        '
        Me.GridColumnEOS.Caption = "design_eos"
        Me.GridColumnEOS.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnEOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEOS.FieldName = "design_eos"
        Me.GridColumnEOS.Name = "GridColumnEOS"
        Me.GridColumnEOS.Visible = True
        Me.GridColumnEOS.VisibleIndex = 12
        Me.GridColumnEOS.Width = 196
        '
        'GridColumnDiv
        '
        Me.GridColumnDiv.Caption = "division"
        Me.GridColumnDiv.FieldName = "division"
        Me.GridColumnDiv.Name = "GridColumnDiv"
        Me.GridColumnDiv.Visible = True
        Me.GridColumnDiv.VisibleIndex = 3
        Me.GridColumnDiv.Width = 116
        '
        'GridColumnRetDate
        '
        Me.GridColumnRetDate.Caption = "ret_date"
        Me.GridColumnRetDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnRetDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnRetDate.FieldName = "ret_date"
        Me.GridColumnRetDate.Name = "GridColumnRetDate"
        Me.GridColumnRetDate.Visible = True
        Me.GridColumnRetDate.VisibleIndex = 10
        Me.GridColumnRetDate.Width = 108
        '
        'GridColuminStoreDate
        '
        Me.GridColuminStoreDate.Caption = "in_store_date"
        Me.GridColuminStoreDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColuminStoreDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColuminStoreDate.FieldName = "delivery_date"
        Me.GridColuminStoreDate.Name = "GridColuminStoreDate"
        Me.GridColuminStoreDate.Visible = True
        Me.GridColuminStoreDate.VisibleIndex = 8
        Me.GridColuminStoreDate.Width = 86
        '
        'GridColumnLifetime
        '
        Me.GridColumnLifetime.Caption = "lifetime (month)"
        Me.GridColumnLifetime.DisplayFormat.FormatString = "n0"
        Me.GridColumnLifetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnLifetime.FieldName = "lifetime"
        Me.GridColumnLifetime.Name = "GridColumnLifetime"
        Me.GridColumnLifetime.UnboundExpression = "DateDiffMonth([delivery_date], [ret_date])"
        Me.GridColumnLifetime.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnLifetime.Visible = True
        Me.GridColumnLifetime.VisibleIndex = 11
        Me.GridColumnLifetime.Width = 62
        '
        'FormFGLineListPrepPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 320)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormFGLineListPrepPrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prepare Estimate Price"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMsrp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDiv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColuminStoreDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLifetime As DevExpress.XtraGrid.Columns.GridColumn
End Class
