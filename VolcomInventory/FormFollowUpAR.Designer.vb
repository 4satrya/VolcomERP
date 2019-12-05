<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFollowUpAR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFollowUpAR))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCAR = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPInvoiceOpen = New DevExpress.XtraTab.XtraTabPage()
        Me.GridColumnid_follow_up_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndue_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up_result = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up_input = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAR.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1013, 43)
        Me.PanelControl1.TabIndex = 4
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(188, 11)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8917
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(44, 11)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8916
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(161, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8915
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8914
        Me.LabelControl3.Text = "From"
        '
        'BView
        '
        Me.BView.Image = CType(resources.GetObject("BView.Image"), System.Drawing.Image)
        Me.BView.Location = New System.Drawing.Point(305, 11)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 20)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "View"
        '
        'XTCAR
        '
        Me.XTCAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAR.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCAR.Location = New System.Drawing.Point(0, 0)
        Me.XTCAR.Name = "XTCAR"
        Me.XTCAR.SelectedTabPage = Me.XTPList
        Me.XTCAR.Size = New System.Drawing.Size(1019, 528)
        Me.XTCAR.TabIndex = 5
        Me.XTCAR.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPInvoiceOpen})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCData)
        Me.XTPList.Controls.Add(Me.PanelControl1)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(1013, 500)
        Me.XTPList.Text = "List"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 43)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1013, 457)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_follow_up_ar, Me.GridColumnid_comp_group, Me.GridColumngroup, Me.GridColumngroup_description, Me.GridColumndue_date, Me.GridColumnfollow_up, Me.GridColumnfollow_up_result, Me.GridColumnfollow_up_date, Me.GridColumnfollow_up_input})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", Nothing, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'XTPInvoiceOpen
        '
        Me.XTPInvoiceOpen.Name = "XTPInvoiceOpen"
        Me.XTPInvoiceOpen.Size = New System.Drawing.Size(1013, 500)
        Me.XTPInvoiceOpen.Text = "Current Invoice Open"
        '
        'GridColumnid_follow_up_ar
        '
        Me.GridColumnid_follow_up_ar.Caption = "id_follow_up_ar"
        Me.GridColumnid_follow_up_ar.FieldName = "id_follow_up_ar"
        Me.GridColumnid_follow_up_ar.Name = "GridColumnid_follow_up_ar"
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumngroup
        '
        Me.GridColumngroup.Caption = "Group"
        Me.GridColumngroup.FieldName = "group"
        Me.GridColumngroup.Name = "GridColumngroup"
        Me.GridColumngroup.Visible = True
        Me.GridColumngroup.VisibleIndex = 0
        '
        'GridColumndue_date
        '
        Me.GridColumndue_date.Caption = "Due Date"
        Me.GridColumndue_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndue_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndue_date.FieldName = "due_date"
        Me.GridColumndue_date.Name = "GridColumndue_date"
        Me.GridColumndue_date.Visible = True
        Me.GridColumndue_date.VisibleIndex = 2
        '
        'GridColumngroup_description
        '
        Me.GridColumngroup_description.Caption = "Group Description"
        Me.GridColumngroup_description.FieldName = "group_description"
        Me.GridColumngroup_description.Name = "GridColumngroup_description"
        Me.GridColumngroup_description.Visible = True
        Me.GridColumngroup_description.VisibleIndex = 1
        '
        'GridColumnfollow_up
        '
        Me.GridColumnfollow_up.Caption = "Follow Up"
        Me.GridColumnfollow_up.FieldName = "follow_up"
        Me.GridColumnfollow_up.Name = "GridColumnfollow_up"
        Me.GridColumnfollow_up.Visible = True
        Me.GridColumnfollow_up.VisibleIndex = 3
        '
        'GridColumnfollow_up_result
        '
        Me.GridColumnfollow_up_result.Caption = "Follow Up Result"
        Me.GridColumnfollow_up_result.FieldName = "follow_up_result"
        Me.GridColumnfollow_up_result.Name = "GridColumnfollow_up_result"
        Me.GridColumnfollow_up_result.Visible = True
        Me.GridColumnfollow_up_result.VisibleIndex = 4
        '
        'GridColumnfollow_up_date
        '
        Me.GridColumnfollow_up_date.Caption = "Date"
        Me.GridColumnfollow_up_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnfollow_up_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfollow_up_date.FieldName = "follow_up_date"
        Me.GridColumnfollow_up_date.Name = "GridColumnfollow_up_date"
        Me.GridColumnfollow_up_date.Visible = True
        Me.GridColumnfollow_up_date.VisibleIndex = 5
        '
        'GridColumnfollow_up_input
        '
        Me.GridColumnfollow_up_input.Caption = "Updated at"
        Me.GridColumnfollow_up_input.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnfollow_up_input.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfollow_up_input.FieldName = "follow_up_input"
        Me.GridColumnfollow_up_input.Name = "GridColumnfollow_up_input"
        Me.GridColumnfollow_up_input.Visible = True
        Me.GridColumnfollow_up_input.VisibleIndex = 6
        '
        'FormFollowUpAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 528)
        Me.Controls.Add(Me.XTCAR)
        Me.Name = "FormFollowUpAR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow Up AR"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAR.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCAR As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInvoiceOpen As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnid_follow_up_ar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndue_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up_result As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up_input As DevExpress.XtraGrid.Columns.GridColumn
End Class
