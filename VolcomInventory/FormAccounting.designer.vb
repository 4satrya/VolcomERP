<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAccounting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccounting))
        Me.XTCGeneral = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPAccount = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAcc = New DevExpress.XtraGrid.GridControl()
        Me.GVAcc = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.address_primary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XTPTreeList = New DevExpress.XtraTab.XtraTabPage()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.id_acc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.id_acc_parent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColAccName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColAccDesc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColIdAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.XTPARAP = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCompany = New DevExpress.XtraGrid.GridControl()
        Me.GVCompany = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CompanyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesReturnAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewCompany = New DevExpress.XtraEditors.SimpleButton()
        Me.LECompanyCategory = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCGeneralSetup = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPurchasing = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnBrowseVAT = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowseRec = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtVATDesc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtVATAccount = New DevExpress.XtraEditors.TextEdit()
        Me.TxtRecDesc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtRecAccount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BalanceMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewTransaction = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.XTCGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCGeneral.SuspendLayout()
        Me.XTPAccount.SuspendLayout()
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPTreeList.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPARAP.SuspendLayout()
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LECompanyCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPGeneral.SuspendLayout()
        CType(Me.XTCGeneralSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCGeneralSetup.SuspendLayout()
        Me.XTPPurchasing.SuspendLayout()
        CType(Me.TxtVATDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVATAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRecDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRecAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BalanceMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCGeneral
        '
        Me.XTCGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCGeneral.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCGeneral.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCGeneral.Location = New System.Drawing.Point(0, 0)
        Me.XTCGeneral.Name = "XTCGeneral"
        Me.XTCGeneral.SelectedTabPage = Me.XTPAccount
        Me.XTCGeneral.Size = New System.Drawing.Size(812, 366)
        Me.XTCGeneral.TabIndex = 0
        Me.XTCGeneral.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAccount, Me.XTPTreeList, Me.XTPARAP, Me.XTPGeneral})
        '
        'XTPAccount
        '
        Me.XTPAccount.Controls.Add(Me.GCAcc)
        Me.XTPAccount.Name = "XTPAccount"
        Me.XTPAccount.Size = New System.Drawing.Size(708, 360)
        Me.XTPAccount.Text = "Chart Of Account"
        '
        'GCAcc
        '
        Me.GCAcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAcc.Location = New System.Drawing.Point(0, 0)
        Me.GCAcc.MainView = Me.GVAcc
        Me.GCAcc.Name = "GCAcc"
        Me.GCAcc.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCAcc.Size = New System.Drawing.Size(708, 360)
        Me.GCAcc.TabIndex = 4
        Me.GCAcc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAcc})
        '
        'GVAcc
        '
        Me.GVAcc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.company, Me.address_primary, Me.is_active, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVAcc.GridControl = Me.GCAcc
        Me.GVAcc.Name = "GVAcc"
        Me.GVAcc.OptionsBehavior.Editable = False
        Me.GVAcc.OptionsFind.AlwaysVisible = True
        Me.GVAcc.OptionsView.ShowGroupPanel = False
        Me.GVAcc.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.company, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'id_company
        '
        Me.id_company.Caption = "ID"
        Me.id_company.FieldName = "id_acc"
        Me.id_company.Name = "id_company"
        '
        'company
        '
        Me.company.Caption = "Account"
        Me.company.FieldName = "acc_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 0
        Me.company.Width = 237
        '
        'address_primary
        '
        Me.address_primary.Caption = "Description"
        Me.address_primary.FieldName = "acc_description"
        Me.address_primary.Name = "address_primary"
        Me.address_primary.Visible = True
        Me.address_primary.VisibleIndex = 1
        Me.address_primary.Width = 500
        '
        'is_active
        '
        Me.is_active.AppearanceHeader.Options.UseTextOptions = True
        Me.is_active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.is_active.Caption = "Active"
        Me.is_active.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.is_active.FieldName = "id_status"
        Me.is_active.Name = "is_active"
        Me.is_active.Visible = True
        Me.is_active.VisibleIndex = 3
        Me.is_active.Width = 110
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueGrayed = "0"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Cost Center"
        Me.GridColumn1.FieldName = "comp_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 333
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "CC Number"
        Me.GridColumn2.FieldName = "comp_number"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Comp"
        Me.GridColumn3.FieldName = "id_comp"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'XTPTreeList
        '
        Me.XTPTreeList.Controls.Add(Me.TreeList1)
        Me.XTPTreeList.Name = "XTPTreeList"
        Me.XTPTreeList.Size = New System.Drawing.Size(708, 360)
        Me.XTPTreeList.Text = "View Ledger"
        '
        'TreeList1
        '
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.id_acc, Me.id_acc_parent, Me.ColAccName, Me.ColAccDesc, Me.ColDebit, Me.ColCredit, Me.ColIdAllChild, Me.TreeListColumn1, Me.TreeListColumn2, Me.TreeListColumn3})
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.KeyFieldName = "id_acc"
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.AutoPopulateColumns = False
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsFilter.AllowMRUFilterList = False
        Me.TreeList1.OptionsFind.AllowFindPanel = True
        Me.TreeList1.OptionsFind.AlwaysVisible = True
        Me.TreeList1.OptionsView.EnableAppearanceEvenRow = True
        Me.TreeList1.ParentFieldName = "id_acc_parent"
        Me.TreeList1.RootValue = "0"
        Me.TreeList1.Size = New System.Drawing.Size(708, 360)
        Me.TreeList1.TabIndex = 0
        '
        'id_acc
        '
        Me.id_acc.Caption = "id_acc"
        Me.id_acc.FieldName = "id_acc"
        Me.id_acc.Name = "id_acc"
        Me.id_acc.OptionsColumn.ReadOnly = True
        Me.id_acc.Width = 185
        '
        'id_acc_parent
        '
        Me.id_acc_parent.Caption = "id_acc_parent"
        Me.id_acc_parent.FieldName = "id_acc_parent"
        Me.id_acc_parent.Name = "id_acc_parent"
        Me.id_acc_parent.OptionsColumn.ReadOnly = True
        Me.id_acc_parent.Width = 186
        '
        'ColAccName
        '
        Me.ColAccName.Caption = "Account"
        Me.ColAccName.FieldName = "acc_name"
        Me.ColAccName.Name = "ColAccName"
        Me.ColAccName.OptionsColumn.ReadOnly = True
        Me.ColAccName.Visible = True
        Me.ColAccName.VisibleIndex = 0
        Me.ColAccName.Width = 165
        '
        'ColAccDesc
        '
        Me.ColAccDesc.Caption = "Description"
        Me.ColAccDesc.FieldName = "acc_description"
        Me.ColAccDesc.Name = "ColAccDesc"
        Me.ColAccDesc.OptionsColumn.ReadOnly = True
        Me.ColAccDesc.Visible = True
        Me.ColAccDesc.VisibleIndex = 1
        Me.ColAccDesc.Width = 227
        '
        'ColDebit
        '
        Me.ColDebit.AppearanceCell.Options.UseTextOptions = True
        Me.ColDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDebit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.Caption = "Debit"
        Me.ColDebit.FieldName = "debit"
        Me.ColDebit.Format.FormatString = "N2"
        Me.ColDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDebit.Name = "ColDebit"
        Me.ColDebit.OptionsColumn.ReadOnly = True
        Me.ColDebit.Visible = True
        Me.ColDebit.VisibleIndex = 3
        Me.ColDebit.Width = 118
        '
        'ColCredit
        '
        Me.ColCredit.AppearanceCell.Options.UseTextOptions = True
        Me.ColCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColCredit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCredit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColCredit.Caption = "Credit"
        Me.ColCredit.FieldName = "credit"
        Me.ColCredit.Format.FormatString = "N2"
        Me.ColCredit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColCredit.Name = "ColCredit"
        Me.ColCredit.OptionsColumn.ReadOnly = True
        Me.ColCredit.Visible = True
        Me.ColCredit.VisibleIndex = 4
        Me.ColCredit.Width = 116
        '
        'ColIdAllChild
        '
        Me.ColIdAllChild.Caption = "Child"
        Me.ColIdAllChild.FieldName = "id_all_child"
        Me.ColIdAllChild.Name = "ColIdAllChild"
        Me.ColIdAllChild.OptionsColumn.ReadOnly = True
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.Caption = "Cost Center"
        Me.TreeListColumn1.FieldName = "company_name"
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.OptionsColumn.ReadOnly = True
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 2
        Me.TreeListColumn1.Width = 117
        '
        'TreeListColumn2
        '
        Me.TreeListColumn2.Caption = "Cost Center Number"
        Me.TreeListColumn2.FieldName = "company_number"
        Me.TreeListColumn2.Name = "TreeListColumn2"
        Me.TreeListColumn2.OptionsColumn.ReadOnly = True
        '
        'TreeListColumn3
        '
        Me.TreeListColumn3.Caption = "Id Company"
        Me.TreeListColumn3.FieldName = "id_comp"
        Me.TreeListColumn3.Name = "TreeListColumn3"
        Me.TreeListColumn3.OptionsColumn.ReadOnly = True
        '
        'XTPARAP
        '
        Me.XTPARAP.Controls.Add(Me.GCCompany)
        Me.XTPARAP.Controls.Add(Me.PanelControl1)
        Me.XTPARAP.Name = "XTPARAP"
        Me.XTPARAP.Size = New System.Drawing.Size(708, 360)
        Me.XTPARAP.Text = "Company Setup"
        '
        'GCCompany
        '
        Me.GCCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompany.Location = New System.Drawing.Point(0, 48)
        Me.GCCompany.MainView = Me.GVCompany
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit2, Me.RepositoryItemTextEdit1})
        Me.GCCompany.Size = New System.Drawing.Size(708, 312)
        Me.GCCompany.TabIndex = 4
        Me.GCCompany.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompany})
        '
        'GVCompany
        '
        Me.GVCompany.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.CompanyCode, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.Category, Me.GridColumn8, Me.GridColumn10, Me.GridColumn9, Me.GridColumnSalesAccount, Me.GridColumnSalesReturnAccount})
        Me.GVCompany.GridControl = Me.GCCompany
        Me.GVCompany.Name = "GVCompany"
        Me.GVCompany.OptionsBehavior.Editable = False
        Me.GVCompany.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID"
        Me.GridColumn4.FieldName = "id_comp"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'CompanyCode
        '
        Me.CompanyCode.Caption = "Code"
        Me.CompanyCode.FieldName = "comp_number"
        Me.CompanyCode.Name = "CompanyCode"
        Me.CompanyCode.Visible = True
        Me.CompanyCode.VisibleIndex = 1
        Me.CompanyCode.Width = 79
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Company"
        Me.GridColumn5.FieldName = "comp_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 105
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Address"
        Me.GridColumn6.FieldName = "address_primary"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Width = 289
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "Active"
        Me.GridColumn7.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.GridColumn7.FieldName = "is_active"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 8
        Me.GridColumn7.Width = 52
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit2.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Category
        '
        Me.Category.Caption = "Category"
        Me.Category.FieldName = "company_category"
        Me.Category.Name = "Category"
        Me.Category.Visible = True
        Me.Category.VisibleIndex = 2
        Me.Category.Width = 80
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Account Payable"
        Me.GridColumn8.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn8.FieldName = "acc_ap"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Down Payment"
        Me.GridColumn10.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn10.FieldName = "acc_dp"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Account Receivable"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn9.FieldName = "acc_ar"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 5
        '
        'GridColumnSalesAccount
        '
        Me.GridColumnSalesAccount.Caption = "Sales Account"
        Me.GridColumnSalesAccount.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnSalesAccount.FieldName = "acc_sales"
        Me.GridColumnSalesAccount.Name = "GridColumnSalesAccount"
        Me.GridColumnSalesAccount.Visible = True
        Me.GridColumnSalesAccount.VisibleIndex = 3
        '
        'GridColumnSalesReturnAccount
        '
        Me.GridColumnSalesReturnAccount.Caption = "Sales Return Account"
        Me.GridColumnSalesReturnAccount.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnSalesReturnAccount.FieldName = "acc_sales_return"
        Me.GridColumnSalesReturnAccount.Name = "GridColumnSalesReturnAccount"
        Me.GridColumnSalesReturnAccount.Visible = True
        Me.GridColumnSalesReturnAccount.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.DisplayValueChecked = "1"
        Me.RepositoryItemCheckEdit3.DisplayValueUnchecked = "0"
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewCompany)
        Me.PanelControl1.Controls.Add(Me.LECompanyCategory)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(708, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewCompany
        '
        Me.BtnViewCompany.Location = New System.Drawing.Point(251, 11)
        Me.BtnViewCompany.Name = "BtnViewCompany"
        Me.BtnViewCompany.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewCompany.TabIndex = 6
        Me.BtnViewCompany.Text = "View"
        '
        'LECompanyCategory
        '
        Me.LECompanyCategory.Location = New System.Drawing.Point(69, 13)
        Me.LECompanyCategory.Name = "LECompanyCategory"
        Me.LECompanyCategory.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LECompanyCategory.Properties.Appearance.Options.UseFont = True
        Me.LECompanyCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECompanyCategory.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_comp_cat", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("comp_cat_name", "Category"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Description")})
        Me.LECompanyCategory.Properties.NullText = ""
        Me.LECompanyCategory.Size = New System.Drawing.Size(178, 20)
        Me.LECompanyCategory.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Category"
        '
        'XTPGeneral
        '
        Me.XTPGeneral.Controls.Add(Me.XTCGeneralSetup)
        Me.XTPGeneral.Name = "XTPGeneral"
        Me.XTPGeneral.Size = New System.Drawing.Size(708, 360)
        Me.XTPGeneral.Text = "General Setup"
        '
        'XTCGeneralSetup
        '
        Me.XTCGeneralSetup.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCGeneralSetup.AppearancePage.Header.Options.UseFont = True
        Me.XTCGeneralSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCGeneralSetup.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCGeneralSetup.Location = New System.Drawing.Point(0, 0)
        Me.XTCGeneralSetup.LookAndFeel.SkinName = "Metropolis"
        Me.XTCGeneralSetup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCGeneralSetup.Name = "XTCGeneralSetup"
        Me.XTCGeneralSetup.SelectedTabPage = Me.XTPPurchasing
        Me.XTCGeneralSetup.Size = New System.Drawing.Size(708, 360)
        Me.XTCGeneralSetup.TabIndex = 0
        Me.XTCGeneralSetup.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPurchasing})
        '
        'XTPPurchasing
        '
        Me.XTPPurchasing.Controls.Add(Me.BtnBrowseVAT)
        Me.XTPPurchasing.Controls.Add(Me.BtnBrowseRec)
        Me.XTPPurchasing.Controls.Add(Me.BtnDiscard)
        Me.XTPPurchasing.Controls.Add(Me.BtnSave)
        Me.XTPPurchasing.Controls.Add(Me.TxtVATDesc)
        Me.XTPPurchasing.Controls.Add(Me.TxtVATAccount)
        Me.XTPPurchasing.Controls.Add(Me.TxtRecDesc)
        Me.XTPPurchasing.Controls.Add(Me.TxtRecAccount)
        Me.XTPPurchasing.Controls.Add(Me.LabelControl3)
        Me.XTPPurchasing.Controls.Add(Me.LabelControl2)
        Me.XTPPurchasing.Name = "XTPPurchasing"
        Me.XTPPurchasing.Size = New System.Drawing.Size(706, 334)
        Me.XTPPurchasing.Text = "Purchasing"
        '
        'BtnBrowseVAT
        '
        Me.BtnBrowseVAT.Image = CType(resources.GetObject("BtnBrowseVAT.Image"), System.Drawing.Image)
        Me.BtnBrowseVAT.Location = New System.Drawing.Point(613, 81)
        Me.BtnBrowseVAT.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BtnBrowseVAT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnBrowseVAT.Name = "BtnBrowseVAT"
        Me.BtnBrowseVAT.Size = New System.Drawing.Size(27, 20)
        Me.BtnBrowseVAT.TabIndex = 9
        Me.BtnBrowseVAT.ToolTip = "Browse"
        '
        'BtnBrowseRec
        '
        Me.BtnBrowseRec.Image = CType(resources.GetObject("BtnBrowseRec.Image"), System.Drawing.Image)
        Me.BtnBrowseRec.Location = New System.Drawing.Point(613, 36)
        Me.BtnBrowseRec.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BtnBrowseRec.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnBrowseRec.Name = "BtnBrowseRec"
        Me.BtnBrowseRec.Size = New System.Drawing.Size(27, 20)
        Me.BtnBrowseRec.TabIndex = 8
        Me.BtnBrowseRec.ToolTip = "Browse"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnDiscard.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDiscard.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDiscard.Appearance.Options.UseBackColor = True
        Me.BtnDiscard.Appearance.Options.UseFont = True
        Me.BtnDiscard.Appearance.Options.UseForeColor = True
        Me.BtnDiscard.Location = New System.Drawing.Point(426, 117)
        Me.BtnDiscard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(104, 29)
        Me.BtnDiscard.TabIndex = 7
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Appearance.Options.UseForeColor = True
        Me.BtnSave.Location = New System.Drawing.Point(536, 117)
        Me.BtnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSave.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(104, 29)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save Changes"
        '
        'TxtVATDesc
        '
        Me.TxtVATDesc.Enabled = False
        Me.TxtVATDesc.Location = New System.Drawing.Point(189, 81)
        Me.TxtVATDesc.Name = "TxtVATDesc"
        Me.TxtVATDesc.Size = New System.Drawing.Size(420, 20)
        Me.TxtVATDesc.TabIndex = 5
        '
        'TxtVATAccount
        '
        Me.TxtVATAccount.Enabled = False
        Me.TxtVATAccount.Location = New System.Drawing.Point(19, 81)
        Me.TxtVATAccount.Name = "TxtVATAccount"
        Me.TxtVATAccount.Size = New System.Drawing.Size(164, 20)
        Me.TxtVATAccount.TabIndex = 4
        '
        'TxtRecDesc
        '
        Me.TxtRecDesc.Enabled = False
        Me.TxtRecDesc.Location = New System.Drawing.Point(189, 36)
        Me.TxtRecDesc.Name = "TxtRecDesc"
        Me.TxtRecDesc.Size = New System.Drawing.Size(420, 20)
        Me.TxtRecDesc.TabIndex = 3
        '
        'TxtRecAccount
        '
        Me.TxtRecAccount.Enabled = False
        Me.TxtRecAccount.Location = New System.Drawing.Point(19, 36)
        Me.TxtRecAccount.Name = "TxtRecAccount"
        Me.TxtRecAccount.Size = New System.Drawing.Size(164, 20)
        Me.TxtRecAccount.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 62)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "VAT In Account"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Receive Account"
        '
        'BalanceMenu
        '
        Me.BalanceMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewTransaction})
        Me.BalanceMenu.Name = "ContextMenuStripYM"
        Me.BalanceMenu.Size = New System.Drawing.Size(136, 26)
        '
        'SMViewTransaction
        '
        Me.SMViewTransaction.Name = "SMViewTransaction"
        Me.SMViewTransaction.Size = New System.Drawing.Size(135, 22)
        Me.SMViewTransaction.Text = "Transaction"
        '
        'FormAccounting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 366)
        Me.Controls.Add(Me.XTCGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccounting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Account"
        CType(Me.XTCGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCGeneral.ResumeLayout(False)
        Me.XTPAccount.ResumeLayout(False)
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPTreeList.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPARAP.ResumeLayout(False)
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LECompanyCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPGeneral.ResumeLayout(False)
        CType(Me.XTCGeneralSetup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCGeneralSetup.ResumeLayout(False)
        Me.XTPPurchasing.ResumeLayout(False)
        Me.XTPPurchasing.PerformLayout()
        CType(Me.TxtVATDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVATAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRecDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRecAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BalanceMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCGeneral As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAccount As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAcc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAcc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents address_primary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XTPTreeList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ColAccName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColAccDesc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents id_acc_parent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents id_acc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents BalanceMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMViewTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColIdAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn3 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents XTPARAP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCCompany As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompany As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CompanyCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewCompany As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LECompanyCategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesReturnAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCGeneralSetup As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPurchasing As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnBrowseVAT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowseRec As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtVATDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtVATAccount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtRecDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtRecAccount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
