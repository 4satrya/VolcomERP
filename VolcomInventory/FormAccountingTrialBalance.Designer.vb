﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingTrialBalance
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
        Me.GCAccTrans = New DevExpress.XtraGrid.GridControl()
        Me.GVAccTrans = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BViewJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEToViewJournal = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromViewJournal = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GCAccTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAccTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEToViewJournal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEToViewJournal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromViewJournal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromViewJournal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAccTrans
        '
        Me.GCAccTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAccTrans.Location = New System.Drawing.Point(0, 44)
        Me.GCAccTrans.MainView = Me.GVAccTrans
        Me.GCAccTrans.Name = "GCAccTrans"
        Me.GCAccTrans.TabIndex = 10
        Me.GCAccTrans.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccTrans})
        '
        'GVAccTrans
        '
        Me.GVAccTrans.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn6, Me.GridColumn4, Me.GridColumn2, Me.GridColumn3})
        Me.GVAccTrans.GridControl = Me.GCAccTrans
        Me.GVAccTrans.Name = "GVAccTrans"
        Me.GVAccTrans.OptionsBehavior.Editable = False
        Me.GVAccTrans.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Date"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 101
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Journal Number"
        Me.GridColumn5.FieldName = "number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 87
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Reff"
        Me.GridColumn6.FieldName = "reff"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 80
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 202
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Debit"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "debit"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        Me.GridColumn2.Width = 116
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Credit"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "credit"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 5
        Me.GridColumn3.Width = 106
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BViewJournal)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.DEToViewJournal)
        Me.PanelControl2.Controls.Add(Me.DEFromViewJournal)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.TabIndex = 11
        '
        'BViewJournal
        '
        Me.BViewJournal.Location = New System.Drawing.Point(440, 12)
        Me.BViewJournal.Name = "BViewJournal"
        Me.BViewJournal.Size = New System.Drawing.Size(119, 22)
        Me.BViewJournal.TabIndex = 152
        Me.BViewJournal.Text = "View Ledger"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(225, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl3.TabIndex = 151
        Me.LabelControl3.Text = "to :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl4.TabIndex = 150
        Me.LabelControl4.Text = "From :"
        '
        'DEToViewJournal
        '
        Me.DEToViewJournal.EditValue = Nothing
        Me.DEToViewJournal.Location = New System.Drawing.Point(252, 13)
        Me.DEToViewJournal.Name = "DEToViewJournal"
        Me.DEToViewJournal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEToViewJournal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEToViewJournal.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEToViewJournal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEToViewJournal.Size = New System.Drawing.Size(172, 20)
        Me.DEToViewJournal.TabIndex = 149
        '
        'DEFromViewJournal
        '
        Me.DEFromViewJournal.EditValue = Nothing
        Me.DEFromViewJournal.Location = New System.Drawing.Point(47, 13)
        Me.DEFromViewJournal.Name = "DEFromViewJournal"
        Me.DEFromViewJournal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromViewJournal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromViewJournal.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromViewJournal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromViewJournal.Size = New System.Drawing.Size(172, 20)
        Me.DEFromViewJournal.TabIndex = 148
        '
        'FormAccountingTrialBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GCAccTrans)
        Me.Controls.Add(Me.PanelControl2)
        Me.Name = "FormAccountingTrialBalance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trial Balance"
        CType(Me.GCAccTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAccTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEToViewJournal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEToViewJournal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromViewJournal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromViewJournal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCAccTrans As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccTrans As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEToViewJournal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromViewJournal As DevExpress.XtraEditors.DateEdit
End Class
