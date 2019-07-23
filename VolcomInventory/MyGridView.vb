Imports System

Namespace MyXtraGrid
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView

		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			' put your initialization code here
		End Sub
        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property

        Friend Sub RaiseViewInfoShowGroupFooter(ByVal sender As Object, ByVal e As ShowGroupFooterEventArgs)
            RaiseEvent ShowGroupFooter(sender, e)
        End Sub

        Public Event ShowGroupFooter As ShowGroupFooterEventHandler
    End Class
End Namespace
