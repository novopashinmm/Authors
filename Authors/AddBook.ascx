<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddBook.ascx.cs" Inherits="Authors.AddBook" %>


<table>
    <tr>
        <td><label>Название:</label></td>
        <td><asp:TextBox runat="server" ID="BookName"></asp:TextBox></td>
    </tr>
    <tr>
        <td><label>Жанр:</label></td>
        <td><asp:TextBox runat="server" ID="Genre"></asp:TextBox></td>
    </tr>
    <tr>
        <td><label>Кол-во страниц:</label></td>
        <td><asp:TextBox runat="server" ID="Pages"></asp:TextBox></td>
    </tr>
</table>



