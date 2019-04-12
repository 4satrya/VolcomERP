<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollOvertime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollOvertime))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LEPayrollPeriode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BOvertimeWindow = New DevExpress.XtraEditors.SimpleButton()
        Me.GCOverTime = New DevExpress.XtraGrid.GridControl()
        Me.GVOverTime = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotHour = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotPoint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOvertime = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDP = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDP = New DevExpress.XtraGrid.GridControl()
        Me.GVDP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIDLeave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPayrollPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPOvertime.SuspendLayout()
        Me.XTPDP.SuspendLayout()
        CType(Me.GCDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Controls.Add(Me.LEPayrollPeriode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BOvertimeWindow)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(913, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 1
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(622, 2)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(98, 36)
        Me.BDelete.TabIndex = 3
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
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.ImageIndex = 2
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(720, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(94, 36)
        Me.BEdit.TabIndex = 2
        Me.BEdit.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(814, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(91, 36)
        Me.BAdd.TabIndex = 1
        Me.BAdd.Text = "Add"
        '
        'LEPayrollPeriode
        '
        Me.LEPayrollPeriode.Location = New System.Drawing.Point(146, 9)
        Me.LEPayrollPeriode.Name = "LEPayrollPeriode"
        Me.LEPayrollPeriode.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPayrollPeriode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEPayrollPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPayrollPeriode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_payroll", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("periode", "Periode"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ot_periode_start", "Periode Start", 20, DevExpress.Utils.FormatType.DateTime, "dd MMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ot_periode_end", "Periode End", 20, DevExpress.Utils.FormatType.DateTime, "dd MMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEPayrollPeriode.Properties.NullText = ""
        Me.LEPayrollPeriode.Properties.ShowFooter = False
        Me.LEPayrollPeriode.Size = New System.Drawing.Size(269, 20)
        Me.LEPayrollPeriode.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(128, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Periode Overtime Payroll : "
        '
        'BOvertimeWindow
        '
        Me.BOvertimeWindow.Dock = System.Windows.Forms.DockStyle.Right
        Me.BOvertimeWindow.ImageIndex = 13
        Me.BOvertimeWindow.ImageList = Me.LargeImageCollection
        Me.BOvertimeWindow.Location = New System.Drawing.Point(761, 2)
        Me.BOvertimeWindow.Name = "BOvertimeWindow"
        Me.BOvertimeWindow.Size = New System.Drawing.Size(150, 36)
        Me.BOvertimeWindow.TabIndex = 5
        Me.BOvertimeWindow.Text = "Based on Attendance"
        '
        'GCOverTime
        '
        Me.GCOverTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOverTime.Location = New System.Drawing.Point(0, 40)
        Me.GCOverTime.MainView = Me.GVOverTime
        Me.GCOverTime.Name = "GCOverTime"
        Me.GCOverTime.Size = New System.Drawing.Size(907, 337)
        Me.GCOverTime.TabIndex = 1
        Me.GCOverTime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOverTime})
        '
        'GVOverTime
        '
        Me.GVOverTime.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn11, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumnTotHour, Me.GridColumnTotPoint})
        Me.GVOverTime.GridControl = Me.GCOverTime
        Me.GVOverTime.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_hour", Me.GridColumnTotHour, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_point", Me.GridColumnTotPoint, "{0:N1}")})
        Me.GVOverTime.Name = "GVOverTime"
        Me.GVOverTime.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVOverTime.OptionsView.ShowFooter = True
        Me.GVOverTime.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_overtime"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id Employee"
        Me.GridColumn2.FieldName = "id_employee"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "NIK"
        Me.GridColumn11.FieldName = "employee_code"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 68
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 124
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Level"
        Me.GridColumn4.FieldName = "employee_level"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 105
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Overtime Start"
        Me.GridColumn5.DisplayFormat.FormatString = "dd MMM yyyy H:mm"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn5.FieldName = "ot_start"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 151
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Overtime End"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMM yyyy H:mm"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "ot_end"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 151
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Is Dayoff"
        Me.GridColumn7.FieldName = "day_off"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        Me.GridColumn7.Width = 60
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Type"
        Me.GridColumn8.FieldName = "ot_type"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 58
        '
        'GridColumnTotHour
        '
        Me.GridColumnTotHour.Caption = "Total Time (hour)"
        Me.GridColumnTotHour.DisplayFormat.FormatString = "N1"
        Me.GridColumnTotHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotHour.FieldName = "total_hour"
        Me.GridColumnTotHour.Name = "GridColumnTotHour"
        Me.GridColumnTotHour.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_hour", "{0:N1}")})
        Me.GridColumnTotHour.Visible = True
        Me.GridColumnTotHour.VisibleIndex = 7
        Me.GridColumnTotHour.Width = 95
        '
        'GridColumnTotPoint
        '
        Me.GridColumnTotPoint.Caption = "Point"
        Me.GridColumnTotPoint.DisplayFormat.FormatString = "N1"
        Me.GridColumnTotPoint.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotPoint.FieldName = "total_point"
        Me.GridColumnTotPoint.Name = "GridColumnTotPoint"
        Me.GridColumnTotPoint.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_point", "{0:N1}")})
        Me.GridColumnTotPoint.Visible = True
        Me.GridColumnTotPoint.VisibleIndex = 8
        Me.GridColumnTotPoint.Width = 77
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 40)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPOvertime
        Me.XtraTabControl1.Size = New System.Drawing.Size(913, 405)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOvertime, Me.XTPDP})
        '
        'XTPOvertime
        '
        Me.XTPOvertime.Controls.Add(Me.GCOverTime)
        Me.XTPOvertime.Controls.Add(Me.PanelControl2)
        Me.XTPOvertime.Name = "XTPOvertime"
        Me.XTPOvertime.Size = New System.Drawing.Size(907, 377)
        Me.XTPOvertime.Text = "Overtime"
        '
        'XTPDP
        '
        Me.XTPDP.Controls.Add(Me.GCDP)
        Me.XTPDP.Name = "XTPDP"
        Me.XTPDP.Size = New System.Drawing.Size(907, 377)
        Me.XTPDP.Text = "DP"
        '
        'GCDP
        '
        Me.GCDP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDP.Location = New System.Drawing.Point(0, 0)
        Me.GCDP.MainView = Me.GVDP
        Me.GCDP.Name = "GCDP"
        Me.GCDP.Size = New System.Drawing.Size(907, 377)
        Me.GCDP.TabIndex = 4
        Me.GCDP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDP})
        '
        'GVDP
        '
        Me.GVDP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDLeave, Me.GridColumn9, Me.GridColumn10, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumnTotHours, Me.GridColumn16, Me.GridColumn17})
        Me.GVDP.GridControl = Me.GCDP
        Me.GVDP.Name = "GVDP"
        Me.GVDP.OptionsBehavior.Editable = False
        Me.GVDP.OptionsFind.AlwaysVisible = True
        Me.GVDP.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDLeave
        '
        Me.GridColumnIDLeave.Caption = "ID DP"
        Me.GridColumnIDLeave.FieldName = "id_emp_dp"
        Me.GridColumnIDLeave.Name = "GridColumnIDLeave"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Number"
        Me.GridColumn9.FieldName = "dp_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 90
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Date Created"
        Me.GridColumn10.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn10.FieldName = "dp_date_created"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        Me.GridColumn10.Width = 96
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Employee"
        Me.GridColumn12.FieldName = "employee_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        Me.GridColumn12.Width = 160
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "NIK"
        Me.GridColumn13.FieldName = "employee_code"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 88
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "DP From"
        Me.GridColumn14.DisplayFormat.FormatString = "dd MMM yyyy H:mm:ss"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn14.FieldName = "start_dp"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 77
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Until"
        Me.GridColumn15.DisplayFormat.FormatString = "dd MMM yyyy H:mm:ss"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn15.FieldName = "end_dp"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 5
        Me.GridColumn15.Width = 66
        '
        'GridColumnTotHours
        '
        Me.GridColumnTotHours.Caption = "Total (hours)"
        Me.GridColumnTotHours.FieldName = "dp_total"
        Me.GridColumnTotHours.Name = "GridColumnTotHours"
        Me.GridColumnTotHours.Visible = True
        Me.GridColumnTotHours.VisibleIndex = 6
        Me.GridColumnTotHours.Width = 73
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Status"
        Me.GridColumn16.FieldName = "report_status"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 7
        Me.GridColumn16.Width = 60
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "ID Report Status"
        Me.GridColumn17.FieldName = "id_report_status"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BDelete)
        Me.PanelControl2.Controls.Add(Me.BEdit)
        Me.PanelControl2.Controls.Add(Me.BAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(907, 40)
        Me.PanelControl2.TabIndex = 2
        '
        'BRefresh
        '
        Me.BRefresh.Location = New System.Drawing.Point(421, 7)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(75, 23)
        Me.BRefresh.TabIndex = 6
        Me.BRefresh.Text = "Refresh"
        '
        'FormEmpPayrollOvertime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 445)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollOvertime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPayrollPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPOvertime.ResumeLayout(False)
        Me.XTPDP.ResumeLayout(False)
        CType(Me.GCDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPayrollPeriode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GCOverTime As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOverTime As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotHour As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotPoint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BOvertimeWindow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOvertime As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIDLeave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
End Class
