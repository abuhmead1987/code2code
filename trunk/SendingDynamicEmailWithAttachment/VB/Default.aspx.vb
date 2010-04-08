Imports System.Net.Mail
Imports System.Configuration
Imports System.Net.Configuration
Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page

    Public Shared ReadOnly Property FormAddress() As String
        Get
            Dim cfg As SmtpSection = ConfigurationManager.GetSection _
            ("system.net/mailSettings/smtp")
            Return cfg.Network.UserName
        End Get
    End Property

    Public Function SendMail(ByVal subject As String, ByVal body As String, ByVal toAddress As String, ByVal isHtml As Boolean, ByVal isSSL As Boolean) As String
        Try
            Using mail As New MailMessage
                mail.From = New MailAddress(FormAddress, "code2code.info")
                mail.To.Add(toAddress)
                mail.Subject = subject
                mail.Body = body
                mail.IsBodyHtml = isHtml
                Dim client As SmtpClient = New SmtpClient()
                client.EnableSsl = isSSL
                If FileUpload1.HasFile Then
                    mail.Attachments.Add(New Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName))
                End If
                client.Send(mail)
            End Using
        Catch ex As SmtpException
            Return ex.Message
        End Try
        Return "Send email successful!"
    End Function

    Protected Sub ButtonSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSend.Click
        Dim sr As StreamReader = New StreamReader(Server.MapPath("template/Contact.htm"))
        sr = File.OpenText(Server.MapPath("template/Contact.htm"))
        Dim content As String = sr.ReadToEnd()
        content = content.Replace("[Sender]", TextBoxName.Text.Trim())
        content = content.Replace("[Email]", "quachngochoangnguyen@gmail.com")
        content = content.Replace("[Content]", TextBoxContent.Text)
        content = content.Replace("[DateTime]", DateTime.Now.ToShortDateString())
        Try
            Response.Write(SendMail("Liên hệ khách hàng", content, TextBoxEmail.Text.Trim(), True, True))
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

End Class
