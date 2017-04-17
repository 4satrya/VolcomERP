<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionRetInSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionRetInSingle))
        Me.EPRet = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnXlsBOF = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSeason = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDesign = New DevExpress.XtraEditors.TextEdit()
        Me.PEView = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnInfoSrs = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowseContactTo = New DevExpress.XtraEditors.SimpleButton()
        Me.DERet = New DevExpress.XtraEditors.TextEdit()
        Me.TxtOrderNumber = New DevExpress.XtraEditors.TextEdit()
        Me.BtnBrowsePO = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtRetOutNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MEAdrressCompTo = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnBrowseContactFrom = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtNameCompTo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCodeCompTo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNameCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCodeCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SCCReturn = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlRet = New DevExpress.XtraEditors.GroupControl()
        Me.GCRetDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVRetDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdRet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSamplePurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEanCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNox = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControlListBarcode = New DevExpress.XtraEditors.GroupControl()
        Me.GCBarcode = New DevExpress.XtraGrid.GridControl()
        Me.GVBarcode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProdOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsFix = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.PanelNavBarcode = New DevExpress.XtraEditors.PanelControl()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BStop = New DevExpress.XtraEditors.SimpleButton()
        Me.BScan = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.EPRet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PEView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DERet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRetOutNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCCReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCReturn.SuspendLayout()
        CType(Me.GroupControlRet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlRet.SuspendLayout()
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControlListBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlListBarcode.SuspendLayout()
        CType(Me.GCBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelNavBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNavBarcode.SuspendLayout()
        Me.SuspendLayout()
        '
        'EPRet
        '
        Me.EPRet.ContainerControl = Me
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnXlsBOF)
        Me.PanelControl3.Controls.Add(Me.BtnAttachment)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Controls.Add(Me.BtnPrint)
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 570)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(873, 38)
        Me.PanelControl3.TabIndex = 179
        '
        'BtnXlsBOF
        '
        Me.BtnXlsBOF.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXlsBOF.Image = CType(resources.GetObject("BtnXlsBOF.Image"), System.Drawing.Image)
        Me.BtnXlsBOF.ImageIndex = 11
        Me.BtnXlsBOF.ImageList = Me.LargeImageCollection
        Me.BtnXlsBOF.Location = New System.Drawing.Point(433, 2)
        Me.BtnXlsBOF.Name = "BtnXlsBOF"
        Me.BtnXlsBOF.Size = New System.Drawing.Size(115, 34)
        Me.BtnXlsBOF.TabIndex = 18
        Me.BtnXlsBOF.Text = "Generate XLS"
        Me.BtnXlsBOF.Visible = False
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
        Me.LargeImageCollection.Images.SetKeyName(10, "attachment-icon.png")
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 10
        Me.BtnAttachment.ImageList = Me.LargeImageCollection
        Me.BtnAttachment.Location = New System.Drawing.Point(548, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(98, 34)
        Me.BtnAttachment.TabIndex = 10
        Me.BtnAttachment.Text = "Attachment"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 34)
        Me.BMark.TabIndex = 11
        Me.BMark.Text = "Mark"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(646, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 34)
        Me.BtnPrint.TabIndex = 9
        Me.BtnPrint.Text = "Print"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(721, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 34)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(796, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "Save"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.LEReportStatus)
        Me.GroupControl3.Controls.Add(Me.LabelControl21)
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 510)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(873, 60)
        Me.GroupControl3.TabIndex = 180
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(624, 6)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(237, 20)
        Me.LEReportStatus.TabIndex = 12
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(576, 9)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(108, 7)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(323, 43)
        Me.MENote.TabIndex = 11
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 9)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl8)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtSeason)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDesign)
        Me.GroupGeneralHeader.Controls.Add(Me.PEView)
        Me.GroupGeneralHeader.Controls.Add(Me.BtnInfoSrs)
        Me.GroupGeneralHeader.Controls.Add(Me.BtnBrowseContactTo)
        Me.GroupGeneralHeader.Controls.Add(Me.DERet)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtOrderNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.BtnBrowsePO)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl7)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtRetOutNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.MEAdrressCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Controls.Add(Me.BtnBrowseContactFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtNameCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtCodeCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtNameCompFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtCodeCompFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl1)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(873, 125)
        Me.GroupGeneralHeader.TabIndex = 181
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(571, 12)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl8.TabIndex = 10006
        Me.LabelControl8.Text = "Season"
        '
        'TxtSeason
        '
        Me.TxtSeason.EditValue = ""
        Me.TxtSeason.Location = New System.Drawing.Point(659, 9)
        Me.TxtSeason.Name = "TxtSeason"
        Me.TxtSeason.Properties.EditValueChangedDelay = 1
        Me.TxtSeason.Properties.ReadOnly = True
        Me.TxtSeason.Size = New System.Drawing.Size(202, 20)
        Me.TxtSeason.TabIndex = 10004
        Me.TxtSeason.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(154, 90)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl6.TabIndex = 10003
        Me.LabelControl6.Text = "Design"
        '
        'TEDesign
        '
        Me.TEDesign.EditValue = ""
        Me.TEDesign.Location = New System.Drawing.Point(226, 87)
        Me.TEDesign.Name = "TEDesign"
        Me.TEDesign.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEDesign.Properties.Appearance.Options.UseFont = True
        Me.TEDesign.Properties.EditValueChangedDelay = 1
        Me.TEDesign.Properties.ReadOnly = True
        Me.TEDesign.Size = New System.Drawing.Size(303, 20)
        Me.TEDesign.TabIndex = 10002
        Me.TEDesign.TabStop = False
        '
        'PEView
        '
        Me.PEView.Dock = System.Windows.Forms.DockStyle.Left
        Me.PEView.Enabled = False
        Me.PEView.Location = New System.Drawing.Point(20, 2)
        Me.PEView.Name = "PEView"
        Me.PEView.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PEView.Properties.ShowMenu = False
        Me.PEView.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PEView.Size = New System.Drawing.Size(109, 121)
        Me.PEView.TabIndex = 10001
        '
        'BtnInfoSrs
        '
        Me.BtnInfoSrs.Appearance.Font = New System.Drawing.Font("Monotype Corsiva", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInfoSrs.Appearance.Options.UseFont = True
        Me.BtnInfoSrs.Enabled = False
        Me.BtnInfoSrs.Location = New System.Drawing.Point(506, 9)
        Me.BtnInfoSrs.Name = "BtnInfoSrs"
        Me.BtnInfoSrs.Size = New System.Drawing.Size(23, 20)
        Me.BtnInfoSrs.TabIndex = 1
        Me.BtnInfoSrs.Text = "i"
        Me.BtnInfoSrs.ToolTip = "Click this button to see qty allowed."
        Me.BtnInfoSrs.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.BtnInfoSrs.ToolTipTitle = "SRS Info"
        '
        'BtnBrowseContactTo
        '
        Me.BtnBrowseContactTo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowseContactTo.Appearance.Options.UseFont = True
        Me.BtnBrowseContactTo.Location = New System.Drawing.Point(506, 61)
        Me.BtnBrowseContactTo.Name = "BtnBrowseContactTo"
        Me.BtnBrowseContactTo.Size = New System.Drawing.Size(23, 20)
        Me.BtnBrowseContactTo.TabIndex = 3
        Me.BtnBrowseContactTo.Text = "..."
        '
        'DERet
        '
        Me.DERet.EditValue = ""
        Me.DERet.Location = New System.Drawing.Point(659, 35)
        Me.DERet.Name = "DERet"
        Me.DERet.Properties.EditValueChangedDelay = 1
        Me.DERet.Properties.ReadOnly = True
        Me.DERet.Size = New System.Drawing.Size(202, 20)
        Me.DERet.TabIndex = 162
        Me.DERet.TabStop = False
        '
        'TxtOrderNumber
        '
        Me.TxtOrderNumber.EditValue = ""
        Me.TxtOrderNumber.Location = New System.Drawing.Point(226, 9)
        Me.TxtOrderNumber.Name = "TxtOrderNumber"
        Me.TxtOrderNumber.Properties.EditValueChangedDelay = 1
        Me.TxtOrderNumber.Properties.ReadOnly = True
        Me.TxtOrderNumber.Size = New System.Drawing.Size(248, 20)
        Me.TxtOrderNumber.TabIndex = 9999
        Me.TxtOrderNumber.TabStop = False
        '
        'BtnBrowsePO
        '
        Me.BtnBrowsePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowsePO.Appearance.Options.UseFont = True
        Me.BtnBrowsePO.Location = New System.Drawing.Point(477, 9)
        Me.BtnBrowsePO.Name = "BtnBrowsePO"
        Me.BtnBrowsePO.Size = New System.Drawing.Size(23, 20)
        Me.BtnBrowsePO.TabIndex = 0
        Me.BtnBrowsePO.Text = "..."
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(154, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "Prod No."
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(571, 38)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'TxtRetOutNumber
        '
        Me.TxtRetOutNumber.EditValue = ""
        Me.TxtRetOutNumber.Location = New System.Drawing.Point(659, 61)
        Me.TxtRetOutNumber.Name = "TxtRetOutNumber"
        Me.TxtRetOutNumber.Properties.EditValueChangedDelay = 1
        Me.TxtRetOutNumber.Properties.ReadOnly = True
        Me.TxtRetOutNumber.Size = New System.Drawing.Size(202, 20)
        Me.TxtRetOutNumber.TabIndex = 8
        Me.TxtRetOutNumber.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(571, 64)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Ret. In Number"
        '
        'MEAdrressCompTo
        '
        Me.MEAdrressCompTo.Location = New System.Drawing.Point(226, 190)
        Me.MEAdrressCompTo.Name = "MEAdrressCompTo"
        Me.MEAdrressCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEAdrressCompTo.Properties.Appearance.Options.UseFont = True
        Me.MEAdrressCompTo.Properties.ReadOnly = True
        Me.MEAdrressCompTo.Size = New System.Drawing.Size(303, 35)
        Me.MEAdrressCompTo.TabIndex = 4444
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(154, 192)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 153
        Me.LabelControl3.Text = "Address"
        '
        'BtnBrowseContactFrom
        '
        Me.BtnBrowseContactFrom.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowseContactFrom.Appearance.Options.UseFont = True
        Me.BtnBrowseContactFrom.Location = New System.Drawing.Point(506, 35)
        Me.BtnBrowseContactFrom.Name = "BtnBrowseContactFrom"
        Me.BtnBrowseContactFrom.Size = New System.Drawing.Size(23, 20)
        Me.BtnBrowseContactFrom.TabIndex = 2
        Me.BtnBrowseContactFrom.Text = "..."
        '
        'TxtNameCompTo
        '
        Me.TxtNameCompTo.EditValue = ""
        Me.TxtNameCompTo.Location = New System.Drawing.Point(307, 61)
        Me.TxtNameCompTo.Name = "TxtNameCompTo"
        Me.TxtNameCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompTo.Properties.ReadOnly = True
        Me.TxtNameCompTo.Size = New System.Drawing.Size(193, 20)
        Me.TxtNameCompTo.TabIndex = 5555
        Me.TxtNameCompTo.TabStop = False
        '
        'TxtCodeCompTo
        '
        Me.TxtCodeCompTo.EditValue = ""
        Me.TxtCodeCompTo.Location = New System.Drawing.Point(226, 61)
        Me.TxtCodeCompTo.Name = "TxtCodeCompTo"
        Me.TxtCodeCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompTo.Properties.ReadOnly = True
        Me.TxtCodeCompTo.Size = New System.Drawing.Size(75, 20)
        Me.TxtCodeCompTo.TabIndex = 6666
        Me.TxtCodeCompTo.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(154, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl2.TabIndex = 149
        Me.LabelControl2.Text = "Received By"
        '
        'TxtNameCompFrom
        '
        Me.TxtNameCompFrom.EditValue = ""
        Me.TxtNameCompFrom.Location = New System.Drawing.Point(307, 35)
        Me.TxtNameCompFrom.Name = "TxtNameCompFrom"
        Me.TxtNameCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompFrom.Properties.ReadOnly = True
        Me.TxtNameCompFrom.Size = New System.Drawing.Size(193, 20)
        Me.TxtNameCompFrom.TabIndex = 8888
        Me.TxtNameCompFrom.TabStop = False
        '
        'TxtCodeCompFrom
        '
        Me.TxtCodeCompFrom.EditValue = ""
        Me.TxtCodeCompFrom.Location = New System.Drawing.Point(226, 35)
        Me.TxtCodeCompFrom.Name = "TxtCodeCompFrom"
        Me.TxtCodeCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompFrom.Properties.ReadOnly = True
        Me.TxtCodeCompFrom.Size = New System.Drawing.Size(75, 20)
        Me.TxtCodeCompFrom.TabIndex = 7777
        Me.TxtCodeCompFrom.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(154, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 145
        Me.LabelControl1.Text = "From"
        '
        'SCCReturn
        '
        Me.SCCReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCReturn.Horizontal = False
        Me.SCCReturn.Location = New System.Drawing.Point(0, 125)
        Me.SCCReturn.Name = "SCCReturn"
        Me.SCCReturn.Panel1.Controls.Add(Me.GroupControlRet)
        Me.SCCReturn.Panel1.Text = "Panel1"
        Me.SCCReturn.Panel2.Controls.Add(Me.GroupControlListBarcode)
        Me.SCCReturn.Panel2.Text = "Panel2"
        Me.SCCReturn.Size = New System.Drawing.Size(873, 385)
        Me.SCCReturn.SplitterPosition = 171
        Me.SCCReturn.TabIndex = 182
        Me.SCCReturn.Text = "SplitContainerControl1"
        '
        'GroupControlRet
        '
        Me.GroupControlRet.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControlRet.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GroupControlRet.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlRet.Controls.Add(Me.GCRetDetail)
        Me.GroupControlRet.Controls.Add(Me.PanelControl1)
        Me.GroupControlRet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlRet.Enabled = False
        Me.GroupControlRet.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlRet.Name = "GroupControlRet"
        Me.GroupControlRet.Size = New System.Drawing.Size(873, 171)
        Me.GroupControlRet.TabIndex = 180
        Me.GroupControlRet.Text = "Return List"
        '
        'GCRetDetail
        '
        Me.GCRetDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetDetail.Location = New System.Drawing.Point(20, 38)
        Me.GCRetDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCRetDetail.MainView = Me.GVRetDetail
        Me.GCRetDetail.Name = "GCRetDetail"
        Me.GCRetDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCRetDetail.Size = New System.Drawing.Size(851, 131)
        Me.GCRetDetail.TabIndex = 1
        Me.GCRetDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetDetail})
        '
        'GVRetDetail
        '
        Me.GVRetDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdRet, Me.GridColumnIdSamplePurcDet, Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnEanCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnRemark, Me.GridColumnNox, Me.GridColumnNumber, Me.GridColumnFrom, Me.GridColumnTo})
        Me.GVRetDetail.GridControl = Me.GCRetDetail
        Me.GVRetDetail.Name = "GVRetDetail"
        Me.GVRetDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsView.ShowFooter = True
        Me.GVRetDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdRet
        '
        Me.GridColumnIdRet.Caption = "ID Ret"
        Me.GridColumnIdRet.FieldName = "id_prod_order_ret_in_det"
        Me.GridColumnIdRet.Name = "GridColumnIdRet"
        Me.GridColumnIdRet.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdSamplePurcDet
        '
        Me.GridColumnIdSamplePurcDet.Caption = "Id Sample Purc Det"
        Me.GridColumnIdSamplePurcDet.FieldName = "id_prod_order_det"
        Me.GridColumnIdSamplePurcDet.Name = "GridColumnIdSamplePurcDet"
        Me.GridColumnIdSamplePurcDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        '
        'GridColumnEanCode
        '
        Me.GridColumnEanCode.Caption = "Vendor Code"
        Me.GridColumnEanCode.FieldName = "ean_code"
        Me.GridColumnEanCode.Name = "GridColumnEanCode"
        Me.GridColumnEanCode.OptionsColumn.ReadOnly = True
        Me.GridColumnEanCode.Visible = True
        Me.GridColumnEanCode.VisibleIndex = 2
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 3
        Me.GridColumnName.Width = 200
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        Me.GridColumnSize.Width = 60
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 5
        Me.GridColumnUOM.Width = 100
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "prod_order_ret_in_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_order_ret_in_det_qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 120
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "prod_order_ret_in_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 7
        Me.GridColumnRemark.Width = 216
        '
        'GridColumnNox
        '
        Me.GridColumnNox.Caption = "No"
        Me.GridColumnNox.FieldName = "no"
        Me.GridColumnNox.Name = "GridColumnNox"
        Me.GridColumnNox.Visible = True
        Me.GridColumnNox.VisibleIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnDel)
        Me.PanelControl1.Controls.Add(Me.BtnEdit)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(851, 36)
        Me.PanelControl1.TabIndex = 0
        Me.PanelControl1.Visible = False
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.ImageIndex = 1
        Me.BtnDel.ImageList = Me.LargeImageCollection
        Me.BtnDel.Location = New System.Drawing.Point(578, 0)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(91, 36)
        Me.BtnDel.TabIndex = 6
        Me.BtnDel.Text = "Delete"
        '
        'BtnEdit
        '
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEdit.ImageIndex = 2
        Me.BtnEdit.ImageList = Me.LargeImageCollection
        Me.BtnEdit.Location = New System.Drawing.Point(669, 0)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(91, 36)
        Me.BtnEdit.TabIndex = 5
        Me.BtnEdit.Text = "Edit"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(760, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 36)
        Me.BtnAdd.TabIndex = 4
        Me.BtnAdd.Text = "Add"
        '
        'GroupControlListBarcode
        '
        Me.GroupControlListBarcode.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlListBarcode.Controls.Add(Me.GCBarcode)
        Me.GroupControlListBarcode.Controls.Add(Me.PanelNavBarcode)
        Me.GroupControlListBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlListBarcode.Enabled = False
        Me.GroupControlListBarcode.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlListBarcode.Name = "GroupControlListBarcode"
        Me.GroupControlListBarcode.Size = New System.Drawing.Size(873, 209)
        Me.GroupControlListBarcode.TabIndex = 1
        Me.GroupControlListBarcode.Text = "List Barcode"
        '
        'GCBarcode
        '
        Me.GCBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBarcode.Location = New System.Drawing.Point(20, 35)
        Me.GCBarcode.MainView = Me.GVBarcode
        Me.GCBarcode.Name = "GCBarcode"
        Me.GCBarcode.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemSpinEdit2})
        Me.GCBarcode.Size = New System.Drawing.Size(851, 172)
        Me.GCBarcode.TabIndex = 4
        Me.GCBarcode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBarcode})
        '
        'GVBarcode
        '
        Me.GVBarcode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnBarcode, Me.GridColumnIdProdOrderDet, Me.GridColumnIsFix})
        Me.GVBarcode.GridControl = Me.GCBarcode
        Me.GVBarcode.Name = "GVBarcode"
        Me.GVBarcode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVBarcode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVBarcode.OptionsCustomization.AllowColumnMoving = False
        Me.GVBarcode.OptionsCustomization.AllowFilter = False
        Me.GVBarcode.OptionsCustomization.AllowGroup = False
        Me.GVBarcode.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVBarcode.OptionsCustomization.AllowSort = False
        Me.GVBarcode.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 53
        '
        'GridColumnBarcode
        '
        Me.GridColumnBarcode.Caption = "Scanned Code"
        Me.GridColumnBarcode.FieldName = "ean_code"
        Me.GridColumnBarcode.Name = "GridColumnBarcode"
        Me.GridColumnBarcode.Visible = True
        Me.GridColumnBarcode.VisibleIndex = 1
        Me.GridColumnBarcode.Width = 816
        '
        'GridColumnIdProdOrderDet
        '
        Me.GridColumnIdProdOrderDet.Caption = "Id Prod Order Det"
        Me.GridColumnIdProdOrderDet.FieldName = "id_prod_order_det"
        Me.GridColumnIdProdOrderDet.Name = "GridColumnIdProdOrderDet"
        Me.GridColumnIdProdOrderDet.OptionsColumn.AllowEdit = False
        Me.GridColumnIdProdOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdProdOrderDet.OptionsColumn.AllowMove = False
        Me.GridColumnIdProdOrderDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIsFix
        '
        Me.GridColumnIsFix.Caption = "Is Fix"
        Me.GridColumnIsFix.FieldName = "is_fix"
        Me.GridColumnIsFix.Name = "GridColumnIsFix"
        Me.GridColumnIsFix.OptionsColumn.AllowEdit = False
        Me.GridColumnIsFix.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIsFix.OptionsColumn.AllowMove = False
        Me.GridColumnIsFix.OptionsColumn.ShowInCustomizationForm = False
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.EditValueChangedDelay = 50
        Me.RepositoryItemSpinEdit2.Mask.EditMask = "n2"
        Me.RepositoryItemSpinEdit2.Mask.SaveLiteral = False
        Me.RepositoryItemSpinEdit2.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 131072})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'PanelNavBarcode
        '
        Me.PanelNavBarcode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelNavBarcode.Controls.Add(Me.BDelete)
        Me.PanelNavBarcode.Controls.Add(Me.BStop)
        Me.PanelNavBarcode.Controls.Add(Me.BScan)
        Me.PanelNavBarcode.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNavBarcode.Location = New System.Drawing.Point(20, 2)
        Me.PanelNavBarcode.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PanelNavBarcode.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelNavBarcode.Name = "PanelNavBarcode"
        Me.PanelNavBarcode.Size = New System.Drawing.Size(851, 33)
        Me.PanelNavBarcode.TabIndex = 0
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 1
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(575, 0)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(94, 33)
        Me.BDelete.TabIndex = 6
        Me.BDelete.Text = "Delete Scan"
        '
        'BStop
        '
        Me.BStop.Dock = System.Windows.Forms.DockStyle.Right
        Me.BStop.Enabled = False
        Me.BStop.ImageIndex = 9
        Me.BStop.ImageList = Me.LargeImageCollection
        Me.BStop.Location = New System.Drawing.Point(669, 0)
        Me.BStop.Name = "BStop"
        Me.BStop.Size = New System.Drawing.Size(91, 33)
        Me.BStop.TabIndex = 5
        Me.BStop.Text = "Stop Scan"
        '
        'BScan
        '
        Me.BScan.Dock = System.Windows.Forms.DockStyle.Right
        Me.BScan.ImageIndex = 8
        Me.BScan.ImageList = Me.LargeImageCollection
        Me.BScan.Location = New System.Drawing.Point(760, 0)
        Me.BScan.Name = "BScan"
        Me.BScan.Size = New System.Drawing.Size(91, 33)
        Me.BScan.TabIndex = 4
        Me.BScan.Text = "Start Scan"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'FormProductionRetInSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 608)
        Me.Controls.Add(Me.SCCReturn)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionRetInSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Finished Goods Return In"
        CType(Me.EPRet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PEView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DERet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRetOutNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCCReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCReturn.ResumeLayout(False)
        CType(Me.GroupControlRet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlRet.ResumeLayout(False)
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GroupControlListBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlListBarcode.ResumeLayout(False)
        CType(Me.GCBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelNavBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNavBarcode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EPRet As System.Windows.Forms.ErrorProvider
    Friend WithEvents SCCReturn As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlRet As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRetDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEanCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNox As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlListBarcode As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCBarcode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBarcode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProdOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsFix As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PanelNavBarcode As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BStop As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BScan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PEView As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnInfoSrs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowseContactTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DERet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnBrowsePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRetOutNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAdrressCompTo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnBrowseContactFrom As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNameCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCodeCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNameCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCodeCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSeason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnXlsBOF As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
End Class
