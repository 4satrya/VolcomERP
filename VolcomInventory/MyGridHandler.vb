Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace MyXtraGrid
    Public Class MyGridHandler
        Inherits DevExpress.XtraGrid.Views.Grid.Handler.GridHandler

        Public Sub New(ByVal gridView As GridView)
            MyBase.New(gridView)
        End Sub

        Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            MyBase.OnKeyDown(e)
            If e.KeyData = Keys.Delete AndAlso View.State = GridState.Normal Then
                View.DeleteRow(View.FocusedRowHandle)
            End If
        End Sub
    End Class

    Public Delegate Sub ShowGroupFooterEventHandler(ByVal sender As Object, ByVal e As ShowGroupFooterEventArgs)

    Public Class ShowGroupFooterEventArgs
        Inherits EventArgs

        'INSTANT VB NOTE: The variable footerLevel was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private footerLevel_Renamed As Integer
        Private footerVisible As Boolean

        Public Sub New(ByVal aFooterLevel As Integer)
            MyBase.New()
            footerVisible = True
            footerLevel_Renamed = aFooterLevel
        End Sub

        Public ReadOnly Property FooterLevel() As Integer
            Get
                Return footerLevel_Renamed
            End Get
        End Property

        Public Property Visible() As Boolean
            Get
                Return footerVisible
            End Get
            Set(ByVal value As Boolean)
                footerVisible = value
            End Set
        End Property
    End Class
End Namespace
