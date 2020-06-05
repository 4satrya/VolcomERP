<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBankWithdrawalBookTransfer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBankWithdrawalBookTransfer))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEPayFrom = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLETrfTo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TEAmountRp = New DevExpress.XtraEditors.TextEdit()
        Me.TEAmount = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEPayFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLETrfTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAmountRp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 167)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(473, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'BConfirm
        '
        Me.BConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BConfirm.Image = CType(resources.GetObject("BConfirm.Image"), System.Drawing.Image)
        Me.BConfirm.Location = New System.Drawing.Point(366, 2)
        Me.BConfirm.Name = "BConfirm"
        Me.BConfirm.Size = New System.Drawing.Size(105, 36)
        Me.BConfirm.TabIndex = 0
        Me.BConfirm.Text = "Confirm"
        '
        'SLEPayFrom
        '
        Me.SLEPayFrom.Location = New System.Drawing.Point(126, 9)
        Me.SLEPayFrom.Name = "SLEPayFrom"
        Me.SLEPayFrom.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.SLEPayFrom.Properties.Appearance.Options.UseFont = True
        Me.SLEPayFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPayFrom.Properties.View = Me.SearchLookUpEdit2View
        Me.SLEPayFrom.Size = New System.Drawing.Size(335, 24)
        Me.SLEPayFrom.TabIndex = 168
        '
        'SearchLookUpEdit2View
        '
        Me.SearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.SearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit2View.Name = "SearchLookUpEdit2View"
        Me.SearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID Acc"
        Me.GridColumn6.FieldName = "id_acc"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Account"
        Me.GridColumn7.FieldName = "acc_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Description"
        Me.GridColumn8.FieldName = "acc_description"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'SLETrfTo
        '
        Me.SLETrfTo.Location = New System.Drawing.Point(126, 39)
        Me.SLETrfTo.Name = "SLETrfTo"
        Me.SLETrfTo.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.SLETrfTo.Properties.Appearance.Options.UseFont = True
        Me.SLETrfTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETrfTo.Properties.View = Me.GridView1
        Me.SLETrfTo.Size = New System.Drawing.Size(335, 24)
        Me.SLETrfTo.TabIndex = 169
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Acc"
        Me.GridColumn1.FieldName = "id_acc"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Account"
        Me.GridColumn2.FieldName = "acc_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "acc_description"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 19)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Transfer From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Transfer To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 19)
        Me.Label3.TabIndex = 172
        Me.Label3.Text = "Amount in Rp"
        '
        'TEAmountRp
        '
        Me.TEAmountRp.Enabled = False
        Me.TEAmountRp.Location = New System.Drawing.Point(126, 129)
        Me.TEAmountRp.Name = "TEAmountRp"
        Me.TEAmountRp.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TEAmountRp.Properties.Appearance.Options.UseFont = True
        Me.TEAmountRp.Properties.Appearance.Options.UseTextOptions = True
        Me.TEAmountRp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEAmountRp.Properties.Mask.EditMask = "N2"
        Me.TEAmountRp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEAmountRp.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEAmountRp.Size = New System.Drawing.Size(335, 24)
        Me.TEAmountRp.TabIndex = 173
        '
        'TEAmount
        '
        Me.TEAmount.Location = New System.Drawing.Point(196, 69)
        Me.TEAmount.Name = "TEAmount"
        Me.TEAmount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TEAmount.Properties.Appearance.Options.UseFont = True
        Me.TEAmount.Properties.Appearance.Options.UseTextOptions = True
        Me.TEAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEAmount.Properties.Mask.EditMask = "N2"
        Me.TEAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEAmount.Size = New System.Drawing.Size(265, 24)
        Me.TEAmount.TabIndex = 175
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 19)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Amount"
        '
        'TEKurs
        '
        Me.TEKurs.Location = New System.Drawing.Point(126, 99)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TEKurs.Properties.Appearance.Options.UseFont = True
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(335, 24)
        Me.TEKurs.TabIndex = 177
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 19)
        Me.Label5.TabIndex = 176
        Me.Label5.Text = "Kurs"
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(126, 69)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LECurrency.Properties.Appearance.Options.UseFont = True
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECurrency.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(64, 24)
        Me.LECurrency.TabIndex = 8937
        '
        'FormBankWithdrawalBookTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 207)
        Me.Controls.Add(Me.LECurrency)
        Me.Controls.Add(Me.TEKurs)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TEAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TEAmountRp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SLETrfTo)
        Me.Controls.Add(Me.SLEPayFrom)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBankWithdrawalBookTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Book Transfer"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLEPayFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLETrfTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAmountRp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEPayFrom As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLETrfTo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TEAmountRp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
End Class
