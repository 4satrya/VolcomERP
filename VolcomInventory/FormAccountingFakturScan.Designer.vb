<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFakturScan
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
        Me.GCFak = New DevExpress.XtraGrid.GridControl()
        Me.GVFak = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFakturDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPInv = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInv = New DevExpress.XtraGrid.GridControl()
        Me.GVInv = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GCFak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPList.SuspendLayout()
        Me.XTPInv.SuspendLayout()
        CType(Me.GCInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFak
        '
        Me.GCFak.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFak.Location = New System.Drawing.Point(0, 0)
        Me.GCFak.MainView = Me.GVFak
        Me.GCFak.Name = "GCFak"
        Me.GCFak.Size = New System.Drawing.Size(649, 335)
        Me.GCFak.TabIndex = 0
        Me.GCFak.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFak})
        '
        'GVFak
        '
        Me.GVFak.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumn2, Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumnUpdate, Me.GridColumnFakturDate})
        Me.GVFak.GridControl = Me.GCFak
        Me.GVFak.Name = "GVFak"
        Me.GVFak.OptionsView.ShowGroupPanel = False
        Me.GVFak.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnId, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_acc_fak_scan"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Period"
        Me.GridColumn2.FieldName = "acc_fak_scan_period"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created Date"
        Me.GridColumn1.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "acc_fak_scan_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Year"
        Me.GridColumn3.FieldName = "acc_fak_scan_year"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Type"
        Me.GridColumn4.FieldName = "faktur_type"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GridColumnUpdate
        '
        Me.GridColumnUpdate.Caption = "Updated/Time"
        Me.GridColumnUpdate.DisplayFormat.FormatString = "dd\/MM\/yyyy hh:mm tt"
        Me.GridColumnUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnUpdate.FieldName = "acc_fak_scan_trans_date"
        Me.GridColumnUpdate.Name = "GridColumnUpdate"
        Me.GridColumnUpdate.Visible = True
        Me.GridColumnUpdate.VisibleIndex = 5
        '
        'GridColumnFakturDate
        '
        Me.GridColumnFakturDate.Caption = "Faktur Date"
        Me.GridColumnFakturDate.FieldName = "faktur_date_view"
        Me.GridColumnFakturDate.Name = "GridColumnFakturDate"
        Me.GridColumnFakturDate.Visible = True
        Me.GridColumnFakturDate.VisibleIndex = 3
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPList
        Me.XTCData.Size = New System.Drawing.Size(655, 363)
        Me.XTCData.TabIndex = 1
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPInv})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCFak)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(649, 335)
        Me.XTPList.Text = "List"
        '
        'XTPInv
        '
        Me.XTPInv.Controls.Add(Me.GCInv)
        Me.XTPInv.Name = "XTPInv"
        Me.XTPInv.Size = New System.Drawing.Size(649, 335)
        Me.XTPInv.Text = "Sales Invoice"
        '
        'GCInv
        '
        Me.GCInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInv.Location = New System.Drawing.Point(0, 0)
        Me.GCInv.MainView = Me.GVInv
        Me.GCInv.Name = "GCInv"
        Me.GCInv.Size = New System.Drawing.Size(649, 335)
        Me.GCInv.TabIndex = 0
        Me.GCInv.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInv})
        '
        'GVInv
        '
        Me.GVInv.GridControl = Me.GCInv
        Me.GVInv.Name = "GVInv"
        Me.GVInv.OptionsFind.AlwaysVisible = True
        Me.GVInv.OptionsView.ShowGroupPanel = False
        '
        'FormAccountingFakturScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 363)
        Me.Controls.Add(Me.XTCData)
        Me.Name = "FormAccountingFakturScan"
        Me.Text = "E-Faktur"
        CType(Me.GCFak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        Me.XTPInv.ResumeLayout(False)
        CType(Me.GCInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFak As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFak As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFakturDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInv As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCInv As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInv As DevExpress.XtraGrid.Views.Grid.GridView
End Class
