<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandRevBreakSize
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl()
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNew = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPOld = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDataOld = New DevExpress.XtraGrid.GridControl()
        Me.GVDataOld = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPNew.SuspendLayout()
        Me.XTPOld.SuspendLayout()
        CType(Me.GCDataOld, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDataOld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(423, 66)
        Me.PanelControl1.TabIndex = 36
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 37)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(54, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Code : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(134, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "[NAMA ARTIKEL]"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(417, 279)
        Me.GCData.TabIndex = 37
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProduct, Me.GridColumnsize, Me.GridColumnQty})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "id_product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 0
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 1
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 66)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPNew
        Me.XTCData.Size = New System.Drawing.Size(423, 307)
        Me.XTCData.TabIndex = 38
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNew, Me.XTPOld})
        '
        'XTPNew
        '
        Me.XTPNew.Controls.Add(Me.GCData)
        Me.XTPNew.Name = "XTPNew"
        Me.XTPNew.Size = New System.Drawing.Size(417, 279)
        Me.XTPNew.Text = "New"
        '
        'XTPOld
        '
        Me.XTPOld.Controls.Add(Me.GCDataOld)
        Me.XTPOld.Name = "XTPOld"
        Me.XTPOld.Size = New System.Drawing.Size(417, 279)
        Me.XTPOld.Text = "Old"
        '
        'GCDataOld
        '
        Me.GCDataOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDataOld.Location = New System.Drawing.Point(0, 0)
        Me.GCDataOld.MainView = Me.GVDataOld
        Me.GCDataOld.Name = "GCDataOld"
        Me.GCDataOld.Size = New System.Drawing.Size(417, 279)
        Me.GCDataOld.TabIndex = 38
        Me.GCDataOld.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDataOld})
        '
        'GVDataOld
        '
        Me.GVDataOld.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVDataOld.GridControl = Me.GCDataOld
        Me.GVDataOld.Name = "GVDataOld"
        Me.GVDataOld.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDataOld.OptionsBehavior.Editable = False
        Me.GVDataOld.OptionsView.ShowFooter = True
        Me.GVDataOld.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_product"
        Me.GridColumn1.FieldName = "id_product"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Size"
        Me.GridColumn2.FieldName = "size"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Qty"
        Me.GridColumn3.DisplayFormat.FormatString = "N0"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "qty"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'FormProdDemandRevBreakSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 373)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandRevBreakSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Breakdown size"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPNew.ResumeLayout(False)
        Me.XTPOld.ResumeLayout(False)
        CType(Me.GCDataOld, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDataOld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNew As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOld As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDataOld As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDataOld As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
