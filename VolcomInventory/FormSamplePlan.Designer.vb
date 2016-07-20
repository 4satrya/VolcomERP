<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSamplePlan
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
        Me.GCSamplePrePO = New DevExpress.XtraGrid.GridControl()
        Me.GVSamplePrePO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdSamplePurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSPNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSPTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCSamplePrePO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSamplePrePO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSamplePrePO
        '
        Me.GCSamplePrePO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSamplePrePO.Location = New System.Drawing.Point(0, 0)
        Me.GCSamplePrePO.MainView = Me.GVSamplePrePO
        Me.GCSamplePrePO.Name = "GCSamplePrePO"
        Me.GCSamplePrePO.Size = New System.Drawing.Size(825, 353)
        Me.GCSamplePrePO.TabIndex = 4
        Me.GCSamplePrePO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSamplePrePO})
        '
        'GVSamplePrePO
        '
        Me.GVSamplePrePO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePurchase, Me.ColSeason, Me.ColSPNumber, Me.ColSPTo, Me.ColSamplePurcDate, Me.ColStatus, Me.ColIDStatus})
        Me.GVSamplePrePO.GridControl = Me.GCSamplePrePO
        Me.GVSamplePrePO.GroupCount = 1
        Me.GVSamplePrePO.Name = "GVSamplePrePO"
        Me.GVSamplePrePO.OptionsBehavior.Editable = False
        Me.GVSamplePrePO.OptionsView.ShowGroupPanel = False
        Me.GVSamplePrePO.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSamplePurchase
        '
        Me.ColIdSamplePurchase.Caption = "ID Sample Plan"
        Me.ColIdSamplePurchase.FieldName = "id_sample_plan"
        Me.ColIdSamplePurchase.Name = "ColIdSamplePurchase"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season_orign"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColSPNumber
        '
        Me.ColSPNumber.Caption = "Number"
        Me.ColSPNumber.FieldName = "sample_plan_number"
        Me.ColSPNumber.Name = "ColSPNumber"
        Me.ColSPNumber.Visible = True
        Me.ColSPNumber.VisibleIndex = 0
        Me.ColSPNumber.Width = 73
        '
        'ColSPTo
        '
        Me.ColSPTo.Caption = "Vendor"
        Me.ColSPTo.FieldName = "comp_name_to"
        Me.ColSPTo.Name = "ColSPTo"
        Me.ColSPTo.Visible = True
        Me.ColSPTo.VisibleIndex = 1
        Me.ColSPTo.Width = 142
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.FieldName = "date_view"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 2
        Me.ColSamplePurcDate.Width = 131
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 3
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'FormSamplePlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 353)
        Me.Controls.Add(Me.GCSamplePrePO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSamplePlan"
        Me.ShowInTaskbar = False
        Me.Text = "Proforma PO Sample"
        CType(Me.GCSamplePrePO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSamplePrePO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSamplePrePO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSamplePrePO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSamplePurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSPNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSPTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
