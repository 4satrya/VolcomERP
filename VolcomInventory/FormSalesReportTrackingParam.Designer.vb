﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReportTrackingParam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReportTrackingParam))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelStore = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCodeCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNameCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.BtnBrowseContactFrom = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LERepArea = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEIsland = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LEGroupAccount = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPriceCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPromo = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LERepArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEIsland.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEGroupAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPriceCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 230)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(406, 37)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(245, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 33)
        Me.BtnCancel.TabIndex = 12
        Me.BtnCancel.TabStop = False
        Me.BtnCancel.Text = "Cancel"
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
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 13
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(320, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(84, 33)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Search"
        '
        'DEEnd
        '
        Me.DEEnd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(245, 9)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEnd.Size = New System.Drawing.Size(144, 20)
        Me.DEEnd.TabIndex = 8928
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(89, 9)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStart.Size = New System.Drawing.Size(140, 20)
        Me.DEStart.TabIndex = 8927
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 8929
        Me.LabelControl2.Text = "Periode"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(235, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 8930
        Me.LabelControl4.Text = "-"
        '
        'LabelStore
        '
        Me.LabelStore.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStore.Location = New System.Drawing.Point(12, 38)
        Me.LabelStore.Name = "LabelStore"
        Me.LabelStore.Size = New System.Drawing.Size(26, 13)
        Me.LabelStore.TabIndex = 8933
        Me.LabelStore.Text = "Store"
        '
        'TxtCodeCompFrom
        '
        Me.TxtCodeCompFrom.EditValue = ""
        Me.TxtCodeCompFrom.Location = New System.Drawing.Point(89, 35)
        Me.TxtCodeCompFrom.Name = "TxtCodeCompFrom"
        Me.TxtCodeCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompFrom.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.TxtCodeCompFrom.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.TxtCodeCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompFrom.Size = New System.Drawing.Size(79, 20)
        Me.TxtCodeCompFrom.TabIndex = 8932
        '
        'TxtNameCompFrom
        '
        Me.TxtNameCompFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameCompFrom.EditValue = ""
        Me.TxtNameCompFrom.Location = New System.Drawing.Point(174, 35)
        Me.TxtNameCompFrom.Name = "TxtNameCompFrom"
        Me.TxtNameCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompFrom.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.TxtNameCompFrom.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNameCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompFrom.Properties.ReadOnly = True
        Me.TxtNameCompFrom.Size = New System.Drawing.Size(186, 20)
        Me.TxtNameCompFrom.TabIndex = 8934
        Me.TxtNameCompFrom.TabStop = False
        '
        'BtnBrowseContactFrom
        '
        Me.BtnBrowseContactFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseContactFrom.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowseContactFrom.Appearance.Options.UseFont = True
        Me.BtnBrowseContactFrom.Location = New System.Drawing.Point(366, 35)
        Me.BtnBrowseContactFrom.Name = "BtnBrowseContactFrom"
        Me.BtnBrowseContactFrom.Size = New System.Drawing.Size(23, 20)
        Me.BtnBrowseContactFrom.TabIndex = 8931
        Me.BtnBrowseContactFrom.TabStop = False
        Me.BtnBrowseContactFrom.Text = "..."
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl21.TabIndex = 8936
        Me.LabelControl21.Text = "Rep Area"
        '
        'LERepArea
        '
        Me.LERepArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LERepArea.Location = New System.Drawing.Point(89, 61)
        Me.LERepArea.Name = "LERepArea"
        Me.LERepArea.Properties.Appearance.Options.UseTextOptions = True
        Me.LERepArea.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LERepArea.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LERepArea.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_employee", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_name", "Representative")})
        Me.LERepArea.Properties.NullText = ""
        Me.LERepArea.Properties.ShowFooter = False
        Me.LERepArea.Size = New System.Drawing.Size(300, 20)
        Me.LERepArea.TabIndex = 8935
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 90)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl1.TabIndex = 8938
        Me.LabelControl1.Text = "Island"
        '
        'LEIsland
        '
        Me.LEIsland.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEIsland.Location = New System.Drawing.Point(89, 87)
        Me.LEIsland.Name = "LEIsland"
        Me.LEIsland.Properties.Appearance.Options.UseTextOptions = True
        Me.LEIsland.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEIsland.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEIsland.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("island", "Island")})
        Me.LEIsland.Properties.NullText = ""
        Me.LEIsland.Properties.ShowFooter = False
        Me.LEIsland.Size = New System.Drawing.Size(300, 20)
        Me.LEIsland.TabIndex = 8937
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 116)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl3.TabIndex = 8940
        Me.LabelControl3.Text = "Group"
        '
        'LEGroupAccount
        '
        Me.LEGroupAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEGroupAccount.Location = New System.Drawing.Point(89, 113)
        Me.LEGroupAccount.Name = "LEGroupAccount"
        Me.LEGroupAccount.Properties.Appearance.Options.UseTextOptions = True
        Me.LEGroupAccount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEGroupAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEGroupAccount.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_comp_group", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("comp_group", "Group Account")})
        Me.LEGroupAccount.Properties.NullText = ""
        Me.LEGroupAccount.Properties.ShowFooter = False
        Me.LEGroupAccount.Size = New System.Drawing.Size(300, 20)
        Me.LEGroupAccount.TabIndex = 8939
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 142)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl5.TabIndex = 8942
        Me.LabelControl5.Text = "Price Category"
        '
        'LEPriceCat
        '
        Me.LEPriceCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEPriceCat.Location = New System.Drawing.Point(89, 139)
        Me.LEPriceCat.Name = "LEPriceCat"
        Me.LEPriceCat.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPriceCat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPriceCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPriceCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_design_cat", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("design_cat", "Price Category")})
        Me.LEPriceCat.Properties.NullText = ""
        Me.LEPriceCat.Properties.ShowFooter = False
        Me.LEPriceCat.Size = New System.Drawing.Size(300, 20)
        Me.LEPriceCat.TabIndex = 8941
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 168)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl6.TabIndex = 8944
        Me.LabelControl6.Text = "Promo"
        '
        'LEPromo
        '
        Me.LEPromo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEPromo.Location = New System.Drawing.Point(89, 165)
        Me.LEPromo.Name = "LEPromo"
        Me.LEPromo.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPromo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPromo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPromo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_promo", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("promo", "Promo")})
        Me.LEPromo.Properties.NullText = ""
        Me.LEPromo.Properties.ShowFooter = False
        Me.LEPromo.Size = New System.Drawing.Size(300, 20)
        Me.LEPromo.TabIndex = 8943
        '
        'FormSalesReportTrackingParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 267)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LEPromo)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LEPriceCat)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LEGroupAccount)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LEIsland)
        Me.Controls.Add(Me.LabelControl21)
        Me.Controls.Add(Me.LERepArea)
        Me.Controls.Add(Me.LabelStore)
        Me.Controls.Add(Me.TxtCodeCompFrom)
        Me.Controls.Add(Me.TxtNameCompFrom)
        Me.Controls.Add(Me.BtnBrowseContactFrom)
        Me.Controls.Add(Me.DEEnd)
        Me.Controls.Add(Me.DEStart)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReportTrackingParam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parameter"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LERepArea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEIsland.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEGroupAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPriceCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelStore As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCodeCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNameCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnBrowseContactFrom As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LERepArea As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEIsland As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEGroupAccount As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPriceCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPromo As DevExpress.XtraEditors.LookUpEdit
End Class
