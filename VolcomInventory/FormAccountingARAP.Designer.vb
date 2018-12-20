<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingARAP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingARAP))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCompNumber = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCompName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEAP = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEAR = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BClearAP = New DevExpress.XtraEditors.SimpleButton()
        Me.BClearAR = New DevExpress.XtraEditors.SimpleButton()
        Me.BClearDP = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDP = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESales = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnClearSales = New DevExpress.XtraEditors.SimpleButton()
        Me.SLESalesReturn = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtCompNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEAP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEAR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEDP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESalesReturn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Company"
        '
        'TxtCompNumber
        '
        Me.TxtCompNumber.Enabled = False
        Me.TxtCompNumber.Location = New System.Drawing.Point(18, 35)
        Me.TxtCompNumber.Name = "TxtCompNumber"
        Me.TxtCompNumber.Size = New System.Drawing.Size(100, 20)
        Me.TxtCompNumber.TabIndex = 1
        '
        'TxtCompName
        '
        Me.TxtCompName.Enabled = False
        Me.TxtCompName.Location = New System.Drawing.Point(121, 35)
        Me.TxtCompName.Name = "TxtCompName"
        Me.TxtCompName.Size = New System.Drawing.Size(281, 20)
        Me.TxtCompName.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 237)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Account Payable"
        '
        'SLEAP
        '
        Me.SLEAP.Location = New System.Drawing.Point(18, 256)
        Me.SLEAP.Name = "SLEAP"
        Me.SLEAP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEAP.Properties.NullText = ""
        Me.SLEAP.Properties.ShowClearButton = False
        Me.SLEAP.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEAP.Size = New System.Drawing.Size(338, 20)
        Me.SLEAP.TabIndex = 5
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id"
        Me.GridColumn2.FieldName = "id_acc"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Account"
        Me.GridColumn3.FieldName = "acc_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "acc_description"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 82)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Account Receivable"
        '
        'SLEAR
        '
        Me.SLEAR.Location = New System.Drawing.Point(18, 101)
        Me.SLEAR.Name = "SLEAR"
        Me.SLEAR.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEAR.Properties.NullText = ""
        Me.SLEAR.Properties.ShowClearButton = False
        Me.SLEAR.Properties.View = Me.GridView1
        Me.SLEAR.Size = New System.Drawing.Size(338, 20)
        Me.SLEAR.TabIndex = 4
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_acc"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Account"
        Me.GridColumn5.FieldName = "acc_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "acc_description"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(328, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(86, 35)
        Me.BtnConfirm.TabIndex = 6
        Me.BtnConfirm.Text = "Confirm"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 366)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(416, 39)
        Me.PanelControl1.TabIndex = 8
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(242, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 35)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        '
        'BClearAP
        '
        Me.BClearAP.Location = New System.Drawing.Point(360, 254)
        Me.BClearAP.Name = "BClearAP"
        Me.BClearAP.Size = New System.Drawing.Size(42, 23)
        Me.BClearAP.TabIndex = 9
        Me.BClearAP.Text = "clear"
        '
        'BClearAR
        '
        Me.BClearAR.Location = New System.Drawing.Point(360, 99)
        Me.BClearAR.Name = "BClearAR"
        Me.BClearAR.Size = New System.Drawing.Size(42, 23)
        Me.BClearAR.TabIndex = 10
        Me.BClearAR.Text = "clear"
        '
        'BClearDP
        '
        Me.BClearDP.Location = New System.Drawing.Point(360, 305)
        Me.BClearDP.Name = "BClearDP"
        Me.BClearDP.Size = New System.Drawing.Size(42, 23)
        Me.BClearDP.TabIndex = 13
        Me.BClearDP.Text = "clear"
        '
        'SLEDP
        '
        Me.SLEDP.Location = New System.Drawing.Point(18, 307)
        Me.SLEDP.Name = "SLEDP"
        Me.SLEDP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDP.Properties.NullText = ""
        Me.SLEDP.Properties.ShowClearButton = False
        Me.SLEDP.Properties.View = Me.GridView2
        Me.SLEDP.Size = New System.Drawing.Size(338, 20)
        Me.SLEDP.TabIndex = 12
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Id"
        Me.GridColumn7.FieldName = "id_acc"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Account"
        Me.GridColumn8.FieldName = "acc_name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Description"
        Me.GridColumn9.FieldName = "acc_description"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(18, 288)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(96, 13)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Down Payment (DP)"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(18, 129)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl5.TabIndex = 14
        Me.LabelControl5.Text = "Sales"
        '
        'SLESales
        '
        Me.SLESales.Location = New System.Drawing.Point(18, 148)
        Me.SLESales.Name = "SLESales"
        Me.SLESales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESales.Properties.NullText = ""
        Me.SLESales.Properties.ShowClearButton = False
        Me.SLESales.Properties.View = Me.GridView3
        Me.SLESales.Size = New System.Drawing.Size(338, 20)
        Me.SLESales.TabIndex = 15
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id"
        Me.GridColumn10.FieldName = "id_acc"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Account"
        Me.GridColumn11.FieldName = "acc_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Description"
        Me.GridColumn12.FieldName = "acc_description"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        '
        'BtnClearSales
        '
        Me.BtnClearSales.Location = New System.Drawing.Point(360, 146)
        Me.BtnClearSales.Name = "BtnClearSales"
        Me.BtnClearSales.Size = New System.Drawing.Size(42, 23)
        Me.BtnClearSales.TabIndex = 16
        Me.BtnClearSales.Text = "clear"
        '
        'SLESalesReturn
        '
        Me.SLESalesReturn.Location = New System.Drawing.Point(18, 193)
        Me.SLESalesReturn.Name = "SLESalesReturn"
        Me.SLESalesReturn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESalesReturn.Properties.NullText = ""
        Me.SLESalesReturn.Properties.ShowClearButton = False
        Me.SLESalesReturn.Properties.View = Me.GridView4
        Me.SLESalesReturn.Size = New System.Drawing.Size(338, 20)
        Me.SLESalesReturn.TabIndex = 17
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumn15})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Id"
        Me.GridColumn13.FieldName = "id_acc"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Account"
        Me.GridColumn14.FieldName = "acc_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Description"
        Me.GridColumn15.FieldName = "acc_description"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(18, 174)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl6.TabIndex = 18
        Me.LabelControl6.Text = "Sales Return"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(360, 191)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(42, 23)
        Me.SimpleButton1.TabIndex = 19
        Me.SimpleButton1.Text = "clear"
        '
        'FormAccountingARAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 405)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.SLESalesReturn)
        Me.Controls.Add(Me.BtnClearSales)
        Me.Controls.Add(Me.SLESales)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.BClearDP)
        Me.Controls.Add(Me.SLEDP)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.BClearAR)
        Me.Controls.Add(Me.BClearAP)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.SLEAR)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SLEAP)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtCompName)
        Me.Controls.Add(Me.TxtCompNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingARAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Setup"
        CType(Me.TxtCompNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEAP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEAR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLEDP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESalesReturn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCompNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCompName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEAP As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEAR As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BClearAP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BClearAR As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BClearDP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEDP As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESales As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnClearSales As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLESalesReturn As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
