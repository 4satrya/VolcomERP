<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandRev
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdProdDemandRev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRevCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPDNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSTT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(709, 506)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProdDemandRev, Me.GridColumnIdPD, Me.GridColumnRevCount, Me.GridColumnPDNumber, Me.GridColumnSTT, Me.GridColumnDate})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProdDemandRev
        '
        Me.GridColumnIdProdDemandRev.Caption = "Id"
        Me.GridColumnIdProdDemandRev.FieldName = "id_prod_demand_rev"
        Me.GridColumnIdProdDemandRev.Name = "GridColumnIdProdDemandRev"
        '
        'GridColumnIdPD
        '
        Me.GridColumnIdPD.Caption = "ID PD"
        Me.GridColumnIdPD.FieldName = "id_prod_demand"
        Me.GridColumnIdPD.Name = "GridColumnIdPD"
        '
        'GridColumnRevCount
        '
        Me.GridColumnRevCount.Caption = "Revision No."
        Me.GridColumnRevCount.FieldName = "rev_count"
        Me.GridColumnRevCount.Name = "GridColumnRevCount"
        Me.GridColumnRevCount.Visible = True
        Me.GridColumnRevCount.VisibleIndex = 1
        Me.GridColumnRevCount.Width = 157
        '
        'GridColumnPDNumber
        '
        Me.GridColumnPDNumber.Caption = "PD Number"
        Me.GridColumnPDNumber.FieldName = "prod_demand_number"
        Me.GridColumnPDNumber.Name = "GridColumnPDNumber"
        Me.GridColumnPDNumber.Visible = True
        Me.GridColumnPDNumber.VisibleIndex = 0
        Me.GridColumnPDNumber.Width = 514
        '
        'GridColumnSTT
        '
        Me.GridColumnSTT.Caption = "Status"
        Me.GridColumnSTT.FieldName = "report_status"
        Me.GridColumnSTT.Name = "GridColumnSTT"
        Me.GridColumnSTT.Visible = True
        Me.GridColumnSTT.VisibleIndex = 3
        Me.GridColumnSTT.Width = 600
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Created Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "created_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 2
        Me.GridColumnDate.Width = 345
        '
        'FormProdDemandRev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 506)
        Me.Controls.Add(Me.GCData)
        Me.Name = "FormProdDemandRev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Demand Revision"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProdDemandRev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRevCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPDNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSTT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
End Class
