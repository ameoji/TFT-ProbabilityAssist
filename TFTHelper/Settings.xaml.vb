Imports System.Windows.Forms
Public Class Settings

    Public Sub MoveWindow(sender As Object, e As Primitives.DragDeltaEventArgs)
        Left += e.HorizontalChange
        Top += e.VerticalChange
    End Sub

    Private Sub CloseAPPClick(sender As Object, e As RoutedEventArgs) Handles CloseAPP.Click
        Forms.Application.Exit()
    End Sub
End Class
