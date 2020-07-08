Imports ZXing
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class QRCodeImage
    Inherits System.Web.UI.Page
    Private Shared ENC_SJIS As Encoding = Encoding.GetEncoding("shift_jis")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' 画面パラメータの受け取り
        Response.ContentType = GetMimeType()
        Response.Flush()
        Using bitmap = NewBarcodeWriter().Write(CreateQRCodeString)
            bitmap.Save(Response.OutputStream, GetImageFormat)
        End Using
        Response.End()
    End Sub

    Private Function CreateQRCodeString() As String
        Dim sb As New StringBuilder

        sb.
            Append("12345").
            Append(Base64Encode("あいうえお"))

        Return sb.ToString
    End Function

    Private Function GetMimeType() As String
        'TODO
        Select Case "png"
            Case "bitmap"
                Return "image/bmp"
            Case "jpg"
                Return "image/jpeg"
            Case "gif"
                Return "image/gif"
            Case Else
                Return "image/png"

        End Select
    End Function

    Private Function GetImageFormat() As ImageFormat
        'TODO
        Select Case "png"
            Case "bitmap"
                Return ImageFormat.Bmp
            Case "jpg"
                Return ImageFormat.Jpeg
            Case "gif"
                Return ImageFormat.Gif
            Case Else
                Return ImageFormat.Png

        End Select
    End Function

    Private Shared Function Base64Encode(s) As String
        Return Convert.ToBase64String(ENC_SJIS.GetBytes(s))
    End Function

    Private Shared Function NewBarcodeWriter() As BarcodeWriter
        Return New BarcodeWriter With {
             .Format = BarcodeFormat.QR_CODE,
             .Options = New QrCode.QrCodeEncodingOptions With {
                 .ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
                 .CharacterSet = "ISO-8859-1",
                 .Height = 160,
                 .Width = 160,
                 .Margin = 4
             }
         }
    End Function
End Class