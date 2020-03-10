<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnOrderDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReturnOrderDet))
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDelDate = New DevExpress.XtraEditors.DateEdit()
        Me.DERetDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSalesOrderNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEForm = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControlTopLeft = New DevExpress.XtraEditors.PanelControl()
        Me.TxtOrderType = New DevExpress.XtraEditors.TextEdit()
        Me.LEOrderType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.CEOnHold = New DevExpress.XtraEditors.CheckEdit()
        Me.MEAdrressCompTo = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCodeCompTo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNameCompTo = New DevExpress.XtraEditors.TextEdit()
        Me.BtnBrowseContactTo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControlBottomRight = New DevExpress.XtraEditors.PanelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControlList = New DevExpress.XtraEditors.GroupControl()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReturnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyAvail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFound = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_detail_on_hold = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportAsFile = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOnHoldList = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnImport2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnImport = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAddMultiple = New DevExpress.XtraEditors.SimpleButton()
        Me.EPForm = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddAnotherProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReviseQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XTCRO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPItems = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPRate = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRate = New DevExpress.XtraGrid.GridControl()
        Me.GVRate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_cargo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncargo_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncargo_rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncargo_lead_time = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncargo_min_weight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUEClasification = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.DEDelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDelDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DERetDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DERetDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSalesOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopLeft.SuspendLayout()
        CType(Me.TxtOrderType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEOrderType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEOnHold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControlBottomRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottomRight.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlList.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.EPForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.XTCRO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRO.SuspendLayout()
        Me.XTPItems.SuspendLayout()
        Me.XTPRate.SuspendLayout()
        CType(Me.GCRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEClasification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopRight)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopLeft)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(902, 155)
        Me.GroupGeneralHeader.TabIndex = 184
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl4)
        Me.PanelControlTopRight.Controls.Add(Me.DEDelDate)
        Me.PanelControlTopRight.Controls.Add(Me.DERetDueDate)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl2)
        Me.PanelControlTopRight.Controls.Add(Me.TxtSalesOrderNumber)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Controls.Add(Me.DEForm)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(637, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(263, 151)
        Me.PanelControlTopRight.TabIndex = 8892
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(12, 88)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl4.TabIndex = 8892
        Me.LabelControl4.Text = "Est. Delivery Date"
        '
        'DEDelDate
        '
        Me.DEDelDate.EditValue = Nothing
        Me.DEDelDate.Location = New System.Drawing.Point(110, 85)
        Me.DEDelDate.Name = "DEDelDate"
        Me.DEDelDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEDelDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDelDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDelDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDelDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDelDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEDelDate.Size = New System.Drawing.Size(132, 20)
        Me.DEDelDate.TabIndex = 3
        Me.DEDelDate.ToolTip = "Estimate date for next delivery"
        Me.DEDelDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'DERetDueDate
        '
        Me.DERetDueDate.EditValue = Nothing
        Me.DERetDueDate.Enabled = False
        Me.DERetDueDate.Location = New System.Drawing.Point(110, 59)
        Me.DERetDueDate.Name = "DERetDueDate"
        Me.DERetDueDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DERetDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DERetDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DERetDueDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DERetDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DERetDueDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DERetDueDate.Size = New System.Drawing.Size(132, 20)
        Me.DERetDueDate.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(92, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Ret. Order Number"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 62)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl2.TabIndex = 8890
        Me.LabelControl2.Text = "Est. Return Date"
        '
        'TxtSalesOrderNumber
        '
        Me.TxtSalesOrderNumber.EditValue = ""
        Me.TxtSalesOrderNumber.Location = New System.Drawing.Point(110, 35)
        Me.TxtSalesOrderNumber.Name = "TxtSalesOrderNumber"
        Me.TxtSalesOrderNumber.Properties.EditValueChangedDelay = 1
        Me.TxtSalesOrderNumber.Properties.ReadOnly = True
        Me.TxtSalesOrderNumber.Size = New System.Drawing.Size(132, 20)
        Me.TxtSalesOrderNumber.TabIndex = 1000
        Me.TxtSalesOrderNumber.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(12, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'DEForm
        '
        Me.DEForm.EditValue = ""
        Me.DEForm.Location = New System.Drawing.Point(110, 10)
        Me.DEForm.Name = "DEForm"
        Me.DEForm.Properties.EditValueChangedDelay = 1
        Me.DEForm.Properties.ReadOnly = True
        Me.DEForm.Size = New System.Drawing.Size(132, 20)
        Me.DEForm.TabIndex = 162
        Me.DEForm.TabStop = False
        '
        'PanelControlTopLeft
        '
        Me.PanelControlTopLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopLeft.Controls.Add(Me.TxtOrderType)
        Me.PanelControlTopLeft.Controls.Add(Me.LEOrderType)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl6)
        Me.PanelControlTopLeft.Controls.Add(Me.CEOnHold)
        Me.PanelControlTopLeft.Controls.Add(Me.MEAdrressCompTo)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl1)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtCodeCompTo)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtNameCompTo)
        Me.PanelControlTopLeft.Controls.Add(Me.BtnBrowseContactTo)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl3)
        Me.PanelControlTopLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlTopLeft.Location = New System.Drawing.Point(21, 2)
        Me.PanelControlTopLeft.Name = "PanelControlTopLeft"
        Me.PanelControlTopLeft.Size = New System.Drawing.Size(761, 151)
        Me.PanelControlTopLeft.TabIndex = 8891
        '
        'TxtOrderType
        '
        Me.TxtOrderType.EditValue = ""
        Me.TxtOrderType.Enabled = False
        Me.TxtOrderType.Location = New System.Drawing.Point(143, 10)
        Me.TxtOrderType.Name = "TxtOrderType"
        Me.TxtOrderType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderType.Properties.Appearance.Options.UseFont = True
        Me.TxtOrderType.Properties.EditValueChangedDelay = 1
        Me.TxtOrderType.Properties.ReadOnly = True
        Me.TxtOrderType.Size = New System.Drawing.Size(318, 20)
        Me.TxtOrderType.TabIndex = 8911
        Me.TxtOrderType.TabStop = False
        '
        'LEOrderType
        '
        Me.LEOrderType.Location = New System.Drawing.Point(55, 10)
        Me.LEOrderType.Name = "LEOrderType"
        Me.LEOrderType.Properties.Appearance.Options.UseTextOptions = True
        Me.LEOrderType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEOrderType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEOrderType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_order_type", "id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("order_type", "Type"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Description")})
        Me.LEOrderType.Properties.NullText = ""
        Me.LEOrderType.Properties.ShowFooter = False
        Me.LEOrderType.Size = New System.Drawing.Size(83, 20)
        Me.LEOrderType.TabIndex = 0
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(10, 13)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 8890
        Me.LabelControl6.Text = "Type"
        '
        'CEOnHold
        '
        Me.CEOnHold.Location = New System.Drawing.Point(55, 115)
        Me.CEOnHold.Name = "CEOnHold"
        Me.CEOnHold.Properties.Caption = "On Hold"
        Me.CEOnHold.Size = New System.Drawing.Size(64, 19)
        Me.CEOnHold.TabIndex = 8889
        '
        'MEAdrressCompTo
        '
        Me.MEAdrressCompTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEAdrressCompTo.Location = New System.Drawing.Point(55, 61)
        Me.MEAdrressCompTo.Name = "MEAdrressCompTo"
        Me.MEAdrressCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEAdrressCompTo.Properties.Appearance.Options.UseFont = True
        Me.MEAdrressCompTo.Properties.ReadOnly = True
        Me.MEAdrressCompTo.Size = New System.Drawing.Size(406, 48)
        Me.MEAdrressCompTo.TabIndex = 4444
        Me.MEAdrressCompTo.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(10, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 145
        Me.LabelControl1.Text = "Store"
        '
        'TxtCodeCompTo
        '
        Me.TxtCodeCompTo.EditValue = ""
        Me.TxtCodeCompTo.Location = New System.Drawing.Point(55, 35)
        Me.TxtCodeCompTo.Name = "TxtCodeCompTo"
        Me.TxtCodeCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompTo.Size = New System.Drawing.Size(82, 20)
        Me.TxtCodeCompTo.TabIndex = 1
        '
        'TxtNameCompTo
        '
        Me.TxtNameCompTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameCompTo.EditValue = ""
        Me.TxtNameCompTo.Location = New System.Drawing.Point(143, 35)
        Me.TxtNameCompTo.Name = "TxtNameCompTo"
        Me.TxtNameCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompTo.Properties.ReadOnly = True
        Me.TxtNameCompTo.Size = New System.Drawing.Size(289, 20)
        Me.TxtNameCompTo.TabIndex = 8888
        Me.TxtNameCompTo.TabStop = False
        '
        'BtnBrowseContactTo
        '
        Me.BtnBrowseContactTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseContactTo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowseContactTo.Appearance.Options.UseFont = True
        Me.BtnBrowseContactTo.Location = New System.Drawing.Point(438, 35)
        Me.BtnBrowseContactTo.Name = "BtnBrowseContactTo"
        Me.BtnBrowseContactTo.Size = New System.Drawing.Size(23, 20)
        Me.BtnBrowseContactTo.TabIndex = 1
        Me.BtnBrowseContactTo.TabStop = False
        Me.BtnBrowseContactTo.Text = "..."
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(10, 63)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 153
        Me.LabelControl3.Text = "Address"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnAttachment)
        Me.PanelControl3.Controls.Add(Me.BtnPrint)
        Me.PanelControl3.Controls.Add(Me.SimpleButton1)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 503)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(902, 38)
        Me.PanelControl3.TabIndex = 187
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 10
        Me.BtnAttachment.ImageList = Me.LargeImageCollection
        Me.BtnAttachment.Location = New System.Drawing.Point(577, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(98, 34)
        Me.BtnAttachment.TabIndex = 10
        Me.BtnAttachment.Text = "Attachment"
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
        Me.LargeImageCollection.Images.SetKeyName(11, "list-add.png")
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(675, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 34)
        Me.BtnPrint.TabIndex = 9
        Me.BtnPrint.Text = "Print"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton1.Location = New System.Drawing.Point(77, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 34)
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "Cancel"
        Me.SimpleButton1.Visible = False
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
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(750, 2)
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
        Me.BtnSave.Location = New System.Drawing.Point(825, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "Save"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.LabelControl8)
        Me.GroupControl3.Controls.Add(Me.SLUEClasification)
        Me.GroupControl3.Controls.Add(Me.PanelControlBottomRight)
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 415)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(902, 88)
        Me.GroupControl3.TabIndex = 186
        '
        'PanelControlBottomRight
        '
        Me.PanelControlBottomRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBottomRight.Controls.Add(Me.LEReportStatus)
        Me.PanelControlBottomRight.Controls.Add(Me.LabelControl21)
        Me.PanelControlBottomRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlBottomRight.Location = New System.Drawing.Point(580, 2)
        Me.PanelControlBottomRight.Name = "PanelControlBottomRight"
        Me.PanelControlBottomRight.Size = New System.Drawing.Size(320, 84)
        Me.PanelControlBottomRight.TabIndex = 145
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(50, 12)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(260, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(126, 40)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(293, 36)
        Me.MENote.TabIndex = 6
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 42)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'GroupControlList
        '
        Me.GroupControlList.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlList.Controls.Add(Me.GCItemList)
        Me.GroupControlList.Controls.Add(Me.PanelControlNav)
        Me.GroupControlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlList.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlList.Name = "GroupControlList"
        Me.GroupControlList.Size = New System.Drawing.Size(896, 232)
        Me.GroupControlList.TabIndex = 185
        Me.GroupControlList.Text = "Item List"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(21, 37)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(873, 193)
        Me.GCItemList.TabIndex = 2
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumnIdSalesTarget, Me.GridColumnUOM, Me.GridColumnReturnCategory, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnProductName, Me.GridColumnIdReturnCat, Me.GridColumnIdDesignPrice, Me.GridColumnPriceType, Me.GridColumnQtyAvail, Me.GridColumnFound, Me.GridColumnid_detail_on_hold})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", Me.GridColumnQty, "{0:f2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:n2}")})
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 41
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 55
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 103
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
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 43
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
        Me.GridColumnQty.FieldName = "sales_return_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        Me.GridColumnQty.Width = 74
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 5
        Me.GridColumnPrice.Width = 89
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 6
        Me.GridColumnAmount.Width = 103
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_return_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 7
        Me.GridColumnRemark.Width = 155
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_return_order"
        Me.GridColumnIdSalesTarget.Name = "GridColumnIdSalesTarget"
        Me.GridColumnIdSalesTarget.OptionsColumn.AllowEdit = False
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
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnReturnCategory
        '
        Me.GridColumnReturnCategory.Caption = "Return Category"
        Me.GridColumnReturnCategory.FieldName = "return_cat"
        Me.GridColumnReturnCategory.Name = "GridColumnReturnCategory"
        Me.GridColumnReturnCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnReturnCategory.Width = 90
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "id design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.AllowEdit = False
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.AllowEdit = False
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sales Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sales_return_order_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnProductName
        '
        Me.GridColumnProductName.Caption = "Product Name"
        Me.GridColumnProductName.FieldName = "product_name"
        Me.GridColumnProductName.Name = "GridColumnProductName"
        Me.GridColumnProductName.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdReturnCat
        '
        Me.GridColumnIdReturnCat.Caption = "GridColumnIdReturnCat"
        Me.GridColumnIdReturnCat.FieldName = "id_return_cat"
        Me.GridColumnIdReturnCat.Name = "GridColumnIdReturnCat"
        Me.GridColumnIdReturnCat.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        Me.GridColumnIdDesignPrice.OptionsColumn.AllowEdit = False
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.OptionsColumn.AllowEdit = False
        '
        'GridColumnQtyAvail
        '
        Me.GridColumnQtyAvail.Caption = "Limit Qty"
        Me.GridColumnQtyAvail.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnQtyAvail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyAvail.FieldName = "qty_avail"
        Me.GridColumnQtyAvail.Name = "GridColumnQtyAvail"
        '
        'GridColumnFound
        '
        Me.GridColumnFound.Caption = "Found"
        Me.GridColumnFound.FieldName = "is_found"
        Me.GridColumnFound.Name = "GridColumnFound"
        '
        'GridColumnid_detail_on_hold
        '
        Me.GridColumnid_detail_on_hold.Caption = "Id Detail On Hold"
        Me.GridColumnid_detail_on_hold.FieldName = "id_detail_on_hold"
        Me.GridColumnid_detail_on_hold.Name = "GridColumnid_detail_on_hold"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlNav.Controls.Add(Me.BtnExportAsFile)
        Me.PanelControlNav.Controls.Add(Me.BtnOnHoldList)
        Me.PanelControlNav.Controls.Add(Me.BtnImport2)
        Me.PanelControlNav.Controls.Add(Me.BtnEdit)
        Me.PanelControlNav.Controls.Add(Me.BtnImport)
        Me.PanelControlNav.Controls.Add(Me.BtnDel)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Controls.Add(Me.BtnAddMultiple)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(21, 2)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(873, 35)
        Me.PanelControlNav.TabIndex = 0
        '
        'BtnExportAsFile
        '
        Me.BtnExportAsFile.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportAsFile.Image = CType(resources.GetObject("BtnExportAsFile.Image"), System.Drawing.Image)
        Me.BtnExportAsFile.ImageList = Me.LargeImageCollection
        Me.BtnExportAsFile.Location = New System.Drawing.Point(334, 0)
        Me.BtnExportAsFile.Name = "BtnExportAsFile"
        Me.BtnExportAsFile.Size = New System.Drawing.Size(112, 35)
        Me.BtnExportAsFile.TabIndex = 8
        Me.BtnExportAsFile.Text = "Export as File"
        '
        'BtnOnHoldList
        '
        Me.BtnOnHoldList.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnOnHoldList.Image = CType(resources.GetObject("BtnOnHoldList.Image"), System.Drawing.Image)
        Me.BtnOnHoldList.ImageList = Me.LargeImageCollection
        Me.BtnOnHoldList.Location = New System.Drawing.Point(446, 0)
        Me.BtnOnHoldList.Name = "BtnOnHoldList"
        Me.BtnOnHoldList.Size = New System.Drawing.Size(112, 35)
        Me.BtnOnHoldList.TabIndex = 7
        Me.BtnOnHoldList.Text = "On Hold List"
        '
        'BtnImport2
        '
        Me.BtnImport2.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnImport2.ImageIndex = 3
        Me.BtnImport2.ImageList = Me.LargeImageCollection
        Me.BtnImport2.Location = New System.Drawing.Point(137, 0)
        Me.BtnImport2.Name = "BtnImport2"
        Me.BtnImport2.Size = New System.Drawing.Size(130, 35)
        Me.BtnImport2.TabIndex = 6
        Me.BtnImport2.Text = "Import From Excel"
        '
        'BtnEdit
        '
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEdit.ImageIndex = 2
        Me.BtnEdit.ImageList = Me.LargeImageCollection
        Me.BtnEdit.Location = New System.Drawing.Point(558, 0)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(34, 35)
        Me.BtnEdit.TabIndex = 4
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.Visible = False
        '
        'BtnImport
        '
        Me.BtnImport.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnImport.ImageIndex = 3
        Me.BtnImport.ImageList = Me.LargeImageCollection
        Me.BtnImport.Location = New System.Drawing.Point(0, 0)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(137, 35)
        Me.BtnImport.TabIndex = 5
        Me.BtnImport.Text = "Import Excel Per Size"
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.ImageIndex = 1
        Me.BtnDel.ImageList = Me.LargeImageCollection
        Me.BtnDel.Location = New System.Drawing.Point(592, 0)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(80, 35)
        Me.BtnDel.TabIndex = 4
        Me.BtnDel.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(672, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(78, 35)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "Add"
        '
        'BtnAddMultiple
        '
        Me.BtnAddMultiple.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddMultiple.ImageIndex = 11
        Me.BtnAddMultiple.ImageList = Me.LargeImageCollection
        Me.BtnAddMultiple.Location = New System.Drawing.Point(750, 0)
        Me.BtnAddMultiple.Name = "BtnAddMultiple"
        Me.BtnAddMultiple.Size = New System.Drawing.Size(123, 35)
        Me.BtnAddMultiple.TabIndex = 3
        Me.BtnAddMultiple.Text = "Add Multiple Item"
        '
        'EPForm
        '
        Me.EPForm.ContainerControl = Me
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAnotherProductToolStripMenuItem, Me.ReviseQtyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(186, 48)
        '
        'AddAnotherProductToolStripMenuItem
        '
        Me.AddAnotherProductToolStripMenuItem.Name = "AddAnotherProductToolStripMenuItem"
        Me.AddAnotherProductToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AddAnotherProductToolStripMenuItem.Text = "Add another product"
        '
        'ReviseQtyToolStripMenuItem
        '
        Me.ReviseQtyToolStripMenuItem.Name = "ReviseQtyToolStripMenuItem"
        Me.ReviseQtyToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ReviseQtyToolStripMenuItem.Text = "Revise Qty"
        '
        'XTCRO
        '
        Me.XTCRO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRO.Location = New System.Drawing.Point(0, 155)
        Me.XTCRO.Name = "XTCRO"
        Me.XTCRO.SelectedTabPage = Me.XTPItems
        Me.XTCRO.Size = New System.Drawing.Size(902, 260)
        Me.XTCRO.TabIndex = 188
        Me.XTCRO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPItems, Me.XTPRate})
        '
        'XTPItems
        '
        Me.XTPItems.Controls.Add(Me.GroupControlList)
        Me.XTPItems.Name = "XTPItems"
        Me.XTPItems.Size = New System.Drawing.Size(896, 232)
        Me.XTPItems.Text = "Items"
        '
        'XTPRate
        '
        Me.XTPRate.Controls.Add(Me.GCRate)
        Me.XTPRate.Name = "XTPRate"
        Me.XTPRate.Size = New System.Drawing.Size(896, 245)
        Me.XTPRate.Text = "Cargo Rate"
        '
        'GCRate
        '
        Me.GCRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRate.Location = New System.Drawing.Point(0, 0)
        Me.GCRate.MainView = Me.GVRate
        Me.GCRate.Name = "GCRate"
        Me.GCRate.Size = New System.Drawing.Size(896, 245)
        Me.GCRate.TabIndex = 0
        Me.GCRate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRate})
        '
        'GVRate
        '
        Me.GVRate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_cargo, Me.GridColumncargo_name, Me.GridColumncargo_rate, Me.GridColumncargo_lead_time, Me.GridColumncargo_min_weight})
        Me.GVRate.GridControl = Me.GCRate
        Me.GVRate.Name = "GVRate"
        Me.GVRate.OptionsBehavior.Editable = False
        Me.GVRate.OptionsFind.AlwaysVisible = True
        Me.GVRate.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_cargo
        '
        Me.GridColumnid_cargo.Caption = "Id Cargo"
        Me.GridColumnid_cargo.FieldName = "id_cargo"
        Me.GridColumnid_cargo.Name = "GridColumnid_cargo"
        '
        'GridColumncargo_name
        '
        Me.GridColumncargo_name.Caption = "Cargo"
        Me.GridColumncargo_name.FieldName = "cargo_name"
        Me.GridColumncargo_name.Name = "GridColumncargo_name"
        Me.GridColumncargo_name.Visible = True
        Me.GridColumncargo_name.VisibleIndex = 0
        '
        'GridColumncargo_rate
        '
        Me.GridColumncargo_rate.Caption = "Rate"
        Me.GridColumncargo_rate.DisplayFormat.FormatString = "N2"
        Me.GridColumncargo_rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumncargo_rate.FieldName = "cargo_rate"
        Me.GridColumncargo_rate.Name = "GridColumncargo_rate"
        Me.GridColumncargo_rate.Visible = True
        Me.GridColumncargo_rate.VisibleIndex = 1
        '
        'GridColumncargo_lead_time
        '
        Me.GridColumncargo_lead_time.Caption = "Lead Time (day)"
        Me.GridColumncargo_lead_time.DisplayFormat.FormatString = "N0"
        Me.GridColumncargo_lead_time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumncargo_lead_time.FieldName = "cargo_lead_time"
        Me.GridColumncargo_lead_time.Name = "GridColumncargo_lead_time"
        Me.GridColumncargo_lead_time.Visible = True
        Me.GridColumncargo_lead_time.VisibleIndex = 2
        '
        'GridColumncargo_min_weight
        '
        Me.GridColumncargo_min_weight.Caption = "Minimum Weight (kg)"
        Me.GridColumncargo_min_weight.DisplayFormat.FormatString = "N2"
        Me.GridColumncargo_min_weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumncargo_min_weight.FieldName = "cargo_min_weight"
        Me.GridColumncargo_min_weight.Name = "GridColumncargo_min_weight"
        Me.GridColumncargo_min_weight.Visible = True
        Me.GridColumncargo_min_weight.VisibleIndex = 3
        '
        'SLUEClasification
        '
        Me.SLUEClasification.Location = New System.Drawing.Point(126, 14)
        Me.SLUEClasification.Name = "SLUEClasification"
        Me.SLUEClasification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEClasification.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEClasification.Size = New System.Drawing.Size(293, 20)
        Me.SLUEClasification.TabIndex = 146
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(27, 17)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl8.TabIndex = 147
        Me.LabelControl8.Text = "Return Clasification"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_return_clasification"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Return Clasification"
        Me.GridColumn2.FieldName = "return_clasification"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormSalesReturnOrderDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 541)
        Me.Controls.Add(Me.XTCRO)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnOrderDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Return"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.DEDelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDelDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DERetDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DERetDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSalesOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopLeft.ResumeLayout(False)
        Me.PanelControlTopLeft.PerformLayout()
        CType(Me.TxtOrderType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEOrderType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEOnHold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.PanelControlBottomRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottomRight.ResumeLayout(False)
        Me.PanelControlBottomRight.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlList.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.EPForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.XTCRO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRO.ResumeLayout(False)
        Me.XTPItems.ResumeLayout(False)
        Me.XTPRate.ResumeLayout(False)
        CType(Me.GCRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEClasification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEForm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSalesOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAdrressCompTo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnBrowseContactTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNameCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCodeCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlList As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPForm As System.Windows.Forms.ErrorProvider
    Friend WithEvents GridColumnProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DERetDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumnIdReturnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlTopLeft As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlBottomRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddMultiple As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnImport2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnQtyAvail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFound As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddAnotherProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReviseQtyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDelDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents XTCRO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPItems As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRate As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_cargo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncargo_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncargo_rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncargo_lead_time As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncargo_min_weight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_detail_on_hold As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEOnHold As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnOnHoldList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExportAsFile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOrderType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LEOrderType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUEClasification As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
