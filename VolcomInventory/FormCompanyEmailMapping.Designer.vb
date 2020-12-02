<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCompanyEmailMapping
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
        Me.GCListStoreGroup = New DevExpress.XtraGrid.GridControl()
        Me.GVListStoreGroup = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPStoreGroup = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPInternal = New DevExpress.XtraTab.XtraTabPage()
        Me.GCListInternal = New DevExpress.XtraGrid.GridControl()
        Me.GVListInternal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTP3PL = New DevExpress.XtraTab.XtraTabPage()
        Me.GC3PL = New DevExpress.XtraGrid.GridControl()
        Me.GV3PL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCListStoreGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListStoreGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl.SuspendLayout()
        Me.XTPStoreGroup.SuspendLayout()
        Me.XTPInternal.SuspendLayout()
        CType(Me.GCListInternal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListInternal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTP3PL.SuspendLayout()
        CType(Me.GC3PL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV3PL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCListStoreGroup
        '
        Me.GCListStoreGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListStoreGroup.Location = New System.Drawing.Point(0, 0)
        Me.GCListStoreGroup.MainView = Me.GVListStoreGroup
        Me.GCListStoreGroup.Name = "GCListStoreGroup"
        Me.GCListStoreGroup.Size = New System.Drawing.Size(1002, 701)
        Me.GCListStoreGroup.TabIndex = 0
        Me.GCListStoreGroup.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListStoreGroup})
        '
        'GVListStoreGroup
        '
        Me.GVListStoreGroup.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn1, Me.GridColumn15, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVListStoreGroup.GridControl = Me.GCListStoreGroup
        Me.GVListStoreGroup.GroupCount = 1
        Me.GVListStoreGroup.Name = "GVListStoreGroup"
        Me.GVListStoreGroup.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVListStoreGroup.OptionsBehavior.Editable = False
        Me.GVListStoreGroup.OptionsFind.AlwaysVisible = True
        Me.GVListStoreGroup.OptionsView.ColumnAutoWidth = False
        Me.GVListStoreGroup.OptionsView.ShowGroupedColumns = True
        Me.GVListStoreGroup.OptionsView.ShowGroupPanel = False
        Me.GVListStoreGroup.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn13"
        Me.GridColumn13.FieldName = "id_mail_manage_mapping"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Store Group"
        Me.GridColumn1.FieldName = "comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 81
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Company Name"
        Me.GridColumn15.FieldName = "comp_name"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        Me.GridColumn15.Width = 85
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Contact Name"
        Me.GridColumn2.FieldName = "contact_person"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 78
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Position"
        Me.GridColumn3.FieldName = "position"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Email"
        Me.GridColumn4.FieldName = "email"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Type"
        Me.GridColumn5.FieldName = "report_mark_type_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Member Type"
        Me.GridColumn6.FieldName = "mail_member_type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 6
        '
        'XtraTabControl
        '
        Me.XtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl.Name = "XtraTabControl"
        Me.XtraTabControl.SelectedTabPage = Me.XTPStoreGroup
        Me.XtraTabControl.Size = New System.Drawing.Size(1008, 729)
        Me.XtraTabControl.TabIndex = 1
        Me.XtraTabControl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPStoreGroup, Me.XTPInternal, Me.XTP3PL})
        '
        'XTPStoreGroup
        '
        Me.XTPStoreGroup.Controls.Add(Me.GCListStoreGroup)
        Me.XTPStoreGroup.Name = "XTPStoreGroup"
        Me.XTPStoreGroup.Size = New System.Drawing.Size(1002, 701)
        Me.XTPStoreGroup.Text = "Store Group"
        '
        'XTPInternal
        '
        Me.XTPInternal.Controls.Add(Me.GCListInternal)
        Me.XTPInternal.Name = "XTPInternal"
        Me.XTPInternal.Size = New System.Drawing.Size(1002, 701)
        Me.XTPInternal.Text = "Internal"
        '
        'GCListInternal
        '
        Me.GCListInternal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListInternal.Location = New System.Drawing.Point(0, 0)
        Me.GCListInternal.MainView = Me.GVListInternal
        Me.GCListInternal.Name = "GCListInternal"
        Me.GCListInternal.Size = New System.Drawing.Size(1002, 701)
        Me.GCListInternal.TabIndex = 1
        Me.GCListInternal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListInternal})
        '
        'GVListInternal
        '
        Me.GVListInternal.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn7, Me.GridColumn10, Me.GridColumn9, Me.GridColumn8, Me.GridColumn11, Me.GridColumn12})
        Me.GVListInternal.GridControl = Me.GCListInternal
        Me.GVListInternal.GroupCount = 1
        Me.GVListInternal.Name = "GVListInternal"
        Me.GVListInternal.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVListInternal.OptionsBehavior.Editable = False
        Me.GVListInternal.OptionsFind.AlwaysVisible = True
        Me.GVListInternal.OptionsView.ColumnAutoWidth = False
        Me.GVListInternal.OptionsView.ShowGroupPanel = False
        Me.GVListInternal.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn7, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "GridColumn14"
        Me.GridColumn14.FieldName = "id_mail_manage_mapping_intern"
        Me.GridColumn14.Name = "GridColumn14"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Name"
        Me.GridColumn7.FieldName = "employee_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Store Group"
        Me.GridColumn10.FieldName = "comp_group"
        Me.GridColumn10.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Position"
        Me.GridColumn9.FieldName = "employee_position"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Email"
        Me.GridColumn8.FieldName = "email_external"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 78
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Type"
        Me.GridColumn11.FieldName = "report_mark_type_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Member Type"
        Me.GridColumn12.FieldName = "mail_member_type"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        '
        'XTP3PL
        '
        Me.XTP3PL.Controls.Add(Me.GC3PL)
        Me.XTP3PL.Name = "XTP3PL"
        Me.XTP3PL.Size = New System.Drawing.Size(1002, 701)
        Me.XTP3PL.Text = "3PL"
        '
        'GC3PL
        '
        Me.GC3PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC3PL.Location = New System.Drawing.Point(0, 0)
        Me.GC3PL.MainView = Me.GV3PL
        Me.GC3PL.Name = "GC3PL"
        Me.GC3PL.Size = New System.Drawing.Size(1002, 701)
        Me.GC3PL.TabIndex = 2
        Me.GC3PL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV3PL})
        '
        'GV3PL
        '
        Me.GV3PL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn18, Me.GridColumn17, Me.GridColumn19, Me.GridColumn20, Me.GridColumn22})
        Me.GV3PL.GridControl = Me.GC3PL
        Me.GV3PL.Name = "GV3PL"
        Me.GV3PL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GV3PL.OptionsBehavior.Editable = False
        Me.GV3PL.OptionsFind.AlwaysVisible = True
        Me.GV3PL.OptionsView.ColumnAutoWidth = False
        Me.GV3PL.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "GridColumn14"
        Me.GridColumn16.FieldName = "id_comp"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "3PL"
        Me.GridColumn18.FieldName = "comp_name"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 0
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Name"
        Me.GridColumn17.FieldName = "contact_person"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Position"
        Me.GridColumn19.FieldName = "position"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Email"
        Me.GridColumn20.FieldName = "email"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 2
        Me.GridColumn20.Width = 78
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Member Type"
        Me.GridColumn22.FieldName = "mail_member_type"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 3
        '
        'FormCompanyEmailMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.XtraTabControl)
        Me.Name = "FormCompanyEmailMapping"
        Me.Text = "Email Mapping"
        CType(Me.GCListStoreGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListStoreGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl.ResumeLayout(False)
        Me.XTPStoreGroup.ResumeLayout(False)
        Me.XTPInternal.ResumeLayout(False)
        CType(Me.GCListInternal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListInternal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTP3PL.ResumeLayout(False)
        CType(Me.GC3PL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV3PL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCListStoreGroup As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListStoreGroup As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPStoreGroup As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInternal As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListInternal As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListInternal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTP3PL As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GC3PL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV3PL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
End Class
