<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesTargetPropose
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
        Me.XTCPropose = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNew = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_trg_propose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnyear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPRev = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRev = New DevExpress.XtraGrid.GridControl()
        Me.GVRev = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnUpdatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPropose.SuspendLayout()
        Me.XTPNew.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPRev.SuspendLayout()
        CType(Me.GCRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPropose
        '
        Me.XTCPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPropose.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPropose.Location = New System.Drawing.Point(0, 0)
        Me.XTCPropose.Name = "XTCPropose"
        Me.XTCPropose.SelectedTabPage = Me.XTPNew
        Me.XTCPropose.Size = New System.Drawing.Size(834, 492)
        Me.XTCPropose.TabIndex = 0
        Me.XTCPropose.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNew, Me.XTPRev})
        '
        'XTPNew
        '
        Me.XTPNew.Controls.Add(Me.GCData)
        Me.XTPNew.Name = "XTPNew"
        Me.XTPNew.Size = New System.Drawing.Size(828, 464)
        Me.XTPNew.Text = "Propose New"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(828, 464)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_trg_propose, Me.GridColumnyear, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumnupdated_date, Me.GridColumnnote, Me.GridColumnstt, Me.GridColumnUpdatedByName})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_trg_propose
        '
        Me.GridColumnid_sales_trg_propose.Caption = "Id"
        Me.GridColumnid_sales_trg_propose.FieldName = "id_sales_trg_propose"
        Me.GridColumnid_sales_trg_propose.Name = "GridColumnid_sales_trg_propose"
        '
        'GridColumnyear
        '
        Me.GridColumnyear.Caption = "Year"
        Me.GridColumnyear.FieldName = "year"
        Me.GridColumnyear.Name = "GridColumnyear"
        Me.GridColumnyear.Visible = True
        Me.GridColumnyear.VisibleIndex = 1
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 2
        '
        'GridColumnupdated_date
        '
        Me.GridColumnupdated_date.Caption = "Updated Date"
        Me.GridColumnupdated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnupdated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnupdated_date.FieldName = "updated_date"
        Me.GridColumnupdated_date.Name = "GridColumnupdated_date"
        Me.GridColumnupdated_date.Visible = True
        Me.GridColumnupdated_date.VisibleIndex = 3
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 5
        '
        'GridColumnstt
        '
        Me.GridColumnstt.Caption = "Status"
        Me.GridColumnstt.FieldName = "report_status"
        Me.GridColumnstt.Name = "GridColumnstt"
        Me.GridColumnstt.Visible = True
        Me.GridColumnstt.VisibleIndex = 6
        '
        'XTPRev
        '
        Me.XTPRev.Controls.Add(Me.GCRev)
        Me.XTPRev.Name = "XTPRev"
        Me.XTPRev.Size = New System.Drawing.Size(828, 464)
        Me.XTPRev.Text = "Revision"
        '
        'GCRev
        '
        Me.GCRev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRev.Location = New System.Drawing.Point(0, 0)
        Me.GCRev.MainView = Me.GVRev
        Me.GCRev.Name = "GCRev"
        Me.GCRev.Size = New System.Drawing.Size(828, 464)
        Me.GCRev.TabIndex = 1
        Me.GCRev.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRev})
        '
        'GVRev
        '
        Me.GVRev.GridControl = Me.GCRev
        Me.GVRev.Name = "GVRev"
        Me.GVRev.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRev.OptionsBehavior.Editable = False
        Me.GVRev.OptionsFind.AlwaysVisible = True
        Me.GVRev.OptionsView.ShowGroupPanel = False
        '
        'GridColumnUpdatedByName
        '
        Me.GridColumnUpdatedByName.Caption = "Updated By"
        Me.GridColumnUpdatedByName.FieldName = "updated_by_name"
        Me.GridColumnUpdatedByName.Name = "GridColumnUpdatedByName"
        Me.GridColumnUpdatedByName.Visible = True
        Me.GridColumnUpdatedByName.VisibleIndex = 4
        '
        'FormSalesTargetPropose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 492)
        Me.Controls.Add(Me.XTCPropose)
        Me.Name = "FormSalesTargetPropose"
        Me.Text = "Propose Sales Target"
        CType(Me.XTCPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPropose.ResumeLayout(False)
        Me.XTPNew.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPRev.ResumeLayout(False)
        CType(Me.GCRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPropose As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNew As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRev As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCRev As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRev As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_trg_propose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnyear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUpdatedByName As DevExpress.XtraGrid.Columns.GridColumn
End Class
