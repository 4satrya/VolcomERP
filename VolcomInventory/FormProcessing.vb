Public Class FormProcessing 
    Public id_process As String
    Public idx As String
    Public idx_main As String = "-1"
    Dim m_CountTo As Integer = 0 ' How many time to loop.
    Dim dtx As New DataTable
    Public dtx2 As New DataTable
    Dim n As Integer
    Dim str_err As String = ""
    Dim is_old_design As String = "1"


    Private Sub FormProcessing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_process = "1" Or id_process = "3" Then
            'initiation datatable
            dtx.Columns.Add("id_product")
            dtx.Columns.Add("id_prod_order_det")
            dtx.Columns.Add("product_code")
            dtx.Columns.Add("product_counting_code")
            dtx.Columns.Add("product_full_code")
            dtx.Columns.Add("is_old_design")

            'get is old design
            Dim query_old_dsg As String = ""
            query_old_dsg += "Select dsg.is_old_design From tb_prod_order pdo "
            query_old_dsg += "INNER Join tb_prod_demand_design pd_dsg On pdo.id_prod_demand_design = pd_dsg.id_prod_demand_design "
            query_old_dsg += "INNER Join tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
            query_old_dsg += "WHERE pdo.id_prod_order = '" + idx_main + "' "
            is_old_design = execute_query(query_old_dsg, 0, True, "", "", "", "")

            'Set the count to 30
            m_CountTo = 30
            ' Disable the start button
            Me.BtnStart.Enabled = False
            ' Enable to stop button
            Me.BtnCancel.Enabled = True
            ' Start the Background Worker working
            BackgroundWorker1.RunWorkerAsync()
        ElseIf id_process = "2" Then
            dtx.Merge(FormProductionPLToWHDet.dt)
            n = dtx.Rows.Count
            'Set the count to 30
            m_CountTo = 30
            ' Disable the start button
            Me.BtnStart.Enabled = False
            ' Enable to stop button
            Me.BtnCancel.Enabled = True
            ' Start the Background Worker working
            BackgroundWorker1.RunWorkerAsync()
        ElseIf id_process = "4" Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        'Set the count to 30
        m_CountTo = 20000
        ' Disable the start button
        Me.BtnStart.Enabled = False
        ' Enable to stop button
        Me.BtnCancel.Enabled = True
        ' Start the Background Worker working
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ' Is the Background Worker do some work?
        If BackgroundWorker1.IsBusy Then
            'If it supports cancellation, Cancel It
            If BackgroundWorker1.WorkerSupportsCancellation Then
                ' Tell the Background Worker to stop working.
                BackgroundWorker1.CancelAsync()
            End If
        End If
        ' Enable to Start Button
        Me.BtnStart.Enabled = True
        ' Disable to Stop Button
        Me.BtnCancel.Enabled = False
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If id_process = "1" Then
            Dim query As String = "Select a.id_product, a.range_awal, a.range_akhir, a.digit_code, b.product_full_code "
            query += "FROM tb_m_product_range a INNER JOIN tb_m_product b On a.id_product = b.id_product  "
            query += "WHERE a.id_prod_order_det = '" + idx + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                'data.Rows(0)("id_product").ToString
                Dim id_product As String = data.Rows(i)("id_product").ToString
                Dim range_awal As Integer = Integer.Parse(data.Rows(i)("range_awal").ToString)
                Dim range_akhir As Integer = Integer.Parse(data.Rows(i)("range_akhir").ToString)
                Dim digit_code As Integer = Integer.Parse(data.Rows(i)("digit_code").ToString)
                Dim product_code As String = data.Rows(i)("product_full_code").ToString
                For j As Integer = range_awal To range_akhir
                    'Console.WriteLine(combine_header_number(product_full_code, j, digit_code))
                    'save to datatable
                    Dim R As DataRow = dtx.NewRow
                    R("id_product") = id_product
                    R("id_prod_order_det") = idx
                    R("product_code") = product_code
                    R("product_counting_code") = combine_header_number("", j, digit_code)
                    R("product_full_code") = combine_header_number(product_code, j, digit_code)
                    dtx.Rows.Add(R)
                    Dim prosentase As Integer = ((j / range_akhir) * (((i + 1) / data.Rows.Count) * 100))
                    BackgroundWorker1.ReportProgress(prosentase)
                    SetLabelText_ThreadSafe(LabelControlPrecentage, "(" + prosentase.ToString + "%)")
                Next
            Next
        ElseIf id_process = "2" Then
            Dim i As Integer = dtx.Rows.Count - 1
            Dim j As Integer = 1
            While (i >= 0)
                If idx = Me.dtx(i)("id_prod_order_det").ToString Then
                    dtx.Rows.RemoveAt(i)
                End If
                ' MsgBox(n.ToString)
                Dim prosentase As Integer = ((j / n) * 100)
                BackgroundWorker1.ReportProgress(prosentase)
                SetLabelText_ThreadSafe(LabelControlPrecentage, "(" + prosentase.ToString + "%)")
                i = i - 1
                j = j + 1
            End While
        ElseIf id_process = "3" Then
            If is_old_design = "1" Then
                Dim query As String = ""
                query += "Select prod.id_product, pdo_det.id_prod_order_det, (prod.product_full_code) As `product_code`, "
                query += "('') AS `product_counting_code`,prod.product_full_code, dsg.is_old_design "
                query += "From tb_prod_order_det pdo_det "
                query += "INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = pdo_det.id_prod_demand_product "
                query += "INNER JOIN tb_m_product prod ON prod.id_product = pd_prod.id_product "
                query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
                query += "WHERE pdo_det.id_prod_order ='" + idx_main + "' "
                dtx = execute_query(query, -1, True, "", "", "", "")
            ElseIf is_old_design = "2"
                Dim query As String = ""
                query += "SELECT a.id_product, pod.id_prod_order_det, a.range_awal, a.range_akhir, a.digit_code, a.product_full_code, a.is_old_design,a.last_print_unique 
                            FROM tb_prod_order_det pod
                            INNER JOIN tb_prod_demand_product pdd ON pdd.id_prod_demand_product=pod.id_prod_demand_product
                            INNER JOIN tb_m_product p ON pdd.id_product=p.id_product
                            INNER JOIN 
                            (
                            SELECT a.id_product, a.id_prod_order_det, MIN(a.range_awal) AS range_awal, MAX(a.range_akhir) AS range_akhir, a.digit_code, b.product_full_code, dsg.is_old_design,b.last_print_unique 
                            FROM tb_m_product_range a 
                            INNER JOIN tb_m_product b ON a.id_product = b.id_product 
                            INNER JOIN tb_m_design dsg ON dsg.id_design = b.id_design 
                            GROUP BY a.id_product 
                            )a ON a.id_product=p.id_product
                            WHERE pod.id_prod_order = '" + idx_main + "' GROUP BY a.id_product "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_product As String = data.Rows(i)("id_product").ToString
                    Dim id_prod_order_det As String = data.Rows(i)("id_prod_order_det").ToString
                    Dim range_awal As Integer = Integer.Parse(data.Rows(i)("range_awal").ToString)
                    'Dim range_akhir As Integer = Integer.Parse(data.Rows(i)("range_akhir").ToString)
                    Dim range_akhir As Integer = Integer.Parse(data.Rows(i)("last_print_unique").ToString)
                    Dim digit_code As Integer = Integer.Parse(data.Rows(i)("digit_code").ToString)
                    Dim product_code As String = data.Rows(i)("product_full_code").ToString
                    Dim is_old_design As String = data.Rows(i)("is_old_design").ToString
                    For j As Integer = range_awal To range_akhir
                        'Console.WriteLine("Ini : " + combine_header_number(product_code, j, digit_code))

                        'save to datatable
                        Dim R As DataRow = dtx.NewRow
                        R("id_product") = id_product
                        R("id_prod_order_det") = id_prod_order_det
                        R("product_code") = product_code
                        R("product_counting_code") = combine_header_number("", j, digit_code)
                        R("product_full_code") = combine_header_number(product_code, j, digit_code)
                        R("is_old_design") = is_old_design
                        dtx.Rows.Add(R)
                        Dim prosentase As Integer = ((j / range_akhir) * (((i + 1) / data.Rows.Count) * 100))
                        BackgroundWorker1.ReportProgress(prosentase)
                        SetLabelText_ThreadSafe(LabelControlPrecentage, "(" + prosentase.ToString + "%)")
                    Next
                Next
            End If
        End If
    End Sub


    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Update the progress bar
        PBProcess.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then
            Me.LabelStatus.Text = "Cancelled"
        Else
            If id_process = "1" Or id_process = "3" Then
                If FormProductionPLToWHDet.dt.Rows.Count > 0 Then
                    FormProductionPLToWHDet.dt.Merge(dtx)
                Else
                    FormProductionPLToWHDet.dt = dtx
                End If
                FormProductionPLToWHDet.GridControl1.DataSource = FormProductionPLToWHDet.dt
            ElseIf id_process = "2" Then
                FormProductionPLToWHDet.GridControl1.DataSource = Nothing
                FormProductionPLToWHDet.dt.Clear()
                FormProductionPLToWHDet.dt.Merge(dtx)
                FormProductionPLToWHDet.GridControl1.DataSource = FormProductionPLToWHDet.dt
            ElseIf id_process = "4" Then
                If str_err = "" Then
                    infoCustom("Prepare order was created succesfully.")
                Else
                    stopCustom("There are some problem with this process. These account are not successfully to create prepare order : " + System.Environment.NewLine + str_err + System.Environment.NewLine + "Please try again later !")
                End If
            End If
            LabelControlPrecentage.Visible = False
            Me.LabelStatus.Text = "Completed"
            Dispose()
        End If
    End Sub

    ' The delegate
    Delegate Sub SetLabelText_Delegate(ByVal [Label] As DevExpress.XtraEditors.LabelControl, ByVal [text] As String)

    ' The delegates subroutine.
    Private Sub SetLabelText_ThreadSafe(ByVal [Label] As DevExpress.XtraEditors.LabelControl, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If [Label].InvokeRequired Then
            Dim MyDelegate As New SetLabelText_Delegate(AddressOf SetLabelText_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[Label], [text]})
        Else
            [Label].Text = [text]
        End If
    End Sub
End Class