<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWorkQuick
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
        Me.PCQuick = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.BRefuse = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMarkNeed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedIdReportType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedReportType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkIdReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedReportNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedIdStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedCan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkNeedReportDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRawLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTimeMiss = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn329 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn894 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn895 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.VolcomMRP.WaitForm), True, True)
        CType(Me.PCQuick, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCQuick.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCQuick
        '
        Me.PCQuick.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCQuick.Controls.Add(Me.PanelControl1)
        Me.PCQuick.Controls.Add(Me.BAccept)
        Me.PCQuick.Controls.Add(Me.BRefuse)
        Me.PCQuick.Controls.Add(Me.SimpleButton1)
        Me.PCQuick.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCQuick.Location = New System.Drawing.Point(0, 526)
        Me.PCQuick.Name = "PCQuick"
        Me.PCQuick.Size = New System.Drawing.Size(784, 36)
        Me.PCQuick.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.CheckEdit1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(584, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(0, 7, 3, 0)
        Me.PanelControl1.Size = New System.Drawing.Size(200, 36)
        Me.PanelControl1.TabIndex = 142
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckEdit1.Location = New System.Drawing.Point(129, 7)
        Me.CheckEdit1.Margin = New System.Windows.Forms.Padding(10)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Select All"
        Me.CheckEdit1.Size = New System.Drawing.Size(68, 19)
        Me.CheckEdit1.TabIndex = 141
        '
        'BAccept
        '
        Me.BAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BAccept.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BAccept.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAccept.Appearance.Options.UseBackColor = True
        Me.BAccept.Appearance.Options.UseFont = True
        Me.BAccept.Appearance.Options.UseForeColor = True
        Me.BAccept.Dock = System.Windows.Forms.DockStyle.Left
        Me.BAccept.Location = New System.Drawing.Point(204, 0)
        Me.BAccept.LookAndFeel.SkinName = "Metropolis"
        Me.BAccept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BAccept.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(93, 36)
        Me.BAccept.TabIndex = 137
        Me.BAccept.Text = "Approve"
        '
        'BRefuse
        '
        Me.BRefuse.Appearance.BackColor = System.Drawing.Color.Red
        Me.BRefuse.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BRefuse.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefuse.Appearance.Options.UseBackColor = True
        Me.BRefuse.Appearance.Options.UseFont = True
        Me.BRefuse.Appearance.Options.UseForeColor = True
        Me.BRefuse.Dock = System.Windows.Forms.DockStyle.Left
        Me.BRefuse.Location = New System.Drawing.Point(101, 0)
        Me.BRefuse.LookAndFeel.SkinMaskColor = System.Drawing.Color.DarkRed
        Me.BRefuse.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black
        Me.BRefuse.LookAndFeel.SkinName = "Metropolis"
        Me.BRefuse.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BRefuse.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRefuse.Name = "BRefuse"
        Me.BRefuse.Size = New System.Drawing.Size(103, 36)
        Me.BRefuse.TabIndex = 139
        Me.BRefuse.Text = "Not Approve"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 0)
        Me.SimpleButton1.LookAndFeel.SkinName = "Metropolis"
        Me.SimpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(101, 36)
        Me.SimpleButton1.TabIndex = 140
        Me.SimpleButton1.Text = "Refresh Data"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMarkNeed, Me.ColMarkNeedIdReportType, Me.ColMarkNeedReportType, Me.ColMarkIdReport, Me.ColMarkNeedReportNumber, Me.GridColumnQty, Me.ColMarkNeedIdStatus, Me.ColMarkNeedStatus, Me.ColMarkNeedCan, Me.ColMarkNeedReportDate, Me.ColLeadTime, Me.ColRawLeadTime, Me.GridColumnTimeMiss, Me.GridColumn329, Me.GridColumn894, Me.GridColumn895, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnSelect})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:n0}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'ColIdMarkNeed
        '
        Me.ColIdMarkNeed.Caption = "Id Mark"
        Me.ColIdMarkNeed.FieldName = "id_report_mark"
        Me.ColIdMarkNeed.Name = "ColIdMarkNeed"
        Me.ColIdMarkNeed.OptionsColumn.AllowEdit = False
        '
        'ColMarkNeedIdReportType
        '
        Me.ColMarkNeedIdReportType.Caption = "Id Report Type"
        Me.ColMarkNeedIdReportType.FieldName = "report_mark_type"
        Me.ColMarkNeedIdReportType.Name = "ColMarkNeedIdReportType"
        Me.ColMarkNeedIdReportType.OptionsColumn.AllowEdit = False
        Me.ColMarkNeedIdReportType.Width = 50
        '
        'ColMarkNeedReportType
        '
        Me.ColMarkNeedReportType.Caption = "Type"
        Me.ColMarkNeedReportType.FieldName = "report_mark_type_name"
        Me.ColMarkNeedReportType.Name = "ColMarkNeedReportType"
        Me.ColMarkNeedReportType.OptionsColumn.AllowEdit = False
        Me.ColMarkNeedReportType.Visible = True
        Me.ColMarkNeedReportType.VisibleIndex = 0
        Me.ColMarkNeedReportType.Width = 109
        '
        'ColMarkIdReport
        '
        Me.ColMarkIdReport.Caption = "Id Report"
        Me.ColMarkIdReport.FieldName = "id_report"
        Me.ColMarkIdReport.Name = "ColMarkIdReport"
        Me.ColMarkIdReport.OptionsColumn.AllowEdit = False
        '
        'ColMarkNeedReportNumber
        '
        Me.ColMarkNeedReportNumber.Caption = "Number"
        Me.ColMarkNeedReportNumber.FieldName = "report_number"
        Me.ColMarkNeedReportNumber.Name = "ColMarkNeedReportNumber"
        Me.ColMarkNeedReportNumber.OptionsColumn.AllowEdit = False
        Me.ColMarkNeedReportNumber.Visible = True
        Me.ColMarkNeedReportNumber.VisibleIndex = 1
        Me.ColMarkNeedReportNumber.Width = 247
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        Me.GridColumnQty.Width = 47
        '
        'ColMarkNeedIdStatus
        '
        Me.ColMarkNeedIdStatus.Caption = "Id Status"
        Me.ColMarkNeedIdStatus.FieldName = "id_report_status"
        Me.ColMarkNeedIdStatus.Name = "ColMarkNeedIdStatus"
        Me.ColMarkNeedIdStatus.OptionsColumn.AllowEdit = False
        '
        'ColMarkNeedStatus
        '
        Me.ColMarkNeedStatus.Caption = "Need"
        Me.ColMarkNeedStatus.FieldName = "report_status"
        Me.ColMarkNeedStatus.Name = "ColMarkNeedStatus"
        Me.ColMarkNeedStatus.OptionsColumn.AllowEdit = False
        Me.ColMarkNeedStatus.Width = 319
        '
        'ColMarkNeedCan
        '
        Me.ColMarkNeedCan.Caption = "Can Approve"
        Me.ColMarkNeedCan.FieldName = "can_mark"
        Me.ColMarkNeedCan.Name = "ColMarkNeedCan"
        Me.ColMarkNeedCan.OptionsColumn.AllowEdit = False
        '
        'ColMarkNeedReportDate
        '
        Me.ColMarkNeedReportDate.Caption = "Date"
        Me.ColMarkNeedReportDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColMarkNeedReportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColMarkNeedReportDate.FieldName = "report_date"
        Me.ColMarkNeedReportDate.Name = "ColMarkNeedReportDate"
        Me.ColMarkNeedReportDate.OptionsColumn.AllowEdit = False
        Me.ColMarkNeedReportDate.Visible = True
        Me.ColMarkNeedReportDate.VisibleIndex = 5
        Me.ColMarkNeedReportDate.Width = 182
        '
        'ColLeadTime
        '
        Me.ColLeadTime.Caption = "Lead Time"
        Me.ColLeadTime.DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss tt"
        Me.ColLeadTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColLeadTime.FieldName = "lead_time"
        Me.ColLeadTime.Name = "ColLeadTime"
        Me.ColLeadTime.OptionsColumn.AllowEdit = False
        Me.ColLeadTime.Width = 146
        '
        'ColRawLeadTime
        '
        Me.ColRawLeadTime.Caption = "Raw Lead Time"
        Me.ColRawLeadTime.FieldName = "raw_lead_time"
        Me.ColRawLeadTime.Name = "ColRawLeadTime"
        Me.ColRawLeadTime.OptionsColumn.AllowEdit = False
        '
        'GridColumnTimeMiss
        '
        Me.GridColumnTimeMiss.Caption = "TimeMiss"
        Me.GridColumnTimeMiss.FieldName = "time_miss"
        Me.GridColumnTimeMiss.Name = "GridColumnTimeMiss"
        Me.GridColumnTimeMiss.OptionsColumn.AllowEdit = False
        '
        'GridColumn329
        '
        Me.GridColumn329.Caption = "Reff#"
        Me.GridColumn329.FieldName = "info_report"
        Me.GridColumn329.Name = "GridColumn329"
        Me.GridColumn329.OptionsColumn.AllowEdit = False
        '
        'GridColumn894
        '
        Me.GridColumn894.Caption = "Code"
        Me.GridColumn894.FieldName = "info_design_code"
        Me.GridColumn894.Name = "GridColumn894"
        Me.GridColumn894.OptionsColumn.AllowEdit = False
        '
        'GridColumn895
        '
        Me.GridColumn895.Caption = "Description"
        Me.GridColumn895.FieldName = "info_design"
        Me.GridColumn895.Name = "GridColumn895"
        Me.GridColumn895.OptionsColumn.AllowEdit = False
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.OptionsColumn.AllowEdit = False
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 2
        Me.GridColumnFrom.Width = 232
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.OptionsColumn.AllowEdit = False
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 3
        Me.GridColumnTo.Width = 222
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 6
        Me.GridColumnSelect.Width = 36
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.LookAndFeel.SkinName = "Visual Studio 2013 Light"
        Me.GCData.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(784, 472)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.MemoEdit1)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 472)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 54)
        Me.PanelControl2.TabIndex = 3
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MemoEdit1.Location = New System.Drawing.Point(80, 12)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(690, 29)
        Me.MemoEdit1.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Comment"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'FormWorkQuick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PCQuick)
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormWorkQuick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quick Approve"
        CType(Me.PCQuick, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCQuick.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCQuick As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BRefuse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMarkNeed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedIdReportType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedReportType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedReportNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedIdStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedCan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkNeedReportDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRawLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTimeMiss As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn329 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn894 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn895 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class
