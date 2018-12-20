<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemReqAddStore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemReqAddStore))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEItem = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAvailable = New DevExpress.XtraEditors.TextEdit()
        CType(Me.SLECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAvailable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Category"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(194, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 23
        Me.LabelControl2.Text = "Item"
        '
        'SLECat
        '
        Me.SLECat.Location = New System.Drawing.Point(17, 34)
        Me.SLECat.Name = "SLECat"
        Me.SLECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECat.Properties.ShowClearButton = False
        Me.SLECat.Properties.View = Me.SearchLookUpEdit1View
        Me.SLECat.Size = New System.Drawing.Size(173, 20)
        Me.SLECat.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnItemCat})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "GridColumn1"
        Me.GridColumnId.FieldName = "id_item_cat"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnItemCat
        '
        Me.GridColumnItemCat.Caption = "Category"
        Me.GridColumnItemCat.FieldName = "item_cat"
        Me.GridColumnItemCat.Name = "GridColumnItemCat"
        Me.GridColumnItemCat.Visible = True
        Me.GridColumnItemCat.VisibleIndex = 0
        '
        'SLEItem
        '
        Me.SLEItem.Location = New System.Drawing.Point(194, 34)
        Me.SLEItem.Name = "SLEItem"
        Me.SLEItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEItem.Properties.ShowClearButton = False
        Me.SLEItem.Properties.View = Me.GridView1
        Me.SLEItem.Size = New System.Drawing.Size(239, 20)
        Me.SLEItem.TabIndex = 1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnItemDesc})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_item"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnItemDesc
        '
        Me.GridColumnItemDesc.Caption = "Item"
        Me.GridColumnItemDesc.FieldName = "item_desc"
        Me.GridColumnItemDesc.Name = "GridColumnItemDesc"
        Me.GridColumnItemDesc.Visible = True
        Me.GridColumnItemDesc.VisibleIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 207)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(563, 48)
        Me.PanelControl1.TabIndex = 100
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(394, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(83, 44)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "Close"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(477, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(84, 44)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Add"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 65)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl3.TabIndex = 25
        Me.LabelControl3.Text = "Store"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(17, 84)
        Me.SLEStore.Name = "SLEStore"
        Me.SLEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStore.Properties.NullText = "- Select Store -"
        Me.SLEStore.Properties.ShowClearButton = False
        Me.SLEStore.Properties.View = Me.GridView2
        Me.SLEStore.Size = New System.Drawing.Size(416, 20)
        Me.SLEStore.TabIndex = 2
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdComp, Me.GridColumnCompName, Me.GridColumnCompNumber, Me.GridColumnComp})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "GridColumn2"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Store Name"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "Store Code"
        Me.GridColumnCompNumber.FieldName = "comp_number"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        '
        'GridColumnComp
        '
        Me.GridColumnComp.Caption = "Store"
        Me.GridColumnComp.FieldName = "comp"
        Me.GridColumnComp.Name = "GridColumnComp"
        Me.GridColumnComp.Visible = True
        Me.GridColumnComp.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(439, 65)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl4.TabIndex = 27
        Me.LabelControl4.Text = "Qty"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(439, 84)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtQty.Properties.Mask.EditMask = "N2"
        Me.TxtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtQty.Size = New System.Drawing.Size(106, 20)
        Me.TxtQty.TabIndex = 3
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(17, 133)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(528, 51)
        Me.MENote.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 114)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl5.TabIndex = 102
        Me.LabelControl5.Text = "Remark"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(439, 19)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl6.TabIndex = 103
        Me.LabelControl6.Text = "Available"
        '
        'TxtAvailable
        '
        Me.TxtAvailable.Enabled = False
        Me.TxtAvailable.Location = New System.Drawing.Point(439, 34)
        Me.TxtAvailable.Name = "TxtAvailable"
        Me.TxtAvailable.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAvailable.Properties.Appearance.Options.UseFont = True
        Me.TxtAvailable.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtAvailable.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAvailable.Properties.Mask.EditMask = "N0"
        Me.TxtAvailable.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAvailable.Size = New System.Drawing.Size(106, 20)
        Me.TxtAvailable.TabIndex = 104
        '
        'FormItemReqAddStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 255)
        Me.Controls.Add(Me.TxtAvailable)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.SLEStore)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SLEItem)
        Me.Controls.Add(Me.SLECat)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormItemReqAddStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add"
        CType(Me.SLECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAvailable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SLEItem As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLECat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAvailable As DevExpress.XtraEditors.TextEdit
End Class
