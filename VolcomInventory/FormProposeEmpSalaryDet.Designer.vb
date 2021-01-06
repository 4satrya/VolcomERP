<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposeEmpSalaryDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProposeEmpSalaryDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.DECreatedAt = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.DEEffectiveDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.CMSGCEmployee = New System.Windows.Forms.ContextMenuStrip()
        Me.RemoveEmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GBEmployee = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCEmployeeId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdEmployeeLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLengthOfWork = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalaryCurrent = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCBasicSalaryCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCJobAllowanceCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCMealAllowanceCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTransportAllowanceCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCHouseAllowanceCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCAttendanceAllowanceCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalaryCurrent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCBasicSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RITESalary = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GCJobAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCMealAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTransportAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCHouseAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCAttendanceAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBComposition = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCFixedSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNonFixedSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCFixedSalaryRp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNonFixedSalaryRp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBIncrease = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCIncrease = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIncreaseRp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBContract = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCContract = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemSearchLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCContractAttachment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GBNote = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCReason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RITEReason = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GCTotalWorkDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdEmployeeSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LUECategory = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LUEType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SBInsertEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.SBRemoveEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SBPrintDetail = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedAt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSGCEmployee.SuspendLayout()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEReason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LUECategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TECreatedBy)
        Me.PanelControl1.Controls.Add(Me.DECreatedAt)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.DEEffectiveDate)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 72)
        Me.PanelControl1.TabIndex = 0
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedBy.Location = New System.Drawing.Point(784, 12)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(203, 20)
        Me.TECreatedBy.TabIndex = 8
        '
        'DECreatedAt
        '
        Me.DECreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DECreatedAt.EditValue = Nothing
        Me.DECreatedAt.Location = New System.Drawing.Point(784, 38)
        Me.DECreatedAt.Name = "DECreatedAt"
        Me.DECreatedAt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DECreatedAt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedAt.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedAt.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedAt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedAt.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedAt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedAt.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedAt.Properties.ReadOnly = True
        Me.DECreatedAt.Size = New System.Drawing.Size(203, 20)
        Me.DECreatedAt.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(703, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Created At"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(703, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Created By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Number"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(105, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(203, 20)
        Me.TENumber.TabIndex = 3
        '
        'DEEffectiveDate
        '
        Me.DEEffectiveDate.EditValue = Nothing
        Me.DEEffectiveDate.Location = New System.Drawing.Point(105, 38)
        Me.DEEffectiveDate.Name = "DEEffectiveDate"
        Me.DEEffectiveDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEffectiveDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffectiveDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEffectiveDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEffectiveDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEEffectiveDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEffectiveDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEEffectiveDate.Size = New System.Drawing.Size(203, 20)
        Me.DEEffectiveDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Effective Date"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBAttachment)
        Me.PanelControl3.Controls.Add(Me.SBPrintDetail)
        Me.PanelControl3.Controls.Add(Me.SBPrint)
        Me.PanelControl3.Controls.Add(Me.SBClose)
        Me.PanelControl3.Controls.Add(Me.SBMark)
        Me.PanelControl3.Controls.Add(Me.SBSave)
        Me.PanelControl3.Controls.Add(Me.SBSubmit)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 681)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1008, 48)
        Me.PanelControl3.TabIndex = 2
        '
        'SBAttachment
        '
        Me.SBAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAttachment.Image = CType(resources.GetObject("SBAttachment.Image"), System.Drawing.Image)
        Me.SBAttachment.ImageIndex = 10
        Me.SBAttachment.Location = New System.Drawing.Point(397, 2)
        Me.SBAttachment.Name = "SBAttachment"
        Me.SBAttachment.Size = New System.Drawing.Size(112, 44)
        Me.SBAttachment.TabIndex = 115
        Me.SBAttachment.TabStop = False
        Me.SBAttachment.Text = "Attachment"
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(626, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(95, 44)
        Me.SBPrint.TabIndex = 3
        Me.SBPrint.Text = "Print"
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(721, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(95, 44)
        Me.SBClose.TabIndex = 4
        Me.SBClose.Text = "Close"
        '
        'SBMark
        '
        Me.SBMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(2, 2)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(95, 44)
        Me.SBMark.TabIndex = 2
        Me.SBMark.Text = "Mark"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(816, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(95, 44)
        Me.SBSave.TabIndex = 5
        Me.SBSave.Text = "Save"
        '
        'SBSubmit
        '
        Me.SBSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSubmit.Image = CType(resources.GetObject("SBSubmit.Image"), System.Drawing.Image)
        Me.SBSubmit.Location = New System.Drawing.Point(911, 2)
        Me.SBSubmit.Name = "SBSubmit"
        Me.SBSubmit.Size = New System.Drawing.Size(95, 44)
        Me.SBSubmit.TabIndex = 1
        Me.SBSubmit.Text = "Submit"
        '
        'GCEmployee
        '
        Me.GCEmployee.ContextMenuStrip = Me.CMSGCEmployee
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 133)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RITESalary, Me.RepositoryItemCheckEdit, Me.RepositoryItemSearchLookUpEdit, Me.RITEReason})
        Me.GCEmployee.Size = New System.Drawing.Size(1008, 454)
        Me.GCEmployee.TabIndex = 3
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'CMSGCEmployee
        '
        Me.CMSGCEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveEmployeeToolStripMenuItem})
        Me.CMSGCEmployee.Name = "CMSGCEmployee"
        Me.CMSGCEmployee.Size = New System.Drawing.Size(173, 26)
        '
        'RemoveEmployeeToolStripMenuItem
        '
        Me.RemoveEmployeeToolStripMenuItem.Name = "RemoveEmployeeToolStripMenuItem"
        Me.RemoveEmployeeToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RemoveEmployeeToolStripMenuItem.Text = "Remove Employee"
        '
        'GVEmployee
        '
        Me.GVEmployee.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseFont = True
        Me.GVEmployee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployee, Me.GBSalaryCurrent, Me.GBSalary, Me.GBComposition, Me.GBIncrease, Me.GBContract, Me.GBNote})
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCEmployeeId, Me.GCNIP, Me.GCName, Me.GCIdDepartement, Me.GCDepartement, Me.GCTotalWorkDays, Me.GCPosition, Me.GCIdEmployeeLevel, Me.GCLevel, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCLengthOfWork, Me.GCIdEmployeeSalary, Me.GCBasicSalaryCurrent, Me.GCJobAllowanceCurrent, Me.GCMealAllowanceCurrent, Me.GCTransportAllowanceCurrent, Me.GCHouseAllowanceCurrent, Me.GCAttendanceAllowanceCurrent, Me.GCTotalSalaryCurrent, Me.GCBasicSalary, Me.GCJobAllowance, Me.GCMealAllowance, Me.GCTransportAllowance, Me.GCHouseAllowance, Me.GCAttendanceAllowance, Me.GCTotalSalary, Me.GCFixedSalary, Me.GCNonFixedSalary, Me.GCFixedSalaryRp, Me.GCNonFixedSalaryRp, Me.GCIncrease, Me.GCIncreaseRp, Me.GCContract, Me.GCContractAttachment, Me.GCReason})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", Me.GCBasicSalary, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", Me.GCJobAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", Me.GCMealAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", Me.GCTransportAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", Me.GCHouseAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", Me.GCAttendanceAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", Me.GCTotalSalary, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary_current", Me.GCBasicSalaryCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job_current", Me.GCJobAllowanceCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal_current", Me.GCMealAllowanceCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans_current", Me.GCTransportAllowanceCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house_current", Me.GCHouseAllowanceCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car_current", Me.GCAttendanceAllowanceCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_current", Me.GCTotalSalaryCurrent, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "increase_rp", Me.GCIncreaseRp, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "increase", Me.GCIncrease, "")})
        Me.GVEmployee.LevelIndent = 0
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowFooter = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GBEmployee
        '
        Me.GBEmployee.Caption = "Employee"
        Me.GBEmployee.Columns.Add(Me.GCEmployeeId)
        Me.GBEmployee.Columns.Add(Me.GCNIP)
        Me.GBEmployee.Columns.Add(Me.GCName)
        Me.GBEmployee.Columns.Add(Me.GCIdDepartement)
        Me.GBEmployee.Columns.Add(Me.GCDepartement)
        Me.GBEmployee.Columns.Add(Me.GCPosition)
        Me.GBEmployee.Columns.Add(Me.GCIdEmployeeLevel)
        Me.GBEmployee.Columns.Add(Me.GCLevel)
        Me.GBEmployee.Columns.Add(Me.GCIdEmployeeStatus)
        Me.GBEmployee.Columns.Add(Me.GCEmployeeStatus)
        Me.GBEmployee.Columns.Add(Me.GCLengthOfWork)
        Me.GBEmployee.Name = "GBEmployee"
        Me.GBEmployee.VisibleIndex = 0
        Me.GBEmployee.Width = 390
        '
        'GCEmployeeId
        '
        Me.GCEmployeeId.FieldName = "id_employee"
        Me.GCEmployeeId.Name = "GCEmployeeId"
        Me.GCEmployeeId.OptionsColumn.AllowEdit = False
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "employee_code"
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.OptionsColumn.AllowEdit = False
        Me.GCNIP.Visible = True
        '
        'GCName
        '
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Visible = True
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        '
        'GCPosition
        '
        Me.GCPosition.Caption = "Position"
        Me.GCPosition.FieldName = "employee_position"
        Me.GCPosition.Name = "GCPosition"
        Me.GCPosition.OptionsColumn.AllowEdit = False
        Me.GCPosition.Visible = True
        '
        'GCIdEmployeeLevel
        '
        Me.GCIdEmployeeLevel.FieldName = "id_employee_level"
        Me.GCIdEmployeeLevel.Name = "GCIdEmployeeLevel"
        '
        'GCLevel
        '
        Me.GCLevel.Caption = "Level"
        Me.GCLevel.FieldName = "employee_level"
        Me.GCLevel.Name = "GCLevel"
        Me.GCLevel.OptionsColumn.AllowEdit = False
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.Width = 90
        '
        'GCLengthOfWork
        '
        Me.GCLengthOfWork.Caption = "Length of Work"
        Me.GCLengthOfWork.FieldName = "length_work"
        Me.GCLengthOfWork.Name = "GCLengthOfWork"
        Me.GCLengthOfWork.OptionsColumn.AllowEdit = False
        Me.GCLengthOfWork.Visible = True
        '
        'GBSalaryCurrent
        '
        Me.GBSalaryCurrent.Caption = "Salary Current"
        Me.GBSalaryCurrent.Columns.Add(Me.GCBasicSalaryCurrent)
        Me.GBSalaryCurrent.Columns.Add(Me.GCJobAllowanceCurrent)
        Me.GBSalaryCurrent.Columns.Add(Me.GCMealAllowanceCurrent)
        Me.GBSalaryCurrent.Columns.Add(Me.GCTransportAllowanceCurrent)
        Me.GBSalaryCurrent.Columns.Add(Me.GCHouseAllowanceCurrent)
        Me.GBSalaryCurrent.Columns.Add(Me.GCAttendanceAllowanceCurrent)
        Me.GBSalaryCurrent.Columns.Add(Me.GCTotalSalaryCurrent)
        Me.GBSalaryCurrent.Name = "GBSalaryCurrent"
        Me.GBSalaryCurrent.VisibleIndex = 1
        Me.GBSalaryCurrent.Width = 627
        '
        'GCBasicSalaryCurrent
        '
        Me.GCBasicSalaryCurrent.Caption = "Basic Salary"
        Me.GCBasicSalaryCurrent.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalaryCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalaryCurrent.FieldName = "basic_salary_current"
        Me.GCBasicSalaryCurrent.Name = "GCBasicSalaryCurrent"
        Me.GCBasicSalaryCurrent.OptionsColumn.AllowEdit = False
        Me.GCBasicSalaryCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary_current", "{0:N0}")})
        Me.GCBasicSalaryCurrent.Visible = True
        '
        'GCJobAllowanceCurrent
        '
        Me.GCJobAllowanceCurrent.Caption = "Job Allowance"
        Me.GCJobAllowanceCurrent.DisplayFormat.FormatString = "N0"
        Me.GCJobAllowanceCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCJobAllowanceCurrent.FieldName = "allow_job_current"
        Me.GCJobAllowanceCurrent.Name = "GCJobAllowanceCurrent"
        Me.GCJobAllowanceCurrent.OptionsColumn.AllowEdit = False
        Me.GCJobAllowanceCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job_current", "{0:N0}")})
        Me.GCJobAllowanceCurrent.Visible = True
        Me.GCJobAllowanceCurrent.Width = 78
        '
        'GCMealAllowanceCurrent
        '
        Me.GCMealAllowanceCurrent.Caption = "Meal Allowance"
        Me.GCMealAllowanceCurrent.DisplayFormat.FormatString = "N0"
        Me.GCMealAllowanceCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCMealAllowanceCurrent.FieldName = "allow_meal_current"
        Me.GCMealAllowanceCurrent.Name = "GCMealAllowanceCurrent"
        Me.GCMealAllowanceCurrent.OptionsColumn.AllowEdit = False
        Me.GCMealAllowanceCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal_current", "{0:N0}")})
        Me.GCMealAllowanceCurrent.Visible = True
        Me.GCMealAllowanceCurrent.Width = 83
        '
        'GCTransportAllowanceCurrent
        '
        Me.GCTransportAllowanceCurrent.Caption = "Transport Allowance"
        Me.GCTransportAllowanceCurrent.DisplayFormat.FormatString = "N0"
        Me.GCTransportAllowanceCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTransportAllowanceCurrent.FieldName = "allow_trans_current"
        Me.GCTransportAllowanceCurrent.Name = "GCTransportAllowanceCurrent"
        Me.GCTransportAllowanceCurrent.OptionsColumn.AllowEdit = False
        Me.GCTransportAllowanceCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans_current", "{0:N0}")})
        Me.GCTransportAllowanceCurrent.Visible = True
        Me.GCTransportAllowanceCurrent.Width = 108
        '
        'GCHouseAllowanceCurrent
        '
        Me.GCHouseAllowanceCurrent.Caption = "House Allowance"
        Me.GCHouseAllowanceCurrent.DisplayFormat.FormatString = "N0"
        Me.GCHouseAllowanceCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHouseAllowanceCurrent.FieldName = "allow_house_current"
        Me.GCHouseAllowanceCurrent.Name = "GCHouseAllowanceCurrent"
        Me.GCHouseAllowanceCurrent.OptionsColumn.AllowEdit = False
        Me.GCHouseAllowanceCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house_current", "{0:N0}")})
        Me.GCHouseAllowanceCurrent.Visible = True
        Me.GCHouseAllowanceCurrent.Width = 91
        '
        'GCAttendanceAllowanceCurrent
        '
        Me.GCAttendanceAllowanceCurrent.Caption = "Attendance Allowance"
        Me.GCAttendanceAllowanceCurrent.DisplayFormat.FormatString = "N0"
        Me.GCAttendanceAllowanceCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAttendanceAllowanceCurrent.FieldName = "allow_car_current"
        Me.GCAttendanceAllowanceCurrent.Name = "GCAttendanceAllowanceCurrent"
        Me.GCAttendanceAllowanceCurrent.OptionsColumn.AllowEdit = False
        Me.GCAttendanceAllowanceCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car_current", "{0:N0}")})
        Me.GCAttendanceAllowanceCurrent.Visible = True
        Me.GCAttendanceAllowanceCurrent.Width = 117
        '
        'GCTotalSalaryCurrent
        '
        Me.GCTotalSalaryCurrent.Caption = "Total THP"
        Me.GCTotalSalaryCurrent.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalaryCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalaryCurrent.FieldName = "total_salary_current"
        Me.GCTotalSalaryCurrent.Name = "GCTotalSalaryCurrent"
        Me.GCTotalSalaryCurrent.OptionsColumn.AllowEdit = False
        Me.GCTotalSalaryCurrent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_current", "{0:N0}")})
        Me.GCTotalSalaryCurrent.Visible = True
        '
        'GBSalary
        '
        Me.GBSalary.Caption = "Salary Propose"
        Me.GBSalary.Columns.Add(Me.GCBasicSalary)
        Me.GBSalary.Columns.Add(Me.GCJobAllowance)
        Me.GBSalary.Columns.Add(Me.GCMealAllowance)
        Me.GBSalary.Columns.Add(Me.GCTransportAllowance)
        Me.GBSalary.Columns.Add(Me.GCHouseAllowance)
        Me.GBSalary.Columns.Add(Me.GCAttendanceAllowance)
        Me.GBSalary.Columns.Add(Me.GCTotalSalary)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 2
        Me.GBSalary.Width = 619
        '
        'GCBasicSalary
        '
        Me.GCBasicSalary.Caption = "Basic Salary"
        Me.GCBasicSalary.ColumnEdit = Me.RITESalary
        Me.GCBasicSalary.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalary.FieldName = "basic_salary"
        Me.GCBasicSalary.Name = "GCBasicSalary"
        Me.GCBasicSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", "{0:N0}")})
        Me.GCBasicSalary.Visible = True
        Me.GCBasicSalary.Width = 67
        '
        'RITESalary
        '
        Me.RITESalary.AutoHeight = False
        Me.RITESalary.DisplayFormat.FormatString = "N0"
        Me.RITESalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITESalary.EditFormat.FormatString = "N0"
        Me.RITESalary.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITESalary.Mask.EditMask = "N0"
        Me.RITESalary.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITESalary.Mask.UseMaskAsDisplayFormat = True
        Me.RITESalary.Name = "RITESalary"
        '
        'GCJobAllowance
        '
        Me.GCJobAllowance.Caption = "Job Allowance"
        Me.GCJobAllowance.ColumnEdit = Me.RITESalary
        Me.GCJobAllowance.DisplayFormat.FormatString = "N0"
        Me.GCJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCJobAllowance.FieldName = "allow_job"
        Me.GCJobAllowance.Name = "GCJobAllowance"
        Me.GCJobAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", "{0:N0}")})
        Me.GCJobAllowance.Visible = True
        Me.GCJobAllowance.Width = 78
        '
        'GCMealAllowance
        '
        Me.GCMealAllowance.Caption = "Meal Allowance"
        Me.GCMealAllowance.ColumnEdit = Me.RITESalary
        Me.GCMealAllowance.DisplayFormat.FormatString = "N0"
        Me.GCMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCMealAllowance.FieldName = "allow_meal"
        Me.GCMealAllowance.Name = "GCMealAllowance"
        Me.GCMealAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", "{0:N0}")})
        Me.GCMealAllowance.Visible = True
        Me.GCMealAllowance.Width = 83
        '
        'GCTransportAllowance
        '
        Me.GCTransportAllowance.Caption = "Transport Allowance"
        Me.GCTransportAllowance.ColumnEdit = Me.RITESalary
        Me.GCTransportAllowance.DisplayFormat.FormatString = "N0"
        Me.GCTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTransportAllowance.FieldName = "allow_trans"
        Me.GCTransportAllowance.Name = "GCTransportAllowance"
        Me.GCTransportAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", "{0:N0}")})
        Me.GCTransportAllowance.Visible = True
        Me.GCTransportAllowance.Width = 108
        '
        'GCHouseAllowance
        '
        Me.GCHouseAllowance.Caption = "House Allowance"
        Me.GCHouseAllowance.ColumnEdit = Me.RITESalary
        Me.GCHouseAllowance.DisplayFormat.FormatString = "N0"
        Me.GCHouseAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHouseAllowance.FieldName = "allow_house"
        Me.GCHouseAllowance.Name = "GCHouseAllowance"
        Me.GCHouseAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", "{0:N0}")})
        Me.GCHouseAllowance.Visible = True
        Me.GCHouseAllowance.Width = 91
        '
        'GCAttendanceAllowance
        '
        Me.GCAttendanceAllowance.Caption = "Attendance Allowance"
        Me.GCAttendanceAllowance.ColumnEdit = Me.RITESalary
        Me.GCAttendanceAllowance.DisplayFormat.FormatString = "N0"
        Me.GCAttendanceAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAttendanceAllowance.FieldName = "allow_car"
        Me.GCAttendanceAllowance.Name = "GCAttendanceAllowance"
        Me.GCAttendanceAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", "{0:N0}")})
        Me.GCAttendanceAllowance.Visible = True
        Me.GCAttendanceAllowance.Width = 117
        '
        'GCTotalSalary
        '
        Me.GCTotalSalary.Caption = "Total THP"
        Me.GCTotalSalary.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalary.FieldName = "total_salary"
        Me.GCTotalSalary.Name = "GCTotalSalary"
        Me.GCTotalSalary.OptionsColumn.AllowEdit = False
        Me.GCTotalSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", "{0:N0}")})
        Me.GCTotalSalary.UnboundExpression = "[basic_salary] + [allow_job] + [allow_meal] + [allow_trans] + [allow_house] + [al" &
    "low_car]"
        Me.GCTotalSalary.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCTotalSalary.Visible = True
        '
        'GBComposition
        '
        Me.GBComposition.Caption = "Composition"
        Me.GBComposition.Columns.Add(Me.GCFixedSalary)
        Me.GBComposition.Columns.Add(Me.GCNonFixedSalary)
        Me.GBComposition.Columns.Add(Me.GCFixedSalaryRp)
        Me.GBComposition.Columns.Add(Me.GCNonFixedSalaryRp)
        Me.GBComposition.Name = "GBComposition"
        Me.GBComposition.VisibleIndex = 3
        Me.GBComposition.Width = 372
        '
        'GCFixedSalary
        '
        Me.GCFixedSalary.Caption = "Fixed Salary"
        Me.GCFixedSalary.FieldName = "fixed_salary"
        Me.GCFixedSalary.Name = "GCFixedSalary"
        Me.GCFixedSalary.OptionsColumn.AllowEdit = False
        Me.GCFixedSalary.Visible = True
        '
        'GCNonFixedSalary
        '
        Me.GCNonFixedSalary.Caption = "Non-fixed Salary"
        Me.GCNonFixedSalary.FieldName = "non_fixed_salary"
        Me.GCNonFixedSalary.Name = "GCNonFixedSalary"
        Me.GCNonFixedSalary.OptionsColumn.AllowEdit = False
        Me.GCNonFixedSalary.Visible = True
        Me.GCNonFixedSalary.Width = 90
        '
        'GCFixedSalaryRp
        '
        Me.GCFixedSalaryRp.Caption = "Fixed Salary (Rp)"
        Me.GCFixedSalaryRp.DisplayFormat.FormatString = "N0"
        Me.GCFixedSalaryRp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCFixedSalaryRp.FieldName = "fixed_salary_rp"
        Me.GCFixedSalaryRp.Name = "GCFixedSalaryRp"
        Me.GCFixedSalaryRp.OptionsColumn.AllowEdit = False
        Me.GCFixedSalaryRp.UnboundExpression = "[basic_salary] + [allow_job] + [allow_meal] + [allow_trans]"
        Me.GCFixedSalaryRp.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCFixedSalaryRp.Visible = True
        Me.GCFixedSalaryRp.Width = 93
        '
        'GCNonFixedSalaryRp
        '
        Me.GCNonFixedSalaryRp.Caption = "Non-fixed Salary (Rp)"
        Me.GCNonFixedSalaryRp.DisplayFormat.FormatString = "N0"
        Me.GCNonFixedSalaryRp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCNonFixedSalaryRp.FieldName = "non_fixed_salary_rp"
        Me.GCNonFixedSalaryRp.Name = "GCNonFixedSalaryRp"
        Me.GCNonFixedSalaryRp.OptionsColumn.AllowEdit = False
        Me.GCNonFixedSalaryRp.UnboundExpression = "[allow_house] + [allow_car]"
        Me.GCNonFixedSalaryRp.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCNonFixedSalaryRp.Visible = True
        Me.GCNonFixedSalaryRp.Width = 114
        '
        'GBIncrease
        '
        Me.GBIncrease.Caption = "Increase"
        Me.GBIncrease.Columns.Add(Me.GCIncrease)
        Me.GBIncrease.Columns.Add(Me.GCIncreaseRp)
        Me.GBIncrease.Name = "GBIncrease"
        Me.GBIncrease.VisibleIndex = 4
        Me.GBIncrease.Width = 150
        '
        'GCIncrease
        '
        Me.GCIncrease.Caption = "Increase"
        Me.GCIncrease.FieldName = "increase"
        Me.GCIncrease.Name = "GCIncrease"
        Me.GCIncrease.OptionsColumn.AllowEdit = False
        Me.GCIncrease.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.GCIncrease.Visible = True
        '
        'GCIncreaseRp
        '
        Me.GCIncreaseRp.Caption = "Increase (Rp)"
        Me.GCIncreaseRp.DisplayFormat.FormatString = "N0"
        Me.GCIncreaseRp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCIncreaseRp.FieldName = "increase_rp"
        Me.GCIncreaseRp.Name = "GCIncreaseRp"
        Me.GCIncreaseRp.OptionsColumn.AllowEdit = False
        Me.GCIncreaseRp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "increase_rp", "{0:N0}")})
        Me.GCIncreaseRp.UnboundExpression = "[total_salary] - [total_salary_current]"
        Me.GCIncreaseRp.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCIncreaseRp.Visible = True
        '
        'GBContract
        '
        Me.GBContract.Caption = "SK / Contract"
        Me.GBContract.Columns.Add(Me.GCContract)
        Me.GBContract.Columns.Add(Me.GCContractAttachment)
        Me.GBContract.Name = "GBContract"
        Me.GBContract.VisibleIndex = 5
        Me.GBContract.Width = 325
        '
        'GCContract
        '
        Me.GCContract.Caption = "SK / Contract"
        Me.GCContract.ColumnEdit = Me.RepositoryItemSearchLookUpEdit
        Me.GCContract.FieldName = "id_employee_status_det"
        Me.GCContract.Name = "GCContract"
        Me.GCContract.Visible = True
        Me.GCContract.Width = 250
        '
        'RepositoryItemSearchLookUpEdit
        '
        Me.RepositoryItemSearchLookUpEdit.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit.Name = "RepositoryItemSearchLookUpEdit"
        Me.RepositoryItemSearchLookUpEdit.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_employee_status_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "id_employee"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "SK / Contract"
        Me.GridColumn3.FieldName = "contract"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GCContractAttachment
        '
        Me.GCContractAttachment.Caption = "Attactment"
        Me.GCContractAttachment.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GCContractAttachment.FieldName = "attachment"
        Me.GCContractAttachment.Name = "GCContractAttachment"
        Me.GCContractAttachment.Visible = True
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
        'GBNote
        '
        Me.GBNote.Caption = "Note"
        Me.GBNote.Columns.Add(Me.GCReason)
        Me.GBNote.Name = "GBNote"
        Me.GBNote.VisibleIndex = 6
        Me.GBNote.Width = 100
        '
        'GCReason
        '
        Me.GCReason.Caption = "Reason"
        Me.GCReason.ColumnEdit = Me.RITEReason
        Me.GCReason.FieldName = "reason"
        Me.GCReason.MinWidth = 100
        Me.GCReason.Name = "GCReason"
        Me.GCReason.Visible = True
        Me.GCReason.Width = 100
        '
        'RITEReason
        '
        Me.RITEReason.AutoHeight = False
        Me.RITEReason.Name = "RITEReason"
        '
        'GCTotalWorkDays
        '
        Me.GCTotalWorkDays.FieldName = "total_workdays"
        Me.GCTotalWorkDays.Name = "GCTotalWorkDays"
        '
        'GCIdEmployeeSalary
        '
        Me.GCIdEmployeeSalary.FieldName = "id_employee_salary"
        Me.GCIdEmployeeSalary.Name = "GCIdEmployeeSalary"
        Me.GCIdEmployeeSalary.OptionsColumn.AllowEdit = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LUECategory)
        Me.PanelControl2.Controls.Add(Me.Label7)
        Me.PanelControl2.Controls.Add(Me.LUEType)
        Me.PanelControl2.Controls.Add(Me.Label6)
        Me.PanelControl2.Controls.Add(Me.SBInsertEmployee)
        Me.PanelControl2.Controls.Add(Me.SBRemoveEmployee)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 72)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 61)
        Me.PanelControl2.TabIndex = 3
        '
        'LUECategory
        '
        Me.LUECategory.Location = New System.Drawing.Point(105, 8)
        Me.LUECategory.Name = "LUECategory"
        Me.LUECategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUECategory.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_sal_pps_category", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("sal_pps_category", "Category")})
        Me.LUECategory.Size = New System.Drawing.Size(203, 20)
        Me.LUECategory.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Category"
        '
        'LUEType
        '
        Me.LUEType.Location = New System.Drawing.Point(105, 34)
        Me.LUEType.Name = "LUEType"
        Me.LUEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUEType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_sal_pps_type", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("sal_pps_type", "Type")})
        Me.LUEType.Size = New System.Drawing.Size(203, 20)
        Me.LUEType.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Type"
        '
        'SBInsertEmployee
        '
        Me.SBInsertEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBInsertEmployee.Image = CType(resources.GetObject("SBInsertEmployee.Image"), System.Drawing.Image)
        Me.SBInsertEmployee.Location = New System.Drawing.Point(712, 8)
        Me.SBInsertEmployee.Name = "SBInsertEmployee"
        Me.SBInsertEmployee.Size = New System.Drawing.Size(130, 45)
        Me.SBInsertEmployee.TabIndex = 1
        Me.SBInsertEmployee.Text = "Insert Employee"
        '
        'SBRemoveEmployee
        '
        Me.SBRemoveEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBRemoveEmployee.Image = CType(resources.GetObject("SBRemoveEmployee.Image"), System.Drawing.Image)
        Me.SBRemoveEmployee.Location = New System.Drawing.Point(848, 8)
        Me.SBRemoveEmployee.Name = "SBRemoveEmployee"
        Me.SBRemoveEmployee.Size = New System.Drawing.Size(139, 45)
        Me.SBRemoveEmployee.TabIndex = 0
        Me.SBRemoveEmployee.Text = "Remove Employee"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.MENote)
        Me.PanelControl4.Controls.Add(Me.Label5)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 587)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1008, 94)
        Me.PanelControl4.TabIndex = 4
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(105, 17)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(882, 58)
        Me.MENote.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Note"
        '
        'SBPrintDetail
        '
        Me.SBPrintDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrintDetail.Image = CType(resources.GetObject("SBPrintDetail.Image"), System.Drawing.Image)
        Me.SBPrintDetail.Location = New System.Drawing.Point(509, 2)
        Me.SBPrintDetail.Name = "SBPrintDetail"
        Me.SBPrintDetail.Size = New System.Drawing.Size(117, 44)
        Me.SBPrintDetail.TabIndex = 116
        Me.SBPrintDetail.Text = "Print Detail"
        '
        'FormProposeEmpSalaryDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCEmployee)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormProposeEmpSalaryDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Employee Salary Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedAt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSGCEmployee.ResumeLayout(False)
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEReason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.LUECategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DECreatedAt As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DEEffectiveDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBInsertEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBRemoveEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents CMSGCEmployee As ContextMenuStrip
    Friend WithEvents RemoveEmployeeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RITESalary As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents LUEType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCEmployeeId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdEmployeeLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCBasicSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCJobAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCMealAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTransportAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCHouseAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCAttendanceAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCContractAttachment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCFixedSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNonFixedSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCContract As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemSearchLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBasicSalaryCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCJobAllowanceCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCMealAllowanceCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTransportAllowanceCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCHouseAllowanceCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCAttendanceAllowanceCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalaryCurrent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIncrease As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdEmployeeSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LUECategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents SBAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCTotalWorkDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCFixedSalaryRp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNonFixedSalaryRp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIncreaseRp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCReason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RITEReason As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GCLengthOfWork As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBEmployee As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalaryCurrent As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBComposition As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBIncrease As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBContract As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBNote As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents SBPrintDetail As DevExpress.XtraEditors.SimpleButton
End Class
