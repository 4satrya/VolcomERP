﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpHoliday
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEReligion = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdReligionSLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReligionSLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEYear = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.GCHoliday = New DevExpress.XtraGrid.GridControl()
        Me.GVHoliday = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdHoliday = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReligion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReligion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.XTCHoliday = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPView = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEReligion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCHoliday.SuspendLayout()
        Me.XTPList.SuspendLayout()
        Me.XTPView.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BImport)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.SLEReligion)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEYear)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(728, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BImport
        '
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BImport.Location = New System.Drawing.Point(631, 2)
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(95, 43)
        Me.BImport.TabIndex = 8906
        Me.BImport.Text = "Import Excel"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(444, 10)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8904
        Me.BSearch.Text = "View"
        '
        'SLEReligion
        '
        Me.SLEReligion.Location = New System.Drawing.Point(272, 12)
        Me.SLEReligion.Name = "SLEReligion"
        Me.SLEReligion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEReligion.Properties.View = Me.GridView1
        Me.SLEReligion.Size = New System.Drawing.Size(166, 20)
        Me.SLEReligion.TabIndex = 8900
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReligionSLE, Me.GridColumnReligionSLE})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdReligionSLE
        '
        Me.GridColumnIdReligionSLE.Caption = "Id Religion"
        Me.GridColumnIdReligionSLE.FieldName = "id_religion"
        Me.GridColumnIdReligionSLE.Name = "GridColumnIdReligionSLE"
        '
        'GridColumnReligionSLE
        '
        Me.GridColumnReligionSLE.Caption = "Religion"
        Me.GridColumnReligionSLE.FieldName = "religion"
        Me.GridColumnReligionSLE.Name = "GridColumnReligionSLE"
        Me.GridColumnReligionSLE.Visible = True
        Me.GridColumnReligionSLE.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(229, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 8899
        Me.LabelControl1.Text = "Religion"
        '
        'SLEYear
        '
        Me.SLEYear.Location = New System.Drawing.Point(52, 12)
        Me.SLEYear.Name = "SLEYear"
        Me.SLEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYear.Properties.View = Me.GVSLEDesgSearch
        Me.SLEYear.Size = New System.Drawing.Size(166, 20)
        Me.SLEYear.TabIndex = 8898
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnYear})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "Year"
        Me.GridColumnYear.FieldName = "year"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.Visible = True
        Me.GridColumnYear.VisibleIndex = 0
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl9.TabIndex = 8897
        Me.LabelControl9.Text = "Year"
        '
        'GCHoliday
        '
        Me.GCHoliday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHoliday.Location = New System.Drawing.Point(0, 0)
        Me.GCHoliday.MainView = Me.GVHoliday
        Me.GCHoliday.Name = "GCHoliday"
        Me.GCHoliday.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit})
        Me.GCHoliday.Size = New System.Drawing.Size(722, 251)
        Me.GCHoliday.TabIndex = 3
        Me.GCHoliday.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHoliday})
        '
        'GVHoliday
        '
        Me.GVHoliday.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdHoliday, Me.GridColumnIdReligion, Me.GridColumnReligion, Me.GridColumnDate, Me.GridColumnDesc})
        Me.GVHoliday.GridControl = Me.GCHoliday
        Me.GVHoliday.Name = "GVHoliday"
        Me.GVHoliday.OptionsBehavior.Editable = False
        Me.GVHoliday.OptionsFind.AlwaysVisible = True
        Me.GVHoliday.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdHoliday
        '
        Me.GridColumnIdHoliday.Caption = "Id Holiday"
        Me.GridColumnIdHoliday.FieldName = "id_emp_holiday"
        Me.GridColumnIdHoliday.Name = "GridColumnIdHoliday"
        '
        'GridColumnIdReligion
        '
        Me.GridColumnIdReligion.Caption = "Id Religion"
        Me.GridColumnIdReligion.Name = "GridColumnIdReligion"
        '
        'GridColumnReligion
        '
        Me.GridColumnReligion.Caption = "Religion"
        Me.GridColumnReligion.FieldName = "religion"
        Me.GridColumnReligion.Name = "GridColumnReligion"
        Me.GridColumnReligion.Visible = True
        Me.GridColumnReligion.VisibleIndex = 1
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Holiday Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "emp_holiday_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 0
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Holiday"
        Me.GridColumnDesc.FieldName = "emp_holiday_desc"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 2
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'XTCHoliday
        '
        Me.XTCHoliday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCHoliday.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCHoliday.Location = New System.Drawing.Point(0, 47)
        Me.XTCHoliday.Name = "XTCHoliday"
        Me.XTCHoliday.SelectedTabPage = Me.XTPList
        Me.XTCHoliday.Size = New System.Drawing.Size(728, 279)
        Me.XTCHoliday.TabIndex = 4
        Me.XTCHoliday.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPView})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCHoliday)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(722, 251)
        Me.XTPList.Text = "List"
        '
        'XTPView
        '
        Me.XTPView.Controls.Add(Me.GridControl1)
        Me.XTPView.Name = "XTPView"
        Me.XTPView.Size = New System.Drawing.Size(722, 251)
        Me.XTPView.Text = "View"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPictureEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(722, 251)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Month"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.FieldName = "hol_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Hindu"
        Me.GridColumn3.FieldName = "hindu"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Islam"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Kristen"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Budha"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "*"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'FormEmpHoliday
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 326)
        Me.Controls.Add(Me.XTCHoliday)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpHoliday"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Holiday List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEReligion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCHoliday.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        Me.XTPView.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEYear As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEReligion As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCHoliday As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHoliday As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GridColumnIdHoliday As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReligion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReligion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReligionSLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReligionSLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCHoliday As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
End Class
