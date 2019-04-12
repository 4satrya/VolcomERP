<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemand
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
        Me.GroupControlProdNumber = New DevExpress.XtraEditors.GroupControl()
        Me.GCProdDemand = New DevExpress.XtraGrid.GridControl()
        Me.GVProdDemand = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnProdDemand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdDemandNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRef = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPDDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.BGVProduct = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BtnLoadDetailPD = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCreate = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCLineList = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPDList = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.GroupControlProdNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProdNumber.SuspendLayout()
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.XTCLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCLineList.SuspendLayout()
        Me.XTPPDList.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControlProdNumber
        '
        Me.GroupControlProdNumber.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlProdNumber.Controls.Add(Me.GCProdDemand)
        Me.GroupControlProdNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProdNumber.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProdNumber.Name = "GroupControlProdNumber"
        Me.GroupControlProdNumber.Size = New System.Drawing.Size(801, 241)
        Me.GroupControlProdNumber.TabIndex = 0
        Me.GroupControlProdNumber.Text = "PD Number"
        '
        'GCProdDemand
        '
        Me.GCProdDemand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdDemand.Location = New System.Drawing.Point(20, 2)
        Me.GCProdDemand.MainView = Me.GVProdDemand
        Me.GCProdDemand.Name = "GCProdDemand"
        Me.GCProdDemand.Size = New System.Drawing.Size(779, 237)
        Me.GCProdDemand.TabIndex = 0
        Me.GCProdDemand.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdDemand})
        '
        'GVProdDemand
        '
        Me.GVProdDemand.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProdDemand, Me.GridColumnProdDemandNumber, Me.GridColumnSeason, Me.GridColumnIdSeason, Me.ColIdReportStatus, Me.ColReportStatus, Me.GridColumnRef, Me.GridColumnType, Me.GridColumnPDDate, Me.GridColumnDivision, Me.GridColumnPD})
        Me.GVProdDemand.GridControl = Me.GCProdDemand
        Me.GVProdDemand.GroupCount = 1
        Me.GVProdDemand.Name = "GVProdDemand"
        Me.GVProdDemand.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProdDemand.OptionsBehavior.Editable = False
        Me.GVProdDemand.OptionsFind.AlwaysVisible = True
        Me.GVProdDemand.OptionsView.ShowGroupPanel = False
        Me.GVProdDemand.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnProdDemand, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnProdDemand
        '
        Me.GridColumnProdDemand.Caption = "ID"
        Me.GridColumnProdDemand.FieldName = "id_prod_demand"
        Me.GridColumnProdDemand.Name = "GridColumnProdDemand"
        '
        'GridColumnProdDemandNumber
        '
        Me.GridColumnProdDemandNumber.Caption = "Production Demand Number"
        Me.GridColumnProdDemandNumber.FieldName = "prod_demand_number"
        Me.GridColumnProdDemandNumber.Name = "GridColumnProdDemandNumber"
        Me.GridColumnProdDemandNumber.Visible = True
        Me.GridColumnProdDemandNumber.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 3
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'ColIdReportStatus
        '
        Me.ColIdReportStatus.Caption = "Id Status"
        Me.ColIdReportStatus.FieldName = "id_report_status"
        Me.ColIdReportStatus.Name = "ColIdReportStatus"
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Status"
        Me.ColReportStatus.FieldName = "report_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Visible = True
        Me.ColReportStatus.VisibleIndex = 5
        '
        'GridColumnRef
        '
        Me.GridColumnRef.Caption = "Reference"
        Me.GridColumnRef.FieldName = "prod_demand_number_ref"
        Me.GridColumnRef.Name = "GridColumnRef"
        Me.GridColumnRef.Visible = True
        Me.GridColumnRef.VisibleIndex = 1
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "pd_type"
        Me.GridColumnType.Name = "GridColumnType"
        '
        'GridColumnPDDate
        '
        Me.GridColumnPDDate.Caption = "Created Date"
        Me.GridColumnPDDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPDDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPDDate.FieldName = "prod_demand_date"
        Me.GridColumnPDDate.Name = "GridColumnPDDate"
        Me.GridColumnPDDate.Visible = True
        Me.GridColumnPDDate.VisibleIndex = 4
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 3
        '
        'GridColumnPD
        '
        Me.GridColumnPD.Caption = "Phase"
        Me.GridColumnPD.FieldName = "pd"
        Me.GridColumnPD.Name = "GridColumnPD"
        Me.GridColumnPD.Visible = True
        Me.GridColumnPD.VisibleIndex = 2
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCProduct)
        Me.GroupControl1.Controls.Add(Me.BtnLoadDetailPD)
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 241)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(801, 215)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Product List"
        Me.GroupControl1.Visible = False
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(20, 36)
        Me.GCProduct.MainView = Me.BGVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(779, 140)
        Me.GCProduct.TabIndex = 39
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVProduct})
        '
        'BGVProduct
        '
        Me.BGVProduct.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn2})
        Me.BGVProduct.GridControl = Me.GCProduct
        Me.BGVProduct.Name = "BGVProduct"
        Me.BGVProduct.OptionsBehavior.ReadOnly = True
        Me.BGVProduct.OptionsCustomization.AllowRowSizing = True
        Me.BGVProduct.OptionsView.ColumnAutoWidth = False
        Me.BGVProduct.OptionsView.RowAutoHeight = True
        Me.BGVProduct.OptionsView.ShowFooter = True
        Me.BGVProduct.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BtnLoadDetailPD
        '
        Me.BtnLoadDetailPD.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnLoadDetailPD.Location = New System.Drawing.Point(20, 2)
        Me.BtnLoadDetailPD.Name = "BtnLoadDetailPD"
        Me.BtnLoadDetailPD.Size = New System.Drawing.Size(779, 34)
        Me.BtnLoadDetailPD.TabIndex = 40
        Me.BtnLoadDetailPD.Text = "Load Detail"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCreate)
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.BMark)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(20, 176)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(779, 37)
        Me.PanelControl1.TabIndex = 3
        '
        'BCreate
        '
        Me.BCreate.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCreate.Enabled = False
        Me.BCreate.Location = New System.Drawing.Point(617, 2)
        Me.BCreate.Name = "BCreate"
        Me.BCreate.Size = New System.Drawing.Size(85, 33)
        Me.BCreate.TabIndex = 2
        Me.BCreate.Text = "Create PO"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.Enabled = False
        Me.BPrint.Location = New System.Drawing.Point(702, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(75, 33)
        Me.BPrint.TabIndex = 1
        Me.BPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 33)
        Me.BMark.TabIndex = 0
        Me.BMark.Text = "Mark"
        '
        'XTCLineList
        '
        Me.XTCLineList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCLineList.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCLineList.Location = New System.Drawing.Point(0, 0)
        Me.XTCLineList.Name = "XTCLineList"
        Me.XTCLineList.SelectedTabPage = Me.XTPPDList
        Me.XTCLineList.Size = New System.Drawing.Size(807, 484)
        Me.XTCLineList.TabIndex = 4
        Me.XTCLineList.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPDList})
        '
        'XTPPDList
        '
        Me.XTPPDList.Controls.Add(Me.GroupControlProdNumber)
        Me.XTPPDList.Controls.Add(Me.GroupControl1)
        Me.XTPPDList.Name = "XTPPDList"
        Me.XTPPDList.Size = New System.Drawing.Size(801, 456)
        Me.XTPPDList.Text = "Transaction List"
        '
        'FormProdDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 484)
        Me.Controls.Add(Me.XTCLineList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemand"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Demand"
        CType(Me.GroupControlProdNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProdNumber.ResumeLayout(False)
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.XTCLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCLineList.ResumeLayout(False)
        Me.XTPPDList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControlProdNumber As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProdDemand As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdDemand As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProdDemand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDemandNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCreate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVProduct As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnLoadDetailPD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCLineList As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPDList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumnRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPDDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPD As DevExpress.XtraGrid.Columns.GridColumn
End Class
