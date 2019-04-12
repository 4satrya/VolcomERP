Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing.Imaging

Public Module TwainModule
    ' this is a single function call which get all images from scanner
    Public Function ScanImages(Optional ByVal ImageType As String = ".jpg", Optional ByVal CloseScannerUIAfterImageTransfer As Boolean = True, Optional ByVal ScannerInfo As String = "") As List(Of String)
        Try
            Dim TW As New TwainHandler
            Dim Z = TW.SelectSourceAndScan(ImageType, CloseScannerUIAfterImageTransfer, ScannerInfo)
            TW.Close()
            TW.Dispose()
            Return Z
        Catch ex As Exception
            Return New List(Of String)
        End Try
    End Function

    Public Function ScanImage(ByVal imageType As String, ByVal CloseUI As Boolean, ByVal ScannerInfo As String) As List(Of Image)
        Try
            Dim TW As New TwainHandler
            Dim Z = TW.ScanAndReturnImages(imageType, CloseUI, ScannerInfo)
            TW.Close()
            TW.Dispose()
            Return Z
        Catch ex As Exception
            Return New List(Of Image)
        End Try
    End Function

    ' this function gets the scan source
    Public Function GetScanSource() As String
        Try
            Dim TW As New TwainHandler
            Dim Obj = TW.GetScanObj()
            Obj.SelectImageSource()
            Return Obj.GetSelectedSourceInfo
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function SaveFileLocation(Optional ByVal sPath As String = "") As String
        If sPath = "" Then
            Return File_Location
        Else
            File_Location = sPath
            Return ""
        End If
    End Function


    Public Property File_Location As String
        Get
            Return System.IO.Path.GetTempPath & Format(Now, "yyyy-MM-dd HH-mm-ss ")
            'Return My.Settings.filepath
        End Get
        Set(value As String)
            If value.Length > 0 Then
                'My.Settings.FilePath = value
                My.Settings.Save()
            End If
        End Set
    End Property
End Module

