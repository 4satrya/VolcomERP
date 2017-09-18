<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGTracking
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
        Me.GroupControlFilter = New DevExpress.XtraEditors.GroupControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.BtnTracking = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEditCode = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControlInfo = New DevExpress.XtraEditors.GroupControl()
        Me.LabelColor = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelSource = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelBranding = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelDivision = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelSize = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelCode = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControlTraccking = New DevExpress.XtraEditors.GroupControl()
        Me.GCTracking = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVTracking = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnTransNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControlFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEditCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlInfo.SuspendLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlTraccking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlTraccking.SuspendLayout()
        CType(Me.GCTracking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVTracking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlFilter
        '
        Me.GroupControlFilter.Controls.Add(Me.DEUntil)
        Me.GroupControlFilter.Controls.Add(Me.DEFrom)
        Me.GroupControlFilter.Controls.Add(Me.BtnTracking)
        Me.GroupControlFilter.Controls.Add(Me.BtnEditCode)
        Me.GroupControlFilter.Controls.Add(Me.LabelControl3)
        Me.GroupControlFilter.Controls.Add(Me.LabelControl2)
        Me.GroupControlFilter.Controls.Add(Me.LabelControl1)
        Me.GroupControlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlFilter.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlFilter.Name = "GroupControlFilter"
        Me.GroupControlFilter.Size = New System.Drawing.Size(841, 60)
        Me.GroupControlFilter.TabIndex = 0
        Me.GroupControlFilter.Text = "Filter"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(489, 30)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(155, 20)
        Me.DEUntil.TabIndex = 8891
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(288, 30)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(155, 20)
        Me.DEFrom.TabIndex = 8890
        '
        'BtnTracking
        '
        Me.BtnTracking.Location = New System.Drawing.Point(656, 28)
        Me.BtnTracking.Name = "BtnTracking"
        Me.BtnTracking.Size = New System.Drawing.Size(75, 23)
        Me.BtnTracking.TabIndex = 2
        Me.BtnTracking.Text = "View"
        '
        'BtnEditCode
        '
        Me.BtnEditCode.Location = New System.Drawing.Point(79, 31)
        Me.BtnEditCode.Name = "BtnEditCode"
        Me.BtnEditCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BtnEditCode.Size = New System.Drawing.Size(160, 20)
        Me.BtnEditCode.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 33)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Unique Code"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(462, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(258, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "From"
        '
        'GroupControlInfo
        '
        Me.GroupControlInfo.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlInfo.Controls.Add(Me.LabelColor)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl21)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl19)
        Me.GroupControlInfo.Controls.Add(Me.LabelSource)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl17)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl16)
        Me.GroupControlInfo.Controls.Add(Me.LabelBranding)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl15)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl13)
        Me.GroupControlInfo.Controls.Add(Me.LabelDivision)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl11)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl10)
        Me.GroupControlInfo.Controls.Add(Me.LabelSize)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl8)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl7)
        Me.GroupControlInfo.Controls.Add(Me.LabelCode)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl5)
        Me.GroupControlInfo.Controls.Add(Me.LabelControl4)
        Me.GroupControlInfo.Controls.Add(Me.LabelTitle)
        Me.GroupControlInfo.Controls.Add(Me.PanelControlImg)
        Me.GroupControlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlInfo.Enabled = False
        Me.GroupControlInfo.Location = New System.Drawing.Point(0, 60)
        Me.GroupControlInfo.Name = "GroupControlInfo"
        Me.GroupControlInfo.Size = New System.Drawing.Size(841, 222)
        Me.GroupControlInfo.TabIndex = 1
        Me.GroupControlInfo.Text = "Information"
        '
        'LabelColor
        '
        Me.LabelColor.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelColor.Location = New System.Drawing.Point(308, 96)
        Me.LabelColor.Name = "LabelColor"
        Me.LabelColor.Size = New System.Drawing.Size(5, 16)
        Me.LabelColor.TabIndex = 19
        Me.LabelColor.Text = "-"
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(288, 96)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(5, 16)
        Me.LabelControl21.TabIndex = 18
        Me.LabelControl21.Text = ":"
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Location = New System.Drawing.Point(216, 96)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(30, 16)
        Me.LabelControl19.TabIndex = 17
        Me.LabelControl19.Text = "Color"
        '
        'LabelSource
        '
        Me.LabelSource.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSource.Location = New System.Drawing.Point(308, 175)
        Me.LabelSource.Name = "LabelSource"
        Me.LabelSource.Size = New System.Drawing.Size(5, 16)
        Me.LabelSource.TabIndex = 16
        Me.LabelSource.Text = "-"
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Location = New System.Drawing.Point(288, 175)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(5, 16)
        Me.LabelControl17.TabIndex = 15
        Me.LabelControl17.Text = ":"
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Location = New System.Drawing.Point(216, 175)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(40, 16)
        Me.LabelControl16.TabIndex = 14
        Me.LabelControl16.Text = "Source"
        '
        'LabelBranding
        '
        Me.LabelBranding.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBranding.Location = New System.Drawing.Point(308, 150)
        Me.LabelBranding.Name = "LabelBranding"
        Me.LabelBranding.Size = New System.Drawing.Size(5, 16)
        Me.LabelBranding.TabIndex = 13
        Me.LabelBranding.Text = "-"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(288, 150)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(5, 16)
        Me.LabelControl15.TabIndex = 12
        Me.LabelControl15.Text = ":"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(216, 150)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl13.TabIndex = 11
        Me.LabelControl13.Text = "Branding"
        '
        'LabelDivision
        '
        Me.LabelDivision.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDivision.Location = New System.Drawing.Point(308, 122)
        Me.LabelDivision.Name = "LabelDivision"
        Me.LabelDivision.Size = New System.Drawing.Size(5, 16)
        Me.LabelDivision.TabIndex = 10
        Me.LabelDivision.Text = "-"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(288, 122)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(5, 16)
        Me.LabelControl11.TabIndex = 9
        Me.LabelControl11.Text = ":"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(216, 122)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl10.TabIndex = 8
        Me.LabelControl10.Text = "Division"
        '
        'LabelSize
        '
        Me.LabelSize.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSize.Location = New System.Drawing.Point(308, 73)
        Me.LabelSize.Name = "LabelSize"
        Me.LabelSize.Size = New System.Drawing.Size(5, 16)
        Me.LabelSize.TabIndex = 7
        Me.LabelSize.Text = "-"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(288, 73)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(5, 16)
        Me.LabelControl8.TabIndex = 6
        Me.LabelControl8.Text = ":"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(216, 73)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 16)
        Me.LabelControl7.TabIndex = 5
        Me.LabelControl7.Text = "Size"
        '
        'LabelCode
        '
        Me.LabelCode.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCode.Location = New System.Drawing.Point(308, 50)
        Me.LabelCode.Name = "LabelCode"
        Me.LabelCode.Size = New System.Drawing.Size(5, 16)
        Me.LabelCode.TabIndex = 4
        Me.LabelCode.Text = "-"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(288, 50)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(5, 16)
        Me.LabelControl5.TabIndex = 3
        Me.LabelControl5.Text = ":"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(216, 50)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(29, 16)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Code"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(216, 17)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(157, 23)
        Me.LabelTitle.TabIndex = 1
        Me.LabelTitle.Text = "PRODUCT NAME"
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(21, 2)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(177, 218)
        Me.PanelControlImg.TabIndex = 0
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(177, 195)
        Me.PictureEdit1.TabIndex = 100
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 195)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(177, 23)
        Me.BtnViewImg.TabIndex = 1
        Me.BtnViewImg.Text = "View Image"
        '
        'GroupControlTraccking
        '
        Me.GroupControlTraccking.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlTraccking.Controls.Add(Me.GCTracking)
        Me.GroupControlTraccking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlTraccking.Enabled = False
        Me.GroupControlTraccking.Location = New System.Drawing.Point(0, 282)
        Me.GroupControlTraccking.Name = "GroupControlTraccking"
        Me.GroupControlTraccking.Size = New System.Drawing.Size(841, 249)
        Me.GroupControlTraccking.TabIndex = 2
        Me.GroupControlTraccking.Text = "Transaction History"
        '
        'GCTracking
        '
        Me.GCTracking.ContextMenuStrip = Me.ViewMenu
        Me.GCTracking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTracking.Location = New System.Drawing.Point(21, 2)
        Me.GCTracking.MainView = Me.GVTracking
        Me.GCTracking.Name = "GCTracking"
        Me.GCTracking.Size = New System.Drawing.Size(818, 245)
        Me.GCTracking.TabIndex = 0
        Me.GCTracking.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTracking})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewDel})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(159, 26)
        '
        'SMViewDel
        '
        Me.SMViewDel.Name = "SMViewDel"
        Me.SMViewDel.Size = New System.Drawing.Size(158, 22)
        Me.SMViewDel.Text = "View Document"
        '
        'GVTracking
        '
        Me.GVTracking.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnTransNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnTransDate, Me.GridColumnType, Me.GridColumnReportStatus, Me.GridColumnCode, Me.GridColumnDesign, Me.GridColumnSize})
        Me.GVTracking.GridControl = Me.GCTracking
        Me.GVTracking.Name = "GVTracking"
        Me.GVTracking.OptionsBehavior.Editable = False
        Me.GVTracking.OptionsBehavior.ReadOnly = True
        Me.GVTracking.OptionsView.ShowGroupPanel = False
        '
        'GridColumnTransNumber
        '
        Me.GridColumnTransNumber.Caption = "Transaction Number"
        Me.GridColumnTransNumber.FieldName = "trans_number"
        Me.GridColumnTransNumber.Name = "GridColumnTransNumber"
        Me.GridColumnTransNumber.Visible = True
        Me.GridColumnTransNumber.VisibleIndex = 0
        Me.GridColumnTransNumber.Width = 119
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 4
        Me.GridColumnFrom.Width = 131
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 5
        Me.GridColumnTo.Width = 131
        '
        'GridColumnTransDate
        '
        Me.GridColumnTransDate.Caption = "Date"
        Me.GridColumnTransDate.FieldName = "trans_date"
        Me.GridColumnTransDate.Name = "GridColumnTransDate"
        Me.GridColumnTransDate.Visible = True
        Me.GridColumnTransDate.VisibleIndex = 6
        Me.GridColumnTransDate.Width = 131
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "report_mark_type_name"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 7
        Me.GridColumnType.Width = 131
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 8
        Me.GridColumnReportStatus.Width = 141
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Unique Code"
        Me.GridColumnCode.FieldName = "product_unique_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 119
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        Me.GridColumnDesign.Width = 119
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 56
        '
        'FormFGTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 531)
        Me.Controls.Add(Me.GroupControlTraccking)
        Me.Controls.Add(Me.GroupControlInfo)
        Me.Controls.Add(Me.GroupControlFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGTracking"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Tracking"
        CType(Me.GroupControlFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlFilter.ResumeLayout(False)
        Me.GroupControlFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEditCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlInfo.ResumeLayout(False)
        Me.GroupControlInfo.PerformLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlTraccking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlTraccking.ResumeLayout(False)
        CType(Me.GCTracking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVTracking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControlFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlInfo As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlTraccking As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCTracking As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTracking As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnEditCode As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents BtnTracking As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelDivision As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelSource As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelBranding As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumnTransNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ViewMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMViewDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
End Class
