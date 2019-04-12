<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingAcc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingAcc))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.MEAccDesc = New DevExpress.XtraEditors.MemoEdit()
        Me.TEAccount = New DevExpress.XtraEditors.TextEdit()
        Me.SLEParentAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnACc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LEActive = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LEAccCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDetail = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEAccountDetail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.EPACC = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEParentAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEAccCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAccountDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPACC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 237)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(665, 36)
        Me.PanelControl1.TabIndex = 0
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(513, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 32)
        Me.BCancel.TabIndex = 1
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(588, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 32)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.MEAccDesc)
        Me.PanelControl3.Controls.Add(Me.TEAccount)
        Me.PanelControl3.Controls.Add(Me.SLEParentAccount)
        Me.PanelControl3.Controls.Add(Me.LEActive)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Controls.Add(Me.LEAccCat)
        Me.PanelControl3.Controls.Add(Me.LabelControl6)
        Me.PanelControl3.Controls.Add(Me.LEDetail)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.TEAccountDetail)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(665, 237)
        Me.PanelControl3.TabIndex = 54
        '
        'MEAccDesc
        '
        Me.MEAccDesc.Location = New System.Drawing.Point(130, 85)
        Me.MEAccDesc.Name = "MEAccDesc"
        Me.MEAccDesc.Size = New System.Drawing.Size(492, 45)
        Me.MEAccDesc.TabIndex = 120
        '
        'TEAccount
        '
        Me.TEAccount.Location = New System.Drawing.Point(130, 51)
        Me.TEAccount.Name = "TEAccount"
        Me.TEAccount.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEAccount.Properties.Appearance.Options.UseFont = True
        Me.TEAccount.Properties.ReadOnly = True
        Me.TEAccount.Size = New System.Drawing.Size(134, 22)
        Me.TEAccount.TabIndex = 119
        '
        'SLEParentAccount
        '
        Me.SLEParentAccount.EditValue = "No Parent Account"
        Me.SLEParentAccount.Location = New System.Drawing.Point(270, 52)
        Me.SLEParentAccount.Name = "SLEParentAccount"
        Me.SLEParentAccount.Properties.Appearance.Options.UseTextOptions = True
        Me.SLEParentAccount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SLEParentAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEParentAccount.Properties.NullText = "No Parent Account"
        Me.SLEParentAccount.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEParentAccount.Size = New System.Drawing.Size(168, 20)
        Me.SLEParentAccount.TabIndex = 118
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAcc, Me.GridColumnACc, Me.GridColumnDesc, Me.GridColumnIdCat, Me.GridColumnCat})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAcc
        '
        Me.GridColumnIdAcc.Caption = "Id Acc"
        Me.GridColumnIdAcc.FieldName = "id_acc"
        Me.GridColumnIdAcc.Name = "GridColumnIdAcc"
        '
        'GridColumnACc
        '
        Me.GridColumnACc.Caption = "Account"
        Me.GridColumnACc.FieldName = "acc_name"
        Me.GridColumnACc.Name = "GridColumnACc"
        Me.GridColumnACc.Visible = True
        Me.GridColumnACc.VisibleIndex = 0
        Me.GridColumnACc.Width = 100
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "acc_description"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 1
        Me.GridColumnDesc.Width = 190
        '
        'GridColumnIdCat
        '
        Me.GridColumnIdCat.Caption = "Id Cat"
        Me.GridColumnIdCat.FieldName = "id_acc_cat"
        Me.GridColumnIdCat.Name = "GridColumnIdCat"
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "acc_cat"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 2
        Me.GridColumnCat.Width = 94
        '
        'LEActive
        '
        Me.LEActive.Location = New System.Drawing.Point(130, 180)
        Me.LEActive.Name = "LEActive"
        Me.LEActive.Properties.Appearance.Options.UseTextOptions = True
        Me.LEActive.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEActive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEActive.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_status", "id_status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("status", "Status")})
        Me.LEActive.Properties.NullText = ""
        Me.LEActive.Properties.ShowFooter = False
        Me.LEActive.Size = New System.Drawing.Size(134, 20)
        Me.LEActive.TabIndex = 117
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(18, 182)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(33, 15)
        Me.LabelControl8.TabIndex = 116
        Me.LabelControl8.Text = "Active"
        '
        'LEAccCat
        '
        Me.LEAccCat.Location = New System.Drawing.Point(130, 16)
        Me.LEAccCat.Name = "LEAccCat"
        Me.LEAccCat.Properties.Appearance.Options.UseTextOptions = True
        Me.LEAccCat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEAccCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEAccCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_acc_cat", "id_acc_cat", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("acc_cat", "Account Categori")})
        Me.LEAccCat.Properties.NullText = ""
        Me.LEAccCat.Properties.ShowFooter = False
        Me.LEAccCat.Size = New System.Drawing.Size(134, 20)
        Me.LEAccCat.TabIndex = 115
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(18, 18)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(48, 15)
        Me.LabelControl6.TabIndex = 114
        Me.LabelControl6.Text = "Category"
        '
        'LEDetail
        '
        Me.LEDetail.Location = New System.Drawing.Point(130, 145)
        Me.LEDetail.Name = "LEDetail"
        Me.LEDetail.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDetail.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDetail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDetail.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_is_det", "id_is_det", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("is_det", "Type Account")})
        Me.LEDetail.Properties.NullText = ""
        Me.LEDetail.Properties.ShowFooter = False
        Me.LEDetail.Size = New System.Drawing.Size(134, 20)
        Me.LEDetail.TabIndex = 113
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(18, 87)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl5.TabIndex = 53
        Me.LabelControl5.Text = "Description"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(18, 54)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 15)
        Me.LabelControl1.TabIndex = 46
        Me.LabelControl1.Text = "Account"
        '
        'TEAccountDetail
        '
        Me.TEAccountDetail.Location = New System.Drawing.Point(444, 51)
        Me.TEAccountDetail.Name = "TEAccountDetail"
        Me.TEAccountDetail.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEAccountDetail.Properties.Appearance.Options.UseFont = True
        Me.TEAccountDetail.Size = New System.Drawing.Size(178, 22)
        Me.TEAccountDetail.TabIndex = 52
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(18, 147)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(33, 15)
        Me.LabelControl3.TabIndex = 48
        Me.LabelControl3.Text = "Detail"
        '
        'EPACC
        '
        Me.EPACC.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPACC.ContainerControl = Me
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'FormAccountingAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 273)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingAcc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accounting Account"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEParentAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEAccCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAccountDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPACC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MEAccDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEAccount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEParentAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LEActive As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEAccCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDetail As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEAccountDetail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnACc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EPACC As System.Windows.Forms.ErrorProvider
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
End Class
