<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollPeriode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollPeriode))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LCStart = New DevExpress.XtraEditors.LabelControl()
        Me.LCEnd = New DevExpress.XtraEditors.LabelControl()
        Me.LCPayrollNote = New DevExpress.XtraEditors.LabelControl()
        Me.MEPayrollNote = New DevExpress.XtraEditors.MemoEdit()
        Me.LCEndOt = New DevExpress.XtraEditors.LabelControl()
        Me.DEEndOt = New DevExpress.XtraEditors.DateEdit()
        Me.DEStartOt = New DevExpress.XtraEditors.DateEdit()
        Me.LCStartOt = New DevExpress.XtraEditors.LabelControl()
        Me.LEPayrollType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LCPayrollType = New DevExpress.XtraEditors.LabelControl()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PCStart = New DevExpress.XtraEditors.PanelControl()
        Me.PCEnd = New DevExpress.XtraEditors.PanelControl()
        Me.PCPayrollType = New DevExpress.XtraEditors.PanelControl()
        Me.PCStartOt = New DevExpress.XtraEditors.PanelControl()
        Me.PCEndOt = New DevExpress.XtraEditors.PanelControl()
        Me.PCPayrollNote = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PCEndStore = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEndStore = New DevExpress.XtraEditors.DateEdit()
        Me.PCStartStore = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEStartStore = New DevExpress.XtraEditors.DateEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEPayrollNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndOt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndOt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartOt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartOt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPayrollType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCStart.SuspendLayout()
        CType(Me.PCEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCEnd.SuspendLayout()
        CType(Me.PCPayrollType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCPayrollType.SuspendLayout()
        CType(Me.PCStartOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCStartOt.SuspendLayout()
        CType(Me.PCEndOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCEndOt.SuspendLayout()
        CType(Me.PCPayrollNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCPayrollNote.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCEndStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCEndStore.SuspendLayout()
        CType(Me.DEEndStore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCStartStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCStartStore.SuspendLayout()
        CType(Me.DEStartStore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 306)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(429, 38)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(277, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 34)
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
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(352, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Save"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(125, 5)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEnd.Size = New System.Drawing.Size(290, 20)
        Me.DEEnd.TabIndex = 8928
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(125, 5)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStart.Size = New System.Drawing.Size(290, 20)
        Me.DEStart.TabIndex = 8927
        '
        'LCStart
        '
        Me.LCStart.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCStart.Location = New System.Drawing.Point(13, 6)
        Me.LCStart.Name = "LCStart"
        Me.LCStart.Size = New System.Drawing.Size(57, 13)
        Me.LCStart.TabIndex = 8929
        Me.LCStart.Text = "Period Start"
        '
        'LCEnd
        '
        Me.LCEnd.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCEnd.Location = New System.Drawing.Point(15, 8)
        Me.LCEnd.Name = "LCEnd"
        Me.LCEnd.Size = New System.Drawing.Size(51, 13)
        Me.LCEnd.TabIndex = 8931
        Me.LCEnd.Text = "Period End"
        '
        'LCPayrollNote
        '
        Me.LCPayrollNote.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCPayrollNote.Location = New System.Drawing.Point(15, 8)
        Me.LCPayrollNote.Name = "LCPayrollNote"
        Me.LCPayrollNote.Size = New System.Drawing.Size(23, 13)
        Me.LCPayrollNote.TabIndex = 8932
        Me.LCPayrollNote.Text = "Note"
        '
        'MEPayrollNote
        '
        Me.MEPayrollNote.Location = New System.Drawing.Point(125, 7)
        Me.MEPayrollNote.Name = "MEPayrollNote"
        Me.MEPayrollNote.Size = New System.Drawing.Size(290, 68)
        Me.MEPayrollNote.TabIndex = 8933
        '
        'LCEndOt
        '
        Me.LCEndOt.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCEndOt.Location = New System.Drawing.Point(15, 8)
        Me.LCEndOt.Name = "LCEndOt"
        Me.LCEndOt.Size = New System.Drawing.Size(98, 13)
        Me.LCEndOt.TabIndex = 8937
        Me.LCEndOt.Text = "Overtime Period End"
        '
        'DEEndOt
        '
        Me.DEEndOt.EditValue = Nothing
        Me.DEEndOt.Location = New System.Drawing.Point(125, 7)
        Me.DEEndOt.Name = "DEEndOt"
        Me.DEEndOt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEndOt.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEndOt.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEndOt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEndOt.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEndOt.Size = New System.Drawing.Size(290, 20)
        Me.DEEndOt.TabIndex = 8935
        '
        'DEStartOt
        '
        Me.DEStartOt.EditValue = Nothing
        Me.DEStartOt.Location = New System.Drawing.Point(125, 5)
        Me.DEStartOt.Name = "DEStartOt"
        Me.DEStartOt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartOt.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStartOt.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStartOt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStartOt.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStartOt.Size = New System.Drawing.Size(290, 20)
        Me.DEStartOt.TabIndex = 8934
        '
        'LCStartOt
        '
        Me.LCStartOt.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCStartOt.Location = New System.Drawing.Point(15, 8)
        Me.LCStartOt.Name = "LCStartOt"
        Me.LCStartOt.Size = New System.Drawing.Size(104, 13)
        Me.LCStartOt.TabIndex = 8936
        Me.LCStartOt.Text = "Overtime Period Start"
        '
        'LEPayrollType
        '
        Me.LEPayrollType.Location = New System.Drawing.Point(125, 7)
        Me.LEPayrollType.Name = "LEPayrollType"
        Me.LEPayrollType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPayrollType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_payroll_type", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("payroll_type", "Type")})
        Me.LEPayrollType.Size = New System.Drawing.Size(290, 20)
        Me.LEPayrollType.TabIndex = 8939
        '
        'LCPayrollType
        '
        Me.LCPayrollType.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCPayrollType.Location = New System.Drawing.Point(15, 8)
        Me.LCPayrollType.Name = "LCPayrollType"
        Me.LCPayrollType.Size = New System.Drawing.Size(24, 13)
        Me.LCPayrollType.TabIndex = 8940
        Me.LCPayrollType.Text = "Type"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'PCStart
        '
        Me.PCStart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCStart.Controls.Add(Me.DEStart)
        Me.PCStart.Controls.Add(Me.LCStart)
        Me.PCStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCStart.Location = New System.Drawing.Point(0, 10)
        Me.PCStart.Name = "PCStart"
        Me.PCStart.Size = New System.Drawing.Size(429, 30)
        Me.PCStart.TabIndex = 8941
        '
        'PCEnd
        '
        Me.PCEnd.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCEnd.Controls.Add(Me.LCEnd)
        Me.PCEnd.Controls.Add(Me.DEEnd)
        Me.PCEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCEnd.Location = New System.Drawing.Point(0, 40)
        Me.PCEnd.Name = "PCEnd"
        Me.PCEnd.Size = New System.Drawing.Size(429, 30)
        Me.PCEnd.TabIndex = 8942
        '
        'PCPayrollType
        '
        Me.PCPayrollType.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCPayrollType.Controls.Add(Me.LCPayrollType)
        Me.PCPayrollType.Controls.Add(Me.LEPayrollType)
        Me.PCPayrollType.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCPayrollType.Location = New System.Drawing.Point(0, 70)
        Me.PCPayrollType.Name = "PCPayrollType"
        Me.PCPayrollType.Size = New System.Drawing.Size(429, 30)
        Me.PCPayrollType.TabIndex = 8943
        '
        'PCStartOt
        '
        Me.PCStartOt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCStartOt.Controls.Add(Me.LCStartOt)
        Me.PCStartOt.Controls.Add(Me.DEStartOt)
        Me.PCStartOt.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCStartOt.Location = New System.Drawing.Point(0, 100)
        Me.PCStartOt.Name = "PCStartOt"
        Me.PCStartOt.Size = New System.Drawing.Size(429, 30)
        Me.PCStartOt.TabIndex = 8944
        '
        'PCEndOt
        '
        Me.PCEndOt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCEndOt.Controls.Add(Me.LCEndOt)
        Me.PCEndOt.Controls.Add(Me.DEEndOt)
        Me.PCEndOt.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCEndOt.Location = New System.Drawing.Point(0, 130)
        Me.PCEndOt.Name = "PCEndOt"
        Me.PCEndOt.Size = New System.Drawing.Size(429, 30)
        Me.PCEndOt.TabIndex = 8945
        '
        'PCPayrollNote
        '
        Me.PCPayrollNote.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCPayrollNote.Controls.Add(Me.LCPayrollNote)
        Me.PCPayrollNote.Controls.Add(Me.MEPayrollNote)
        Me.PCPayrollNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCPayrollNote.Location = New System.Drawing.Point(0, 220)
        Me.PCPayrollNote.Name = "PCPayrollNote"
        Me.PCPayrollNote.Size = New System.Drawing.Size(429, 86)
        Me.PCPayrollNote.TabIndex = 8946
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(429, 10)
        Me.PanelControl2.TabIndex = 8947
        '
        'PCEndStore
        '
        Me.PCEndStore.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCEndStore.Controls.Add(Me.LabelControl1)
        Me.PCEndStore.Controls.Add(Me.DEEndStore)
        Me.PCEndStore.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCEndStore.Location = New System.Drawing.Point(0, 190)
        Me.PCEndStore.Name = "PCEndStore"
        Me.PCEndStore.Size = New System.Drawing.Size(429, 30)
        Me.PCEndStore.TabIndex = 8949
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(15, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl1.TabIndex = 8937
        Me.LabelControl1.Text = "Store Period End"
        '
        'DEEndStore
        '
        Me.DEEndStore.EditValue = Nothing
        Me.DEEndStore.Location = New System.Drawing.Point(125, 7)
        Me.DEEndStore.Name = "DEEndStore"
        Me.DEEndStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEndStore.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEndStore.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEndStore.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEndStore.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEndStore.Size = New System.Drawing.Size(290, 20)
        Me.DEEndStore.TabIndex = 8935
        '
        'PCStartStore
        '
        Me.PCStartStore.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCStartStore.Controls.Add(Me.LabelControl2)
        Me.PCStartStore.Controls.Add(Me.DEStartStore)
        Me.PCStartStore.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCStartStore.Location = New System.Drawing.Point(0, 160)
        Me.PCStartStore.Name = "PCStartStore"
        Me.PCStartStore.Size = New System.Drawing.Size(429, 30)
        Me.PCStartStore.TabIndex = 8948
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl2.TabIndex = 8936
        Me.LabelControl2.Text = "Store Period Start"
        '
        'DEStartStore
        '
        Me.DEStartStore.EditValue = Nothing
        Me.DEStartStore.Location = New System.Drawing.Point(125, 5)
        Me.DEStartStore.Name = "DEStartStore"
        Me.DEStartStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartStore.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStartStore.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStartStore.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStartStore.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStartStore.Size = New System.Drawing.Size(290, 20)
        Me.DEStartStore.TabIndex = 8934
        '
        'FormEmpPayrollPeriode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 344)
        Me.Controls.Add(Me.PCPayrollNote)
        Me.Controls.Add(Me.PCEndStore)
        Me.Controls.Add(Me.PCStartStore)
        Me.Controls.Add(Me.PCEndOt)
        Me.Controls.Add(Me.PCStartOt)
        Me.Controls.Add(Me.PCPayrollType)
        Me.Controls.Add(Me.PCEnd)
        Me.Controls.Add(Me.PCStart)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollPeriode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periode Payroll"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEPayrollNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndOt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndOt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartOt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartOt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPayrollType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCStart.ResumeLayout(False)
        Me.PCStart.PerformLayout()
        CType(Me.PCEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCEnd.ResumeLayout(False)
        Me.PCEnd.PerformLayout()
        CType(Me.PCPayrollType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCPayrollType.ResumeLayout(False)
        Me.PCPayrollType.PerformLayout()
        CType(Me.PCStartOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCStartOt.ResumeLayout(False)
        Me.PCStartOt.PerformLayout()
        CType(Me.PCEndOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCEndOt.ResumeLayout(False)
        Me.PCEndOt.PerformLayout()
        CType(Me.PCPayrollNote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCPayrollNote.ResumeLayout(False)
        Me.PCPayrollNote.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCEndStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCEndStore.ResumeLayout(False)
        Me.PCEndStore.PerformLayout()
        CType(Me.DEEndStore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCStartStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCStartStore.ResumeLayout(False)
        Me.PCStartStore.PerformLayout()
        CType(Me.DEStartStore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LCStart As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LCEnd As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LCPayrollNote As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEPayrollNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LCEndOt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEndOt As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStartOt As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LCStartOt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPayrollType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LCPayrollType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents PCStart As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCPayrollNote As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCEndOt As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCStartOt As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCPayrollType As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCEnd As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCEndStore As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEndStore As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PCStartStore As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStartStore As DevExpress.XtraEditors.DateEdit
End Class
