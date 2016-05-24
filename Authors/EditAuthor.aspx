<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAuthor.aspx.cs" Inherits="Authors.EditAuthor" %>

<head>
    <link rel="stylesheet" href="Content/Style.css"/>
</head>

<form id="editForm" runat="server">
    <div>
        <table style="margin-left: auto; margin-right: auto">
            <tr>
                <td><asp:Label runat="server" Text="Фамилия"></asp:Label></td>
                <td><asp:TextBox ID="LastName" runat="server"></asp:TextBox><br/></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Имя"></asp:Label></td>
                <td><asp:TextBox ID="FirstName"  runat="server"></asp:TextBox><br/></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Отчество"></asp:Label></td>
                <td><asp:TextBox ID="MiddleName" runat="server"></asp:TextBox><br/></td>
            </tr>
        </table>
        <br/>
        <br/>
        <br/>
        <label style="margin-right: auto">Книги</label>

        <a href="javascript:void(0)" onClick="javascript:window.open('~/AddBook.html', 'okno', 'width=845, height=400, status=no, toolbar=no, menubar=no, scrollbars=yes, resizable=yes');">Добавить книгу</a>
        

        <hr style="width: 75%; color: rgb(151, 7, 11);">
        <asp:Repeater ID="SubRepeater" runat="server" >
            <HeaderTemplate>
                <table class="t1" border="0" cellpadding="0" cellspacing="0" style="margin-right: auto; margin-left: auto">
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="l">
                        <label>Название:&nbsp;&nbsp;</label>
                    </td>
                    <td class="r">
                        <span><%# Eval("Name") %></span>
                    </td>
                </tr>
                <tr>
                    <td class="l">
                        <label>Жанр:&nbsp;&nbsp;</label>
                    </td>
                    <td >
                        <span><%# Eval("Genre") %></span>
                    </td>
                </tr>
                <tr>
                    <td class="l">
                        <label>Кол-во страниц:&nbsp;&nbsp;</label>
                    </td>
                    <td class="r">
                        <span><%# Eval("TotalPages") %></span>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button runat="server" Text="Сохранить"/>
    </div>
</form>    
