<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="QRCodeSample.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=Shift_JIS"/>
    <title>QR�R�[�h�T���v��</title>
    <style>
        .qrcode-area {
            border: solid 2px #000;
            width: 300px;
            height: 300px;
            margin: 10px auto 0 auto;
        }
        .qrcode-image {
            margin: auto;
        }
        table td {
            border: solid 1px #000;
        }
    </style>
</head>
<body>
    <h1>QR�R�[�h�T���v��</h1>
    <form id="form1" runat="server">
        <div class="qrcode-area">
            <asp:Image ID="QRImage" runat="server" CssClass="qrcode-image"/><br />
            <asp:Label ID="lblQRImageFileName" runat="server"></asp:Label>
        </div>
        <hr />
        <table style="width: 500px; margin: 10px auto 0 auto; border-collapse:collapse;">
            <caption>QR�R�[�h������</caption>
            <colgroup>
                <col width="150"/>
                <col width="250"/>
            </colgroup>
            <tbody>
                <tr>
                    <td>
                        �e�L�X�g1(���p�p��)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtItem1" MaxLength="100" Width="200" style="margin-bottom:5px;"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        �e�L�X�g2(�S�p����)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtItem2" MaxLength="100" Width="200" style="margin-bottom:5px;"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>�摜�`��</td>
                    <td>
                        <asp:DropDownList ID="lstImageFormat" runat="server">
                            <asp:ListItem Value="bitmap">BITMAP</asp:ListItem>
                            <asp:ListItem Value="jpg">JPG</asp:ListItem>
                            <asp:ListItem Value="png" Selected="True">PNG</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right;">
                        <input type="submit" value="QR�R�[�h����" />
                    </td>
                </tr>
            </tbody>
        </table>

    </form>
</body>
</html>
