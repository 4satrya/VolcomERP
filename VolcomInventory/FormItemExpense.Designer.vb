<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemExpense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemExpense))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReortStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPaidStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBeneficiary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.DEBBKTo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.DEBBKFrom = New DevExpress.XtraEditors.DateEdit()
        Me.BViewPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBankWithdrawal = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.DEBBKTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 46)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCData.Size = New System.Drawing.Size(783, 507)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnReortStt, Me.GridColumnPaidStt, Me.GridColumnBal, Me.GridColumntotal, Me.GridColumnIdComp, Me.GridColumnBeneficiary})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_item_expense"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 2
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created by"
        Me.GridColumnCreatedByName.FieldName = "created_by_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 3
        '
        'GridColumnReortStt
        '
        Me.GridColumnReortStt.Caption = "Approval Status"
        Me.GridColumnReortStt.FieldName = "report_status"
        Me.GridColumnReortStt.Name = "GridColumnReortStt"
        Me.GridColumnReortStt.Visible = True
        Me.GridColumnReortStt.VisibleIndex = 4
        '
        'GridColumnPaidStt
        '
        Me.GridColumnPaidStt.Caption = "Payment Status"
        Me.GridColumnPaidStt.FieldName = "paid_status"
        Me.GridColumnPaidStt.Name = "GridColumnPaidStt"
        Me.GridColumnPaidStt.Visible = True
        Me.GridColumnPaidStt.VisibleIndex = 5
        '
        'GridColumnBal
        '
        Me.GridColumnBal.Caption = "Balance Due"
        Me.GridColumnBal.DisplayFormat.FormatString = "N2"
        Me.GridColumnBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBal.FieldName = "balance"
        Me.GridColumnBal.Name = "GridColumnBal"
        Me.GridColumnBal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", "{0:N2}")})
        Me.GridColumnBal.Visible = True
        Me.GridColumnBal.VisibleIndex = 6
        '
        'GridColumntotal
        '
        Me.GridColumntotal.Caption = "Total"
        Me.GridColumntotal.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "total"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumntotal.Visible = True
        Me.GridColumntotal.VisibleIndex = 7
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnBeneficiary
        '
        Me.GridColumnBeneficiary.Caption = "Vendor"
        Me.GridColumnBeneficiary.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnBeneficiary.FieldName = "comp"
        Me.GridColumnBeneficiary.Name = "GridColumnBeneficiary"
        Me.GridColumnBeneficiary.Visible = True
        Me.GridColumnBeneficiary.VisibleIndex = 1
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.DEBBKTo)
        Me.PanelControlNav.Controls.Add(Me.LabelControl19)
        Me.PanelControlNav.Controls.Add(Me.LabelControl18)
        Me.PanelControlNav.Controls.Add(Me.DEBBKFrom)
        Me.PanelControlNav.Controls.Add(Me.BViewPayment)
        Me.PanelControlNav.Controls.Add(Me.BtnBankWithdrawal)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(783, 46)
        Me.PanelControlNav.TabIndex = 1
        '
        'DEBBKTo
        '
        Me.DEBBKTo.EditValue = Nothing
        Me.DEBBKTo.Location = New System.Drawing.Point(224, 13)
        Me.DEBBKTo.Name = "DEBBKTo"
        Me.DEBBKTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEBBKTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEBBKTo.Size = New System.Drawing.Size(158, 20)
        Me.DEBBKTo.TabIndex = 8930
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(206, 16)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl19.TabIndex = 8929
        Me.LabelControl19.Text = "To"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl18.TabIndex = 8928
        Me.LabelControl18.Text = "From"
        '
        'DEBBKFrom
        '
        Me.DEBBKFrom.EditValue = Nothing
        Me.DEBBKFrom.Location = New System.Drawing.Point(42, 13)
        Me.DEBBKFrom.Name = "DEBBKFrom"
        Me.DEBBKFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEBBKFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEBBKFrom.Size = New System.Drawing.Size(158, 20)
        Me.DEBBKFrom.TabIndex = 8927
        '
        'BViewPayment
        '
        Me.BViewPayment.Location = New System.Drawing.Point(388, 11)
        Me.BViewPayment.Name = "BViewPayment"
        Me.BViewPayment.Size = New System.Drawing.Size(60, 23)
        Me.BViewPayment.TabIndex = 8926
        Me.BViewPayment.Text = "view"
        '
        'BtnBankWithdrawal
        '
        Me.BtnBankWithdrawal.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBankWithdrawal.Image = CType(resources.GetObject("BtnBankWithdrawal.Image"), System.Drawing.Image)
        Me.BtnBankWithdrawal.Location = New System.Drawing.Point(651, 2)
        Me.BtnBankWithdrawal.Name = "BtnBankWithdrawal"
        Me.BtnBankWithdrawal.Size = New System.Drawing.Size(130, 42)
        Me.BtnBankWithdrawal.TabIndex = 0
        Me.BtnBankWithdrawal.Text = "Bank Withdrawal"
        '
        'FormItemExpense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 553)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNav)
        Me.Name = "FormItemExpense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expense"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.DEBBKTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReortStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPaidStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBeneficiary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnBankWithdrawal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEBBKTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEBBKFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BViewPayment As DevExpress.XtraEditors.SimpleButton
End Class
