<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="QRCodeSample.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=Shift_JIS"/>
    <title>QRコードサンプル</title>
    <style>
        .container {
            width: 800px;
            margin: auto;
        }
        .qrcode-area {
            border: solid 2px #000;
            padding-top: 5px;
            width: 250px;
            height: 250px;
            display: inline-block;
            margin-left: 5px;
            margin-right: 5px;
            background-color: lightgray;
        }
        .qrcode-image {
            display: block;
            margin-left: auto;
            margin-right: auto;
            margin-top: 10px;
        }
        .qrcode-input-area {
            width: 500px;
            margin: 10px auto 0 auto;
            border-collapse:collapse;
        }
        .qrcode-input-area td {
            border: solid 1px #000;
        }
    </style>
</head>
<body>
    <div class="container">
    <h1>QRコードサンプル</h1>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <div class="qrcode-area">
                <asp:Label ID="Label3" runat="server" Text="画像ファイル作成"></asp:Label>
                <asp:Image ID="QRImage" runat="server" class="qrcode-image"/><br />
                <asp:Label ID="lblQRImageFileName" runat="server"></asp:Label>
            </div>
            <div class="qrcode-area">
                <asp:Label ID="Label4" runat="server" Text="HTMLに画像データ埋め込み"></asp:Label>
                <asp:Image ID="QRImage2" runat="server" class="qrcode-image" ViewStateMode="Disabled"/><br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            <div class="qrcode-area">
                <asp:Label ID="Label5" runat="server" Text="画像生成処理"></asp:Label>
                <asp:Image ID="QRImage3" runat="server" class="qrcode-image"/><br />
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </div>
        </div>
        <hr />
        <table class="qrcode-input-area">
            <caption>QRコード文字列</caption>
            <colgroup>
                <col width="200"/>
                <col width="300"/>
            </colgroup>
            <tbody>
                <tr>
                    <td>
                        テキスト1(半角英数)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtItem1" MaxLength="100" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        テキスト2(全角文字)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtItem2" MaxLength="100" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>画像形式</td>
                    <td>
                        <asp:DropDownList ID="lstImageFormat" runat="server">
                            <asp:ListItem Value="png" Selected="True">PNG</asp:ListItem>
                            <asp:ListItem Value="bitmap">BITMAP</asp:ListItem>
                            <asp:ListItem Value="jpg">JPG</asp:ListItem>
                            <asp:ListItem Value="gif">GIF</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;">
                        <input type="submit" value="QRコード生成" />
                    </td>
                </tr>
            </tbody>
        </table>
    </form>


    </div>
</body>
</html>
