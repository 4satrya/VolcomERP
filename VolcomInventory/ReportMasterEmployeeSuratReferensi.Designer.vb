<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportMasterEmployeeSuratReferensi
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportMasterEmployeeSuratReferensi))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.L_text = New DevExpress.XtraReports.UI.XRRichText()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_employee_name = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_address_primary = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_hrd_employee_name2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_hrd_employee_position2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_date = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.L_text, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.L_text, Me.XrLabel1, Me.XLNumber, Me.L_employee_name, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.L_address_primary, Me.XrLabel20, Me.XrLabel19, Me.L_hrd_employee_name2, Me.L_hrd_employee_position2, Me.L_date, Me.XrLabel12})
        Me.Detail.HeightF = 605.2733!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'L_text
        '
        Me.L_text.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.L_text.LocationFloat = New DevExpress.Utils.PointFloat(0.0003034418!, 212.0!)
        Me.L_text.Name = "L_text"
        Me.L_text.SerializableRtfString = resources.GetString("L_text.SerializableRtfString")
        Me.L_text.SizeF = New System.Drawing.SizeF(650.0002!, 195.7941!)
        Me.L_text.StylePriority.UseFont = False
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Calibri", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 37.99998!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(650.0!, 30.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "TO WHOM IT MAY CONCERN"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XLNumber
        '
        Me.XLNumber.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(0!, 67.99997!)
        Me.XLNumber.Multiline = True
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(650.0!, 30.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.Text = "[number]"
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'L_employee_name
        '
        Me.L_employee_name.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_employee_name.LocationFloat = New DevExpress.Utils.PointFloat(170.0982!, 166.0001!)
        Me.L_employee_name.Multiline = True
        Me.L_employee_name.Name = "L_employee_name"
        Me.L_employee_name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_employee_name.SizeF = New System.Drawing.SizeF(479.9021!, 23.00002!)
        Me.L_employee_name.StylePriority.UseFont = False
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(151.2257!, 166.0001!)
        Me.XrLabel11.Multiline = True
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(18.8725!, 23.00002!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 166.0001!)
        Me.XrLabel10.Multiline = True
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(151.2254!, 23.00002!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.Text = "Name "
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 128.0!)
        Me.XrLabel9.Multiline = True
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(649.9999!, 23.00001!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.Text = "This certifies that:"
        '
        'L_address_primary
        '
        Me.L_address_primary.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_address_primary.LocationFloat = New DevExpress.Utils.PointFloat(170.0982!, 189.0!)
        Me.L_address_primary.Multiline = True
        Me.L_address_primary.Name = "L_address_primary"
        Me.L_address_primary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_address_primary.SizeF = New System.Drawing.SizeF(479.9021!, 23.00002!)
        Me.L_address_primary.StylePriority.UseFont = False
        '
        'XrLabel20
        '
        Me.XrLabel20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(151.2257!, 189.0!)
        Me.XrLabel20.Multiline = True
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(18.8725!, 23.00002!)
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.Text = ":"
        '
        'XrLabel19
        '
        Me.XrLabel19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(0.0002702077!, 189.0!)
        Me.XrLabel19.Multiline = True
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(151.2254!, 23.00002!)
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.Text = "Address "
        '
        'L_hrd_employee_name2
        '
        Me.L_hrd_employee_name2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_hrd_employee_name2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 559.2734!)
        Me.L_hrd_employee_name2.Multiline = True
        Me.L_hrd_employee_name2.Name = "L_hrd_employee_name2"
        Me.L_hrd_employee_name2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_hrd_employee_name2.SizeF = New System.Drawing.SizeF(650.0!, 23.0!)
        Me.L_hrd_employee_name2.StylePriority.UseFont = False
        '
        'L_hrd_employee_position2
        '
        Me.L_hrd_employee_position2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_hrd_employee_position2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 582.2733!)
        Me.L_hrd_employee_position2.Multiline = True
        Me.L_hrd_employee_position2.Name = "L_hrd_employee_position2"
        Me.L_hrd_employee_position2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_hrd_employee_position2.SizeF = New System.Drawing.SizeF(650.0!, 23.0!)
        Me.L_hrd_employee_position2.StylePriority.UseFont = False
        '
        'L_date
        '
        Me.L_date.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_date.LocationFloat = New DevExpress.Utils.PointFloat(0.0003019969!, 0!)
        Me.L_date.Multiline = True
        Me.L_date.Name = "L_date"
        Me.L_date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_date.SizeF = New System.Drawing.SizeF(650.0!, 23.0!)
        Me.L_date.StylePriority.UseFont = False
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(0!, 449.4987!)
        Me.XrLabel12.Multiline = True
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(650.0!, 23.0!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "Kind Regards,"
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 215.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportMasterEmployeeSuratReferensi
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 215, 100)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.L_text, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_employee_name As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_address_primary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_hrd_employee_name2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_hrd_employee_position2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_date As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_text As DevExpress.XtraReports.UI.XRRichText
End Class
