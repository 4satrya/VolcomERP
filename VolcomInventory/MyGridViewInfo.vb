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

        Protected Overrides Sub CalcRowFooterInfo(ByVal ri As GridRowInfo, ByVal row As DevExpress.XtraGrid.Views.Grid.GridRow, ByVal nextRow As DevExpress.XtraGrid.Views.Grid.GridRow)
            Dim height As Integer = ri.RowFooters.RowFootersHeight
            If height = 0 Then
                Return
            End If

            Dim isShowCurrentFooter As Boolean = IsShowCurrentRowFooter(ri)
            Dim startLevel As Integer = ri.Level
            Dim footerRowHandle As Integer = ri.RowHandle

            If (Not ri.IsGroupRow) OrElse (Not isShowCurrentFooter) Then
                footerRowHandle = View.GetParentRowHandle(footerRowHandle)
            End If

            If Not isShowCurrentFooter Then
                startLevel -= 1
            End If

            Dim top As Integer = ri.TotalBounds.Bottom - height - ri.RowSeparatorBounds.Height
            Dim left As Integer = ri.IndentRect.Right - (If((Not isShowCurrentFooter), LevelIndent, 0))
            If IsRightToLeft Then
                left = ri.TotalBounds.Left
            End If
            ri.RowFooters.Bounds = New Rectangle(left, top, ri.DataBounds.Right - left, height)

            Dim n As Integer = 0
            Do While n < ri.RowFooters.RowFooterCount
                Dim args As New ShowGroupFooterEventArgs(startLevel)
                RaiseShowGroupFooter(args)

                If Not args.Visible Then
                    startLevel -= 1
                    left -= LevelIndent
                    ri.RowFooters.RowFooterCount += 1
                    footerRowHandle = View.GetParentRowHandle(footerRowHandle)

                    n += 1
                    Continue Do
                End If

                Dim fi As New GridRowFooterInfo()
                ri.RowFooters.Add(fi)
                fi.RowHandle = footerRowHandle
                fi.Bounds = ri.Bounds
                fi.Level = startLevel
                fi.Bounds.Y = top
                fi.Bounds.X = left
                fi.Bounds.Width = ri.DataBounds.Right - fi.Bounds.Left
                fi.Bounds.Height = GroupFooterHeight
                top += fi.Bounds.Height

                If Not ri.IndicatorRect.IsEmpty Then
                    fi.IndicatorRect = ri.IndicatorRect
                    fi.IndicatorRect.Y = fi.Bounds.Y
                    fi.IndicatorRect.Height = fi.Bounds.Height
                End If

                If View.OptionsView.ShowHorizontalLines <> DevExpress.Utils.DefaultBoolean.False Then
                    ri.AddLineInfo(Nothing, fi.Bounds.Left, fi.Bounds.Bottom - 1, fi.Bounds.Width, 1, PaintAppearance.HorzLine)
                    fi.Bounds.Height -= 1
                End If

                CalcRowCellsFooterInfo(fi, ri)
                footerRowHandle = View.GetParentRowHandle(footerRowHandle)
                startLevel -= 1
                left -= LevelIndent
                n += 1
            Loop
        End Sub

        Public Overrides Function GetRowFooterCount(ByVal rowHandle As Integer, ByVal rowVisibleIndex As Integer, ByVal isExpanded As Boolean) As Integer
            Dim initialVisibleFootersCount As Integer = MyBase.GetRowFooterCount(rowHandle, rowVisibleIndex, isExpanded)
            Dim visibleFootersCount As Integer = initialVisibleFootersCount

            Dim footerRowHandle As Integer = rowHandle
            For i As Integer = 0 To initialVisibleFootersCount - 1
                Dim args As New ShowGroupFooterEventArgs(View.GetRowLevel(footerRowHandle))
                RaiseShowGroupFooter(args)

                If Not args.Visible Then
                    visibleFootersCount -= 1
                End If

                footerRowHandle = View.GetParentRowHandle(footerRowHandle)
            Next i

            Return visibleFootersCount
        End Function

        Private Sub RaiseShowGroupFooter(ByVal args As ShowGroupFooterEventArgs)
            Dim aView As MyGridView = TryCast(View, MyGridView)
            If aView IsNot Nothing Then
                aView.RaiseViewInfoShowGroupFooter(aView, args)
            End If
        End Sub
    End Class
End Namespace
