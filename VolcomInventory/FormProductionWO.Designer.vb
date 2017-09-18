<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProductionWO
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionWO))
        Me.EPMatWO = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.BReviseWO = New DevExpress.XtraEditors.SimpleButton()
        Me.ImgBut = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupGeneralFooter = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.METotSay = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.TEVat = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.TEGrossTot = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LEpayment = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.TETot = New DevExpress.XtraEditors.TextEdit()
        Me.TEVatTot = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.BSearchCompShipTo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.MECompShipToAddress = New DevExpress.XtraEditors.MemoEdit()
        Me.TECompShipToName = New DevExpress.XtraEditors.TextEdit()
        Me.TECompShipTo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.GConListPurchase = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl()
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.DEDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.DEDateNow = New DevExpress.XtraEditors.DateEdit()
        Me.DEEstRecDate = New DevExpress.XtraEditors.DateEdit()
        Me.CheckEditMainVendor = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDelDate = New DevExpress.XtraEditors.DateEdit()
        Me.TEWOCode = New DevExpress.XtraEditors.TextEdit()
        Me.BPickWO = New DevExpress.XtraEditors.SimpleButton()
        Me.TEWO = New DevExpress.XtraEditors.TextEdit()
        Me.TEDesignCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl27 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDesign = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDelivery = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TETOP = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TELeadTime = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TECompAttn = New DevExpress.XtraEditors.TextEdit()
        Me.MECompAddress = New DevExpress.XtraEditors.MemoEdit()
        Me.TECompName = New DevExpress.XtraEditors.TextEdit()
        Me.TECompCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEWONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.EPMatWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralFooter.SuspendLayout()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEGrossTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEpayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVatTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECompShipToAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompShipToName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompShipTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPurchase.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateNow.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateNow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEstRecDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEstRecDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditMainVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDelDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWOCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesignCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDelivery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETOP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompAttn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECompAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPMatWO
        '
        Me.EPMatWO.ContainerControl = Me
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BReviseWO)
        Me.GroupControl3.Controls.Add(Me.BtnAttachment)
        Me.GroupControl3.Controls.Add(Me.BMark)
        Me.GroupControl3.Controls.Add(Me.BPrint)
        Me.GroupControl3.Controls.Add(Me.BCancel)
        Me.GroupControl3.Controls.Add(Me.BSave)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 547)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(909, 35)
        Me.GroupControl3.TabIndex = 56
        '
        'BReviseWO
        '
        Me.BReviseWO.Dock = System.Windows.Forms.DockStyle.Left
        Me.BReviseWO.ImageIndex = 3
        Me.BReviseWO.ImageList = Me.ImgBut
        Me.BReviseWO.Location = New System.Drawing.Point(112, 2)
        Me.BReviseWO.Name = "BReviseWO"
        Me.BReviseWO.Size = New System.Drawing.Size(92, 31)
        Me.BReviseWO.TabIndex = 17
        Me.BReviseWO.Text = "Revise"
        '
        'ImgBut
        '
        Me.ImgBut.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImgBut.ImageStream = CType(resources.GetObject("ImgBut.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImgBut.Images.SetKeyName(0, "20_24x24.png")
        Me.ImgBut.Images.SetKeyName(1, "8_24x24.png")
        Me.ImgBut.Images.SetKeyName(2, "23_24x24.png")
        Me.ImgBut.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImgBut.Images.SetKeyName(4, "check_mark.png")
        Me.ImgBut.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImgBut.Images.SetKeyName(6, "printer_3.png")
        Me.ImgBut.Images.SetKeyName(7, "save.png")
        Me.ImgBut.Images.SetKeyName(8, "31_24x24.png")
        Me.ImgBut.Images.SetKeyName(9, "18_24x24.png")
        Me.ImgBut.Images.SetKeyName(10, "attachment-icon.png")
        Me.ImgBut.Images.SetKeyName(11, "document_32.png")
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 10
        Me.BtnAttachment.ImageList = Me.ImgBut
        Me.BtnAttachment.Location = New System.Drawing.Point(519, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(115, 31)
        Me.BtnAttachment.TabIndex = 16
        Me.BtnAttachment.Text = "Attachment"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.ImgBut
        Me.BMark.Location = New System.Drawing.Point(20, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(92, 31)
        Me.BMark.TabIndex = 4
        Me.BMark.Text = "Mark"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.ImgBut
        Me.BPrint.Location = New System.Drawing.Point(634, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(90, 31)
        Me.BPrint.TabIndex = 3
        Me.BPrint.Text = "Print"
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.ImgBut
        Me.BCancel.Location = New System.Drawing.Point(724, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(95, 31)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Enabled = False
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.ImgBut
        Me.BSave.Location = New System.Drawing.Point(819, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(88, 31)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'GroupGeneralFooter
        '
        Me.GroupGeneralFooter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl21)
        Me.GroupGeneralFooter.Controls.Add(Me.TEKurs)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl22)
        Me.GroupGeneralFooter.Controls.Add(Me.LECurrency)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl19)
        Me.GroupGeneralFooter.Controls.Add(Me.METotSay)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl18)
        Me.GroupGeneralFooter.Controls.Add(Me.MENote)
        Me.GroupGeneralFooter.Controls.Add(Me.TEVat)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl17)
        Me.GroupGeneralFooter.Controls.Add(Me.TEGrossTot)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl15)
        Me.GroupGeneralFooter.Controls.Add(Me.LEpayment)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl14)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl13)
        Me.GroupGeneralFooter.Controls.Add(Me.TETot)
        Me.GroupGeneralFooter.Controls.Add(Me.TEVatTot)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl20)
        Me.GroupGeneralFooter.Controls.Add(Me.BSearchCompShipTo)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl9)
        Me.GroupGeneralFooter.Controls.Add(Me.MECompShipToAddress)
        Me.GroupGeneralFooter.Controls.Add(Me.TECompShipToName)
        Me.GroupGeneralFooter.Controls.Add(Me.TECompShipTo)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl23)
        Me.GroupGeneralFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralFooter.Location = New System.Drawing.Point(0, 409)
        Me.GroupGeneralFooter.Name = "GroupGeneralFooter"
        Me.GroupGeneralFooter.Size = New System.Drawing.Size(909, 138)
        Me.GroupGeneralFooter.TabIndex = 55
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(407, 37)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl21.TabIndex = 146
        Me.LabelControl21.Text = "Kurs"
        '
        'TEKurs
        '
        Me.TEKurs.EditValue = "1"
        Me.TEKurs.Location = New System.Drawing.Point(482, 34)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(162, 20)
        Me.TEKurs.TabIndex = 145
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(765, 37)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl22.TabIndex = 144
        Me.LabelControl22.Text = "%"
        '
        'LECurrency
        '
        Me.LECurrency.Enabled = False
        Me.LECurrency.Location = New System.Drawing.Point(482, 8)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECurrency.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(162, 20)
        Me.LECurrency.TabIndex = 141
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(407, 90)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl19.TabIndex = 140
        Me.LabelControl19.Text = "Say"
        '
        'METotSay
        '
        Me.METotSay.Location = New System.Drawing.Point(482, 87)
        Me.METotSay.Name = "METotSay"
        Me.METotSay.Properties.MaxLength = 100
        Me.METotSay.Properties.ReadOnly = True
        Me.METotSay.Size = New System.Drawing.Size(402, 38)
        Me.METotSay.TabIndex = 139
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 11)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(77, 8)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(316, 41)
        Me.MENote.TabIndex = 137
        '
        'TEVat
        '
        Me.TEVat.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEVat.Location = New System.Drawing.Point(724, 32)
        Me.TEVat.Name = "TEVat"
        Me.TEVat.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEVat.Properties.Appearance.Options.UseFont = True
        Me.TEVat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TEVat.Properties.IsFloatValue = False
        Me.TEVat.Properties.Mask.EditMask = "N00"
        Me.TEVat.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.TEVat.Size = New System.Drawing.Size(35, 22)
        Me.TEVat.TabIndex = 136
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(664, 11)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl17.TabIndex = 135
        Me.LabelControl17.Text = "Gross Total"
        '
        'TEGrossTot
        '
        Me.TEGrossTot.EditValue = ""
        Me.TEGrossTot.Location = New System.Drawing.Point(724, 8)
        Me.TEGrossTot.Name = "TEGrossTot"
        Me.TEGrossTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEGrossTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEGrossTot.Properties.EditValueChangedDelay = 1
        Me.TEGrossTot.Properties.Mask.EditMask = "N2"
        Me.TEGrossTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEGrossTot.Properties.Mask.SaveLiteral = False
        Me.TEGrossTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEGrossTot.Properties.ReadOnly = True
        Me.TEGrossTot.Size = New System.Drawing.Size(160, 20)
        Me.TEGrossTot.TabIndex = 134
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(664, 64)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl15.TabIndex = 132
        Me.LabelControl15.Text = "Total"
        '
        'LEpayment
        '
        Me.LEpayment.Location = New System.Drawing.Point(482, 61)
        Me.LEpayment.Name = "LEpayment"
        Me.LEpayment.Properties.Appearance.Options.UseTextOptions = True
        Me.LEpayment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEpayment.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEpayment.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEpayment.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEpayment.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEpayment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEpayment.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_payment", "Id payment", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("payment", "Payment")})
        Me.LEpayment.Properties.NullText = ""
        Me.LEpayment.Properties.ShowFooter = False
        Me.LEpayment.Size = New System.Drawing.Size(162, 20)
        Me.LEpayment.TabIndex = 142
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(664, 37)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(16, 13)
        Me.LabelControl14.TabIndex = 131
        Me.LabelControl14.Text = "Vat"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(407, 11)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl13.TabIndex = 129
        Me.LabelControl13.Text = "Currency"
        '
        'TETot
        '
        Me.TETot.EditValue = ""
        Me.TETot.Location = New System.Drawing.Point(724, 61)
        Me.TETot.Name = "TETot"
        Me.TETot.Properties.Appearance.Options.UseTextOptions = True
        Me.TETot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETot.Properties.EditValueChangedDelay = 1
        Me.TETot.Properties.Mask.EditMask = "N2"
        Me.TETot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETot.Properties.Mask.SaveLiteral = False
        Me.TETot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETot.Properties.ReadOnly = True
        Me.TETot.Size = New System.Drawing.Size(160, 20)
        Me.TETot.TabIndex = 127
        '
        'TEVatTot
        '
        Me.TEVatTot.EditValue = ""
        Me.TEVatTot.Location = New System.Drawing.Point(782, 34)
        Me.TEVatTot.Name = "TEVatTot"
        Me.TEVatTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVatTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVatTot.Properties.EditValueChangedDelay = 1
        Me.TEVatTot.Properties.Mask.EditMask = "N2"
        Me.TEVatTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVatTot.Properties.Mask.SaveLiteral = False
        Me.TEVatTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEVatTot.Properties.ReadOnly = True
        Me.TEVatTot.Size = New System.Drawing.Size(102, 20)
        Me.TEVatTot.TabIndex = 126
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(27, 90)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl20.TabIndex = 123
        Me.LabelControl20.Text = "Address"
        '
        'BSearchCompShipTo
        '
        Me.BSearchCompShipTo.Location = New System.Drawing.Point(370, 61)
        Me.BSearchCompShipTo.Name = "BSearchCompShipTo"
        Me.BSearchCompShipTo.Size = New System.Drawing.Size(23, 20)
        Me.BSearchCompShipTo.TabIndex = 119
        Me.BSearchCompShipTo.Text = "..."
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(407, 64)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl9.TabIndex = 133
        Me.LabelControl9.Text = "Payment Type"
        '
        'MECompShipToAddress
        '
        Me.MECompShipToAddress.Location = New System.Drawing.Point(77, 87)
        Me.MECompShipToAddress.Name = "MECompShipToAddress"
        Me.MECompShipToAddress.Properties.MaxLength = 100
        Me.MECompShipToAddress.Properties.ReadOnly = True
        Me.MECompShipToAddress.Size = New System.Drawing.Size(316, 38)
        Me.MECompShipToAddress.TabIndex = 117
        '
        'TECompShipToName
        '
        Me.TECompShipToName.EditValue = ""
        Me.TECompShipToName.Location = New System.Drawing.Point(156, 61)
        Me.TECompShipToName.Name = "TECompShipToName"
        Me.TECompShipToName.Properties.EditValueChangedDelay = 1
        Me.TECompShipToName.Properties.ReadOnly = True
        Me.TECompShipToName.Size = New System.Drawing.Size(208, 20)
        Me.TECompShipToName.TabIndex = 116
        '
        'TECompShipTo
        '
        Me.TECompShipTo.EditValue = ""
        Me.TECompShipTo.Location = New System.Drawing.Point(77, 61)
        Me.TECompShipTo.Name = "TECompShipTo"
        Me.TECompShipTo.Properties.EditValueChangedDelay = 1
        Me.TECompShipTo.Properties.ReadOnly = True
        Me.TECompShipTo.Size = New System.Drawing.Size(73, 20)
        Me.TECompShipTo.TabIndex = 115
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(25, 64)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl23.TabIndex = 88
        Me.LabelControl23.Text = "Ship To"
        '
        'GConListPurchase
        '
        Me.GConListPurchase.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPurchase.Controls.Add(Me.PanelControl1)
        Me.GConListPurchase.Dock = System.Windows.Forms.DockStyle.Top
        Me.GConListPurchase.Location = New System.Drawing.Point(0, 191)
        Me.GConListPurchase.Name = "GConListPurchase"
        Me.GConListPurchase.Size = New System.Drawing.Size(909, 218)
        Me.GConListPurchase.TabIndex = 54
        Me.GConListPurchase.Text = "List Purchase"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GCListPurchase)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(887, 214)
        Me.PanelControl1.TabIndex = 19
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(887, 214)
        Me.GCListPurchase.TabIndex = 0
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.GridColumnVendorCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColSubtotal, Me.ColNote, Me.ColColor, Me.ColSize})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_prod_demand_product"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 24
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 112
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "UPC Code"
        Me.GridColumnVendorCode.FieldName = "ean_code"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.Visible = True
        Me.GridColumnVendorCode.VisibleIndex = 3
        Me.GridColumnVendorCode.Width = 80
        '
        'ColName
        '
        Me.ColName.Caption = "Description"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 175
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Unit Cost"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "estimate_cost"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 7
        Me.ColPrice.Width = 111
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "{0:N2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "prod_order_qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_order_qty", "{0:N2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 6
        Me.ColQty.Width = 53
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total_cost"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.OptionsColumn.AllowEdit = False
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 8
        Me.ColSubtotal.Width = 132
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 9
        Me.ColNote.Width = 71
        '
        'ColColor
        '
        Me.ColColor.AppearanceCell.Options.UseTextOptions = True
        Me.ColColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.AppearanceHeader.Options.UseTextOptions = True
        Me.ColColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.Caption = "Color"
        Me.ColColor.FieldName = "color"
        Me.ColColor.Name = "ColColor"
        Me.ColColor.OptionsColumn.AllowEdit = False
        Me.ColColor.Visible = True
        Me.ColColor.VisibleIndex = 4
        Me.ColColor.Width = 59
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 5
        Me.ColSize.Width = 59
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.DEDueDate)
        Me.GroupGeneralHeader.Controls.Add(Me.DEDateNow)
        Me.GroupGeneralHeader.Controls.Add(Me.DEEstRecDate)
        Me.GroupGeneralHeader.Controls.Add(Me.CheckEditMainVendor)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl16)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDelDate)
        Me.GroupGeneralHeader.Controls.Add(Me.TEWOCode)
        Me.GroupGeneralHeader.Controls.Add(Me.BPickWO)
        Me.GroupGeneralHeader.Controls.Add(Me.TEWO)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDesignCode)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl25)
        Me.GroupGeneralHeader.Controls.Add(Me.TEPONumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl27)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDesign)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl24)
        Me.GroupGeneralHeader.Controls.Add(Me.LEDelivery)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl12)
        Me.GroupGeneralHeader.Controls.Add(Me.LESeason)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl11)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl10)
        Me.GroupGeneralHeader.Controls.Add(Me.TETOP)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl8)
        Me.GroupGeneralHeader.Controls.Add(Me.TELeadTime)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl7)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl1)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompAttn)
        Me.GroupGeneralHeader.Controls.Add(Me.MECompAddress)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompName)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompCode)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.TEWONumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(909, 191)
        Me.GroupGeneralHeader.TabIndex = 53
        '
        'DEDueDate
        '
        Me.DEDueDate.EditValue = Nothing
        Me.DEDueDate.Location = New System.Drawing.Point(706, 105)
        Me.DEDueDate.Name = "DEDueDate"
        Me.DEDueDate.Properties.Appearance.Options.UseTextOptions = True
        Me.DEDueDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.DEDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDueDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDueDate.Size = New System.Drawing.Size(191, 20)
        Me.DEDueDate.TabIndex = 172
        '
        'DEDateNow
        '
        Me.DEDateNow.EditValue = Nothing
        Me.DEDateNow.Enabled = False
        Me.DEDateNow.Location = New System.Drawing.Point(706, 40)
        Me.DEDateNow.Name = "DEDateNow"
        Me.DEDateNow.Properties.Appearance.Options.UseTextOptions = True
        Me.DEDateNow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.DEDateNow.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateNow.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDateNow.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDateNow.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateNow.Properties.ReadOnly = True
        Me.DEDateNow.Size = New System.Drawing.Size(191, 20)
        Me.DEDateNow.TabIndex = 171
        '
        'DEEstRecDate
        '
        Me.DEEstRecDate.EditValue = Nothing
        Me.DEEstRecDate.Location = New System.Drawing.Point(706, 72)
        Me.DEEstRecDate.Name = "DEEstRecDate"
        Me.DEEstRecDate.Properties.Appearance.Options.UseTextOptions = True
        Me.DEEstRecDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.DEEstRecDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEstRecDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEstRecDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEstRecDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEstRecDate.Size = New System.Drawing.Size(191, 20)
        Me.DEEstRecDate.TabIndex = 170
        '
        'CheckEditMainVendor
        '
        Me.CheckEditMainVendor.Location = New System.Drawing.Point(223, 160)
        Me.CheckEditMainVendor.Name = "CheckEditMainVendor"
        Me.CheckEditMainVendor.Properties.Caption = "Set as main vendor"
        Me.CheckEditMainVendor.Size = New System.Drawing.Size(115, 19)
        Me.CheckEditMainVendor.TabIndex = 169
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(357, 40)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl16.TabIndex = 168
        Me.LabelControl16.Text = "Est. Mat Sent Date"
        '
        'TEDelDate
        '
        Me.TEDelDate.EditValue = Nothing
        Me.TEDelDate.Location = New System.Drawing.Point(452, 37)
        Me.TEDelDate.Name = "TEDelDate"
        Me.TEDelDate.Properties.Appearance.Options.UseTextOptions = True
        Me.TEDelDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDelDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEDelDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TEDelDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.TEDelDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEDelDate.Size = New System.Drawing.Size(163, 20)
        Me.TEDelDate.TabIndex = 167
        '
        'TEWOCode
        '
        Me.TEWOCode.EditValue = ""
        Me.TEWOCode.Location = New System.Drawing.Point(92, 9)
        Me.TEWOCode.Name = "TEWOCode"
        Me.TEWOCode.Properties.EditValueChangedDelay = 1
        Me.TEWOCode.Properties.ReadOnly = True
        Me.TEWOCode.Size = New System.Drawing.Size(60, 20)
        Me.TEWOCode.TabIndex = 166
        Me.TEWOCode.TabStop = False
        '
        'BPickWO
        '
        Me.BPickWO.Location = New System.Drawing.Point(308, 9)
        Me.BPickWO.LookAndFeel.SkinName = "Blue"
        Me.BPickWO.Name = "BPickWO"
        Me.BPickWO.Size = New System.Drawing.Size(30, 20)
        Me.BPickWO.TabIndex = 165
        Me.BPickWO.Text = "..."
        '
        'TEWO
        '
        Me.TEWO.EditValue = ""
        Me.TEWO.Location = New System.Drawing.Point(158, 9)
        Me.TEWO.Name = "TEWO"
        Me.TEWO.Properties.EditValueChangedDelay = 1
        Me.TEWO.Properties.ReadOnly = True
        Me.TEWO.Size = New System.Drawing.Size(144, 20)
        Me.TEWO.TabIndex = 164
        '
        'TEDesignCode
        '
        Me.TEDesignCode.EditValue = ""
        Me.TEDesignCode.Location = New System.Drawing.Point(706, 136)
        Me.TEDesignCode.Name = "TEDesignCode"
        Me.TEDesignCode.Properties.EditValueChangedDelay = 1
        Me.TEDesignCode.Properties.ReadOnly = True
        Me.TEDesignCode.Size = New System.Drawing.Size(191, 20)
        Me.TEDesignCode.TabIndex = 163
        Me.TEDesignCode.TabStop = False
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(634, 139)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl25.TabIndex = 162
        Me.LabelControl25.Text = "Code"
        '
        'TEPONumber
        '
        Me.TEPONumber.EditValue = ""
        Me.TEPONumber.Location = New System.Drawing.Point(452, 6)
        Me.TEPONumber.Name = "TEPONumber"
        Me.TEPONumber.Properties.EditValueChangedDelay = 1
        Me.TEPONumber.Properties.ReadOnly = True
        Me.TEPONumber.Size = New System.Drawing.Size(163, 20)
        Me.TEPONumber.TabIndex = 158
        '
        'LabelControl27
        '
        Me.LabelControl27.Location = New System.Drawing.Point(357, 9)
        Me.LabelControl27.Name = "LabelControl27"
        Me.LabelControl27.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl27.TabIndex = 159
        Me.LabelControl27.Text = "PO Number"
        '
        'TEDesign
        '
        Me.TEDesign.EditValue = ""
        Me.TEDesign.Location = New System.Drawing.Point(452, 133)
        Me.TEDesign.Name = "TEDesign"
        Me.TEDesign.Properties.EditValueChangedDelay = 1
        Me.TEDesign.Properties.ReadOnly = True
        Me.TEDesign.Size = New System.Drawing.Size(163, 20)
        Me.TEDesign.TabIndex = 144
        Me.TEDesign.TabStop = False
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(357, 136)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl24.TabIndex = 145
        Me.LabelControl24.Text = "Design"
        '
        'LEDelivery
        '
        Me.LEDelivery.Location = New System.Drawing.Point(832, 9)
        Me.LEDelivery.Name = "LEDelivery"
        Me.LEDelivery.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEDelivery.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LEDelivery.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LEDelivery.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LEDelivery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDelivery.Properties.NullText = ""
        Me.LEDelivery.Properties.ReadOnly = True
        Me.LEDelivery.Properties.ShowFooter = False
        Me.LEDelivery.Properties.View = Me.GridView1
        Me.LEDelivery.Size = New System.Drawing.Size(65, 20)
        Me.LEDelivery.TabIndex = 143
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Season"
        Me.GridColumn1.FieldName = "id_delivery"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Delivery"
        Me.GridColumn2.FieldName = "delivery"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(634, 12)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 139
        Me.LabelControl12.Text = "Season"
        '
        'LESeason
        '
        Me.LESeason.Location = New System.Drawing.Point(706, 9)
        Me.LESeason.Name = "LESeason"
        Me.LESeason.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LESeason.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESeason.Properties.NullText = ""
        Me.LESeason.Properties.ReadOnly = True
        Me.LESeason.Properties.ShowFooter = False
        Me.LESeason.Properties.View = Me.GridView2
        Me.LESeason.Size = New System.Drawing.Size(120, 20)
        Me.LESeason.TabIndex = 7
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Season"
        Me.GridColumn3.FieldName = "id_season"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Season"
        Me.GridColumn4.FieldName = "season"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(634, 108)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl11.TabIndex = 137
        Me.LabelControl11.Text = "Due Date"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(634, 75)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl10.TabIndex = 135
        Me.LabelControl10.Text = "Est. Rec Date"
        '
        'TETOP
        '
        Me.TETOP.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TETOP.Location = New System.Drawing.Point(452, 101)
        Me.TETOP.Name = "TETOP"
        Me.TETOP.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TETOP.Properties.Appearance.Options.UseFont = True
        Me.TETOP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TETOP.Properties.IsFloatValue = False
        Me.TETOP.Properties.Mask.EditMask = "N00"
        Me.TETOP.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TETOP.Size = New System.Drawing.Size(163, 22)
        Me.TETOP.TabIndex = 5
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(357, 104)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl8.TabIndex = 129
        Me.LabelControl8.Text = "TOP"
        '
        'TELeadTime
        '
        Me.TELeadTime.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TELeadTime.Location = New System.Drawing.Point(452, 68)
        Me.TELeadTime.Name = "TELeadTime"
        Me.TELeadTime.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TELeadTime.Properties.Appearance.Options.UseFont = True
        Me.TELeadTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TELeadTime.Properties.IsFloatValue = False
        Me.TELeadTime.Properties.Mask.EditMask = "N00"
        Me.TELeadTime.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TELeadTime.Size = New System.Drawing.Size(163, 22)
        Me.TELeadTime.TabIndex = 4
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(357, 72)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl7.TabIndex = 126
        Me.LabelControl7.Text = "Lead Time"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(634, 43)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Date"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 92)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 123
        Me.LabelControl5.Text = "Address"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(28, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 122
        Me.LabelControl2.Text = "Attn."
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 121
        Me.LabelControl1.Text = "Work Order"
        '
        'TECompAttn
        '
        Me.TECompAttn.EditValue = ""
        Me.TECompAttn.Location = New System.Drawing.Point(92, 63)
        Me.TECompAttn.Name = "TECompAttn"
        Me.TECompAttn.Properties.EditValueChangedDelay = 1
        Me.TECompAttn.Properties.ReadOnly = True
        Me.TECompAttn.Size = New System.Drawing.Size(246, 20)
        Me.TECompAttn.TabIndex = 0
        Me.TECompAttn.TabStop = False
        '
        'MECompAddress
        '
        Me.MECompAddress.Location = New System.Drawing.Point(92, 89)
        Me.MECompAddress.Name = "MECompAddress"
        Me.MECompAddress.Properties.MaxLength = 100
        Me.MECompAddress.Properties.ReadOnly = True
        Me.MECompAddress.Size = New System.Drawing.Size(246, 38)
        Me.MECompAddress.TabIndex = 0
        Me.MECompAddress.TabStop = False
        '
        'TECompName
        '
        Me.TECompName.EditValue = ""
        Me.TECompName.Location = New System.Drawing.Point(158, 37)
        Me.TECompName.Name = "TECompName"
        Me.TECompName.Properties.EditValueChangedDelay = 1
        Me.TECompName.Properties.ReadOnly = True
        Me.TECompName.Size = New System.Drawing.Size(180, 20)
        Me.TECompName.TabIndex = 0
        Me.TECompName.TabStop = False
        '
        'TECompCode
        '
        Me.TECompCode.EditValue = ""
        Me.TECompCode.Location = New System.Drawing.Point(92, 37)
        Me.TECompCode.Name = "TECompCode"
        Me.TECompCode.Properties.EditValueChangedDelay = 1
        Me.TECompCode.Properties.ReadOnly = True
        Me.TECompCode.Size = New System.Drawing.Size(60, 20)
        Me.TECompCode.TabIndex = 0
        Me.TECompCode.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(28, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "To"
        '
        'TEWONumber
        '
        Me.TEWONumber.EditValue = ""
        Me.TEWONumber.Location = New System.Drawing.Point(92, 134)
        Me.TEWONumber.Name = "TEWONumber"
        Me.TEWONumber.Properties.EditValueChangedDelay = 1
        Me.TEWONumber.Properties.ReadOnly = True
        Me.TEWONumber.Size = New System.Drawing.Size(246, 20)
        Me.TEWONumber.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 137)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "WO Number"
        '
        'FormProductionWO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 582)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupGeneralFooter)
        Me.Controls.Add(Me.GConListPurchase)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionWO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order"
        CType(Me.EPMatWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralFooter.ResumeLayout(False)
        Me.GroupGeneralFooter.PerformLayout()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEGrossTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEpayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVatTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECompShipToAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompShipToName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompShipTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPurchase.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateNow.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateNow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEstRecDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEstRecDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditMainVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDelDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWOCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesignCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDelivery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETOP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompAttn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECompAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EPMatWO As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralFooter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents METotSay As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEVat As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEGrossTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEpayment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEVatTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearchCompShipTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MECompShipToAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECompShipToName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompShipTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GConListPurchase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDelDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEWOCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BPickWO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEWO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEDesignCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDelivery As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETOP As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TELeadTime As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECompAttn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MECompAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECompName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEWONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Public WithEvents ImgBut As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckEditMainVendor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DEEstRecDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEDateNow As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BReviseWO As DevExpress.XtraEditors.SimpleButton
End Class
