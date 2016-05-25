<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAuthor.aspx.cs" Inherits="Authors.EditAuthor" %>

<%@ Register Src="~/AddBook.ascx" TagPrefix="uc1" TagName="AddBook" %>


<head>
    <link rel="stylesheet" href="Content/Style.css"/>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css"/>
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
        <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script>
        $(function() {
            $('#btnAddBook').click(function() {
                $('#popup').dialog({
                    title: "Добавить книгу",
                    width: 500,
                    height: 500,
                    modal: true,
                    buttons: {
                        save: function() {
                            var $div = $("<div>", { id: "foo", class: "a" });
                            $("#editForm").append($div);
                        },
                        close: function() {
                            $(this).dialog('close');
                        }
                    }
                });
            });
        })
    </script>
</head>


<body>
    <form id="editForm" runat="server">
        <div>
            <asp:Label runat="server" ID="AuthorID" Visible="False"></asp:Label>
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

            <a href="#" id="btnAddBook">Добавить книгу</a>
        

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
                            <span id="BookName<%# Container.ItemIndex + 1 %>"><%# Eval("Name") %></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="l">
                            <label>Жанр:&nbsp;&nbsp;</label>
                        </td>
                        <td >
                            <span id="Genre<%# Container.ItemIndex + 1 %>"><%# Eval("Genre") %></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="l">
                            <label>Кол-во страниц:&nbsp;&nbsp;</label>
                        </td>
                        <td class="r">
                            <span id="TotalPages<%# Container.ItemIndex + 1 %>"><%# Eval("TotalPages") %></span>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button runat="server" Text="Сохранить" ID="Save" OnClick="Save_OnClick"/>
        </div>
        <div>
        <div id="popup" title="Добавить книгу" style="display: none">
            <uc1:AddBook runat="server" ID="AddBook" />
        </div>
            <%--<input id="btnAddBook" type="button" value="AddBook"/>--%>
        </div>
    </form>   
</body> 
