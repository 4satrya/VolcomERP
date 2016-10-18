<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormHome))
        Me.PanelName = New DevExpress.XtraEditors.PanelControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelName = New System.Windows.Forms.Label()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNotif = New DevExpress.XtraTab.XtraTabPage()
        Me.GCNotif = New DevExpress.XtraGrid.GridControl()
        Me.GVNotif = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdNotif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdNotifDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsread = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotifTitle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotifTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotifDateNew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMarkRead = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnEmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemToggleSwitch1 = New DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.XTPInfo = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.PanelName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelName.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPNotif.SuspendLayout()
        CType(Me.GCNotif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVNotif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemToggleSwitch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelName
        '
        Me.PanelName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelName.Controls.Add(Me.Label2)
        Me.PanelName.Controls.Add(Me.LabelName)
        Me.PanelName.Controls.Add(Me.PictureEdit1)
        Me.PanelName.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelName.Location = New System.Drawing.Point(0, 0)
        Me.PanelName.Name = "PanelName"
        Me.PanelName.Size = New System.Drawing.Size(735, 116)
        Me.PanelName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(107, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(262, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "MANAGEMENT TRAINEE | GENERAL DEPT."
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelName.Location = New System.Drawing.Point(106, 25)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(347, 25)
        Me.LabelName.TabIndex = 1
        Me.LabelName.Text = "CATUR SATRIYA ANNAS (090450508)"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Size = New System.Drawing.Size(100, 116)
        Me.PictureEdit1.TabIndex = 0
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 196)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPNotif
        Me.XtraTabControl1.Size = New System.Drawing.Size(735, 248)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNotif, Me.XTPInfo})
        '
        'XTPNotif
        '
        Me.XTPNotif.Controls.Add(Me.GCNotif)
        Me.XTPNotif.Image = CType(resources.GetObject("XTPNotif.Image"), System.Drawing.Image)
        Me.XTPNotif.Name = "XTPNotif"
        Me.XTPNotif.Size = New System.Drawing.Size(707, 246)
        Me.XTPNotif.Text = "Notification"
        '
        'GCNotif
        '
        Me.GCNotif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNotif.Location = New System.Drawing.Point(0, 0)
        Me.GCNotif.MainView = Me.GVNotif
        Me.GCNotif.Name = "GCNotif"
        Me.GCNotif.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemToggleSwitch1, Me.RepositoryItemImageEdit1, Me.RepositoryItemCheckEdit1})
        Me.GCNotif.Size = New System.Drawing.Size(707, 246)
        Me.GCNotif.TabIndex = 1
        Me.GCNotif.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNotif})
        '
        'GVNotif
        '
        Me.GVNotif.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdNotif, Me.GridColumnIdNotifDet, Me.GridColumnIsread, Me.GridColumnNotifTitle, Me.GridColumnNotif, Me.GridColumnNotifTime, Me.GridColumnNotifDateNew, Me.GridColumnMarkRead, Me.GridColumnEmp, Me.GridColumnType})
        Me.GVNotif.GridControl = Me.GCNotif
        Me.GVNotif.GroupCount = 1
        Me.GVNotif.Name = "GVNotif"
        Me.GVNotif.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVNotif.OptionsCustomization.AllowGroup = False
        Me.GVNotif.OptionsView.RowAutoHeight = True
        Me.GVNotif.OptionsView.ShowGroupPanel = False
        Me.GVNotif.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnNotifDateNew, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnNotifTime, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdNotif
        '
        Me.GridColumnIdNotif.Caption = "Id Notif"
        Me.GridColumnIdNotif.FieldName = "id_notif"
        Me.GridColumnIdNotif.Name = "GridColumnIdNotif"
        Me.GridColumnIdNotif.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdNotifDet
        '
        Me.GridColumnIdNotifDet.Caption = "ID Notif Det"
        Me.GridColumnIdNotifDet.FieldName = "id_notif_det"
        Me.GridColumnIdNotifDet.Name = "GridColumnIdNotifDet"
        '
        'GridColumnIsread
        '
        Me.GridColumnIsread.Caption = "Is Read"
        Me.GridColumnIsread.FieldName = "is_read"
        Me.GridColumnIsread.Name = "GridColumnIsread"
        '
        'GridColumnNotifTitle
        '
        Me.GridColumnNotifTitle.Caption = "Subject"
        Me.GridColumnNotifTitle.FieldName = "notif_title"
        Me.GridColumnNotifTitle.Name = "GridColumnNotifTitle"
        Me.GridColumnNotifTitle.OptionsColumn.AllowEdit = False
        Me.GridColumnNotifTitle.Visible = True
        Me.GridColumnNotifTitle.VisibleIndex = 2
        Me.GridColumnNotifTitle.Width = 124
        '
        'GridColumnNotif
        '
        Me.GridColumnNotif.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNotif.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnNotif.Caption = "Notification"
        Me.GridColumnNotif.FieldName = "notif_content"
        Me.GridColumnNotif.Name = "GridColumnNotif"
        Me.GridColumnNotif.OptionsColumn.AllowEdit = False
        Me.GridColumnNotif.Visible = True
        Me.GridColumnNotif.VisibleIndex = 3
        Me.GridColumnNotif.Width = 150
        '
        'GridColumnNotifTime
        '
        Me.GridColumnNotifTime.Caption = "Time"
        Me.GridColumnNotifTime.DisplayFormat.FormatString = "hh:mm tt"
        Me.GridColumnNotifTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNotifTime.FieldName = "notif_time"
        Me.GridColumnNotifTime.Name = "GridColumnNotifTime"
        Me.GridColumnNotifTime.OptionsColumn.AllowEdit = False
        Me.GridColumnNotifTime.Visible = True
        Me.GridColumnNotifTime.VisibleIndex = 4
        Me.GridColumnNotifTime.Width = 113
        '
        'GridColumnNotifDateNew
        '
        Me.GridColumnNotifDateNew.Caption = "Date"
        Me.GridColumnNotifDateNew.DisplayFormat.FormatString = "D"
        Me.GridColumnNotifDateNew.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNotifDateNew.FieldName = "notif_time"
        Me.GridColumnNotifDateNew.GroupFormat.FormatString = "D"
        Me.GridColumnNotifDateNew.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNotifDateNew.Name = "GridColumnNotifDateNew"
        Me.GridColumnNotifDateNew.OptionsColumn.AllowEdit = False
        Me.GridColumnNotifDateNew.Visible = True
        Me.GridColumnNotifDateNew.VisibleIndex = 2
        '
        'GridColumnMarkRead
        '
        Me.GridColumnMarkRead.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMarkRead.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnMarkRead.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMarkRead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnMarkRead.Caption = "Select"
        Me.GridColumnMarkRead.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnMarkRead.FieldName = "is_read_view"
        Me.GridColumnMarkRead.Name = "GridColumnMarkRead"
        Me.GridColumnMarkRead.Visible = True
        Me.GridColumnMarkRead.VisibleIndex = 0
        Me.GridColumnMarkRead.Width = 67
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnEmp
        '
        Me.GridColumnEmp.Caption = "From"
        Me.GridColumnEmp.FieldName = "employee_name"
        Me.GridColumnEmp.FieldNameSortGroup = "id_employee"
        Me.GridColumnEmp.Name = "GridColumnEmp"
        Me.GridColumnEmp.OptionsColumn.AllowEdit = False
        Me.GridColumnEmp.OptionsColumn.ReadOnly = True
        Me.GridColumnEmp.Visible = True
        Me.GridColumnEmp.VisibleIndex = 1
        Me.GridColumnEmp.Width = 124
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.OptionsColumn.AllowEdit = False
        Me.GridColumnType.Width = 111
        '
        'RepositoryItemToggleSwitch1
        '
        Me.RepositoryItemToggleSwitch1.AutoHeight = False
        Me.RepositoryItemToggleSwitch1.Name = "RepositoryItemToggleSwitch1"
        Me.RepositoryItemToggleSwitch1.OffText = "Off"
        Me.RepositoryItemToggleSwitch1.OnText = "On"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.AutoHeight = False
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'XTPInfo
        '
        Me.XTPInfo.Image = CType(resources.GetObject("XTPInfo.Image"), System.Drawing.Image)
        Me.XTPInfo.Name = "XTPInfo"
        Me.XTPInfo.Size = New System.Drawing.Size(707, 246)
        Me.XTPInfo.Text = "Information"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Bottom
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 116)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(735, 80)
        Me.GroupControl1.TabIndex = 3
        Me.GroupControl1.Text = "Quick Menu"
        '
        'FormHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 444)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelName)
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FormHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        CType(Me.PanelName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelName.ResumeLayout(False)
        Me.PanelName.PerformLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPNotif.ResumeLayout(False)
        CType(Me.GCNotif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVNotif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemToggleSwitch1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelName As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelName As Label
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNotif As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInfo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCNotif As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVNotif As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdNotif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdNotifDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsread As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotifTitle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotifTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotifDateNew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMarkRead As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnEmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemToggleSwitch1 As DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
End Class
