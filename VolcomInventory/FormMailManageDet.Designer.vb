﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailManageDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManageDet))
        Me.XTCMail = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPreview = New DevExpress.XtraTab.XtraTabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.MESubject = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.MECC = New DevExpress.XtraEditors.MemoEdit()
        Me.METo = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.MEFrom = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPData = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPFrom = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMember = New DevExpress.XtraGrid.GridControl()
        Me.GVMember = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_mail_manage_member = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_mail_manage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_mail_member_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_user = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_contact = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmail_address = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmail_member_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnLog = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDraft = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUpdatedDate = New DevExpress.XtraEditors.DateEdit()
        Me.DECreatedDate = New DevExpress.XtraEditors.DateEdit()
        Me.TxtUpdatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMailStatus = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMailType = New DevExpress.XtraEditors.TextEdit()
        Me.TxtEmailNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMail.SuspendLayout()
        Me.XTPreview.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.MESubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.METo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPData.SuspendLayout()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPFrom.SuspendLayout()
        CType(Me.GCMember, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DEUpdatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMailStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMailType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmailNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCMail
        '
        Me.XTCMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMail.Location = New System.Drawing.Point(0, 152)
        Me.XTCMail.Name = "XTCMail"
        Me.XTCMail.SelectedTabPage = Me.XTPreview
        Me.XTCMail.Size = New System.Drawing.Size(828, 411)
        Me.XTCMail.TabIndex = 0
        Me.XTCMail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPreview, Me.XTPData})
        '
        'XTPreview
        '
        Me.XTPreview.Controls.Add(Me.WebBrowser1)
        Me.XTPreview.Controls.Add(Me.PanelControl4)
        Me.XTPreview.Name = "XTPreview"
        Me.XTPreview.Size = New System.Drawing.Size(822, 383)
        Me.XTPreview.Text = "Preview"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(315, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(507, 383)
        Me.WebBrowser1.TabIndex = 1
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.MESubject)
        Me.PanelControl4.Controls.Add(Me.LabelControl12)
        Me.PanelControl4.Controls.Add(Me.MECC)
        Me.PanelControl4.Controls.Add(Me.METo)
        Me.PanelControl4.Controls.Add(Me.LabelControl10)
        Me.PanelControl4.Controls.Add(Me.LabelControl11)
        Me.PanelControl4.Controls.Add(Me.MEFrom)
        Me.PanelControl4.Controls.Add(Me.LabelControl9)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(315, 383)
        Me.PanelControl4.TabIndex = 0
        '
        'MESubject
        '
        Me.MESubject.Location = New System.Drawing.Point(14, 285)
        Me.MESubject.Name = "MESubject"
        Me.MESubject.Properties.ReadOnly = True
        Me.MESubject.Size = New System.Drawing.Size(283, 35)
        Me.MESubject.TabIndex = 18
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(14, 266)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl12.TabIndex = 17
        Me.LabelControl12.Text = "Subject"
        '
        'MECC
        '
        Me.MECC.Location = New System.Drawing.Point(14, 201)
        Me.MECC.Name = "MECC"
        Me.MECC.Properties.ReadOnly = True
        Me.MECC.Size = New System.Drawing.Size(283, 59)
        Me.MECC.TabIndex = 16
        '
        'METo
        '
        Me.METo.Location = New System.Drawing.Point(14, 117)
        Me.METo.Name = "METo"
        Me.METo.Properties.ReadOnly = True
        Me.METo.Size = New System.Drawing.Size(283, 59)
        Me.METo.TabIndex = 15
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(14, 98)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl10.TabIndex = 11
        Me.LabelControl10.Text = "To"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(14, 182)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl11.TabIndex = 13
        Me.LabelControl11.Text = "Cc"
        '
        'MEFrom
        '
        Me.MEFrom.Location = New System.Drawing.Point(14, 34)
        Me.MEFrom.Name = "MEFrom"
        Me.MEFrom.Properties.ReadOnly = True
        Me.MEFrom.Size = New System.Drawing.Size(283, 59)
        Me.MEFrom.TabIndex = 9
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl9.TabIndex = 9
        Me.LabelControl9.Text = "From"
        '
        'XTPData
        '
        Me.XTPData.Controls.Add(Me.XTCData)
        Me.XTPData.Name = "XTPData"
        Me.XTPData.Size = New System.Drawing.Size(822, 383)
        Me.XTPData.Text = "Data"
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPFrom
        Me.XTCData.Size = New System.Drawing.Size(822, 383)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPFrom, Me.XTPDetail})
        '
        'XTPFrom
        '
        Me.XTPFrom.Controls.Add(Me.GCMember)
        Me.XTPFrom.Name = "XTPFrom"
        Me.XTPFrom.Size = New System.Drawing.Size(793, 377)
        Me.XTPFrom.Text = "From/To/Cc"
        '
        'GCMember
        '
        Me.GCMember.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMember.Location = New System.Drawing.Point(0, 0)
        Me.GCMember.MainView = Me.GVMember
        Me.GCMember.Name = "GCMember"
        Me.GCMember.Size = New System.Drawing.Size(793, 377)
        Me.GCMember.TabIndex = 0
        Me.GCMember.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMember})
        '
        'GVMember
        '
        Me.GVMember.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_mail_manage_member, Me.GridColumnid_mail_manage, Me.GridColumnid_mail_member_type, Me.GridColumnid_user, Me.GridColumnid_comp_contact, Me.GridColumndescription, Me.GridColumnmail_address, Me.GridColumnmail_member_type})
        Me.GVMember.GridControl = Me.GCMember
        Me.GVMember.GroupCount = 1
        Me.GVMember.Name = "GVMember"
        Me.GVMember.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMember.OptionsBehavior.Editable = False
        Me.GVMember.OptionsView.ShowGroupedColumns = True
        Me.GVMember.OptionsView.ShowGroupPanel = False
        Me.GVMember.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnmail_member_type, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnid_mail_manage_member
        '
        Me.GridColumnid_mail_manage_member.Caption = "id_mail_manage_member"
        Me.GridColumnid_mail_manage_member.FieldName = "id_mail_manage_member"
        Me.GridColumnid_mail_manage_member.Name = "GridColumnid_mail_manage_member"
        '
        'GridColumnid_mail_manage
        '
        Me.GridColumnid_mail_manage.Caption = "id_mail_manage"
        Me.GridColumnid_mail_manage.FieldName = "id_mail_manage"
        Me.GridColumnid_mail_manage.Name = "GridColumnid_mail_manage"
        '
        'GridColumnid_mail_member_type
        '
        Me.GridColumnid_mail_member_type.Caption = "id_mail_member_type"
        Me.GridColumnid_mail_member_type.FieldName = "id_mail_member_type"
        Me.GridColumnid_mail_member_type.Name = "GridColumnid_mail_member_type"
        '
        'GridColumnid_user
        '
        Me.GridColumnid_user.Caption = "id_user"
        Me.GridColumnid_user.FieldName = "id_user"
        Me.GridColumnid_user.Name = "GridColumnid_user"
        '
        'GridColumnid_comp_contact
        '
        Me.GridColumnid_comp_contact.Caption = "id_comp_contact"
        Me.GridColumnid_comp_contact.FieldName = "id_comp_contact"
        Me.GridColumnid_comp_contact.Name = "GridColumnid_comp_contact"
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Name"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'GridColumnmail_address
        '
        Me.GridColumnmail_address.Caption = "Email"
        Me.GridColumnmail_address.FieldName = "mail_address"
        Me.GridColumnmail_address.Name = "GridColumnmail_address"
        Me.GridColumnmail_address.Visible = True
        Me.GridColumnmail_address.VisibleIndex = 2
        '
        'GridColumnmail_member_type
        '
        Me.GridColumnmail_member_type.Caption = "Type"
        Me.GridColumnmail_member_type.FieldName = "mail_member_type"
        Me.GridColumnmail_member_type.FieldNameSortGroup = "id_mail_member_type"
        Me.GridColumnmail_member_type.Name = "GridColumnmail_member_type"
        Me.GridColumnmail_member_type.Visible = True
        Me.GridColumnmail_member_type.VisibleIndex = 0
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(793, 377)
        Me.XTPDetail.Text = "Detail"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(793, 377)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsBehavior.Editable = False
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnLog)
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnDraft)
        Me.PanelControl2.Controls.Add(Me.BtnSend)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 563)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(828, 48)
        Me.PanelControl2.TabIndex = 2
        '
        'BtnLog
        '
        Me.BtnLog.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnLog.Image = CType(resources.GetObject("BtnLog.Image"), System.Drawing.Image)
        Me.BtnLog.Location = New System.Drawing.Point(2, 2)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(105, 44)
        Me.BtnLog.TabIndex = 3
        Me.BtnLog.Text = "Log Email"
        Me.BtnLog.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(541, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(105, 44)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancelled"
        Me.BtnCancel.Visible = False
        '
        'BtnDraft
        '
        Me.BtnDraft.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDraft.Image = CType(resources.GetObject("BtnDraft.Image"), System.Drawing.Image)
        Me.BtnDraft.Location = New System.Drawing.Point(646, 2)
        Me.BtnDraft.Name = "BtnDraft"
        Me.BtnDraft.Size = New System.Drawing.Size(90, 44)
        Me.BtnDraft.TabIndex = 1
        Me.BtnDraft.Text = "Draft"
        '
        'BtnSend
        '
        Me.BtnSend.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSend.Image = CType(resources.GetObject("BtnSend.Image"), System.Drawing.Image)
        Me.BtnSend.Location = New System.Drawing.Point(736, 2)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 44)
        Me.BtnSend.TabIndex = 0
        Me.BtnSend.Text = "Send"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl3)
        Me.PanelControl1.Controls.Add(Me.MENote)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TxtMailStatus)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TxtMailType)
        Me.PanelControl1.Controls.Add(Me.TxtEmailNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(828, 152)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.DEUpdatedDate)
        Me.PanelControl3.Controls.Add(Me.DECreatedDate)
        Me.PanelControl3.Controls.Add(Me.TxtUpdatedBy)
        Me.PanelControl3.Controls.Add(Me.TxtCreatedBy)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Controls.Add(Me.LabelControl7)
        Me.PanelControl3.Controls.Add(Me.LabelControl6)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(484, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(342, 148)
        Me.PanelControl3.TabIndex = 8
        '
        'DEUpdatedDate
        '
        Me.DEUpdatedDate.EditValue = Nothing
        Me.DEUpdatedDate.Enabled = False
        Me.DEUpdatedDate.Location = New System.Drawing.Point(90, 63)
        Me.DEUpdatedDate.Name = "DEUpdatedDate"
        Me.DEUpdatedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUpdatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUpdatedDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEUpdatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUpdatedDate.Size = New System.Drawing.Size(243, 20)
        Me.DEUpdatedDate.TabIndex = 14
        '
        'DECreatedDate
        '
        Me.DECreatedDate.EditValue = Nothing
        Me.DECreatedDate.Enabled = False
        Me.DECreatedDate.Location = New System.Drawing.Point(90, 11)
        Me.DECreatedDate.Name = "DECreatedDate"
        Me.DECreatedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DECreatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedDate.Size = New System.Drawing.Size(243, 20)
        Me.DECreatedDate.TabIndex = 9
        '
        'TxtUpdatedBy
        '
        Me.TxtUpdatedBy.Enabled = False
        Me.TxtUpdatedBy.Location = New System.Drawing.Point(90, 88)
        Me.TxtUpdatedBy.Name = "TxtUpdatedBy"
        Me.TxtUpdatedBy.Size = New System.Drawing.Size(243, 20)
        Me.TxtUpdatedBy.TabIndex = 13
        '
        'TxtCreatedBy
        '
        Me.TxtCreatedBy.Enabled = False
        Me.TxtCreatedBy.Location = New System.Drawing.Point(90, 37)
        Me.TxtCreatedBy.Name = "TxtCreatedBy"
        Me.TxtCreatedBy.Size = New System.Drawing.Size(243, 20)
        Me.TxtCreatedBy.TabIndex = 9
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(10, 91)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl8.TabIndex = 12
        Me.LabelControl8.Text = "Updated By"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(10, 66)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl7.TabIndex = 11
        Me.LabelControl7.Text = "Updated Date"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(10, 40)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl6.TabIndex = 10
        Me.LabelControl6.Text = "Created By"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(10, 14)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Created Date"
        '
        'MENote
        '
        Me.MENote.Enabled = False
        Me.MENote.Location = New System.Drawing.Point(89, 91)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(243, 43)
        Me.MENote.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(15, 93)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Note"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 68)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Last Status"
        '
        'TxtMailStatus
        '
        Me.TxtMailStatus.Enabled = False
        Me.TxtMailStatus.Location = New System.Drawing.Point(89, 65)
        Me.TxtMailStatus.Name = "TxtMailStatus"
        Me.TxtMailStatus.Size = New System.Drawing.Size(243, 20)
        Me.TxtMailStatus.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Mail Type"
        '
        'TxtMailType
        '
        Me.TxtMailType.Enabled = False
        Me.TxtMailType.Location = New System.Drawing.Point(89, 39)
        Me.TxtMailType.Name = "TxtMailType"
        Me.TxtMailType.Size = New System.Drawing.Size(243, 20)
        Me.TxtMailType.TabIndex = 2
        '
        'TxtEmailNumber
        '
        Me.TxtEmailNumber.Enabled = False
        Me.TxtEmailNumber.Location = New System.Drawing.Point(89, 13)
        Me.TxtEmailNumber.Name = "TxtEmailNumber"
        Me.TxtEmailNumber.Size = New System.Drawing.Size(243, 20)
        Me.TxtEmailNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(15, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Email Number"
        '
        'FormMailManageDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 611)
        Me.Controls.Add(Me.XTCMail)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.MinimizeBox = False
        Me.Name = "FormMailManageDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMail.ResumeLayout(False)
        Me.XTPreview.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.MESubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.METo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPData.ResumeLayout(False)
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPFrom.ResumeLayout(False)
        CType(Me.GCMember, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DEUpdatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMailStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMailType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmailNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCMail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPreview As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPData As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDraft As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtMailType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtEmailNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtMailStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DECreatedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtUpdatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUpdatedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MECC As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents METo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEFrom As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPFrom As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMember As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMember As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_mail_manage_member As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_mail_manage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_mail_member_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_user As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_contact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmail_address As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmail_member_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MESubject As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BtnLog As DevExpress.XtraEditors.SimpleButton
End Class
