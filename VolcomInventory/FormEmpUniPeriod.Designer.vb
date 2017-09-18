<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniPeriod
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
        Me.GCUni = New DevExpress.XtraGrid.GridControl()
        Me.GVUni = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPeriodName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSelectionStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSelectionEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDistribution = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCUni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCUni
        '
        Me.GCUni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUni.Location = New System.Drawing.Point(0, 0)
        Me.GCUni.MainView = Me.GVUni
        Me.GCUni.Name = "GCUni"
        Me.GCUni.Size = New System.Drawing.Size(653, 319)
        Me.GCUni.TabIndex = 1
        Me.GCUni.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUni})
        '
        'GVUni
        '
        Me.GVUni.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPeriodName, Me.GridColumnSelectionStart, Me.GridColumnSelectionEnd, Me.GridColumnCreatedDate, Me.GridColumnDistribution})
        Me.GVUni.GridControl = Me.GCUni
        Me.GVUni.Name = "GVUni"
        Me.GVUni.OptionsBehavior.Editable = False
        Me.GVUni.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPeriodName
        '
        Me.GridColumnPeriodName.Caption = "Period"
        Me.GridColumnPeriodName.FieldName = "period_name"
        Me.GridColumnPeriodName.Name = "GridColumnPeriodName"
        Me.GridColumnPeriodName.Visible = True
        Me.GridColumnPeriodName.VisibleIndex = 0
        '
        'GridColumnSelectionStart
        '
        Me.GridColumnSelectionStart.Caption = "Est. Selection Start"
        Me.GridColumnSelectionStart.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnSelectionStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSelectionStart.FieldName = "selection_date_start"
        Me.GridColumnSelectionStart.Name = "GridColumnSelectionStart"
        Me.GridColumnSelectionStart.Visible = True
        Me.GridColumnSelectionStart.VisibleIndex = 1
        '
        'GridColumnSelectionEnd
        '
        Me.GridColumnSelectionEnd.Caption = "Est. Selection End"
        Me.GridColumnSelectionEnd.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnSelectionEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSelectionEnd.FieldName = "selection_date_end"
        Me.GridColumnSelectionEnd.Name = "GridColumnSelectionEnd"
        Me.GridColumnSelectionEnd.Visible = True
        Me.GridColumnSelectionEnd.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 3
        '
        'GridColumnDistribution
        '
        Me.GridColumnDistribution.Caption = "Est. Distribution"
        Me.GridColumnDistribution.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnDistribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDistribution.FieldName = "distribution_date"
        Me.GridColumnDistribution.Name = "GridColumnDistribution"
        Me.GridColumnDistribution.Visible = True
        Me.GridColumnDistribution.VisibleIndex = 4
        '
        'FormEmpUniPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 319)
        Me.Controls.Add(Me.GCUni)
        Me.Name = "FormEmpUniPeriod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uniform"
        CType(Me.GCUni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCUni As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUni As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPeriodName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelectionStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelectionEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDistribution As DevExpress.XtraGrid.Columns.GridColumn
End Class
