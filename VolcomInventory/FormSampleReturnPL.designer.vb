<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleReturnPL
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
        Me.GCSamplePL = New DevExpress.XtraGrid.GridControl()
        Me.GVSamplePL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSamplePLNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCSamplePL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSamplePL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSamplePL
        '
        Me.GCSamplePL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSamplePL.Location = New System.Drawing.Point(0, 0)
        Me.GCSamplePL.MainView = Me.GVSamplePL
        Me.GCSamplePL.Name = "GCSamplePL"
        Me.GCSamplePL.Size = New System.Drawing.Size(809, 282)
        Me.GCSamplePL.TabIndex = 1
        Me.GCSamplePL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSamplePL})
        '
        'GVSamplePL
        '
        Me.GVSamplePL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnSamplePLNumber, Me.GridColumnPLDate, Me.GridColumnNote, Me.GridColumnReportStatus, Me.GridColumnTo})
        Me.GVSamplePL.GridControl = Me.GCSamplePL
        Me.GVSamplePL.Name = "GVSamplePL"
        Me.GVSamplePL.OptionsBehavior.Editable = False
        Me.GVSamplePL.OptionsView.ShowGroupPanel = False
        Me.GVSamplePL.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnId, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_sample_pl_ret"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnSamplePLNumber
        '
        Me.GridColumnSamplePLNumber.Caption = "Number"
        Me.GridColumnSamplePLNumber.FieldName = "sample_pl_ret_number"
        Me.GridColumnSamplePLNumber.Name = "GridColumnSamplePLNumber"
        Me.GridColumnSamplePLNumber.Visible = True
        Me.GridColumnSamplePLNumber.VisibleIndex = 0
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPLDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPLDate.FieldName = "sample_pl_ret_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 2
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "sample_pl_ret_note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 3
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.FieldNameSortGroup = "id_report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 4
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 1
        '
        'FormSampleReturnPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 282)
        Me.Controls.Add(Me.GCSamplePL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleReturnPL"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inbound Sample"
        CType(Me.GCSamplePL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSamplePL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCSamplePL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSamplePL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSamplePLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
End Class
