Imports ZXing
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class Index
    Inherits System.Web.UI.Page

    Private Shared ENC_SJIS As Encoding = Encoding.GetEncoding("shift_jis")
    Private Shared QR_IMAGE_NAME As String = "sample_qr"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If IsPostBack Then
            SupplyItem()

            ' ファイル生成
            CreateQRImage(CreateQRCodeString(), QRImageFileName(), GetImageFormat)
            QRImage.ImageUrl = $"~/Images/Tmp/{QRImageFileName()}?time={DateTime.Now.Ticks.ToString}"
            lblQRImageFileName.Text = QRImageFileName()

            ' 画像データ貼り付け
            ' IE制限あり
            ' IE7非対応
            ' IE8 32KB以上不可能
            ' ViewStateにデータが記録されているため、ViewStateMode=Disableを指定すること。
            QRImage2.ImageUrl = GetQRImageBase64String(CreateQRCodeString(), GetImageFormat)
            Label1.Text = lstImageFormat.SelectedValue

            ' 生成専用ページへのリクエストをセット
            ' imgリクエストは、原則get通信になる。パラメータはget or sessionで渡す
            QRImage3.ImageUrl = $"QRCodeImage.aspx?time={DateTime.Now.Ticks.ToString}"
            Label2.Text = lstImageFormat.SelectedValue
        Else
            InitDisplay()
        End If

    End Sub

    Private Sub SupplyItem()
        Dim supply As Action(Of TextBox, String) = Sub(t, def_val) If (String.IsNullOrEmpty(t.Text)) Then t.Text = def_val

        supply(txtItem1, "Mi, id sollicitudin urna fermentum ut fusce varius nisl ac ipsum gravida vel pretium tellus.")
        supply(txtItem2, "あいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねの")
    End Sub


    Private Sub InitDisplay()
        txtItem1.Text = "Mi, id sollicitudin urna fermentum ut fusce varius nisl ac ipsum gravida vel pretium tellus."
        txtItem2.Text = "あいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねの"
    End Sub

    Private Function CreateQRCodeString() As String
        Dim sb As New StringBuilder

        sb.
            Append(txtItem1.Text).
            Append(Base64Encode(txtItem2.Text))

        Return sb.ToString
    End Function

    Private Function QRImageFileName() As String
        Return $"{QR_IMAGE_NAME}.{GetImageExt()}"
    End Function

    Private Shared Function Base64Encode(s) As String
        Return Convert.ToBase64String(ENC_SJIS.GetBytes(s))
    End Function


    Private Sub CreateQRImage(targetString As String, filename As String, imgFormat As ImageFormat)
        Using bitmap = NewBarcodeWriter().Write(targetString)
            ' 画像はbitmapのほかに、png, jpgなど選択可能
            bitmap.Save(Server.MapPath($"./Images/Tmp/{filename}"), imgFormat)

        End Using
    End Sub

    Private Function GetQRImageBase64String(targetString As String, imgFormat As ImageFormat) As String
        Using bitmap = NewBarcodeWriter().Write(targetString)
            Using ms = New MemoryStream()
                bitmap.Save(ms, imgFormat)
                Return $"data:{GetMimeType()};base64,{Convert.ToBase64String(ms.ToArray)}"
            End Using
        End Using
    End Function


    Private Function GetImageExt() As String

        Select Case lstImageFormat.SelectedValue
            Case "bitmap"
                Return "bmp"
            Case "jpg"
                Return "jpg"
            Case "gif"
                Return "gif"
            Case Else
                Return "png"

        End Select
    End Function


    Private Function GetMimeType() As String

        Select Case lstImageFormat.SelectedValue
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

        Select Case lstImageFormat.SelectedValue
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

    Private Shared Function NewBarcodeWriter() As BarcodeWriter
        Return New BarcodeWriter With {
             .Format = BarcodeFormat.QR_CODE,
             .Options = New QrCode.QrCodeEncodingOptions With {
                 .ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M, ' 誤り訂正レベル:M:15%まで訂正可能
                 .CharacterSet = "ISO-8859-1", ' 文字セット。デフォルト値は"ISO-8859-1"であり、日本語扱えず。Shift_JISを使いたい場合、特別な対応必要。
                 .Height = 160,
                 .Width = 160,
                 .Margin = 4  ' 上下左右のマージンをセル数で指定。デフォルトは4。QRコードには、周囲に4セル以上のマージンが必要。通常は4でOK。ただし、表示画像の周りに余白を用意するのであれば0でも良い。
             }
         }
    End Function

End Class