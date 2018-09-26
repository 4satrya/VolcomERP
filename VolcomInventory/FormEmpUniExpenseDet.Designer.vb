<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpUniExpenseDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpUniExpenseDet))
        Me.GroupControlTop = New DevExpress.XtraEditors.GroupControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNIP = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.TxtAcc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAccNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDel = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDraftJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControlBottom = New DevExpress.XtraEditors.GroupControl()
        Me.PanelBottomRight = New DevExpress.XtraEditors.PanelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControlMiddle = New DevExpress.XtraEditors.GroupControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPLDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControlTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlTop.SuspendLayout()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNIP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAccNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.GroupControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlBottom.SuspendLayout()
        CType(Me.PanelBottomRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottomRight.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlMiddle.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlTop
        '
        Me.GroupControlTop.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlTop.Controls.Add(Me.DEEnd)
        Me.GroupControlTop.Controls.Add(Me.DEStart)
        Me.GroupControlTop.Controls.Add(Me.LabelControl7)
        Me.GroupControlTop.Controls.Add(Me.LabelControl8)
        Me.GroupControlTop.Controls.Add(Me.TxtEmployeeName)
        Me.GroupControlTop.Controls.Add(Me.TxtNIP)
        Me.GroupControlTop.Controls.Add(Me.LabelControl6)
        Me.GroupControlTop.Controls.Add(Me.PanelControl1)
        Me.GroupControlTop.Controls.Add(Me.TxtAcc)
        Me.GroupControlTop.Controls.Add(Me.TxtAccNo)
        Me.GroupControlTop.Controls.Add(Me.LabelControl5)
        Me.GroupControlTop.Controls.Add(Me.TxtDel)
        Me.GroupControlTop.Controls.Add(Me.LabelControl4)
        Me.GroupControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlTop.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlTop.Name = "GroupControlTop"
        Me.GroupControlTop.Size = New System.Drawing.Size(987, 136)
        Me.GroupControlTop.TabIndex = 1
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(270, 95)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEnd.Size = New System.Drawing.Size(175, 20)
        Me.DEEnd.TabIndex = 8928
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(104, 95)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStart.Size = New System.Drawing.Size(150, 20)
        Me.DEStart.TabIndex = 8927
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(33, 98)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl7.TabIndex = 8929
        Me.LabelControl7.Text = "Period"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(260, 98)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl8.TabIndex = 8930
        Me.LabelControl8.Text = "-"
        '
        'TxtEmployeeName
        '
        Me.TxtEmployeeName.Enabled = False
        Me.TxtEmployeeName.Location = New System.Drawing.Point(188, 69)
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.Size = New System.Drawing.Size(257, 20)
        Me.TxtEmployeeName.TabIndex = 13
        '
        'TxtNIP
        '
        Me.TxtNIP.Enabled = False
        Me.TxtNIP.Location = New System.Drawing.Point(106, 69)
        Me.TxtNIP.Name = "TxtNIP"
        Me.TxtNIP.Size = New System.Drawing.Size(80, 20)
        Me.TxtNIP.TabIndex = 12
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(33, 72)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Employee"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.TxtNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DECreated)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(724, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(261, 132)
        Me.PanelControl1.TabIndex = 10
        '
        'TxtNumber
        '
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(72, 41)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(171, 20)
        Me.TxtNumber.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 18)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Date"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Number"
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(72, 15)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy hh:mm tt"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(171, 20)
        Me.DECreated.TabIndex = 4
        '
        'TxtAcc
        '
        Me.TxtAcc.Enabled = False
        Me.TxtAcc.Location = New System.Drawing.Point(188, 43)
        Me.TxtAcc.Name = "TxtAcc"
        Me.TxtAcc.Size = New System.Drawing.Size(257, 20)
        Me.TxtAcc.TabIndex = 9
        '
        'TxtAccNo
        '
        Me.TxtAccNo.Enabled = False
        Me.TxtAccNo.Location = New System.Drawing.Point(106, 43)
        Me.TxtAccNo.Name = "TxtAccNo"
        Me.TxtAccNo.Size = New System.Drawing.Size(80, 20)
        Me.TxtAccNo.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(33, 46)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "Account"
        '
        'TxtDel
        '
        Me.TxtDel.Location = New System.Drawing.Point(106, 17)
        Me.TxtDel.Name = "TxtDel"
        Me.TxtDel.Size = New System.Drawing.Size(339, 20)
        Me.TxtDel.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(33, 20)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Delivery#"
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.Controls.Add(Me.BtnDraftJournal)
        Me.PanelControlBottom.Controls.Add(Me.BtnMark)
        Me.PanelControlBottom.Controls.Add(Me.BtnAttachment)
        Me.PanelControlBottom.Controls.Add(Me.BtnPrint)
        Me.PanelControlBottom.Controls.Add(Me.BtnClose)
        Me.PanelControlBottom.Controls.Add(Me.BtnSave)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 592)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(987, 45)
        Me.PanelControlBottom.TabIndex = 3
        '
        'BtnDraftJournal
        '
        Me.BtnDraftJournal.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDraftJournal.Image = CType(resources.GetObject("BtnDraftJournal.Image"), System.Drawing.Image)
        Me.BtnDraftJournal.ImageIndex = 13
        Me.BtnDraftJournal.Location = New System.Drawing.Point(509, 2)
        Me.BtnDraftJournal.Name = "BtnDraftJournal"
        Me.BtnDraftJournal.Size = New System.Drawing.Size(109, 41)
        Me.BtnDraftJournal.TabIndex = 15
        Me.BtnDraftJournal.TabStop = False
        Me.BtnDraftJournal.Text = "Draft Journal"
        '
        'BtnMark
        '
        Me.BtnMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMark.Image = CType(resources.GetObject("BtnMark.Image"), System.Drawing.Image)
        Me.BtnMark.Location = New System.Drawing.Point(2, 2)
        Me.BtnMark.Name = "BtnMark"
        Me.BtnMark.Size = New System.Drawing.Size(88, 41)
        Me.BtnMark.TabIndex = 5
        Me.BtnMark.Text = "Mark"
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(618, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(106, 41)
        Me.BtnAttachment.TabIndex = 4
        Me.BtnAttachment.Text = "Attachment"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(724, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 41)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(811, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(87, 41)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(898, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(87, 41)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save"
        '
        'GroupControlBottom
        '
        Me.GroupControlBottom.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlBottom.Controls.Add(Me.PanelBottomRight)
        Me.GroupControlBottom.Controls.Add(Me.MENote)
        Me.GroupControlBottom.Controls.Add(Me.LabelControl2)
        Me.GroupControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControlBottom.Location = New System.Drawing.Point(0, 521)
        Me.GroupControlBottom.Name = "GroupControlBottom"
        Me.GroupControlBottom.Size = New System.Drawing.Size(987, 71)
        Me.GroupControlBottom.TabIndex = 4
        Me.GroupControlBottom.Text = "."
        '
        'PanelBottomRight
        '
        Me.PanelBottomRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelBottomRight.Controls.Add(Me.LEReportStatus)
        Me.PanelBottomRight.Controls.Add(Me.LabelControl21)
        Me.PanelBottomRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelBottomRight.Location = New System.Drawing.Point(678, 2)
        Me.PanelBottomRight.Name = "PanelBottomRight"
        Me.PanelBottomRight.Size = New System.Drawing.Size(307, 67)
        Me.PanelBottomRight.TabIndex = 140
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(90, 6)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.LEReportStatus.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(211, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(40, 9)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(71, 9)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(285, 49)
        Me.MENote.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(33, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Note"
        '
        'GroupControlMiddle
        '
        Me.GroupControlMiddle.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlMiddle.Controls.Add(Me.GCData)
        Me.GroupControlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlMiddle.Location = New System.Drawing.Point(0, 136)
        Me.GroupControlMiddle.Name = "GroupControlMiddle"
        Me.GroupControlMiddle.Size = New System.Drawing.Size(987, 385)
        Me.GroupControlMiddle.TabIndex = 5
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(20, 2)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(965, 381)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumnIdPLDet, Me.GridColumnIdProduct})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 38
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 105
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 310
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Size"
        Me.GridColumn4.FieldName = "size"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 59
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Qty"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 66
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Cost"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "design_cop"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 134
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Amount"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "amount"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn7.UnboundExpression = "[qty] * [design_cop]"
        Me.GridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 216
        '
        'GridColumnIdPLDet
        '
        Me.GridColumnIdPLDet.Caption = "ID Del Detail"
        Me.GridColumnIdPLDet.FieldName = "id_pl_sales_order_del_det"
        Me.GridColumnIdPLDet.Name = "GridColumnIdPLDet"
        Me.GridColumnIdPLDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.AllowEdit = False
        '
        'FormEmpUniExpenseDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 637)
        Me.Controls.Add(Me.GroupControlMiddle)
        Me.Controls.Add(Me.GroupControlBottom)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.GroupControlTop)
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniExpenseDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expense"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControlTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlTop.ResumeLayout(False)
        Me.GroupControlTop.PerformLayout()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNIP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAccNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.GroupControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlBottom.ResumeLayout(False)
        Me.GroupControlBottom.PerformLayout()
        CType(Me.PanelBottomRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottomRight.ResumeLayout(False)
        Me.PanelBottomRight.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlMiddle.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControlTop As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlBottom As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelBottomRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlMiddle As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtAcc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAccNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnIdPLDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNIP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDraftJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
