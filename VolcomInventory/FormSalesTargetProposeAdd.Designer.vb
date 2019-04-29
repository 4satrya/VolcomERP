<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesTargetProposeAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesTargetProposeAdd))
        Me.XTCStore = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPExisting = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCloseStoreExisting = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAddStoreExisting = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPNew = New DevExpress.XtraTab.XtraTabPage()
        Me.GridColumnStoreType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStore.SuspendLayout()
        Me.XTPExisting.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCStore
        '
        Me.XTCStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStore.Location = New System.Drawing.Point(0, 0)
        Me.XTCStore.Name = "XTCStore"
        Me.XTCStore.SelectedTabPage = Me.XTPExisting
        Me.XTCStore.Size = New System.Drawing.Size(724, 455)
        Me.XTCStore.TabIndex = 0
        Me.XTCStore.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPExisting, Me.XTPNew})
        '
        'XTPExisting
        '
        Me.XTPExisting.Controls.Add(Me.GCData)
        Me.XTPExisting.Controls.Add(Me.PanelControl1)
        Me.XTPExisting.Name = "XTPExisting"
        Me.XTPExisting.Size = New System.Drawing.Size(718, 427)
        Me.XTPExisting.Text = "Existing Store"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(718, 383)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompNumber, Me.GridColumnCompName, Me.GridColumnIsSelect, Me.GridColumnStoreType})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "Store Account"
        Me.GridColumnCompNumber.FieldName = "comp_number"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        Me.GridColumnCompNumber.OptionsColumn.ReadOnly = True
        Me.GridColumnCompNumber.Visible = True
        Me.GridColumnCompNumber.VisibleIndex = 0
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Store"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.OptionsColumn.ReadOnly = True
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 1
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsSelect.Caption = "Select"
        Me.GridColumnIsSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        Me.GridColumnIsSelect.Visible = True
        Me.GridColumnIsSelect.VisibleIndex = 3
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCloseStoreExisting)
        Me.PanelControl1.Controls.Add(Me.BtnAddStoreExisting)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 383)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(718, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCloseStoreExisting
        '
        Me.BtnCloseStoreExisting.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCloseStoreExisting.Image = CType(resources.GetObject("BtnCloseStoreExisting.Image"), System.Drawing.Image)
        Me.BtnCloseStoreExisting.Location = New System.Drawing.Point(538, 2)
        Me.BtnCloseStoreExisting.Name = "BtnCloseStoreExisting"
        Me.BtnCloseStoreExisting.Size = New System.Drawing.Size(89, 40)
        Me.BtnCloseStoreExisting.TabIndex = 1
        Me.BtnCloseStoreExisting.Text = "Close"
        '
        'BtnAddStoreExisting
        '
        Me.BtnAddStoreExisting.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddStoreExisting.Image = CType(resources.GetObject("BtnAddStoreExisting.Image"), System.Drawing.Image)
        Me.BtnAddStoreExisting.Location = New System.Drawing.Point(627, 2)
        Me.BtnAddStoreExisting.Name = "BtnAddStoreExisting"
        Me.BtnAddStoreExisting.Size = New System.Drawing.Size(89, 40)
        Me.BtnAddStoreExisting.TabIndex = 0
        Me.BtnAddStoreExisting.Text = "Add"
        '
        'XTPNew
        '
        Me.XTPNew.Name = "XTPNew"
        Me.XTPNew.Size = New System.Drawing.Size(718, 427)
        Me.XTPNew.Text = "New Store"
        '
        'GridColumnStoreType
        '
        Me.GridColumnStoreType.Caption = "Store Type"
        Me.GridColumnStoreType.FieldName = "store_type"
        Me.GridColumnStoreType.Name = "GridColumnStoreType"
        Me.GridColumnStoreType.OptionsColumn.ReadOnly = True
        Me.GridColumnStoreType.Visible = True
        Me.GridColumnStoreType.VisibleIndex = 2
        '
        'FormSalesTargetProposeAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 455)
        Me.Controls.Add(Me.XTCStore)
        Me.MinimizeBox = False
        Me.Name = "FormSalesTargetProposeAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Store"
        CType(Me.XTCStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStore.ResumeLayout(False)
        Me.XTPExisting.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStore As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPExisting As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPNew As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCloseStoreExisting As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddStoreExisting As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnStoreType As DevExpress.XtraGrid.Columns.GridColumn
End Class
