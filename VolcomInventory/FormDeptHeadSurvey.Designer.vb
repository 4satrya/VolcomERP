﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDeptHeadSurvey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDeptHeadSurvey))
        Me.TEDeptHead = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDept = New DevExpress.XtraEditors.TextEdit()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQuestion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIUEValue = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GCInformation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIMEInformation = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPForm = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCListPeriod = New DevExpress.XtraGrid.GridControl()
        Me.GVListPeriod = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.TEDeptHead.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIUEValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIMEInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPForm.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCListPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEDeptHead
        '
        Me.TEDeptHead.Location = New System.Drawing.Point(107, 12)
        Me.TEDeptHead.Name = "TEDeptHead"
        Me.TEDeptHead.Properties.ReadOnly = True
        Me.TEDeptHead.Size = New System.Drawing.Size(239, 20)
        Me.TEDeptHead.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(37, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Nama Atasan"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(37, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Departemen"
        '
        'TEDept
        '
        Me.TEDept.Location = New System.Drawing.Point(107, 38)
        Me.TEDept.Name = "TEDept"
        Me.TEDept.Properties.ReadOnly = True
        Me.TEDept.Size = New System.Drawing.Size(239, 20)
        Me.TEDept.TabIndex = 4
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(20, 2)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIUEValue, Me.RIMEInformation})
        Me.GCList.Size = New System.Drawing.Size(814, 329)
        Me.GCList.TabIndex = 5
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCId, Me.GCNo, Me.GCQuestion, Me.GCValue, Me.GCInformation})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsView.ShowColumnHeaders = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.RowHeight = 50
        '
        'GCId
        '
        Me.GCId.FieldName = "id_question_depthead"
        Me.GCId.Name = "GCId"
        '
        'GCNo
        '
        Me.GCNo.FieldName = "no"
        Me.GCNo.Name = "GCNo"
        Me.GCNo.OptionsColumn.AllowEdit = False
        Me.GCNo.Visible = True
        Me.GCNo.VisibleIndex = 0
        '
        'GCQuestion
        '
        Me.GCQuestion.FieldName = "question"
        Me.GCQuestion.Name = "GCQuestion"
        Me.GCQuestion.OptionsColumn.AllowEdit = False
        Me.GCQuestion.Visible = True
        Me.GCQuestion.VisibleIndex = 1
        '
        'GCValue
        '
        Me.GCValue.ColumnEdit = Me.RIUEValue
        Me.GCValue.FieldName = "value"
        Me.GCValue.Name = "GCValue"
        Me.GCValue.Visible = True
        Me.GCValue.VisibleIndex = 2
        '
        'RIUEValue
        '
        Me.RIUEValue.AutoHeight = False
        Me.RIUEValue.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RIUEValue.Name = "RIUEValue"
        '
        'GCInformation
        '
        Me.GCInformation.ColumnEdit = Me.RIMEInformation
        Me.GCInformation.FieldName = "information"
        Me.GCInformation.MinWidth = 500
        Me.GCInformation.Name = "GCInformation"
        Me.GCInformation.Visible = True
        Me.GCInformation.VisibleIndex = 3
        Me.GCInformation.Width = 500
        '
        'RIMEInformation
        '
        Me.RIMEInformation.Name = "RIMEInformation"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.GCList)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 73)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(836, 333)
        Me.GroupControl3.TabIndex = 8
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(747, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(87, 41)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "Save"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(660, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(87, 41)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(573, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 41)
        Me.BtnPrint.TabIndex = 4
        Me.BtnPrint.Text = "Print"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 406)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(836, 45)
        Me.PanelControl1.TabIndex = 6
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.TEDept)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TEDeptHead)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(836, 73)
        Me.GroupControl1.TabIndex = 6
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPForm
        Me.XtraTabControl1.Size = New System.Drawing.Size(842, 479)
        Me.XtraTabControl1.TabIndex = 5
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPForm, Me.XtraTabPage2})
        '
        'XTPForm
        '
        Me.XTPForm.Controls.Add(Me.GroupControl3)
        Me.XTPForm.Controls.Add(Me.GroupControl1)
        Me.XTPForm.Controls.Add(Me.PanelControl1)
        Me.XTPForm.Name = "XTPForm"
        Me.XTPForm.Size = New System.Drawing.Size(836, 451)
        Me.XTPForm.Text = "Formulir Survey Dept Head"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCListPeriod)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(836, 451)
        Me.XtraTabPage2.Text = "Periode Survey Dept Head"
        '
        'GCListPeriod
        '
        Me.GCListPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPeriod.Location = New System.Drawing.Point(0, 0)
        Me.GCListPeriod.MainView = Me.GVListPeriod
        Me.GCListPeriod.Name = "GCListPeriod"
        Me.GCListPeriod.Size = New System.Drawing.Size(836, 451)
        Me.GCListPeriod.TabIndex = 0
        Me.GCListPeriod.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPeriod})
        '
        'GVListPeriod
        '
        Me.GVListPeriod.GridControl = Me.GCListPeriod
        Me.GVListPeriod.Name = "GVListPeriod"
        Me.GVListPeriod.OptionsView.ShowGroupPanel = False
        '
        'FormDeptHeadSurvey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 479)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FormDeptHeadSurvey"
        Me.Text = "Survey Dept Head"
        CType(Me.TEDeptHead.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIUEValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIMEInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPForm.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCListPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TEDeptHead As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDept As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQuestion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIUEValue As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GCInformation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIMEInformation As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPForm As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCListPeriod As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPeriod As DevExpress.XtraGrid.Views.Grid.GridView
End Class
