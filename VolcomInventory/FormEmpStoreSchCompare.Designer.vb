﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpStoreSchCompare
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
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BPrintSum = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilSum = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DEStartSum = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BViewSum = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPlan = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleTable = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleTable = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPCurrent = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleAfter = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleAfter = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSum.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartSum.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPlan.SuspendLayout()
        CType(Me.GCScheduleTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPCurrent.SuspendLayout()
        CType(Me.GCScheduleAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LEDeptSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BPrintSum)
        Me.PanelControl1.Controls.Add(Me.DEUntilSum)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.DEStartSum)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.BViewSum)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(822, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(478, 12)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(151, 20)
        Me.LEDeptSum.TabIndex = 22
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(409, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Departement"
        '
        'BPrintSum
        '
        Me.BPrintSum.Location = New System.Drawing.Point(727, 9)
        Me.BPrintSum.Name = "BPrintSum"
        Me.BPrintSum.Size = New System.Drawing.Size(86, 25)
        Me.BPrintSum.TabIndex = 20
        Me.BPrintSum.Text = "print"
        '
        'DEUntilSum
        '
        Me.DEUntilSum.EditValue = Nothing
        Me.DEUntilSum.Location = New System.Drawing.Point(276, 12)
        Me.DEUntilSum.Name = "DEUntilSum"
        Me.DEUntilSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSum.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSum.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilSum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilSum.Size = New System.Drawing.Size(127, 20)
        Me.DEUntilSum.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(232, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Until : "
        '
        'DEStartSum
        '
        Me.DEStartSum.EditValue = Nothing
        Me.DEStartSum.Location = New System.Drawing.Point(112, 12)
        Me.DEStartSum.Name = "DEStartSum"
        Me.DEStartSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartSum.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartSum.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStartSum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStartSum.Size = New System.Drawing.Size(114, 20)
        Me.DEStartSum.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Attendance from : "
        '
        'BViewSum
        '
        Me.BViewSum.Location = New System.Drawing.Point(635, 9)
        Me.BViewSum.Name = "BViewSum"
        Me.BViewSum.Size = New System.Drawing.Size(86, 25)
        Me.BViewSum.TabIndex = 15
        Me.BViewSum.Text = "view"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 42)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPlan
        Me.XtraTabControl1.Size = New System.Drawing.Size(822, 226)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPlan, Me.XTPCurrent})
        '
        'XTPPlan
        '
        Me.XTPPlan.Controls.Add(Me.GCScheduleTable)
        Me.XTPPlan.Name = "XTPPlan"
        Me.XTPPlan.Size = New System.Drawing.Size(816, 198)
        Me.XTPPlan.Text = "Planning"
        '
        'GCScheduleTable
        '
        Me.GCScheduleTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleTable.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleTable.MainView = Me.GVScheduleTable
        Me.GCScheduleTable.Name = "GCScheduleTable"
        Me.GCScheduleTable.Size = New System.Drawing.Size(816, 198)
        Me.GCScheduleTable.TabIndex = 5
        Me.GCScheduleTable.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScheduleTable})
        '
        'GVScheduleTable
        '
        Me.GVScheduleTable.GridControl = Me.GCScheduleTable
        Me.GVScheduleTable.Name = "GVScheduleTable"
        Me.GVScheduleTable.OptionsView.ColumnAutoWidth = False
        Me.GVScheduleTable.OptionsView.ShowGroupPanel = False
        '
        'XTPCurrent
        '
        Me.XTPCurrent.Controls.Add(Me.GCScheduleAfter)
        Me.XTPCurrent.Name = "XTPCurrent"
        Me.XTPCurrent.Size = New System.Drawing.Size(816, 198)
        Me.XTPCurrent.Text = "Current"
        '
        'GCScheduleAfter
        '
        Me.GCScheduleAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleAfter.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleAfter.MainView = Me.GVScheduleAfter
        Me.GCScheduleAfter.Name = "GCScheduleAfter"
        Me.GCScheduleAfter.Size = New System.Drawing.Size(816, 198)
        Me.GCScheduleAfter.TabIndex = 5
        Me.GCScheduleAfter.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScheduleAfter})
        '
        'GVScheduleAfter
        '
        Me.GVScheduleAfter.GridControl = Me.GCScheduleAfter
        Me.GVScheduleAfter.Name = "GVScheduleAfter"
        Me.GVScheduleAfter.OptionsView.ColumnAutoWidth = False
        Me.GVScheduleAfter.OptionsView.ShowGroupPanel = False
        '
        'FormEmpStoreSchCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 268)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpStoreSchCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Compare Schedule"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSum.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartSum.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPlan.ResumeLayout(False)
        CType(Me.GCScheduleTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPCurrent.ResumeLayout(False)
        CType(Me.GCScheduleAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleAfter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPlan As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPCurrent As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPrintSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilSum As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents DEStartSum As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents BViewSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCScheduleTable As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleTable As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCScheduleAfter As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleAfter As DevExpress.XtraGrid.Views.Grid.GridView
End Class
