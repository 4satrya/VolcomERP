﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpAttn
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
        Me.BGetData = New DevExpress.XtraEditors.SimpleButton()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GCSchedule = New DevExpress.XtraGrid.GridControl()
        Me.GV = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BGetData)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.DEEnd)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.DEStart)
        Me.PanelControl1.Controls.Add(Me.Label16)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(789, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BGetData
        '
        Me.BGetData.Location = New System.Drawing.Point(390, 10)
        Me.BGetData.Name = "BGetData"
        Me.BGetData.Size = New System.Drawing.Size(75, 23)
        Me.BGetData.TabIndex = 111
        Me.BGetData.Text = "Get Data"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(309, 10)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(75, 23)
        Me.BView.TabIndex = 110
        Me.BView.Text = "View"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(187, 12)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(116, 20)
        Me.DEEnd.TabIndex = 109
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(170, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "-"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(48, 12)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(116, 20)
        Me.DEStart.TabIndex = 107
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 13)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Date"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GCSchedule
        '
        Me.GCSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSchedule.Location = New System.Drawing.Point(0, 47)
        Me.GCSchedule.MainView = Me.GV
        Me.GCSchedule.Name = "GCSchedule"
        Me.GCSchedule.Size = New System.Drawing.Size(789, 286)
        Me.GCSchedule.TabIndex = 1
        Me.GCSchedule.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV})
        '
        'GV
        '
        Me.GV.GridControl = Me.GCSchedule
        Me.GV.Name = "GV"
        Me.GV.OptionsView.ShowGroupPanel = False
        '
        'FormEmpAttn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 333)
        Me.Controls.Add(Me.GCSchedule)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpAttn"
        Me.Text = "FormEmpAttn"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCSchedule As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label16 As Label
    Friend WithEvents BGetData As DevExpress.XtraEditors.SimpleButton
End Class
