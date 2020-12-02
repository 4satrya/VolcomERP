<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignImagesLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignImagesLog))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GCImageList = New DevExpress.XtraGrid.GridControl()
        Me.GVImageList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCImageList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVImageList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 45)
        Me.PanelControl1.TabIndex = 3
        '
        'SBCancel
        '
        Me.SBCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCancel.Image = CType(resources.GetObject("SBCancel.Image"), System.Drawing.Image)
        Me.SBCancel.Location = New System.Drawing.Point(682, 2)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(100, 41)
        Me.SBCancel.TabIndex = 1
        Me.SBCancel.Text = "Cancel"
        '
        'GCImageList
        '
        Me.GCImageList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCImageList.Location = New System.Drawing.Point(0, 0)
        Me.GCImageList.MainView = Me.GVImageList
        Me.GCImageList.Name = "GCImageList"
        Me.GCImageList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit, Me.RepositoryItemHyperLinkEdit, Me.RepositoryItemDateEdit})
        Me.GCImageList.Size = New System.Drawing.Size(784, 516)
        Me.GCImageList.TabIndex = 4
        Me.GCImageList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVImageList})
        '
        'GVImageList
        '
        Me.GVImageList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn7, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVImageList.GridControl = Me.GCImageList
        Me.GVImageList.Name = "GVImageList"
        Me.GVImageList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVImageList.OptionsBehavior.ReadOnly = True
        Me.GVImageList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "File Name"
        Me.GridColumn3.FieldName = "file_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "URL"
        Me.GridColumn7.ColumnEdit = Me.RepositoryItemHyperLinkEdit
        Me.GridColumn7.FieldName = "url"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        '
        'RepositoryItemHyperLinkEdit
        '
        Me.RepositoryItemHyperLinkEdit.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit.Name = "RepositoryItemHyperLinkEdit"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Uploaded At"
        Me.GridColumn4.ColumnEdit = Me.RepositoryItemDateEdit
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "created_at"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'RepositoryItemDateEdit
        '
        Me.RepositoryItemDateEdit.AutoHeight = False
        Me.RepositoryItemDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.RepositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.RepositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.RepositoryItemDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit.Name = "RepositoryItemDateEdit"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Uploaded By"
        Me.GridColumn5.FieldName = "created_by"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Image"
        Me.GridColumn6.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GridColumn6.FieldName = "image"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit.PictureGrayed = CType(resources.GetObject("RepositoryItemCheckEdit.PictureGrayed"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit.PictureUnchecked = CType(resources.GetObject("RepositoryItemCheckEdit.PictureUnchecked"), System.Drawing.Image)
        '
        'FormDesignImagesLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCImageList)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormDesignImagesLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Images Log"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCImageList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVImageList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCImageList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVImageList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
