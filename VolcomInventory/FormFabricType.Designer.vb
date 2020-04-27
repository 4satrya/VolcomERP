<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFabricType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFabricType))
        Me.PanelControlNavLineList = New DevExpress.XtraEditors.PanelControl()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavLineList.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNavLineList
        '
        Me.PanelControlNavLineList.Controls.Add(Me.BAdd)
        Me.PanelControlNavLineList.Controls.Add(Me.BEdit)
        Me.PanelControlNavLineList.Controls.Add(Me.BtnView)
        Me.PanelControlNavLineList.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNavLineList.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNavLineList.Name = "PanelControlNavLineList"
        Me.PanelControlNavLineList.Size = New System.Drawing.Size(911, 40)
        Me.PanelControlNavLineList.TabIndex = 4
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Image = CType(resources.GetObject("BAdd.Image"), System.Drawing.Image)
        Me.BAdd.ImageIndex = 15
        Me.BAdd.Location = New System.Drawing.Point(738, 2)
        Me.BAdd.LookAndFeel.SkinName = "Metropolis"
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(80, 36)
        Me.BAdd.TabIndex = 96
        Me.BAdd.Text = "Add"
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.Image = CType(resources.GetObject("BEdit.Image"), System.Drawing.Image)
        Me.BEdit.ImageIndex = 15
        Me.BEdit.Location = New System.Drawing.Point(818, 2)
        Me.BEdit.LookAndFeel.SkinName = "Metropolis"
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(91, 36)
        Me.BEdit.TabIndex = 95
        Me.BEdit.Text = "Edit"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.ImageIndex = 15
        Me.BtnView.Location = New System.Drawing.Point(2, 2)
        Me.BtnView.LookAndFeel.SkinName = "Metropolis"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(106, 36)
        Me.BtnView.TabIndex = 94
        Me.BtnView.Text = "Refresh"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 40)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(911, 483)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_design, Me.GridColumncode, Me.GridColumnName, Me.GridColumn1})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_design
        '
        Me.GridColumnid_design.Caption = "id"
        Me.GridColumnid_design.FieldName = "id_fabric_type"
        Me.GridColumnid_design.Name = "GridColumnid_design"
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Fabric Type"
        Me.GridColumncode.FieldName = "fabric_type_name"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Fabrication"
        Me.GridColumnName.FieldName = "fabrication"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Age"
        Me.GridColumn1.FieldName = "age"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'FormFabricType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 523)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNavLineList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFabricType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fabric Type"
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavLineList.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
