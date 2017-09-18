<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSuperUser
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSuperUser))
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConn = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDepartement = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOther = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtHost = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDB = New DevExpress.XtraEditors.LabelControl()
        Me.BSendMessage = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOutlet = New DevExpress.XtraEditors.SimpleButton()
        Me.BSubDep = New DevExpress.XtraEditors.SimpleButton()
        Me.BMockMark = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 197)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(430, 23)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Test Barcode"
        '
        'BtnConn
        '
        Me.BtnConn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnConn.Location = New System.Drawing.Point(0, 128)
        Me.BtnConn.Name = "BtnConn"
        Me.BtnConn.Size = New System.Drawing.Size(430, 23)
        Me.BtnConn.TabIndex = 1
        Me.BtnConn.Text = "Change Connection"
        '
        'BtnDepartement
        '
        Me.BtnDepartement.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnDepartement.Location = New System.Drawing.Point(0, 151)
        Me.BtnDepartement.Name = "BtnDepartement"
        Me.BtnDepartement.Size = New System.Drawing.Size(430, 23)
        Me.BtnDepartement.TabIndex = 2
        Me.BtnDepartement.Text = "Change Departement"
        '
        'BtnOther
        '
        Me.BtnOther.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnOther.Location = New System.Drawing.Point(0, 266)
        Me.BtnOther.Name = "BtnOther"
        Me.BtnOther.Size = New System.Drawing.Size(430, 23)
        Me.BtnOther.TabIndex = 3
        Me.BtnOther.Text = "Other"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(103, 31)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Size = New System.Drawing.Size(58, 54)
        Me.PictureEdit1.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(167, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Host"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(167, 62)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Database"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(221, 43)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = ":"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(221, 62)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = ":"
        '
        'TxtHost
        '
        Me.TxtHost.Location = New System.Drawing.Point(231, 43)
        Me.TxtHost.Name = "TxtHost"
        Me.TxtHost.Size = New System.Drawing.Size(60, 13)
        Me.TxtHost.TabIndex = 12
        Me.TxtHost.Text = "192.168.1.2"
        '
        'TxtDB
        '
        Me.TxtDB.Location = New System.Drawing.Point(231, 62)
        Me.TxtDB.Name = "TxtDB"
        Me.TxtDB.Size = New System.Drawing.Size(75, 13)
        Me.TxtDB.TabIndex = 14
        Me.TxtDB.Text = "Database name"
        '
        'BSendMessage
        '
        Me.BSendMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BSendMessage.Location = New System.Drawing.Point(0, 220)
        Me.BSendMessage.Name = "BSendMessage"
        Me.BSendMessage.Size = New System.Drawing.Size(430, 23)
        Me.BSendMessage.TabIndex = 15
        Me.BSendMessage.Text = "Send Message"
        '
        'BtnOutlet
        '
        Me.BtnOutlet.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnOutlet.Location = New System.Drawing.Point(0, 243)
        Me.BtnOutlet.Name = "BtnOutlet"
        Me.BtnOutlet.Size = New System.Drawing.Size(430, 23)
        Me.BtnOutlet.TabIndex = 16
        Me.BtnOutlet.Text = "Outlet Setup"
        '
        'BSubDep
        '
        Me.BSubDep.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BSubDep.Location = New System.Drawing.Point(0, 174)
        Me.BSubDep.Name = "BSubDep"
        Me.BSubDep.Size = New System.Drawing.Size(430, 23)
        Me.BSubDep.TabIndex = 17
        Me.BSubDep.Text = "Change Sub Departement"
        '
        'BMockMark
        '
        Me.BMockMark.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMockMark.Location = New System.Drawing.Point(0, 105)
        Me.BMockMark.Name = "BMockMark"
        Me.BMockMark.Size = New System.Drawing.Size(430, 23)
        Me.BMockMark.TabIndex = 18
        Me.BMockMark.Text = "Mock Mark"
        '
        'FormSuperUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 289)
        Me.Controls.Add(Me.BMockMark)
        Me.Controls.Add(Me.BtnConn)
        Me.Controls.Add(Me.BtnDepartement)
        Me.Controls.Add(Me.BSubDep)
        Me.Controls.Add(Me.TxtDB)
        Me.Controls.Add(Me.TxtHost)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.BSendMessage)
        Me.Controls.Add(Me.BtnOutlet)
        Me.Controls.Add(Me.BtnOther)
        Me.MaximizeBox = False
        Me.Name = "FormSuperUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormSuperUser"
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDepartement As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOther As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtHost As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDB As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSendMessage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOutlet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSubDep As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMockMark As DevExpress.XtraEditors.SimpleButton
End Class