Module MainCode
#Region "Twain DLL calls are defined here with some required enums"

    ' windows message
    <StructLayout(LayoutKind.Sequential, Pack:=4)> Public Structure WINMSG_S
        Public hwnd As IntPtr
        Public message As Integer
        Public wParam As IntPtr
        Public lParam As IntPtr
        Public time As Integer
        Public x As Integer
        Public y As Integer
    End Structure

    ' twain general commands - these are not standard commands, they are just to simplify stuff 
    Public Enum TwainCommand
        TwainCommand_Not = -1
        TwainCommand_Null = 0
        TwainCommand_TransferReady = 1
        TwainCommand_CloseRequest = 2
        TwainCommand_CloseOk = 3
        TwainCommand_DeviceEvent = 4
        TwainCommand_Failure = 5
    End Enum

    ' data groups
    <Flags()> Public Enum TwDG As Short
        TwDG_Control = &H1
        TwDG_Image = &H2
        TwDG_Audio = &H4
    End Enum

    ' data argument types
    Public Enum TwDAT As Short
        TwDAT_Null = &H0
        TwDAT_Capability = &H1
        TwDAT_Event = &H2
        TwDAT_Identity = &H3
        TwDAT_Parent = &H4
        TwDAT_PendingXfers = &H5
        TwDAT_SetupMemXfer = &H6
        TwDAT_SetupFileXfer = &H7
        TwDAT_Status = &H8
        TwDAT_UserInterface = &H9
        TwDAT_XferGroup = &HA
        TwDAT_TwunkIdentity = &HB
        TwDAT_CustomDSData = &HC
        TwDAT_DeviceEvent = &HD
        TwDAT_FileSystem = &HE
        TwDAT_PassThru = &HF
        TwDAT_ImageInfo = &H101
        TwDAT_ImageLayout = &H102
        TwDAT_ImageMemXfer = &H103
        TwDAT_ImageNativeXfer = &H104
        TwDAT_ImageFileXfer = &H105
        TwDAT_CieColor = &H106
        TwDAT_GrayResponse = &H107
        TwDAT_RGBResponse = &H108
        TwDAT_JpegCompression = &H109
        TwDAT_Palette8 = &H10A
        TwDAT_ExtImageInfo = &H10B
        TwDAT_SetupFileXfer2 = &H301
    End Enum

    ' message
    Public Enum TwMSG As Short
        TwMSG_Null = &H0
        TwMSG_Get = &H1
        TwMSG_GetCurrent = &H2
        TwMSG_GetDefault = &H3
        TwMSG_GetFirst = &H4
        TwMSG_GetNext = &H5
        TwMSG_Set = &H6
        TwMSG_Reset = &H7
        TwMSG_QuerySupport = &H8
        TwMSG_XFerReady = &H101
        TwMSG_CloseDSReq = &H102
        TwMSG_CloseDSOK = &H103
        TwMSG_DeviceEvent = &H104
        TwMSG_CheckStatus = &H201
        TwMSG_OpenDSM = &H301
        TwMSG_CloseDSM = &H302
        TwMSG_OpenDS = &H401
        TwMSG_CloseDS = &H402
        TwMSG_UserSelect = &H403
        TwMSG_DisableDS = &H501
        TwMSG_EnableDS = &H502
        TwMSG_EnableDSUIOnly = &H503
        TwMSG_ProcessEvent = &H601
        TwMSG_EndXfer = &H701
        TwMSG_StopFeeder = &H702
        TwMSG_ChangeDirectory = &H801
        TwMSG_CreateDirectory = &H802
        TwMSG_Delete = &H803
        TwMSG_FormatMedia = &H804
        TwMSG_GetClose = &H805
        TwMSG_GetFirstFile = &H806
        TwMSG_GetInfo = &H807
        TwMSG_GetNextFile = &H808
        TwMSG_Rename = &H809
        TwMSG_Copy = &H80A
        TwMSG_AutoCaptureDir = &H80B
        TwMSG_PassThru = &H901
    End Enum

    ' return code
    Public Enum TwRC As Short
        TwRC_Success = &H0
        TwRC_Failure = &H1
        TwRC_CheckStatus = &H2
        TwRC_Cancel = &H3
        TwRC_DSEvent = &H4
        TwRC_NotDSEvent = &H5
        TwRC_XferDone = &H6
        TwRC_EndOfList = &H7
        TwRC_InfoNotSupported = &H8
        TwRC_DataNotAvailable = &H9
    End Enum

    ' condition code
    Public Enum TwCC As Short
        TwCC_Success = &H0
        TwCC_Bummer = &H1
        TwCC_LowMemory = &H2
        TwCC_NoDS = &H3
        TwCC_MaxConnections = &H4
        TwCC_OperationError = &H5
        TwCC_BadCap = &H6
        TwCC_BadProtocol = &H9
        TwCC_BadValue = &HA
        TwCC_SeqError = &HB
        TwCC_BadDest = &HC
        TwCC_CapUnsupported = &HD
        TwCC_CapBadOperation = &HE
        TwCC_CapSeqError = &HF
        TwCC_Denied = &H10
        TwCC_FileExists = &H11
        TwCC_FileNotFound = &H12
        TwCC_NotEmpty = &H13
        TwCC_PaperJam = &H14
        TwCC_PaperDoubleFeed = &H15
        TwCC_FileWriteError = &H16
        TwCC_CheckDeviceOnline = &H17
    End Enum

    ' type definition
    Public Enum TwOn As Short
        TwOn_Array = &H3
        TwOn_Enum = &H4
        TwOn_One = &H5
        TwOn_Range = &H6
        TwOn_DontCare = -1
    End Enum

    ' type definition
    Public Enum TwType As Short
        TwType_Int8 = &H0
        TwType_Int16 = &H1
        TwType_Int32 = &H2
        TwType_UInt8 = &H3
        TwType_UInt16 = &H4
        TwType_UInt32 = &H5
        TwType_Bool = &H6
        TwType_Fix32 = &H7
        TwType_Frame = &H8
        TwType_Str32 = &H9
        TwType_Str64 = &HA
        TwType_Str128 = &HB
        TwType_Str255 = &HC
        TwType_Str1024 = &HD
        TwType_Str512 = &HE
    End Enum

    ' capabilities
    Public Enum TwCap As Short
        TwCap_XferCount = &H1
        TwCap_ICompression = &H100
        TwCap_IPixelType = &H101
        TwCap_IUnits = &H102
        TwCap_IXferMech = &H103
        TwCap_FeederEnabled = &H1002
        TwCap_FeederLoaded = &H1003
        TwCap_PAPERDETECTABLE = &H100D
        TwCap_AutoFeed = &H1007
        TwCap_AutoScan = &H1010
    End Enum


    <StructLayout(LayoutKind.Sequential, Pack:=2, CharSet:=CharSet.Ansi)> Public Class TwIdentity
        Public Id As IntPtr
        Public Version As TwVersion
        Public ProtocolMajor As Short
        Public ProtocolMinor As Short
        Public SupportedGroups As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public Manufacturer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public ProductFamily As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public ProductName As String
    End Class

    <StructLayout(LayoutKind.Sequential, Pack:=2, CharSet:=CharSet.Ansi)> Public Structure TwVersion
        Public MajorNum As Short
        Public MinorNum As Short
        Public Language As Short
        Public Country As Short
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public Info As String
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Class TwUserInterface
        Public ShowUI As Short
        Public ModalUI As Short
        Public ParentHand As IntPtr
    End Class

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Class TwStatus
        Public ConditionCode As Short
        Public Reserved As Short
    End Class

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Structure TwEvent
        Public EventPtr As IntPtr
        Public Message As Short
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Class TwImageInfo
        Public XResolution As Integer
        Public YResolution As Integer
        Public ImageWidth As Integer
        Public ImageLength As Integer
        Public SamplesPerPixel As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public BitsPerSample() As Short
        Public BitsPerPixel As Short
        Public Planar As Short
        Public PixelType As Short
        Public Compression As Short
    End Class

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Class TwPendingXfers
        Public Count As Short
        Public EOJ As Integer
    End Class

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Structure TwFix32
        Public Whole As Short
        Public Frac As Short

        Public Function ToFloat() As Single
            Return CType(Whole + (CType(Frac, Single) / 65536.0F), Single)
        End Function

        Public Sub FromFloat(ByVal f As Single)
            Dim i As Integer = CType(((f * 65536.0F) + 0.5F), Integer)
            Whole = CType(i / 2 ^ 16, Short)
            Frac = CType(i & &HFFFF, Short)
        End Sub
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Class TwCapability
        Public Cap As Short
        Public ConType As Short
        Public Handle As IntPtr

        Public Sub TwCapability(ByVal capIn As TwCap)
            Cap = CType(capIn, Short)
            ConType = -1
        End Sub

        Public Sub New(ByVal capIn As TwCap, ByVal sval As Short)
            Cap = CType(capIn, Short)
            ConType = CType(TwOn.TwOn_One, Short)
            Handle = GlobalAlloc(&H42, 6)
            Dim pv As IntPtr = GlobalLock(Handle)
            Marshal.WriteInt16(pv, 0, CType(TwType.TwType_Int16, Short))
            Marshal.WriteInt32(pv, 2, CType(sval, Integer))
            GlobalUnlock(Handle)
        End Sub

        Public Function GetValue() As Int32
            Dim pv As IntPtr = GlobalLock(Handle)
            Dim V = Marshal.ReadInt32(pv, 2)
            GlobalUnlock(Handle)
            Return V
        End Function

        Public Sub Dispose()
            If Not Equals(Handle, IntPtr.Zero) Then
                GlobalFree(Handle)
            End If
        End Sub

        Protected Overrides Sub Finalize()
            If Not Equals(Handle, IntPtr.Zero) Then
                GlobalFree(Handle)
            End If
        End Sub
    End Class

    <StructLayout(LayoutKind.Sequential, Pack:=2)> Public Class BITMAPINFOHEADER
        Public biSize As Integer
        Public biWidth As Integer
        Public biHeight As Integer
        Public biPlanes As Short
        Public biBitCount As Short
        Public biCompression As Integer
        Public biSizeImage As Integer
        Public biXPelsPerMeter As Integer
        Public biYPelsPerMeter As Integer
        Public biClrUsed As Integer
        Public biClrImportant As Integer
    End Class


    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DSM_Parent(<[In](), Out()> ByVal origin As TwIdentity, ByVal zeroptr As IntPtr, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, ByRef refptr As IntPtr) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DSM_Ident(<[In](), Out()> ByVal origin As TwIdentity, ByVal zeroptr As IntPtr, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, <[In](), Out()> ByVal idds As TwIdentity) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DSM_Status(<[In](), Out()> ByVal origin As TwIdentity, ByVal zeroptr As IntPtr, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, <[In](), Out()> ByVal dsmstat As TwStatus) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_Userif(<[In](), Out()> ByVal origin As TwIdentity, <[In](), Out()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, ByVal guif As TwUserInterface) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_Event(<[In](), Out()> ByVal origin As TwIdentity, <[In](), Out()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, ByRef evt As TwEvent) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_Status(<[In](), Out()> ByVal origin As TwIdentity, <[In]()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, <[In](), Out()> ByVal dsmstat As TwStatus) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_Cap(<[In](), Out()> ByVal origin As TwIdentity, <[In]()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, <[In](), Out()> ByVal capa As TwCapability) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_Iinf(<[In](), Out()> ByVal origin As TwIdentity, <[In]()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, <[In](), Out()> ByVal imginf As TwImageInfo) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_Ixfer(<[In](), Out()> ByVal origin As TwIdentity, <[In]()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, ByRef hbitmap As IntPtr) As TwRC
    End Function

    <DllImport("twain_32.dll", EntryPoint:="#1")> Function DS_pxfer(<[In](), Out()> ByVal origin As TwIdentity, <[In]()> ByVal dest As TwIdentity, ByVal dg As TwDG, ByVal dat As TwDAT, ByVal msg As TwMSG, <[In](), Out()> ByVal pxfr As TwPendingXfers) As TwRC
    End Function


