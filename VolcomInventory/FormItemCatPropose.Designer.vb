<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemCatPropose
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
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCCat = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPItemCat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCItemCat = New DevExpress.XtraGrid.GridControl()
        Me.GVItemCat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPItemCatPropose = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCCat.SuspendLayout()
        Me.XTPItemCat.SuspendLayout()
        CType(Me.GCItemCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPItemCatPropose.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(945, 500)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_item_cat_propose"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "created_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'XTCCat
        '
        Me.XTCCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCCat.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCCat.Location = New System.Drawing.Point(0, 0)
        Me.XTCCat.Name = "XTCCat"
        Me.XTCCat.SelectedTabPage = Me.XTPItemCat
        Me.XTCCat.Size = New System.Drawing.Size(951, 528)
        Me.XTCCat.TabIndex = 1
        Me.XTCCat.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPItemCat, Me.XTPItemCatPropose})
        '
        'XTPItemCat
        '
        Me.XTPItemCat.Controls.Add(Me.GCItemCat)
        Me.XTPItemCat.Name = "XTPItemCat"
        Me.XTPItemCat.Size = New System.Drawing.Size(945, 500)
        Me.XTPItemCat.Text = "Budget Category"
        '
        'GCItemCat
        '
        Me.GCItemCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemCat.Location = New System.Drawing.Point(0, 0)
        Me.GCItemCat.MainView = Me.GVItemCat
        Me.GCItemCat.Name = "GCItemCat"
        Me.GCItemCat.Size = New System.Drawing.Size(945, 500)
        Me.GCItemCat.TabIndex = 1
        Me.GCItemCat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemCat})
        '
        'GVItemCat
        '
        Me.GVItemCat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.GVItemCat.GridControl = Me.GCItemCat
        Me.GVItemCat.Name = "GVItemCat"
        Me.GVItemCat.OptionsBehavior.Editable = False
        Me.GVItemCat.OptionsFind.AlwaysVisible = True
        Me.GVItemCat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id"
        Me.GridColumn6.FieldName = "id_item_cat"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Expense Type"
        Me.GridColumn7.FieldName = "expense_type"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Category"
        Me.GridColumn8.FieldName = "item_cat"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Category (En)"
        Me.GridColumn9.FieldName = "item_cat_en"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'XTPItemCatPropose
        '
        Me.XTPItemCatPropose.Controls.Add(Me.GCData)
        Me.XTPItemCatPropose.Name = "XTPItemCatPropose"
        Me.XTPItemCatPropose.Size = New System.Drawing.Size(945, 500)
        Me.XTPItemCatPropose.Text = "Setup Budget Category"
        '
        'FormItemCatPropose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 528)
        Me.Controls.Add(Me.XTCCat)
        Me.Name = "FormItemCatPropose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Category"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCCat.ResumeLayout(False)
        Me.XTPItemCat.ResumeLayout(False)
        CType(Me.GCItemCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPItemCatPropose.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCCat As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPItemCat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCItemCat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemCat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPItemCatPropose As DevExpress.XtraTab.XtraTabPage
End Class
