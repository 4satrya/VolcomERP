<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreTracking
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtPaymentMethod = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTrackingCode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MEAddress = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtStore = New DevExpress.XtraEditors.TextEdit()
        Me.BtnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtOrderNumber = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtPaymentMethod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTrackingCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(18, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Order Number"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TxtPaymentMethod)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.TxtTrackingCode)
        Me.PanelControl1.Controls.Add(Me.TxtPhone)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.MEAddress)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.TxtCustomer)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TxtStore)
        Me.PanelControl1.Controls.Add(Me.BtnSearch)
        Me.PanelControl1.Controls.Add(Me.TxtOrderNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(771, 220)
        Me.PanelControl1.TabIndex = 1
        '
        'TxtPaymentMethod
        '
        Me.TxtPaymentMethod.Location = New System.Drawing.Point(120, 176)
        Me.TxtPaymentMethod.Name = "TxtPaymentMethod"
        Me.TxtPaymentMethod.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaymentMethod.Properties.Appearance.Options.UseFont = True
        Me.TxtPaymentMethod.Properties.ReadOnly = True
        Me.TxtPaymentMethod.Size = New System.Drawing.Size(638, 20)
        Me.TxtPaymentMethod.TabIndex = 153
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(18, 153)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl7.TabIndex = 152
        Me.LabelControl7.Text = "Tracking Code"
        '
        'TxtTrackingCode
        '
        Me.TxtTrackingCode.Location = New System.Drawing.Point(120, 150)
        Me.TxtTrackingCode.Name = "TxtTrackingCode"
        Me.TxtTrackingCode.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTrackingCode.Properties.Appearance.Options.UseFont = True
        Me.TxtTrackingCode.Properties.ReadOnly = True
        Me.TxtTrackingCode.Size = New System.Drawing.Size(639, 20)
        Me.TxtTrackingCode.TabIndex = 151
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(536, 66)
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPhone.Properties.Appearance.Options.UseFont = True
        Me.TxtPhone.Properties.ReadOnly = True
        Me.TxtPhone.Size = New System.Drawing.Size(222, 20)
        Me.TxtPhone.TabIndex = 150
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(497, 69)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl6.TabIndex = 149
        Me.LabelControl6.Text = "Phone"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(18, 179)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl5.TabIndex = 148
        Me.LabelControl5.Text = "Payment Method"
        '
        'MEAddress
        '
        Me.MEAddress.Location = New System.Drawing.Point(120, 92)
        Me.MEAddress.Name = "MEAddress"
        Me.MEAddress.Properties.ReadOnly = True
        Me.MEAddress.Size = New System.Drawing.Size(638, 52)
        Me.MEAddress.TabIndex = 147
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(18, 94)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl4.TabIndex = 146
        Me.LabelControl4.Text = "Address"
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(120, 66)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCustomer.Properties.Appearance.Options.UseFont = True
        Me.TxtCustomer.Properties.ReadOnly = True
        Me.TxtCustomer.Size = New System.Drawing.Size(371, 20)
        Me.TxtCustomer.TabIndex = 145
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(18, 69)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl3.TabIndex = 144
        Me.LabelControl3.Text = "Customer"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(18, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 143
        Me.LabelControl2.Text = "Store"
        '
        'TxtStore
        '
        Me.TxtStore.Location = New System.Drawing.Point(120, 39)
        Me.TxtStore.Name = "TxtStore"
        Me.TxtStore.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStore.Properties.Appearance.Options.UseFont = True
        Me.TxtStore.Properties.ReadOnly = True
        Me.TxtStore.Size = New System.Drawing.Size(638, 20)
        Me.TxtStore.TabIndex = 142
        '
        'BtnSearch
        '
        Me.BtnSearch.Appearance.BackColor = System.Drawing.Color.LightSeaGreen
        Me.BtnSearch.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSearch.Appearance.Options.UseBackColor = True
        Me.BtnSearch.Appearance.Options.UseFont = True
        Me.BtnSearch.Appearance.Options.UseForeColor = True
        Me.BtnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnSearch.Location = New System.Drawing.Point(703, 13)
        Me.BtnSearch.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSearch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSearch.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(56, 20)
        Me.BtnSearch.TabIndex = 141
        Me.BtnSearch.Text = "Search"
        '
        'TxtOrderNumber
        '
        Me.TxtOrderNumber.Location = New System.Drawing.Point(120, 13)
        Me.TxtOrderNumber.Name = "TxtOrderNumber"
        Me.TxtOrderNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtOrderNumber.Size = New System.Drawing.Size(576, 20)
        Me.TxtOrderNumber.TabIndex = 2
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCData)
        Me.PanelControl2.Controls.Add(Me.PanelControl4)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 220)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(771, 341)
        Me.PanelControl2.TabIndex = 2
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(2, 45)
        Me.GCData.LookAndFeel.SkinName = "Visual Studio 2013 Light"
        Me.GCData.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(767, 250)
        Me.GCData.TabIndex = 157
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnTime, Me.GridColumnTransNumber, Me.GridColumnTransStatus, Me.GridColumnTransType})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsCustomization.AllowSort = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnTime
        '
        Me.GridColumnTime.Caption = "Time"
        Me.GridColumnTime.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnTime.FieldName = "trans_time"
        Me.GridColumnTime.Name = "GridColumnTime"
        Me.GridColumnTime.Visible = True
        Me.GridColumnTime.VisibleIndex = 0
        '
        'GridColumnTransNumber
        '
        Me.GridColumnTransNumber.Caption = "Transaction Number"
        Me.GridColumnTransNumber.FieldName = "trans_number"
        Me.GridColumnTransNumber.Name = "GridColumnTransNumber"
        Me.GridColumnTransNumber.Visible = True
        Me.GridColumnTransNumber.VisibleIndex = 2
        '
        'GridColumnTransStatus
        '
        Me.GridColumnTransStatus.Caption = "Transaction Status"
        Me.GridColumnTransStatus.FieldName = "report_status"
        Me.GridColumnTransStatus.Name = "GridColumnTransStatus"
        Me.GridColumnTransStatus.Visible = True
        Me.GridColumnTransStatus.VisibleIndex = 3
        '
        'GridColumnTransType
        '
        Me.GridColumnTransType.Caption = "Type"
        Me.GridColumnTransType.FieldName = "trans_type"
        Me.GridColumnTransType.Name = "GridColumnTransType"
        Me.GridColumnTransType.Visible = True
        Me.GridColumnTransType.VisibleIndex = 1
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.SimpleButton2)
        Me.PanelControl4.Controls.Add(Me.SimpleButton1)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(2, 295)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(767, 44)
        Me.PanelControl4.TabIndex = 156
        Me.PanelControl4.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(612, 6)
        Me.SimpleButton2.LookAndFeel.SkinName = "Metropolis"
        Me.SimpleButton2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(70, 28)
        Me.SimpleButton2.TabIndex = 155
        Me.SimpleButton2.Text = "Close"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(685, 6)
        Me.SimpleButton1.LookAndFeel.SkinName = "Metropolis"
        Me.SimpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(71, 28)
        Me.SimpleButton1.TabIndex = 154
        Me.SimpleButton1.Text = "Print"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(767, 43)
        Me.PanelControl3.TabIndex = 155
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(16, 10)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(134, 21)
        Me.LabelControl8.TabIndex = 1
        Me.LabelControl8.Text = "Transaction History"
        '
        'FormOLStoreTracking
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 561)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tracking Order"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtPaymentMethod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTrackingCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtPaymentMethod As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTrackingCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtStore As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransType As DevExpress.XtraGrid.Columns.GridColumn
End Class