#End Region

#Region "Other OS DLL calls"
    <DllImport("kernel32.dll", ExactSpelling:=True)> Function GlobalAlloc(ByVal flags As Integer, ByVal size As Integer) As IntPtr
    End Function

    <DllImport("kernel32.dll", ExactSpelling:=True)> Function GlobalLock(ByVal handle As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", ExactSpelling:=True)> Function GlobalUnlock(ByVal handle As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", ExactSpelling:=True)> Function GetMessagePos() As Integer
    End Function

    <DllImport("user32.dll", ExactSpelling:=True)> Function GetMessageTime() As Integer
    End Function

    <DllImport("gdi32.dll", ExactSpelling:=True)> Function GetDeviceCaps(ByVal hDC As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("gdi32.dll", CharSet:=CharSet.Auto)> Function CreateDC(ByVal szdriver As String, ByVal szdevice As String, ByVal szoutput As String, ByVal devmode As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll", ExactSpelling:=True)> Function DeleteDC(ByVal hdc As IntPtr) As Boolean
    End Function

    <DllImport("gdi32.dll", ExactSpelling:=True)> Function SetDIBitsToDevice(ByVal hdc As IntPtr, ByVal xdst As Integer, ByVal ydst As Integer, ByVal width As Integer, ByVal height As Integer, ByVal xsrc As Integer, ByVal ysrc As Integer, ByVal start As Integer, ByVal lines As Integer, ByVal bitsptr As IntPtr, ByVal bmiptr As IntPtr, ByVal color As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", ExactSpelling:=True)> Function GlobalFree(ByVal handle As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> Public Sub OutputDebugString(ByVal outstr As String)
    End Sub

    <DllImport("gdiplus.dll", ExactSpelling:=True)> Public Function GdipCreateBitmapFromGdiDib(ByVal bminfo As IntPtr, ByVal pixdat As IntPtr, ByRef image As IntPtr) As Integer
    End Function

    <DllImport("gdiplus.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)> Public Function GdipSaveImageToFile(ByVal image As IntPtr, ByVal filename As String, <[In]()> ByRef clsid As Guid, ByVal encparams As IntPtr) As Integer
    End Function

    <DllImport("gdiplus.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)> Public Function GdipSaveImageToStream(ByVal image As IntPtr, ByVal ms As Stream, <[In]()> ByRef clsid As Guid, ByVal encparams As IntPtr) As Integer
    End Function

    <DllImport("gdiplus.dll", ExactSpelling:=True)> Public Function GdipDisposeImage(ByVal image As IntPtr) As Integer
    End Function

    Public Enum Status
        Ok = 0
        GenericError = 1
        InvalidParameter = 2
        OutOfMemory = 3
        ObjectBusy = 4
        InsufficientBuffer = 5
        NotImplemented = 6
        Win32Error = 7
        WrongState = 8
        Aborted = 9
        FileNotFound = 10
        ValueOverflow = 11
        AccessDenied = 12
        UnknownImageFormat = 13
        FontFamilyNotFound = 14
        FontStyleNotFound = 15
        NotTrueTypeFont = 16
        UnsupportedGdiplusVersion = 17
        GdiplusNotInitialized = 18
        PropertyNotFound = 19
        PropertyNotSupported = 20
        ProfileNotFound = 21
    End Enum

#End Region



    ' this class simulates the user interface
    Public Class TwainHandler
        Inherits System.Windows.Forms.Form
        Implements IMessageFilter

        Private TwainObj As New Twain                   ' this is the twain object that contains most operations
        Private MessageFilterOn As Boolean = False ' this is a flag that indicates the message filter is active

        Private ImageFileNames As New List(Of String)   ' this list stores the file names scanned
        Private PictureNumber As Integer = 0            ' this holds the number of pictures
        Private ImageExtension As String = ".jpg"       ' default image type used
        Private CloseSourceAfterFirstTransfer As Boolean = True ' used to close source as soon as image transfer finishs


        ' this function is used to get the scanner object
        Public Function GetScanObj() As Twain
            Return TwainObj
        End Function

        ' this function is used to scan images. It should be Used to scan multiple images
        Public Function SelectSourceAndScan(Optional ByVal PrefferedImageExtension As String = ".jpg", Optional ByVal CloseSourceAfterImgTransfer As Boolean = True, Optional ByVal ScannerInfo As String = "") As List(Of String)

            ' set the behaviour after transfering the image
            CloseSourceAfterFirstTransfer = CloseSourceAfterImgTransfer

            ' set the requested extension
            ImageExtension = PrefferedImageExtension

            ' select image source
            If ScannerInfo = "" Then
                If Not TwainObj.SelectImageSource() Then
                    Return New List(Of String)
                End If
            End If

            ' add filter
            If (Not MessageFilterOn) Then
                Me.Enabled = False
                MessageFilterOn = True
                Application.AddMessageFilter(Me)
            End If

            ' scan image
            TwainObj.AcquireImageSourceAndDisplayUserInterface(ScannerInfo)

            ' wait until processing is finished
            Do While Me.Enabled = False
                Threading.Thread.Sleep(100)
                Application.DoEvents()
            Loop

            ' close twain source
            TwainObj.CloseSource()

            ' return images
            Return ImageFileNames
        End Function

        Public Function ScanAndReturnImages(Optional ByVal PrefferedImageExtension As String = ".jpg", Optional ByVal CloseSourceAfterImgTransfer As Boolean = True, Optional ByVal ScannerInfo As String = "") As List(Of Image)

            ' set the behaviour after transfering the image
            CloseSourceAfterFirstTransfer = CloseSourceAfterImgTransfer

            ' set the requested extension
            ImageExtension = PrefferedImageExtension

            ' select image source
            If ScannerInfo = "" Then
                If Not TwainObj.SelectImageSource() Then
                    Return New List(Of Image)
                End If
            End If

            ' add filter
            If (Not MessageFilterOn) Then
                Me.Enabled = False
                MessageFilterOn = True
                Application.AddMessageFilter(Me)
            End If

            ' scan image
            TwainObj.AcquireImageSourceAndDisplayUserInterface(ScannerInfo)

            ' wait until processing is finished
            Do While Me.Enabled = False
                Threading.Thread.Sleep(100)
                Application.DoEvents()
            Loop

            ' close twain source
            TwainObj.CloseSource()

            ' return images
            Return TwainObj.SavedImages
        End Function



        ' as soon as the form get generated, you need to set the handle of the window
        Public Sub New()
            ' call original constructor
            MyBase.New()

            ' create the twain object
            TwainObj = New Twain()

            ' link this object with the window
            TwainObj.InitializeDSM(Me.Handle)
        End Sub



        ' this function is used to end scan operation.
        ' it removes the message filter
        Private Sub EndingScan()
            If (MessageFilterOn) Then
                Application.RemoveMessageFilter(Me)
                MessageFilterOn = False
                Me.Enabled = True
                Me.Activate()
            End If
        End Sub



        ' this method is used to perform processing for twain functions
        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage

            ' this part of code checks to see the kind of response, or message sent from
            ' the scanner, and according to that, you get an easy to process 
            Dim cmd As TwainCommand = TwainObj.PassMessage(m)

            ' check to see if this was not a twain command, then don't do any processing
            If (cmd = TwainCommand.TwainCommand_Not) Then
                Return False
            End If

            ' if this is a twain command perfom processing here.
            Select Case cmd
                ' check to see if the message send by the scanner is close request
                Case TwainCommand.TwainCommand_CloseRequest
                    EndingScan()
                    TwainObj.CloseSource()
                Case TwainCommand.TwainCommand_CloseOk
                    EndingScan()
                    TwainObj.CloseSource()
                Case TwainCommand.TwainCommand_Failure
                    EndingScan()
                    TwainObj.CloseSource()
                Case TwainCommand.TwainCommand_DeviceEvent
                    ' some device event code should go here

                Case TwainCommand.TwainCommand_TransferReady

                    ' load the list of pictures
                    Dim pics = TwainObj.TransferPictures(ImageExtension)
                    'TwainObj.TransferImages()
                    ' usually you close the source and end the scan process
                    ' probably with multipage scan, you should not do this
                    ' so this variable is used to control such option
                    If CloseSourceAfterFirstTransfer Then
                        EndingScan()
                        TwainObj.CloseSource()
                    End If


                    ' next save the images
                    Dim i As Integer
                    For i = 0 To pics.Count - 1 Step 1
                        PictureNumber += 1

                        ImageFileNames.Add(pics.Item(i))
                    Next

                Case TwainCommand.TwainCommand_Null
                    ' the two commands here probably caused some problems, now the problem is fixed
                    ' EndingScan()
                    'tw.CloseSrc()

            End Select

            Return True
        End Function


    End Class



    ' this class contains all the code needed to run twain
    Public Class Twain


        Private hwnd As IntPtr                      ' a handle for the window
        Private appid As TwIdentity                 ' the identity of the application
        Private SelectedDataSource As TwIdentity    ' source DataSource identity
        Private evtmsg As TwEvent                   ' event message
        Private winmsg_m As WINMSG_S                ' windows message
        Private FeederAvailable As Boolean = False  ' document feeder
        Private PaperDetectable As Boolean = False  ' paper detection is disabled
        Private ImageEncoders = ImageCodecInfo.GetImageEncoders()   ' used to store list of image encoders

        ' few constants needed here
        Private Const CountryUSA As Short = 1
        Private Const LanguageUSA As Short = 13
        Private Const ProtocolMajor As Short = 1
        Private Const ProtocolMinor As Short = 9

        Private lstImage As New List(Of Image)

        ' the constructor for this class
        Public Sub New()
            appid = New TwIdentity()
            appid.Id = IntPtr.Zero
            appid.Version.MajorNum = 1
            appid.Version.MinorNum = 1
            appid.Version.Language = LanguageUSA
            appid.Version.Country = CountryUSA
            appid.Version.Info = "Twain 3.0"
            appid.ProtocolMajor = ProtocolMajor
            appid.ProtocolMinor = ProtocolMinor
            appid.SupportedGroups = CType(TwDG.TwDG_Image Or TwDG.TwDG_Control, Integer)
            appid.Manufacturer = "MKA-SOFT"
            appid.ProductFamily = "Freeware"
            appid.ProductName = "EasyTwain"

            SelectedDataSource = New TwIdentity()
            SelectedDataSource.Id = IntPtr.Zero

            evtmsg.EventPtr = Marshal.AllocHGlobal(Marshal.SizeOf(winmsg_m))
        End Sub
        ' this function is used to select the source 
        Public Function SelectImageSource() As Boolean
            Dim ReturnCode As TwRC

            ' close any source that was open before
            Me.CloseSource()
            If Equals(appid.Id, IntPtr.Zero) = True Then
                InitializeDSM(hwnd)
                If Equals(appid.Id, IntPtr.Zero) = True Then
                    Return False
                End If
            End If

            ' ask the DSM manager to display user interface to the end user and store the source id in SelectedDataSource
            ReturnCode = DSM_Ident(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Identity, TwMSG.TwMSG_UserSelect, SelectedDataSource)
            If ReturnCode = TwRC.TwRC_Cancel Then
                Return False
            End If
            Return True
        End Function
        ' this function is used aquire an image source/scanner
        Public Sub AcquireImageSourceAndDisplayUserInterface(Optional ByVal ScannerInfo As String = "")
            Dim rc As TwRC

            ' close previously open DS and DSM
            CloseSource()

            If Equals(appid.Id, IntPtr.Zero) = True Then
                ' open the DSM
                InitializeDSM(hwnd)
                If Equals(appid.Id, IntPtr.Zero) = True Then
                    Return
                End If
            End If

            ' if the scanner info is not empty, this means you want to use specific source
            If ScannerInfo <> "" Then
                Dim SI As String() = ScannerInfo.Split(vbNewLine, Chr(13), Chr(10))
                Dim ReturnCode As TwRC
                ReturnCode = DSM_Ident(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Identity, TwMSG.TwMSG_GetFirst, SelectedDataSource)
                Do
                    If SelectedDataSource.Manufacturer = SI(0) And SelectedDataSource.ProductFamily = SI(2) And SelectedDataSource.ProductName = SI(4) Then
                        Exit Do
                    End If
                    ReturnCode = DSM_Ident(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Identity, TwMSG.TwMSG_GetNext, SelectedDataSource)
                Loop While ReturnCode = TwRC.TwRC_Success

                If ReturnCode = TwRC.TwRC_Failure Then
                    Return
                End If
            End If

            ' next aquire the scanner
            rc = DSM_Ident(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Identity, TwMSG.TwMSG_OpenDS, Me.SelectedDataSource)
            If (rc <> TwRC.TwRC_Success) Then
                Return
            End If

            Dim cap As TwCapability

            ' feeder check
            FeederAvailable = False

            ' this part is used to activate the document feeder if the scanner supports it
            cap = New TwCapability(TwCap.TwCap_FeederEnabled, 0)
            rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Get, cap)
            If (rc = TwRC.TwRC_Success) Then
                ' enable the feeder
                cap = New TwCapability(TwCap.TwCap_FeederEnabled, 1)
                rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
                If rc = TwRC.TwRC_Success Then
                    ' enable the auto feed
                    cap = New TwCapability(TwCap.TwCap_AutoFeed, 1)
                    rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
                    If rc = TwRC.TwRC_Success Then
                        ' enable the auto scan
                        cap = New TwCapability(TwCap.TwCap_AutoScan, 1)
                        rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
                        If rc = TwRC.TwRC_Success Then
                            ' set the capability
                            FeederAvailable = True
                        End If
                    End If
                End If
            End If

            ' if no feeder is there, or some error happened, unset the properties
            If Not FeederAvailable Then
                cap = New TwCapability(TwCap.TwCap_FeederEnabled, 0)
                rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
                cap = New TwCapability(TwCap.TwCap_AutoFeed, 0)
                rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
                cap = New TwCapability(TwCap.TwCap_AutoScan, 0)
                rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
            End If

            ' this part is used to check if the device can inform you if documents are there.
            cap = New TwCapability(TwCap.TwCap_PAPERDETECTABLE, 0)
            rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Get, cap)
            If (rc = TwRC.TwRC_Success) Then
                PaperDetectable = True
            End If

            ' set the capability of the device, accept any number of images
            cap = New TwCapability(TwCap.TwCap_XferCount, -1)
            rc = DS_Cap(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Capability, TwMSG.TwMSG_Set, cap)
            If (rc <> TwRC.TwRC_Success) Then
                Me.CloseSource()
                Return
            End If


            Dim guif As TwUserInterface = New TwUserInterface()
            guif.ShowUI = 1
            guif.ModalUI = 1
            guif.ParentHand = hwnd
            ' enable the image source to display its own user interface
            rc = DS_Userif(appid, Me.SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_UserInterface, TwMSG.TwMSG_EnableDS, guif)
            If (rc <> TwRC.TwRC_Success) Then
                Me.CloseSource()
                Return
            End If
        End Sub
        ' initialize DSM
        Public Sub InitializeDSM(ByVal hwndp As IntPtr)
            ' close any previously opened data source
            Finish()

            ' open the Data source manager, linking it with the window handle
            Dim ReturnCode As TwRC = DSM_Parent(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Parent, TwMSG.TwMSG_OpenDSM, hwndp)

            If (ReturnCode = TwRC.TwRC_Success) Then

                ' get the data source
                ReturnCode = DSM_Ident(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Identity, TwMSG.TwMSG_GetDefault, Me.SelectedDataSource)

                ' if evetything goes well update the handle inside the twain object,
                ' otherwise close the DSM
                If (ReturnCode = TwRC.TwRC_Success) Then
                    hwnd = hwndp
                Else
                    ReturnCode = DSM_Parent(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Parent, TwMSG.TwMSG_CloseDSM, hwndp)
                End If
            End If
        End Sub
        ' finish working with the source
        Public Sub Finish()
            Dim rc As TwRC
            ' close the source if it was not closed
            Me.CloseSource()
            If Not Equals(appid.Id, IntPtr.Zero) Then
                ' tell the data source manager to close the source
                rc = DSM_Parent(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Parent, TwMSG.TwMSG_CloseDSM, hwnd)
            End If
            appid.Id = IntPtr.Zero
        End Sub
        ' this function is used to transfer pictures from the device.
        Public Function TransferPictures(ByVal ImageExtension As String) As List(Of String)

            ' define a list that will store the pictures
            Dim pics As List(Of String) = New List(Of String)

            ' if no device is selected, then just return empty list of files.
            If Equals(SelectedDataSource.Id, IntPtr.Zero) Then
                Return pics
            End If

            Dim ReturnCode As TwRC
            Dim BitmapHandle As IntPtr = IntPtr.Zero
            Dim pxfr As TwPendingXfers = New TwPendingXfers()

            Do
                ' sleep for some time to give time for the scanner
                ' it happened in my case where paper jam happened
                Threading.Thread.Sleep(100)

                pxfr.Count = 0
                BitmapHandle = IntPtr.Zero

                ' the image information object
                Dim iinf As TwImageInfo = New TwImageInfo()

                ' ask the data source to return the image information to you so that you can read it.
                ReturnCode = DS_Iinf(appid, SelectedDataSource, TwDG.TwDG_Image, TwDAT.TwDAT_ImageInfo, TwMSG.TwMSG_Get, iinf)

                ' if getting image information does not work the you are having an error, close the source, and
                ' return the error
                If (ReturnCode <> TwRC.TwRC_Success) Then
                    Me.CloseSource()
                    Return pics
                End If

                ' now ask the data source to transfer the image to you sending you the handle to the buffer in the BitmapHandle 
                ReturnCode = DS_Ixfer(appid, SelectedDataSource, TwDG.TwDG_Image, TwDAT.TwDAT_ImageNativeXfer, TwMSG.TwMSG_Get, BitmapHandle)

                ' if transfereing image information causes some kind of error, stop the operation, 
                ' close the data source, and finally return the pictures
                If (ReturnCode <> TwRC.TwRC_XferDone) Then
                    Me.CloseSource()
                    Return pics
                End If

                ' now ask the data source if there is any other image to transfer
                ReturnCode = DS_pxfer(appid, SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_PendingXfers, TwMSG.TwMSG_EndXfer, pxfr)

                ' if there is any error, again close the datasource, and return the pics
                If (ReturnCode <> TwRC.TwRC_Success) Then
                    Me.CloseSource()
                    Return pics
                End If

                ' this part saves the picture to disk
                Dim img As IntPtr = CType(BitmapHandle, IntPtr)
                Dim dibhand As IntPtr
                Dim bmpptr As IntPtr
                Dim pixptr As IntPtr
                dibhand = img
                bmpptr = GlobalLock(dibhand)
                pixptr = GetPixelInfo(bmpptr)

                Dim filepath As String

                ' create temp file
                'Dim FilePath = System.IO.Path.GetTempPath & Format(Now, "yyyy-MM-dd HH-mm-ss ")
                filepath = System.IO.Path.GetTempPath & Format(Now, "yyyy-MM-dd HH-mm-ss ")


                ' save image to disk
                If Not SaveImageDIB(filepath & "_" & Format(pics.Count, "0000") & ImageExtension, bmpptr, pixptr) Then
                    ' probably an error happened, so don't store anything
                Else
                    pics.Add(filepath & "_" & Format(pics.Count, "0000") & ImageExtension)
                End If

                ' free memory
                GlobalFree(dibhand)
                dibhand = IntPtr.Zero


            Loop While (pxfr.Count <> 0)

            ' this one is used to reset the list of pending transfers
            ' it also discards all pending images so pay attention to this one
            ReturnCode = DS_pxfer(appid, SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_PendingXfers, TwMSG.TwMSG_Reset, pxfr)

            ' return the pictures
            Return pics
        End Function

        ' this function is used to transfer pictures from the device.
        Public Sub TransferImages()
            ' define a list that will store the pictures
            Dim ReturnCode As TwRC
            Dim BitmapHandle As IntPtr = IntPtr.Zero
            Dim pxfr As TwPendingXfers = New TwPendingXfers()

            Do
                ' sleep for some time to give time for the scanner
                ' it happened in my case where paper jam happened
                Threading.Thread.Sleep(100)

                pxfr.Count = 0
                BitmapHandle = IntPtr.Zero

                ' the image information object
                Dim iinf As TwImageInfo = New TwImageInfo()

                ' ask the data source to return the image information to you so that you can read it.
                ReturnCode = DS_Iinf(appid, SelectedDataSource, TwDG.TwDG_Image, TwDAT.TwDAT_ImageInfo, TwMSG.TwMSG_Get, iinf)

                ' if getting image information does not work the you are having an error, close the source, and
                ' return the error
                If (ReturnCode <> TwRC.TwRC_Success) Then
                    Me.CloseSource()
                End If

                ' now ask the data source to transfer the image to you sending you the handle to the buffer in the BitmapHandle 
                ReturnCode = DS_Ixfer(appid, SelectedDataSource, TwDG.TwDG_Image, TwDAT.TwDAT_ImageNativeXfer, TwMSG.TwMSG_Get, BitmapHandle)

                ' if transfereing image information causes some kind of error, stop the operation, 
                ' close the data source, and finally return the pictures
                If (ReturnCode <> TwRC.TwRC_XferDone) Then
                    Me.CloseSource()
                End If

                ' now ask the data source if there is any other image to transfer
                ReturnCode = DS_pxfer(appid, SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_PendingXfers, TwMSG.TwMSG_EndXfer, pxfr)

                ' if there is any error, again close the datasource, and return the pics
                If (ReturnCode <> TwRC.TwRC_Success) Then
                    Me.CloseSource()
                End If

                ' this part saves the picture to disk
                Dim img As IntPtr = CType(BitmapHandle, IntPtr)
                Dim dibhand As IntPtr
                Dim bmpptr As IntPtr
                Dim pixptr As IntPtr
                dibhand = img

                Dim imag As Image = Image.FromHbitmap(dibhand)

                bmpptr = GlobalLock(dibhand)
                pixptr = GetPixelInfo(bmpptr)

                ' save image to disk
                SaveImageToList(bmpptr, pixptr)

                ' free memory
                GlobalFree(dibhand)
                dibhand = IntPtr.Zero
            Loop While (pxfr.Count <> 0)

            ' this one is used to reset the list of pending transfers
            ' it also discards all pending images so pay attention to this one
            ReturnCode = DS_pxfer(appid, SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_PendingXfers, TwMSG.TwMSG_Reset, pxfr)
        End Sub

        ' this function closes the source ( the scanner ).
        Public Sub CloseSource()
            Dim rc As TwRC
            If Not Equals(SelectedDataSource.Id, IntPtr.Zero) Then
                Dim guif As TwUserInterface = New TwUserInterface()

                ' tell the data source to disable its user interface
                rc = DS_Userif(appid, SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_UserInterface, TwMSG.TwMSG_DisableDS, guif)

                ' tell the device manager to release the source
                rc = DSM_Ident(appid, IntPtr.Zero, TwDG.TwDG_Control, TwDAT.TwDAT_Identity, TwMSG.TwMSG_CloseDS, SelectedDataSource)

                ' set the pointer to zero
                SelectedDataSource.Id = IntPtr.Zero
            End If
        End Sub
        ' this function will check the messages and tells the type of twain command you have
        Public Function PassMessage(ByVal m As Message) As TwainCommand

            ' is the source ID of this message is null then this message is not a twain commad
            If Equals(SelectedDataSource.Id, IntPtr.Zero) Then
                Return TwainCommand.TwainCommand_Not
            End If



            ' if you get to this point, this means the message is a twain command
            ' get curser position ? not sure about this function 
            Dim pos As Integer = GetMessagePos()


            winmsg_m.hwnd = m.HWnd                      ' get the handle
            winmsg_m.message = m.Msg                    ' get the message
            winmsg_m.wParam = m.WParam                  ' get the parameters
            winmsg_m.lParam = m.LParam
            winmsg_m.time = GetMessageTime()
            winmsg_m.x = pos                            ' get the x location
            winmsg_m.y = Int(pos / 2 ^ 16)              ' get the y location

            ' as far as i unerstand this method is used to send information 
            ' our managed object (winmsg_m) to unmanaged one (in this case 
            ' the data pointed to by EventPtr).
            Marshal.StructureToPtr(winmsg_m, evtmsg.EventPtr, False)
            evtmsg.Message = 0

            ' call the data source using this operation triplate
            Dim ReturnCode As TwRC = DS_Event(appid, SelectedDataSource, TwDG.TwDG_Control, TwDAT.TwDAT_Event, TwMSG.TwMSG_ProcessEvent, evtmsg)
            If (ReturnCode = TwRC.TwRC_NotDSEvent) Then
                Return TwainCommand.TwainCommand_Not
            End If

            ' if the return code represents an error then return that
            If ReturnCode = TwRC.TwRC_Failure Then
                Return TwainCommand.TwainCommand_Failure
            End If

            ' if a cancel operation is being requested then this is a close request
            If ReturnCode = TwRC.TwRC_Cancel Then
                Return TwainCommand.TwainCommand_CloseRequest
            End If

            ' not sure here about the code but for now I assume we need to check this code
            If ReturnCode = TwRC.TwRC_DSEvent Then
                ' do some check here just in case
            End If

            ' if you reach this point, then simply there should be a message 

            ' if the message received here is that the transfer is ready, then simply 
            ' return a command saying that transfer is ready
            If (evtmsg.Message = CType(TwMSG.TwMSG_XFerReady, Short)) Then
                Return TwainCommand.TwainCommand_TransferReady
            End If

            ' if the data source is requesting a close operation then
            ' send a close request
            If (evtmsg.Message = CType(TwMSG.TwMSG_CloseDSReq, Short)) Then
                Return TwainCommand.TwainCommand_CloseRequest
            End If

            ' if the message says that the close operation is ok, then
            ' return that
            If (evtmsg.Message = CType(TwMSG.TwMSG_CloseDSOK, Short)) Then
                Return TwainCommand.TwainCommand_CloseOk
            End If

            ' this is a device event
            If (evtmsg.Message = CType(TwMSG.TwMSG_DeviceEvent, Short)) Then
                Return TwainCommand.TwainCommand_DeviceEvent
            End If

            ' else return null, the message code should be checked here just in case
            ' because it could contain some other information
            Return TwainCommand.TwainCommand_Null
        End Function
        ' this function is used to get picture information
        Public Function GetPixelInfo(ByVal bmpptr As IntPtr) As IntPtr

            ' this will be a buffer to read image info
            Dim Bmi As BITMAPINFOHEADER
            Bmi = New BITMAPINFOHEADER()

            ' get the information from the bitmap pointer
            Marshal.PtrToStructure(bmpptr, Bmi)

            ' if image size if not defined, then calculate it
            If (Bmi.biSizeImage = 0) Then
                Bmi.biSizeImage = Int((((Bmi.biWidth * Bmi.biBitCount) + 31) And (Not (31))) / 2 ^ 3) * Bmi.biHeight
            End If

            ' colors used
            Dim p As Integer = Bmi.biClrUsed
            If ((p = 0) And (Bmi.biBitCount <= 8)) Then
                p = Int(1 * 2 ^ Bmi.biBitCount)
            End If
            p = (p * 4) + Bmi.biSize + CType(bmpptr.ToInt32, Integer)

            ' return a pointer to the pixel format
            Return New IntPtr(p)
        End Function

        Public Function SavedImages() As List(Of Image)
            If IsNothing(lstImage) Then
                Return New List(Of Image)
            Else
                Return lstImage
            End If
        End Function

        Public Function DisposeImageList() As Boolean
            Try
                If IsNothing(lstImage) Then
                    Return True
                Else
                    For i = 0 To lstImage.Count - 1
                        lstImage(i).Dispose()
                    Next

                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ' this function is used to save a picture
        Private Function SaveImageDIB(ByVal picname As String, ByVal bminfo As IntPtr, ByVal pixdat As IntPtr) As Boolean

            Dim clsid As Guid
            ' get the class id for the image encoder
            If Not GetCodecClsid(picname, clsid) Then
                MessageBox.Show("Unknown picture format for extension " + Path.GetExtension(picname), "Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Dim img As IntPtr = IntPtr.Zero
            ' create bitmap based on the information provided
            Dim st As Status = GdipCreateBitmapFromGdiDib(bminfo, pixdat, img)
            If (st <> 0) Or (Equals(img, IntPtr.Zero)) Then
                Return False
            End If

            ' save the image to file
            st = GdipSaveImageToFile(img, picname, clsid, IntPtr.Zero)

            ' free the memory
            GdipDisposeImage(img)

            Return st = 0
        End Function

        Private Function SaveImageToList(ByVal bminfo As IntPtr, ByVal pixdat As IntPtr) As Boolean
            Try
                Dim img As IntPtr = IntPtr.Zero
                ' create bitmap based on the information provided
                Dim st As Status = GdipCreateBitmapFromGdiDib(bminfo, pixdat, img)
                If (st <> 0) Or (Equals(img, IntPtr.Zero)) Then
                    Return False
                End If

                ' save the image to list

                Dim simg As Image = Image.FromHbitmap(img)

                If IsNothing(simg) = False Then
                    lstImage.Add(simg)
                End If


                ' free the memory
                GdipDisposeImage(img)

                Return st = 0
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Function
        ' this function is used to get the class id for a given file format
        Private Function GetCodecClsid(ByVal filename As String, ByRef clsid As Guid) As Boolean
            clsid = Guid.Empty
            ' get extension of a file name
            Dim ext As String = Path.GetExtension(filename)

            'Checking string for null
            If IsNothing(ext) Then
                Return False
            End If
            ext = "*" + ext.ToUpper()
            Dim codec As ImageCodecInfo
            For Each codec In ImageEncoders
                If (codec.FilenameExtension.IndexOf(ext) >= 0) Then
                    clsid = codec.Clsid
                    Return True
                End If
            Next
            Return False
        End Function
        ' this class is used to return selected source info
        Public Function GetSelectedSourceInfo() As String
            Dim S As String = ""
            S = S & Me.SelectedDataSource.Manufacturer & vbNewLine
            S = S & Me.SelectedDataSource.ProductFamily & vbNewLine
            S = S & Me.SelectedDataSource.ProductName & vbNewLine
            Return S
        End Function
    End Class

End Module
