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
End Namespace
