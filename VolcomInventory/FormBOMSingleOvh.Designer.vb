<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBOMSingleOvh
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.GCOVH = New DevExpress.XtraGrid.GridControl()
        Me.GVOVH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCOVHPrice = New DevExpress.XtraGrid.GridControl()
        Me.GVOVHPrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColMatPirce = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCompany = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrenct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.BGetKurs = New DevExpress.XtraEditors.SimpleButton()
        Me.CEOVHMain = New DevExpress.XtraEditors.CheckEdit()
        Me.TEPriceTot = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPrice = New DevExpress.XtraEditors.TextEdit()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEUOM = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEQty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.TEVendCur = New DevExpress.XtraEditors.TextEdit()
        Me.TEVendPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControlUpdateName = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelBomName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCOVHPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOVHPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.CEOVHMain.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPriceTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendCur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(824, 496)
        Me.SplitContainerControl1.SplitterPosition = 296
        Me.SplitContainerControl1.TabIndex = 28
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCOVH)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(824, 296)
        Me.GroupGeneral.TabIndex = 14
        Me.GroupGeneral.Text = "Overhead"
        '
        'GCOVH
        '
        Me.GCOVH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOVH.Location = New System.Drawing.Point(2, 20)
        Me.GCOVH.MainView = Me.GVOVH
        Me.GCOVH.Name = "GCOVH"
        Me.GCOVH.Size = New System.Drawing.Size(820, 274)
        Me.GCOVH.TabIndex = 11
        Me.GCOVH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOVH, Me.GridView3})
        '
        'GVOVH
        '
        Me.GVOVH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnCat, Me.GridColumn6, Me.GridColumn3, Me.GridColumn4})
        Me.GVOVH.GridControl = Me.GCOVH
        Me.GVOVH.Name = "GVOVH"
        Me.GVOVH.OptionsBehavior.Editable = False
        Me.GVOVH.OptionsFind.AlwaysVisible = True
        Me.GVOVH.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVOVH.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat"
        Me.GridColumn1.FieldName = "id_ovh"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnCat
        '
        Me.GridColumnCat.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCat.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "ovh_cat"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Code"
        Me.GridColumn6.FieldName = "overhead_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Overhead"
        Me.GridColumn3.FieldName = "overhead"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "UOM"
        Me.GridColumn4.FieldName = "uom"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCOVH
        Me.GridView3.Name = "GridView3"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.GCOVHPrice)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(824, 195)
        Me.GroupControl1.TabIndex = 15
        Me.GroupControl1.Text = "Price"
        '
        'GCOVHPrice
        '
        Me.GCOVHPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOVHPrice.Location = New System.Drawing.Point(2, 20)
        Me.GCOVHPrice.MainView = Me.GVOVHPrice
        Me.GCOVHPrice.Name = "GCOVHPrice"
        Me.GCOVHPrice.Size = New System.Drawing.Size(820, 173)
        Me.GCOVHPrice.TabIndex = 3
        Me.GCOVHPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOVHPrice, Me.GridView1})
        '
        'GVOVHPrice
        '
        Me.GVOVHPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColMatPirce, Me.GridColumn2, Me.ColPriceName, Me.ColCompany, Me.ColPrice, Me.ColDate, Me.ColCurrenct, Me.GridColumnIDCurrency})
        Me.GVOVHPrice.GridControl = Me.GCOVHPrice
        Me.GVOVHPrice.Name = "GVOVHPrice"
        Me.GVOVHPrice.OptionsBehavior.Editable = False
        Me.GVOVHPrice.OptionsView.ShowGroupPanel = False
        '
        'ColMatPirce
        '
        Me.ColMatPirce.Caption = "Id Price"
        Me.ColMatPirce.FieldName = "id_ovh_price"
        Me.ColMatPirce.Name = "ColMatPirce"
        '
        'ColPriceName
        '
        Me.ColPriceName.Caption = "Name"
        Me.ColPriceName.FieldName = "ovh_price_name"
        Me.ColPriceName.Name = "ColPriceName"
        Me.ColPriceName.Visible = True
        Me.ColPriceName.VisibleIndex = 0
        Me.ColPriceName.Width = 239
        '
        'ColCompany
        '
        Me.ColCompany.Caption = "Vendor"
        Me.ColCompany.FieldName = "comp_name"
        Me.ColCompany.Name = "ColCompany"
        Me.ColCompany.Visible = True
        Me.ColCompany.VisibleIndex = 2
        Me.ColCompany.Width = 348
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N4"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "ovh_price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 4
        Me.ColPrice.Width = 348
        '
        'ColDate
        '
        Me.ColDate.Caption = "Date"
        Me.ColDate.FieldName = "ovh_price_date"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.Visible = True
        Me.ColDate.VisibleIndex = 5
        Me.ColDate.Width = 359
        '
        'ColCurrenct
        '
        Me.ColCurrenct.AppearanceCell.Options.UseTextOptions = True
        Me.ColCurrenct.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCurrenct.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCurrenct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCurrenct.Caption = "Currency"
        Me.ColCurrenct.FieldName = "currency"
        Me.ColCurrenct.Name = "ColCurrenct"
        Me.ColCurrenct.Visible = True
        Me.ColCurrenct.VisibleIndex = 3
        Me.ColCurrenct.Width = 119
        '
        'GridColumnIDCurrency
        '
        Me.GridColumnIDCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnIDCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIDCurrency.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIDCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIDCurrency.Caption = "ID Currency"
        Me.GridColumnIDCurrency.Name = "GridColumnIDCurrency"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCOVHPrice
        Me.GridView1.Name = "GridView1"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.BGetKurs)
        Me.GroupControl2.Controls.Add(Me.CEOVHMain)
        Me.GroupControl2.Controls.Add(Me.TEPriceTot)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.TEPrice)
        Me.GroupControl2.Controls.Add(Me.TEKurs)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.TEUOM)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.TEQty)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl2.Location = New System.Drawing.Point(0, 496)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(824, 63)
        Me.GroupControl2.TabIndex = 27
        Me.GroupControl2.Text = "Detail"
        '
        'BGetKurs
        '
        Me.BGetKurs.Location = New System.Drawing.Point(158, 24)
        Me.BGetKurs.Name = "BGetKurs"
        Me.BGetKurs.Size = New System.Drawing.Size(70, 23)
        Me.BGetKurs.TabIndex = 119
        Me.BGetKurs.Text = "Get Kurs"
        '
        'CEOVHMain
        '
        Me.CEOVHMain.EditValue = True
        Me.CEOVHMain.Location = New System.Drawing.Point(691, 27)
        Me.CEOVHMain.Name = "CEOVHMain"
        Me.CEOVHMain.Properties.Caption = "Set as main Vendor"
        Me.CEOVHMain.Size = New System.Drawing.Size(128, 19)
        Me.CEOVHMain.TabIndex = 118
        '
        'TEPriceTot
        '
        Me.TEPriceTot.Enabled = False
        Me.TEPriceTot.Location = New System.Drawing.Point(534, 27)
        Me.TEPriceTot.Name = "TEPriceTot"
        Me.TEPriceTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEPriceTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TEPriceTot.Properties.Mask.EditMask = "N4"
        Me.TEPriceTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPriceTot.Properties.Mask.SaveLiteral = False
        Me.TEPriceTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPriceTot.Size = New System.Drawing.Size(142, 20)
        Me.TEPriceTot.TabIndex = 6
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(534, 11)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl7.TabIndex = 116
        Me.LabelControl7.Text = "Total Price"
        '
        'TEPrice
        '
        Me.TEPrice.Location = New System.Drawing.Point(234, 27)
        Me.TEPrice.Name = "TEPrice"
        Me.TEPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.TEPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEPrice.Properties.Mask.EditMask = "N4"
        Me.TEPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPrice.Properties.Mask.SaveLiteral = False
        Me.TEPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPrice.Size = New System.Drawing.Size(141, 20)
        Me.TEPrice.TabIndex = 3
        '
        'TEKurs
        '
        Me.TEKurs.Location = New System.Drawing.Point(23, 26)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Properties.ReadOnly = True
        Me.TEKurs.Size = New System.Drawing.Size(129, 20)
        Me.TEKurs.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(234, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 114
        Me.LabelControl2.Text = "Price"
        '
        'TEUOM
        '
        Me.TEUOM.Enabled = False
        Me.TEUOM.Location = New System.Drawing.Point(470, 26)
        Me.TEUOM.Name = "TEUOM"
        Me.TEUOM.Properties.Appearance.Options.UseTextOptions = True
        Me.TEUOM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEUOM.Size = New System.Drawing.Size(58, 20)
        Me.TEUOM.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(23, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 88
        Me.LabelControl3.Text = "Kurs"
        '
        'TEQty
        '
        Me.TEQty.Location = New System.Drawing.Point(381, 27)
        Me.TEQty.Name = "TEQty"
        Me.TEQty.Properties.Appearance.Options.UseTextOptions = True
        Me.TEQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEQty.Properties.EditValueChangedDelay = 1
        Me.TEQty.Properties.Mask.EditMask = "N2"
        Me.TEQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEQty.Properties.Mask.SaveLiteral = False
        Me.TEQty.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEQty.Size = New System.Drawing.Size(83, 20)
        Me.TEQty.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(381, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl1.TabIndex = 84
        Me.LabelControl1.Text = "Qty"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(421, -5)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(49, 15)
        Me.LabelControl5.TabIndex = 112
        Me.LabelControl5.Text = "Currency"
        Me.LabelControl5.Visible = False
        '
        'LECurrency
        '
        Me.LECurrency.Enabled = False
        Me.LECurrency.Location = New System.Drawing.Point(421, 12)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(84, 20)
        Me.LECurrency.TabIndex = 1
        Me.LECurrency.Visible = False
        '
        'TEVendCur
        '
        Me.TEVendCur.Enabled = False
        Me.TEVendCur.Location = New System.Drawing.Point(158, 12)
        Me.TEVendCur.Name = "TEVendCur"
        Me.TEVendCur.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVendCur.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TEVendCur.Size = New System.Drawing.Size(84, 20)
        Me.TEVendCur.TabIndex = 89
        Me.TEVendCur.Visible = False
        '
        'TEVendPrice
        '
        Me.TEVendPrice.Enabled = False
        Me.TEVendPrice.Location = New System.Drawing.Point(248, 12)
        Me.TEVendPrice.Name = "TEVendPrice"
        Me.TEVendPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVendPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVendPrice.Properties.Mask.EditMask = "N2"
        Me.TEVendPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVendPrice.Properties.Mask.SaveLiteral = False
        Me.TEVendPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEVendPrice.Size = New System.Drawing.Size(167, 20)
        Me.TEVendPrice.TabIndex = 81
        Me.TEVendPrice.Visible = False
        '
        'LabelControlUpdateName
        '
        Me.LabelControlUpdateName.Location = New System.Drawing.Point(158, -4)
        Me.LabelControlUpdateName.Name = "LabelControlUpdateName"
        Me.LabelControlUpdateName.Size = New System.Drawing.Size(60, 13)
        Me.LabelControlUpdateName.TabIndex = 82
        Me.LabelControlUpdateName.Text = "Vendor Price"
        Me.LabelControlUpdateName.Visible = False
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.LabelBomName)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Controls.Add(Me.TEVendCur)
        Me.PanelControl2.Controls.Add(Me.LabelControl5)
        Me.PanelControl2.Controls.Add(Me.LECurrency)
        Me.PanelControl2.Controls.Add(Me.TEVendPrice)
        Me.PanelControl2.Controls.Add(Me.LabelControlUpdateName)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 559)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(824, 38)
        Me.PanelControl2.TabIndex = 26
        '
        'LabelBomName
        '
        Me.LabelBomName.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBomName.Location = New System.Drawing.Point(89, 6)
        Me.LabelBomName.Name = "LabelBomName"
        Me.LabelBomName.Size = New System.Drawing.Size(6, 26)
        Me.LabelBomName.TabIndex = 13
        Me.LabelBomName.Text = "-"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(5, 6)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(84, 26)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Method : "
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(684, 0)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 38)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(754, 0)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 38)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = " Save"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Contact Person"
        Me.GridColumn2.FieldName = "cp"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 219
        '
        'FormBOMSingleOvh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 597)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBOMSingleOvh"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Overhead"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCOVHPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOVHPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.CEOVHMain.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPriceTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendCur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCOVH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOVH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCOVHPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOVHPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColMatPirce As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompany As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrenct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TEPriceTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEUOM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TEVendCur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVendPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControlUpdateName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelBomName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEOVHMain As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnIDCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGetKurs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
