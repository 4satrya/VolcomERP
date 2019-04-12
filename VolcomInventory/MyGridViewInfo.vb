Imports System
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace MyXtraGrid
	Public Class MyGridViewInfo
		Inherits GridViewInfo

		Public Sub New(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
			MyBase.New(gridView)
		End Sub

        Public Overrides Function CalcRowHeight(ByVal graphics As Graphics, ByVal rowHandle As Integer, ByVal min As Integer, ByVal level As Integer, ByVal useCache As Boolean, ByVal columns As GridColumnsInfo) As Integer
            Return MyBase.CalcRowHeight(graphics, rowHandle, MinRowHeight, level, useCache, columns)
        End Function

        Public Overrides ReadOnly Property MinRowHeight() As Integer
			Get
                Return 10
            End Get
		End Property
	End Class
End Namespace
