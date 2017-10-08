﻿Imports Newtonsoft.Json
Public Class MemberForm
    Private Sub BtnAccept_Click(sender As Object, e As RoutedEventArgs) Handles BtnAccept.Click
        AddMember()
        AddDept()
    End Sub
    Private Sub MemberForm_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        CmbDept.ItemsSource = DepatmentService.GetDept()
    End Sub
        Private Sub AddDept()
        For Each item In CmbDept.Items
            If CmbDept.Text = item
                Exit Sub
                End If
            Next
        DepatmentService.AddDepatment(CmbDept.Text)
    End Sub
    Private Async Sub AddMember()
         Dim member As Object = New Linq.JObject()
                member.FName = TxtFirstName.Text
                member.LName = TxtLastName.Text
                member.Phone = TxtPhone.Text
                member.Dept = CmbDept.Text
                member.Sem = TxtSemester.Text
        If Await MemberService.AddMember(member) Then
            DashBoard.SnackBarMessageQueue.Enqueue("Registered "+ TxtFirstName.Text+ " as Member.", "UNDO", Sub()
                MsgBox("Undo Clicked")
            End Sub)
        Else
            DashBoard.SnackBarMessageQueue.Enqueue("Failed registering "+ TxtFirstName.Text) 
        End If
    End Sub
End Class
