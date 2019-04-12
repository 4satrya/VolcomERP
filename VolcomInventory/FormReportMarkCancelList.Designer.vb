<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkCancelList
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
        Me.PCDepartement = New DevExpress.XtraEditors.PanelControl()
        Me.BViewReqList = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCListCancel = New DevExpress.XtraGrid.GridControl()
        Me.GVListCancel = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProposedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompleteName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompleteDatetime = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PCDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCDepartement.SuspendLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCDepartement
        '
        Me.PCDepartement.Controls.Add(Me.BViewReqList)
        Me.PCDepartement.Controls.Add(Me.SLEDepartement)
        Me.PCDepartement.Controls.Add(Me.LabelControl1)
        Me.PCDepartement.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCDepartement.Location = New System.Drawing.Point(0, 0)
        Me.PCDepartement.Name = "PCDepartement"
        Me.PCDepartement.Size = New System.Drawing.Size(1007, 39)
        Me.PCDepartement.TabIndex = 0
        '
        'BViewReqList
        '
        Me.BViewReqList.Location = New System.Drawing.Point(227, 7)
        Me.BViewReqList.Name = "BViewReqList"
        Me.BViewReqList.Size = New System.Drawing.Size(60, 23)
        Me.BViewReqList.TabIndex = 8915
        Me.BViewReqList.Text = "view"
        '
        'SLEDepartement
        '
        Me.SLEDepartement.Location = New System.Drawing.Point(81, 9)
        Me.SLEDepartement.Name = "SLEDepartement"
        Me.SLEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDepartement.Properties.View = Me.GridView1
        Me.SLEDepartement.Size = New System.Drawing.Size(140, 20)
        Me.SLEDepartement.TabIndex = 8914
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn26, Me.GridColumn27})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "ID Departement"
        Me.GridColumn26.FieldName = "id_departement"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Departement"
        Me.GridColumn27.FieldName = "departement"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 8913
        Me.LabelControl1.Text = "Departement"
        '
        'GCListCancel
        '
        Me.GCListCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListCancel.Location = New System.Drawing.Point(0, 39)
        Me.GCListCancel.MainView = Me.GVListCancel
        Me.GCListCancel.Name = "GCListCancel"
        Me.GCListCancel.Size = New System.Drawing.Size(1007, 467)
        Me.GCListCancel.TabIndex = 1
        Me.GCListCancel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListCancel})
        '
        'GVListCancel
        '
        Me.GVListCancel.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnReportNumber, Me.GridColumnReportDate, Me.GridColumnProposedBy, Me.GridColumnType, Me.GridColumnCompleteName, Me.GridColumnCompleteDatetime})
        Me.GVListCancel.GridControl = Me.GCListCancel
        Me.GVListCancel.Name = "GVListCancel"
        Me.GVListCancel.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID Report Cancel"
        Me.GridColumnID.FieldName = "id_report_mark_cancel"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnReportNumber
        '
        Me.GridColumnReportNumber.Caption = "Number"
        Me.GridColumnReportNumber.FieldName = "id_report_mark_cancel"
        Me.GridColumnReportNumber.Name = "GridColumnReportNumber"
        Me.GridColumnReportNumber.Visible = True
        Me.GridColumnReportNumber.VisibleIndex = 0
        '
        'GridColumnReportDate
        '
        Me.GridColumnReportDate.Caption = "Date Proposed"
        Me.GridColumnReportDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnReportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnReportDate.FieldName = "created_datetime"
        Me.GridColumnReportDate.Name = "GridColumnReportDate"
        Me.GridColumnReportDate.Visible = True
        Me.GridColumnReportDate.VisibleIndex = 2
        '
        'GridColumnProposedBy
        '
        Me.GridColumnProposedBy.Caption = "Proposed By"
        Me.GridColumnProposedBy.FieldName = "employee_name"
        Me.GridColumnProposedBy.Name = "GridColumnProposedBy"
        Me.GridColumnProposedBy.Visible = True
        Me.GridColumnProposedBy.VisibleIndex = 3
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "report_mark_type_name"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 1
        '
        'GridColumnCompleteName
        '
        Me.GridColumnCompleteName.Caption = "Complete By"
        Me.GridColumnCompleteName.FieldName = "name_complete"
        Me.GridColumnCompleteName.Name = "GridColumnCompleteName"
        Me.GridColumnCompleteName.Visible = True
        Me.GridColumnCompleteName.VisibleIndex = 4
        '
        'GridColumnCompleteDatetime
        '
        Me.GridColumnCompleteDatetime.Caption = "Complete Datetime"
        Me.GridColumnCompleteDatetime.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnCompleteDatetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCompleteDatetime.FieldName = "complete_datetime"
        Me.GridColumnCompleteDatetime.Name = "GridColumnCompleteDatetime"
        Me.GridColumnCompleteDatetime.Visible = True
        Me.GridColumnCompleteDatetime.VisibleIndex = 5
        '
        'FormReportMarkCancelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 506)
        Me.Controls.Add(Me.GCListCancel)
        Me.Controls.Add(Me.PCDepartement)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkCancelList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Cancel Form"
        CType(Me.PCDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCDepartement.ResumeLayout(False)
        Me.PCDepartement.PerformLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCDepartement As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCListCancel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListCancel As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProposedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BViewReqList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnCompleteName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompleteDatetime As DevExpress.XtraGrid.Columns.GridColumn
End Class
