<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGRepairReturnRec
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
        Me.XTCRepairRec = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPTransList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRepairRec = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMPrePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVRepairRec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRepair = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFGRepairNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPWaitingList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRepairList = New DevExpress.XtraGrid.GridControl()
        Me.GVRepairList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWH = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCRepairRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRepairRec.SuspendLayout()
        Me.XTPTransList.SuspendLayout()
        CType(Me.GCRepairRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVRepairRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWaitingList.SuspendLayout()
        CType(Me.GCRepairList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRepairList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCRepairRec
        '
        Me.XTCRepairRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRepairRec.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCRepairRec.Location = New System.Drawing.Point(0, 0)
        Me.XTCRepairRec.Name = "XTCRepairRec"
        Me.XTCRepairRec.SelectedTabPage = Me.XTPTransList
        Me.XTCRepairRec.Size = New System.Drawing.Size(703, 349)
        Me.XTCRepairRec.TabIndex = 1
        Me.XTCRepairRec.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPTransList, Me.XTPWaitingList})
        '
        'XTPTransList
        '
        Me.XTPTransList.Controls.Add(Me.GCRepairRec)
        Me.XTPTransList.Controls.Add(Me.GCFilter)
        Me.XTPTransList.Name = "XTPTransList"
        Me.XTPTransList.Size = New System.Drawing.Size(697, 321)
        Me.XTPTransList.Text = "Transaction List"
        '
        'GCRepairRec
        '
        Me.GCRepairRec.ContextMenuStrip = Me.ViewMenu
        Me.GCRepairRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRepairRec.Location = New System.Drawing.Point(0, 39)
        Me.GCRepairRec.MainView = Me.GVRepairRec
        Me.GCRepairRec.Name = "GCRepairRec"
        Me.GCRepairRec.Size = New System.Drawing.Size(697, 282)
        Me.GCRepairRec.TabIndex = 7
        Me.GCRepairRec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRepairRec})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMPrePrint, Me.SMPrint})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(137, 48)
        '
        'SMPrePrint
        '
        Me.SMPrePrint.Name = "SMPrePrint"
        Me.SMPrePrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrePrint.Text = "Pre Printing"
        '
        'SMPrint
        '
        Me.SMPrint.Name = "SMPrint"
        Me.SMPrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrint.Text = "Print"
        '
        'GVRepairRec
        '
        Me.GVRepairRec.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnNumber, Me.GridColumnRepair, Me.GridColumnCreatedDate, Me.GridColumnFGRepairNote, Me.GridColumnStatus, Me.GridColumnCompFrom, Me.GridColumnCompTo, Me.GridColumnWH})
        Me.GVRepairRec.GridControl = Me.GCRepairRec
        Me.GVRepairRec.Name = "GVRepairRec"
        Me.GVRepairRec.OptionsBehavior.Editable = False
        Me.GVRepairRec.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "Id"
        Me.GridColumnID.FieldName = "id_fg_repair_return_rec"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_repair_return_rec_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnRepair
        '
        Me.GridColumnRepair.Caption = "Repair#"
        Me.GridColumnRepair.FieldName = "fg_repair_return_number"
        Me.GridColumnRepair.Name = "GridColumnRepair"
        Me.GridColumnRepair.Visible = True
        Me.GridColumnRepair.VisibleIndex = 1
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "fg_repair_return_rec_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnFGRepairNote
        '
        Me.GridColumnFGRepairNote.Caption = "Note"
        Me.GridColumnFGRepairNote.FieldName = "fg_repair_return_rec_note"
        Me.GridColumnFGRepairNote.Name = "GridColumnFGRepairNote"
        Me.GridColumnFGRepairNote.Visible = True
        Me.GridColumnFGRepairNote.VisibleIndex = 6
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 7
        '
        'GridColumnCompFrom
        '
        Me.GridColumnCompFrom.Caption = "From"
        Me.GridColumnCompFrom.FieldName = "comp_from"
        Me.GridColumnCompFrom.Name = "GridColumnCompFrom"
        Me.GridColumnCompFrom.Visible = True
        Me.GridColumnCompFrom.VisibleIndex = 2
        '
        'GridColumnCompTo
        '
        Me.GridColumnCompTo.Caption = "To"
        Me.GridColumnCompTo.FieldName = "comp_to"
        Me.GridColumnCompTo.Name = "GridColumnCompTo"
        Me.GridColumnCompTo.Visible = True
        Me.GridColumnCompTo.VisibleIndex = 3
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(697, 39)
        Me.GCFilter.TabIndex = 6
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(317, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'XTPWaitingList
        '
        Me.XTPWaitingList.Controls.Add(Me.GCRepairList)
        Me.XTPWaitingList.Name = "XTPWaitingList"
        Me.XTPWaitingList.Size = New System.Drawing.Size(697, 321)
        Me.XTPWaitingList.Text = "Waiting to Receive"
        '
        'GCRepairList
        '
        Me.GCRepairList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRepairList.Location = New System.Drawing.Point(0, 0)
        Me.GCRepairList.MainView = Me.GVRepairList
        Me.GCRepairList.Name = "GCRepairList"
        Me.GCRepairList.Size = New System.Drawing.Size(697, 321)
        Me.GCRepairList.TabIndex = 8
        Me.GCRepairList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRepairList})
        '
        'GVRepairList
        '
        Me.GVRepairList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVRepairList.GridControl = Me.GCRepairList
        Me.GVRepairList.Name = "GVRepairList"
        Me.GVRepairList.OptionsBehavior.Editable = False
        Me.GVRepairList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_fg_repair_return"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "fg_repair_return_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "fg_repair_return_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "fg_repair_return_note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "From"
        Me.GridColumn6.FieldName = "comp_from"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "To"
        Me.GridColumn7.FieldName = "comp_to"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumnWH
        '
        Me.GridColumnWH.Caption = "WH"
        Me.GridColumnWH.FieldName = "wh"
        Me.GridColumnWH.Name = "GridColumnWH"
        Me.GridColumnWH.Visible = True
        Me.GridColumnWH.VisibleIndex = 4
        '
        'FormFGRepairReturnRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 349)
        Me.Controls.Add(Me.XTCRepairRec)
        Me.MinimizeBox = False
        Me.Name = "FormFGRepairReturnRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive Return Repair Product"
        CType(Me.XTCRepairRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRepairRec.ResumeLayout(False)
        Me.XTPTransList.ResumeLayout(False)
        CType(Me.GCRepairRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVRepairRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWaitingList.ResumeLayout(False)
        CType(Me.GCRepairList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRepairList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCRepairRec As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPTransList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRepairRec As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRepairRec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRepair As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFGRepairNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPWaitingList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRepairList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRepairList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMPrePrint As ToolStripMenuItem
    Friend WithEvents SMPrint As ToolStripMenuItem
    Friend WithEvents GridColumnWH As DevExpress.XtraGrid.Columns.GridColumn
End Class
