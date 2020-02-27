Option Strict On
Public Class averageUnitsShipped
    ''Declarations
    Dim count As Integer = 0
    Dim input As Integer = 0
    Dim average As Double = 0
    Dim unitStats(6) As Integer
    '' when the user uses enter utton to add another number to the running total
    '' if the day 7 number gets entered it calculates average,displays,then disables input
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        If (count < unitStats.Length And Int32.TryParse(txtInput.Text, input) And input > 0 And input < Integer.MaxValue) Then ''validation
            txtListBox.Text = txtListBox.Text + input.ToString() + Environment.NewLine
            unitStats(count) = input
            count += 1
            txtInput.Text = ""
            If (count + 1 > unitStats.Length) Then ''output/calculation begin if true
                btnEnter.Enabled = False
                For i As Integer = 0 To unitStats.Length - 1
                    average += unitStats(i)
                Next
                lblDay.Text = ""
                txtInput.Enabled = False
                average = average / unitStats.Length
                lblOutput.Text = "average units shipped each day in week: " + average.ToString()
            Else
                lblDay.Text = "day" + (count + 1).ToString() '' change the day if its not day 7
            End If
        End If

    End Sub
    '' resets all controls and vairables to default
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        count = 0
        input = 0
        average = 0
        lblDay.Text = "day1"
        lblOutput.Text = ""
        txtInput.Text = ""
        txtListBox.Text = ""
        btnEnter.Enabled = True
        txtInput.Enabled = True
    End Sub
    '' ME CLOSE
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
