Imports ZXing
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Index
    Inherits System.Web.UI.Page

    Private Shared QR_IMAGE_NAME As String = "sample_qr"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitDisplay()

        If IsPostBack Then
            CreateQRImage(CreateQRCodeString(), QRImageFileName(), lstImageFormat.SelectedValue)
            QRImage.ImageUrl = $"~/Images/{QRImageFileName()}?time={DateTime.Now.Ticks.ToString}"
            Me.lblQRImageFileName.Text = QRImageFileName()
        End If

    End Sub


    Private Sub InitDisplay()
        ' イメージファイルの削除
    End Sub

    Private Function CreateQRCodeString() As String
        Dim sb As New StringBuilder

        sb.
            Append(If(String.IsNullOrEmpty(txtItem1.Text), "txtItem1", txtItem1.Text)).
            Append(If(String.IsNullOrEmpty(txtItem2.Text), "txtItem2", Base64Encode(txtItem2.Text)))

        Return sb.ToString
    End Function

    Private Function QRImageFileName() As String
        Dim ext As String = "png"
        Select Case lstImageFormat.SelectedValue
            Case "bitmap"
                ext = "bmp"
            Case "jpg"
                ext = "jpg"
            Case Else

        End Select
        Return $"{QR_IMAGE_NAME}.{ext}"
    End Function

    Private Shared Function Base64Encode(s) As String
        Dim encSJIS As Encoding = Encoding.GetEncoding("shift_jis")
        Return Convert.ToBase64String(encSJIS.GetBytes(s))
    End Function


    Private Sub CreateQRImage(targetString As String, filename As String, imageFormatName As String)
        Dim bw = New BarcodeWriter With {
             .Format = BarcodeFormat.QR_CODE,
             .Options = New QrCode.QrCodeEncodingOptions With {
                 .ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
                 .CharacterSet = "ISO-8859-1",
                 .Height = 160,
                 .Width = 160,
                 .Margin = 4
             }
         }

        Dim imgFmt As ImageFormat = ImageFormat.Png
        Select Case imageFormatName
            Case "bitmap"
                imgFmt = ImageFormat.Bmp
            Case "jpg"
                imgFmt = ImageFormat.Jpeg
            Case Else

        End Select

        Using bitmap = bw.Write(targetString)
            ' 画像はbitmapのほかに、png, jpgなど選択可能
            bitmap.Save(Server.MapPath($"./Images/{filename}"), imgFmt)

        End Using
    End Sub

End Class