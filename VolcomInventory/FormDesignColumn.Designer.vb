<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignColumn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignColumn))
        Me.GCDesignColumn = New DevExpress.XtraGrid.GridControl()
        Me.GVDesignColumn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DropDownButtonValue = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenuValue = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarButtonItemAddValue = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemEditValue = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItemAddColumn = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemEditColumn = New DevExpress.XtraBars.BarButtonItem()
        Me.DropDownButtonColumn = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenuColumn = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SLUEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCDesignColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesignColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PopupMenuValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCDesignColumn
        '
        Me.GCDesignColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesignColumn.Location = New System.Drawing.Point(0, 52)
        Me.GCDesignColumn.MainView = Me.GVDesignColumn
        Me.GCDesignColumn.Name = "GCDesignColumn"
        Me.GCDesignColumn.Size = New System.Drawing.Size(784, 509)
        Me.GCDesignColumn.TabIndex = 0
        Me.GCDesignColumn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesignColumn})
        '
        'GVDesignColumn
        '
        Me.GVDesignColumn.GridControl = Me.GCDesignColumn
        Me.GVDesignColumn.Name = "GVDesignColumn"
        Me.GVDesignColumn.OptionsBehavior.Editable = False
        Me.GVDesignColumn.OptionsView.ColumnAutoWidth = False
        Me.GVDesignColumn.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DropDownButtonValue)
        Me.PanelControl1.Controls.Add(Me.DropDownButtonColumn)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.SLUEType)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 52)
        Me.PanelControl1.TabIndex = 1
        '
        'DropDownButtonValue
        '
        Me.DropDownButtonValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DropDownButtonValue.DropDownControl = Me.PopupMenuValue
        Me.DropDownButtonValue.Image = CType(resources.GetObject("DropDownButtonValue.Image"), System.Drawing.Image)
        Me.DropDownButtonValue.Location = New System.Drawing.Point(560, 14)
        Me.DropDownButtonValue.Name = "DropDownButtonValue"
        Me.DropDownButtonValue.Size = New System.Drawing.Size(103, 23)
        Me.DropDownButtonValue.TabIndex = 5
        Me.DropDownButtonValue.Text = "Value"
        '
        'PopupMenuValue
        '
        Me.PopupMenuValue.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemAddValue), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEditValue)})
        Me.PopupMenuValue.Manager = Me.BarManager
        Me.PopupMenuValue.Name = "PopupMenuValue"
        '
        'BarButtonItemAddValue
        '
        Me.BarButtonItemAddValue.Caption = "Add"
        Me.BarButtonItemAddValue.Id = 0
        Me.BarButtonItemAddValue.Name = "BarButtonItemAddValue"
        '
        'BarButtonItemEditValue
        '
        Me.BarButtonItemEditValue.Caption = "Edit"
        Me.BarButtonItemEditValue.Id = 1
        Me.BarButtonItemEditValue.Name = "BarButtonItemEditValue"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItemAddValue, Me.BarButtonItemEditValue, Me.BarButtonItemAddColumn, Me.BarButtonItemEditColumn})
        Me.BarManager.MaxItemId = 4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(784, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 561)
        Me.barDockControlBottom.Size = New System.Drawing.Size(784, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 561)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(784, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 561)
        '
        'BarButtonItemAddColumn
        '
        Me.BarButtonItemAddColumn.Caption = "Add"
        Me.BarButtonItemAddColumn.Id = 2
        Me.BarButtonItemAddColumn.Name = "BarButtonItemAddColumn"
        '
        'BarButtonItemEditColumn
        '
        Me.BarButtonItemEditColumn.Caption = "Edit"
        Me.BarButtonItemEditColumn.Id = 3
        Me.BarButtonItemEditColumn.Name = "BarButtonItemEditColumn"
        '
        'DropDownButtonColumn
        '
        Me.DropDownButtonColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DropDownButtonColumn.DropDownControl = Me.PopupMenuColumn
        Me.DropDownButtonColumn.Image = CType(resources.GetObject("DropDownButtonColumn.Image"), System.Drawing.Image)
        Me.DropDownButtonColumn.Location = New System.Drawing.Point(669, 14)
        Me.DropDownButtonColumn.Name = "DropDownButtonColumn"
        Me.DropDownButtonColumn.Size = New System.Drawing.Size(103, 23)
        Me.DropDownButtonColumn.TabIndex = 4
        Me.DropDownButtonColumn.Text = "Column"
        '
        'PopupMenuColumn
        '
        Me.PopupMenuColumn.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemAddColumn), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEditColumn)})
        Me.PopupMenuColumn.Manager = Me.BarManager
        Me.PopupMenuColumn.Name = "PopupMenuColumn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Type"
        '
        'SLUEType
        '
        Me.SLUEType.Location = New System.Drawing.Point(53, 16)
        Me.SLUEType.Name = "SLUEType"
        Me.SLUEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEType.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEType.Size = New System.Drawing.Size(200, 20)
        Me.SLUEType.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Type"
        Me.GridColumn1.FieldName = "code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "id_code_detail_front"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn3"
        Me.GridColumn3.FieldName = "id_code_detail_end"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'FormDesignColumn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCDesignColumn)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FormDesignColumn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Column"
        CType(Me.GCDesignColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesignColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PopupMenuValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GCDesignColumn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesignColumn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DropDownButtonValue As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButtonColumn As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PopupMenuValue As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarButtonItemAddValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemEditValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItemAddColumn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemEditColumn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuColumn As DevExpress.XtraBars.PopupMenu
End Class
