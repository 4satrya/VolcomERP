﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayroll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayroll))
        Me.XTCPayroll = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriode = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayrollPeriode = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollPeriode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPSalaryFormat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BOvertime = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPayroll.SuspendLayout()
        Me.XTPPeriode.SuspendLayout()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalaryFormat.SuspendLayout()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPayroll
        '
        Me.XTCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPayroll.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPayroll.Location = New System.Drawing.Point(0, 0)
        Me.XTCPayroll.Name = "XTCPayroll"
        Me.XTCPayroll.SelectedTabPage = Me.XTPPeriode
        Me.XTCPayroll.Size = New System.Drawing.Size(1121, 469)
        Me.XTCPayroll.TabIndex = 0
        Me.XTCPayroll.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriode, Me.XTPSalaryFormat})
        '
        'XTPPeriode
        '
        Me.XTPPeriode.Controls.Add(Me.GCPayrollPeriode)
        Me.XTPPeriode.Name = "XTPPeriode"
        Me.XTPPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.XTPPeriode.Text = "Periode"
        '
        'GCPayrollPeriode
        '
        Me.GCPayrollPeriode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayrollPeriode.Location = New System.Drawing.Point(0, 0)
        Me.GCPayrollPeriode.MainView = Me.GVPayrollPeriode
        Me.GCPayrollPeriode.Name = "GCPayrollPeriode"
        Me.GCPayrollPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.GCPayrollPeriode.TabIndex = 0
        Me.GCPayrollPeriode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollPeriode})
        '
        'GVPayrollPeriode
        '
        Me.GVPayrollPeriode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnPStart, Me.GridColumnPEnd, Me.GridColumnLastUpd, Me.GridColumnLastUpdBy, Me.GridColumnNote})
        Me.GVPayrollPeriode.GridControl = Me.GCPayrollPeriode
        Me.GVPayrollPeriode.Name = "GVPayrollPeriode"
        Me.GVPayrollPeriode.OptionsBehavior.ReadOnly = True
        Me.GVPayrollPeriode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_payroll"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnPStart
        '
        Me.GridColumnPStart.Caption = "Periode Start"
        Me.GridColumnPStart.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPStart.FieldName = "periode_start"
        Me.GridColumnPStart.Name = "GridColumnPStart"
        Me.GridColumnPStart.Visible = True
        Me.GridColumnPStart.VisibleIndex = 0
        Me.GridColumnPStart.Width = 160
        '
        'GridColumnPEnd
        '
        Me.GridColumnPEnd.Caption = "Periode End"
        Me.GridColumnPEnd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPEnd.FieldName = "periode_end"
        Me.GridColumnPEnd.Name = "GridColumnPEnd"
        Me.GridColumnPEnd.Visible = True
        Me.GridColumnPEnd.VisibleIndex = 1
        Me.GridColumnPEnd.Width = 136
        '
        'GridColumnLastUpd
        '
        Me.GridColumnLastUpd.Caption = "Last Update"
        Me.GridColumnLastUpd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnLastUpd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpd.FieldName = "employee_name"
        Me.GridColumnLastUpd.Name = "GridColumnLastUpd"
        Me.GridColumnLastUpd.Visible = True
        Me.GridColumnLastUpd.VisibleIndex = 2
        Me.GridColumnLastUpd.Width = 199
        '
        'GridColumnLastUpdBy
        '
        Me.GridColumnLastUpdBy.Caption = "Last Update By"
        Me.GridColumnLastUpdBy.FieldName = "employee_name"
        Me.GridColumnLastUpdBy.Name = "GridColumnLastUpdBy"
        Me.GridColumnLastUpdBy.Visible = True
        Me.GridColumnLastUpdBy.VisibleIndex = 3
        Me.GridColumnLastUpdBy.Width = 162
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 4
        Me.GridColumnNote.Width = 440
        '
        'XTPSalaryFormat
        '
        Me.XTPSalaryFormat.Controls.Add(Me.GCPayroll)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl1)
        Me.XTPSalaryFormat.Name = "XTPSalaryFormat"
        Me.XTPSalaryFormat.Size = New System.Drawing.Size(1115, 441)
        Me.XTPSalaryFormat.Text = "Worksheet"
        '
        'GCPayroll
        '
        Me.GCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.Size = New System.Drawing.Size(1115, 402)
        Me.GCPayroll.TabIndex = 1
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'GVPayroll
        '
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton3)
        Me.PanelControl1.Controls.Add(Me.BOvertime)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1115, 39)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton3.ImageIndex = 6
        Me.SimpleButton3.ImageList = Me.LargeImageCollection
        Me.SimpleButton3.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(86, 35)
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Print"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'BOvertime
        '
        Me.BOvertime.Dock = System.Windows.Forms.DockStyle.Right
        Me.BOvertime.ImageIndex = 18
        Me.BOvertime.ImageList = Me.LargeImageCollection
        Me.BOvertime.Location = New System.Drawing.Point(909, 2)
        Me.BOvertime.Name = "BOvertime"
        Me.BOvertime.Size = New System.Drawing.Size(101, 35)
        Me.BOvertime.TabIndex = 1
        Me.BOvertime.Text = "Overtime"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageIndex = 17
        Me.SimpleButton1.ImageList = Me.LargeImageCollection
        Me.SimpleButton1.Location = New System.Drawing.Point(1010, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(103, 35)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Setting"
        '
        'FormEmpPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 469)
        Me.Controls.Add(Me.XTCPayroll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll Worksheet"
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPayroll.ResumeLayout(False)
        Me.XTPPeriode.ResumeLayout(False)
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalaryFormat.ResumeLayout(False)
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPayroll As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalaryFormat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPayrollPeriode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollPeriode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BOvertime As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPayroll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayroll As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
End Class
