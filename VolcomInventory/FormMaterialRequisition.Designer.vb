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
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMRS
        '
        Me.GCMRS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMRS.Location = New System.Drawing.Point(0, 0)
        Me.GCMRS.MainView = Me.GVMRS
        Me.GCMRS.Name = "GCMRS"
        Me.GCMRS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCMRS.Size = New System.Drawing.Size(784, 561)
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
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 7
        Me.GridColumnDesign.Width = 67
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
        'FormMaterialRequisition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCMRS)
        Me.Name = "FormMaterialRequisition"
        Me.Text = "Material Requisition"
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
