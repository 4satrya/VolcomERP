<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkCancel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportMarkCancel))
        Me.DEDateProposed = New DevExpress.XtraEditors.DateEdit()
        Me.MEReason = New DevExpress.XtraEditors.MemoEdit()
        Me.TECancelBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PCSubmit = New DevExpress.XtraEditors.PanelControl()
        Me.BSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.PCAttachment = New DevExpress.XtraEditors.PanelControl()
        Me.BAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportMarkType = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.BViewApproval = New DevExpress.XtraEditors.SimpleButton()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCReportList = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewDet = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVReportList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PCAddDel = New DevExpress.XtraEditors.PanelControl()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.PCPrint = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DEDateProposed.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateProposed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECancelBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCSubmit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSubmit.SuspendLayout()
        CType(Me.PCAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAttachment.SuspendLayout()
        CType(Me.LEReportMarkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCReportList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVReportList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCAddDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAddDel.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PCPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'DEDateProposed
        '
        Me.DEDateProposed.EditValue = Nothing
        Me.DEDateProposed.Enabled = False
        Me.DEDateProposed.Location = New System.Drawing.Point(126, 38)
        Me.DEDateProposed.Name = "DEDateProposed"
        Me.DEDateProposed.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateProposed.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateProposed.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDateProposed.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateProposed.Size = New System.Drawing.Size(184, 20)
        Me.DEDateProposed.TabIndex = 154
        '
        'MEReason
        '
        Me.MEReason.Location = New System.Drawing.Point(34, 36)
        Me.MEReason.Name = "MEReason"
        Me.MEReason.Size = New System.Drawing.Size(667, 78)
        Me.MEReason.TabIndex = 153
        '
        'TECancelBy
        '
        Me.TECancelBy.EditValue = "[Auto Generate]"
        Me.TECancelBy.Location = New System.Drawing.Point(340, 12)
        Me.TECancelBy.Name = "TECancelBy"
        Me.TECancelBy.Properties.ReadOnly = True
        Me.TECancelBy.Size = New System.Drawing.Size(312, 20)
        Me.TECancelBy.TabIndex = 152
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl2.TabIndex = 151
        Me.LabelControl2.Text = "Cancel Reason"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(287, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 150
        Me.LabelControl1.Text = "Cancel By"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(34, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl3.TabIndex = 155
        Me.LabelControl3.Text = "Date Proposed"
        '
        'PCSubmit
        '
        Me.PCSubmit.Controls.Add(Me.BSubmit)
        Me.PCSubmit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCSubmit.Location = New System.Drawing.Point(0, 507)
        Me.PCSubmit.Name = "PCSubmit"
        Me.PCSubmit.Size = New System.Drawing.Size(717, 29)
        Me.PCSubmit.TabIndex = 161
        '
        'BSubmit
        '
        Me.BSubmit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BSubmit.ImageIndex = 4
        Me.BSubmit.Location = New System.Drawing.Point(2, 2)
        Me.BSubmit.Name = "BSubmit"
        Me.BSubmit.Size = New System.Drawing.Size(713, 25)
        Me.BSubmit.TabIndex = 15
        Me.BSubmit.TabStop = False
        Me.BSubmit.Text = "Submit"
        '
        'PCAttachment
        '
        Me.PCAttachment.Controls.Add(Me.BAttachment)
        Me.PCAttachment.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCAttachment.Location = New System.Drawing.Point(0, 478)
        Me.PCAttachment.Name = "PCAttachment"
        Me.PCAttachment.Size = New System.Drawing.Size(717, 29)
        Me.PCAttachment.TabIndex = 162
        '
        'BAttachment
        '
        Me.BAttachment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BAttachment.ImageIndex = 4
        Me.BAttachment.Location = New System.Drawing.Point(2, 2)
        Me.BAttachment.Name = "BAttachment"
        Me.BAttachment.Size = New System.Drawing.Size(713, 25)
        Me.BAttachment.TabIndex = 15
        Me.BAttachment.TabStop = False
        Me.BAttachment.Text = "Attachment"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(34, 67)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl10.TabIndex = 166
        Me.LabelControl10.Text = "Report Mark Type"
        '
        'LEReportMarkType
        '
        Me.LEReportMarkType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEReportMarkType.Location = New System.Drawing.Point(126, 64)
        Me.LEReportMarkType.Name = "LEReportMarkType"
        Me.LEReportMarkType.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportMarkType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportMarkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportMarkType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type_name", "Report Type")})
        Me.LEReportMarkType.Properties.NullText = ""
        Me.LEReportMarkType.Properties.ShowFooter = False
        Me.LEReportMarkType.Size = New System.Drawing.Size(423, 20)
        Me.LEReportMarkType.TabIndex = 165
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.BViewApproval)
        Me.GroupControl1.Controls.Add(Me.TENumber)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.TECancelBy)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.DEDateProposed)
        Me.GroupControl1.Controls.Add(Me.LEReportMarkType)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(717, 100)
        Me.GroupControl1.TabIndex = 167
        Me.GroupControl1.Text = "Header"
        '
        'BViewApproval
        '
        Me.BViewApproval.Location = New System.Drawing.Point(316, 36)
        Me.BViewApproval.Name = "BViewApproval"
        Me.BViewApproval.Size = New System.Drawing.Size(81, 23)
        Me.BViewApproval.TabIndex = 169
        Me.BViewApproval.Text = "view approval"
        '
        'TENumber
        '
        Me.TENumber.EditValue = "[Auto Generate]"
        Me.TENumber.Location = New System.Drawing.Point(126, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(155, 20)
        Me.TENumber.TabIndex = 168
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(34, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 167
        Me.LabelControl4.Text = "Number"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCReportList)
        Me.GroupControl2.Controls.Add(Me.PCAddDel)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 100)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(717, 210)
        Me.GroupControl2.TabIndex = 168
        Me.GroupControl2.Text = "List Document"
        '
        'GCReportList
        '
        Me.GCReportList.ContextMenuStrip = Me.ViewMenu
        Me.GCReportList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReportList.Location = New System.Drawing.Point(20, 41)
        Me.GCReportList.MainView = Me.GVReportList
        Me.GCReportList.Name = "GCReportList"
        Me.GCReportList.Size = New System.Drawing.Size(695, 167)
        Me.GCReportList.TabIndex = 0
        Me.GCReportList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReportList})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewDet})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(133, 26)
        '
        'SMViewDet
        '
        Me.SMViewDet.Name = "SMViewDet"
        Me.SMViewDet.Size = New System.Drawing.Size(132, 22)
        Me.SMViewDet.Text = "View Detail"
        '
        'GVReportList
        '
        Me.GVReportList.GridControl = Me.GCReportList
        Me.GVReportList.Name = "GVReportList"
        Me.GVReportList.OptionsBehavior.ReadOnly = True
        Me.GVReportList.OptionsView.ShowGroupPanel = False
        '
        'PCAddDel
        '
        Me.PCAddDel.Controls.Add(Me.BDelete)
        Me.PCAddDel.Controls.Add(Me.BAdd)
        Me.PCAddDel.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCAddDel.Location = New System.Drawing.Point(20, 2)
        Me.PCAddDel.Name = "PCAddDel"
        Me.PCAddDel.Size = New System.Drawing.Size(695, 39)
        Me.PCAddDel.TabIndex = 1
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 1
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(503, 2)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(93, 35)
        Me.BDelete.TabIndex = 1
        Me.BDelete.Text = "Delete"
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
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(596, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(97, 35)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Add"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.MEReason)
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 310)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(717, 139)
        Me.GroupControl3.TabIndex = 169
        Me.GroupControl3.Text = "Reason"
        '
        'PCPrint
        '
        Me.PCPrint.Controls.Add(Me.BPrint)
        Me.PCPrint.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCPrint.Location = New System.Drawing.Point(0, 449)
        Me.PCPrint.Name = "PCPrint"
        Me.PCPrint.Size = New System.Drawing.Size(717, 29)
        Me.PCPrint.TabIndex = 170
        Me.PCPrint.Visible = False
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BPrint.ImageIndex = 4
        Me.BPrint.Location = New System.Drawing.Point(2, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(713, 25)
        Me.BPrint.TabIndex = 15
        Me.BPrint.TabStop = False
        Me.BPrint.Text = "Print"
        '
        'FormReportMarkCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 536)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PCPrint)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PCAttachment)
        Me.Controls.Add(Me.PCSubmit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkCancel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Form"
        CType(Me.DEDateProposed.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateProposed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECancelBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCSubmit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSubmit.ResumeLayout(False)
        CType(Me.PCAttachment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAttachment.ResumeLayout(False)
        CType(Me.LEReportMarkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCReportList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVReportList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCAddDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAddDel.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.PCPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCPrint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DEDateProposed As DevExpress.XtraEditors.DateEdit
    Friend WithEvents MEReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECancelBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PCSubmit As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCAttachment As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportMarkType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCReportList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReportList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCAddDel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMViewDet As ToolStripMenuItem
    Friend WithEvents PCPrint As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BViewApproval As DevExpress.XtraEditors.SimpleButton
End Class
