<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewProdDemand
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
        Me.components = New System.ComponentModel.Container()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelStatus = New DevExpress.XtraEditors.LabelControl()
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl()
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.BGVProduct = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControlCompleted = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditShowNonActive = New DevExpress.XtraEditors.CheckEdit()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.XTCPD = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPRevision = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdProdDemandRev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRevCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPDNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSTT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewBreakdownSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlCompleted.SuspendLayout()
        CType(Me.CheckEditShowNonActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPD.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        Me.XTPRevision.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelStatus)
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(830, 91)
        Me.PanelControl1.TabIndex = 35
        '
        'LabelStatus
        '
        Me.LabelStatus.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(12, 59)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(61, 15)
        Me.LabelStatus.TabIndex = 31
        Me.LabelStatus.Text = "Status : xxx"
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 38)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(66, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Season : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(122, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "PD/12/3/4/5/6"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.BMark)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 430)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(830, 60)
        Me.GroupControl1.TabIndex = 148
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleButton1.Location = New System.Drawing.Point(20, 32)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(808, 26)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Attachment"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Top
        Me.BMark.Location = New System.Drawing.Point(20, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(808, 30)
        Me.BMark.TabIndex = 5
        Me.BMark.Text = "Mark"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCProduct)
        Me.GroupControl2.Controls.Add(Me.PanelControlCompleted)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(824, 311)
        Me.GroupControl2.TabIndex = 149
        '
        'GCProduct
        '
        Me.GCProduct.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(20, 34)
        Me.GCProduct.MainView = Me.BGVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(802, 275)
        Me.GCProduct.TabIndex = 40
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVProduct})
        '
        'BGVProduct
        '
        Me.BGVProduct.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn2})
        Me.BGVProduct.GridControl = Me.GCProduct
        Me.BGVProduct.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.BGVProduct.Name = "BGVProduct"
        Me.BGVProduct.OptionsBehavior.ReadOnly = True
        Me.BGVProduct.OptionsCustomization.AllowRowSizing = True
        Me.BGVProduct.OptionsView.ShowFooter = True
        Me.BGVProduct.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        '
        'PanelControlCompleted
        '
        Me.PanelControlCompleted.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlCompleted.Controls.Add(Me.CheckEditShowNonActive)
        Me.PanelControlCompleted.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlCompleted.Location = New System.Drawing.Point(20, 2)
        Me.PanelControlCompleted.Name = "PanelControlCompleted"
        Me.PanelControlCompleted.Size = New System.Drawing.Size(802, 32)
        Me.PanelControlCompleted.TabIndex = 42
        Me.PanelControlCompleted.Visible = False
        '
        'CheckEditShowNonActive
        '
        Me.CheckEditShowNonActive.Location = New System.Drawing.Point(8, 6)
        Me.CheckEditShowNonActive.Name = "CheckEditShowNonActive"
        Me.CheckEditShowNonActive.Properties.Caption = "show non active status"
        Me.CheckEditShowNonActive.Size = New System.Drawing.Size(150, 19)
        Me.CheckEditShowNonActive.TabIndex = 164
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = -1
        '
        'XTCPD
        '
        Me.XTCPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPD.Location = New System.Drawing.Point(0, 91)
        Me.XTCPD.Name = "XTCPD"
        Me.XTCPD.SelectedTabPage = Me.XTPDetail
        Me.XTCPD.Size = New System.Drawing.Size(830, 339)
        Me.XTCPD.TabIndex = 190
        Me.XTCPD.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDetail, Me.XTPRevision})
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GroupControl2)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(824, 311)
        Me.XTPDetail.Text = "Detail"
        '
        'XTPRevision
        '
        Me.XTPRevision.Controls.Add(Me.GCData)
        Me.XTPRevision.Name = "XTPRevision"
        Me.XTPRevision.PageVisible = False
        Me.XTPRevision.Size = New System.Drawing.Size(824, 311)
        Me.XTPRevision.Text = "Revision"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(824, 311)
        Me.GCData.TabIndex = 1
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
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewBreakdownSizeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(183, 26)
        '
        'ViewBreakdownSizeToolStripMenuItem
        '
        Me.ViewBreakdownSizeToolStripMenuItem.Name = "ViewBreakdownSizeToolStripMenuItem"
        Me.ViewBreakdownSizeToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ViewBreakdownSizeToolStripMenuItem.Text = "view breakdown size"
        '
        'FormViewProdDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 490)
        Me.Controls.Add(Me.XTCPD)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormViewProdDemand"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Demand"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlCompleted.ResumeLayout(False)
        CType(Me.CheckEditShowNonActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPD.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        Me.XTPRevision.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BGVProduct As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LabelStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlCompleted As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditShowNonActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XTCPD As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRevision As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProdDemandRev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRevCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPDNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSTT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewBreakdownSizeToolStripMenuItem As ToolStripMenuItem
End Class
