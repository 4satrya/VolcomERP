<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutZalora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutZalora))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSycn = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_payout_zalora = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstatement_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_payout = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_confirm_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnSycn)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(662, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(464, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(81, 42)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        '
        'BtnSycn
        '
        Me.BtnSycn.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSycn.Image = CType(resources.GetObject("BtnSycn.Image"), System.Drawing.Image)
        Me.BtnSycn.Location = New System.Drawing.Point(545, 2)
        Me.BtnSycn.Name = "BtnSycn"
        Me.BtnSycn.Size = New System.Drawing.Size(115, 42)
        Me.BtnSycn.TabIndex = 1
        Me.BtnSycn.Text = "Sync Payout"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 46)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(662, 330)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_payout_zalora, Me.GridColumnstatement_number, Me.GridColumn1, Me.GridColumnsync_date, Me.GridColumntotal_payout, Me.GridColumnis_confirm_view, Me.GridColumnreport_status})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_payout_zalora
        '
        Me.GridColumnid_payout_zalora.Caption = "id_payout_zalora"
        Me.GridColumnid_payout_zalora.FieldName = "id_payout_zalora"
        Me.GridColumnid_payout_zalora.Name = "GridColumnid_payout_zalora"
        '
        'GridColumnstatement_number
        '
        Me.GridColumnstatement_number.Caption = "Number"
        Me.GridColumnstatement_number.FieldName = "statement_number"
        Me.GridColumnstatement_number.Name = "GridColumnstatement_number"
        Me.GridColumnstatement_number.Visible = True
        Me.GridColumnstatement_number.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created At"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "zalora_created_at"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumnsync_date
        '
        Me.GridColumnsync_date.Caption = "Sync Date"
        Me.GridColumnsync_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsync_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsync_date.FieldName = "sync_date"
        Me.GridColumnsync_date.Name = "GridColumnsync_date"
        Me.GridColumnsync_date.Visible = True
        Me.GridColumnsync_date.VisibleIndex = 2
        '
        'GridColumntotal_payout
        '
        Me.GridColumntotal_payout.Caption = "Total Payout"
        Me.GridColumntotal_payout.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal_payout.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_payout.FieldName = "total_payout"
        Me.GridColumntotal_payout.Name = "GridColumntotal_payout"
        Me.GridColumntotal_payout.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_payout", "{0:N2}")})
        Me.GridColumntotal_payout.Visible = True
        Me.GridColumntotal_payout.VisibleIndex = 3
        '
        'GridColumnis_confirm_view
        '
        Me.GridColumnis_confirm_view.Caption = "Verify Status"
        Me.GridColumnis_confirm_view.FieldName = "is_confirm_view"
        Me.GridColumnis_confirm_view.Name = "GridColumnis_confirm_view"
        Me.GridColumnis_confirm_view.Visible = True
        Me.GridColumnis_confirm_view.VisibleIndex = 4
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Propose Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 5
        '
        'FormPayoutZalora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 376)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPayoutZalora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zalora Payout List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSycn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_payout_zalora As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstatement_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_payout As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_confirm_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
End Class
