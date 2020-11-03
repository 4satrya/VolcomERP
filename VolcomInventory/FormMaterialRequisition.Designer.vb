<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMaterialRequisition
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GCMRS = New DevExpress.XtraGrid.GridControl()
        Me.GVMRS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdMRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompReqFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompReqFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompReqTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompReqTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMRSNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMRS
        '
        Me.GCMRS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMRS.Location = New System.Drawing.Point(0, 44)
        Me.GCMRS.MainView = Me.GVMRS
        Me.GCMRS.Name = "GCMRS"
        Me.GCMRS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCMRS.Size = New System.Drawing.Size(784, 517)
        Me.GCMRS.TabIndex = 9
        Me.GCMRS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMRS})
        '
        'GVMRS
        '
        Me.GVMRS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdMRS, Me.GridColumnIdWO, Me.GridColumnIdCompReqFrom, Me.GridColumnCompReqFrom, Me.GridColumnIdCompReqTo, Me.GridColumnCompReqTo, Me.GridColumnDate, Me.GridColumnStatus, Me.GridColumnWONumber, Me.GridColumnMRSNumber, Me.GridColumnIdReportStatus, Me.GridColumnPONumber, Me.GridColumnCode, Me.GridColumnDesign, Me.GridColumnCreatedBy})
        Me.GVMRS.GridControl = Me.GCMRS
        Me.GVMRS.Name = "GVMRS"
        Me.GVMRS.OptionsBehavior.Editable = False
        Me.GVMRS.OptionsFind.AlwaysVisible = True
        Me.GVMRS.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdMRS
        '
        Me.GridColumnIdMRS.Caption = "Id MRS"
        Me.GridColumnIdMRS.FieldName = "id_prod_order_mrs"
        Me.GridColumnIdMRS.Name = "GridColumnIdMRS"
        '
        'GridColumnIdWO
        '
        Me.GridColumnIdWO.Caption = "Id WO"
        Me.GridColumnIdWO.FieldName = "id_prod_order_wo"
        Me.GridColumnIdWO.Name = "GridColumnIdWO"
        '
        'GridColumnIdCompReqFrom
        '
        Me.GridColumnIdCompReqFrom.Caption = "Id Comp From"
        Me.GridColumnIdCompReqFrom.FieldName = "id_comp_name_req_from"
        Me.GridColumnIdCompReqFrom.Name = "GridColumnIdCompReqFrom"
        '
        'GridColumnCompReqFrom
        '
        Me.GridColumnCompReqFrom.Caption = "From"
        Me.GridColumnCompReqFrom.FieldName = "comp_name_req_from"
        Me.GridColumnCompReqFrom.Name = "GridColumnCompReqFrom"
        Me.GridColumnCompReqFrom.Visible = True
        Me.GridColumnCompReqFrom.VisibleIndex = 1
        Me.GridColumnCompReqFrom.Width = 95
        '
        'GridColumnIdCompReqTo
        '
        Me.GridColumnIdCompReqTo.Caption = "Id Comp To"
        Me.GridColumnIdCompReqTo.FieldName = "id_comp_name_req_to"
        Me.GridColumnIdCompReqTo.Name = "GridColumnIdCompReqTo"
        '
        'GridColumnCompReqTo
        '
        Me.GridColumnCompReqTo.Caption = "To"
        Me.GridColumnCompReqTo.FieldName = "comp_name_req_to"
        Me.GridColumnCompReqTo.Name = "GridColumnCompReqTo"
        Me.GridColumnCompReqTo.Visible = True
        Me.GridColumnCompReqTo.VisibleIndex = 2
        Me.GridColumnCompReqTo.Width = 108
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "prod_order_mrs_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 3
        Me.GridColumnDate.Width = 94
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        Me.GridColumnStatus.Width = 84
        '
        'GridColumnWONumber
        '
        Me.GridColumnWONumber.Caption = "WO Number"
        Me.GridColumnWONumber.FieldName = "prod_order_wo_number"
        Me.GridColumnWONumber.Name = "GridColumnWONumber"
        Me.GridColumnWONumber.Width = 150
        '
        'GridColumnMRSNumber
        '
        Me.GridColumnMRSNumber.Caption = "Number"
        Me.GridColumnMRSNumber.FieldName = "prod_order_mrs_number"
        Me.GridColumnMRSNumber.Name = "GridColumnMRSNumber"
        Me.GridColumnMRSNumber.Visible = True
        Me.GridColumnMRSNumber.VisibleIndex = 0
        Me.GridColumnMRSNumber.Width = 104
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'GridColumnPONumber
        '
        Me.GridColumnPONumber.Caption = "PO Number"
        Me.GridColumnPONumber.FieldName = "prod_order_number"
        Me.GridColumnPONumber.Name = "GridColumnPONumber"
        Me.GridColumnPONumber.Visible = True
        Me.GridColumnPONumber.VisibleIndex = 5
        Me.GridColumnPONumber.Width = 67
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 6
        Me.GridColumnCode.Width = 67
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 7
        Me.GridColumnDesign.Width = 67
        '
        'GridColumnCreatedBy
        '
        Me.GridColumnCreatedBy.Caption = "Created By"
        Me.GridColumnCreatedBy.FieldName = "created_by"
        Me.GridColumnCreatedBy.Name = "GridColumnCreatedBy"
        Me.GridColumnCreatedBy.Visible = True
        Me.GridColumnCreatedBy.VisibleIndex = 8
        Me.GridColumnCreatedBy.Width = 80
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Appearance.BackColor = System.Drawing.Color.Lime
        Me.RepositoryItemProgressBar1.EndColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.RepositoryItemProgressBar1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.RepositoryItemProgressBar1.ShowTitle = True
        Me.RepositoryItemProgressBar1.StartColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar1.Step = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DEStart)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 44)
        Me.PanelControl1.TabIndex = 10
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(42, 12)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEStart.Size = New System.Drawing.Size(172, 20)
        Me.DEStart.TabIndex = 24
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 25
        Me.LabelControl1.Text = "From"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(220, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 26
        Me.LabelControl2.Text = "Until"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(247, 12)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(172, 20)
        Me.DEUntil.TabIndex = 27
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(425, 10)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(49, 23)
        Me.BView.TabIndex = 28
        Me.BView.Text = "view"
        '
        'FormMaterialRequisition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCMRS)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormMaterialRequisition"
        Me.Text = "Material Requisition"
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCMRS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMRS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompReqFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompReqFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompReqTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompReqTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMRSNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
End Class
