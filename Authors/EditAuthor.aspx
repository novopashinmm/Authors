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
                        save: function () {
                            var j = 1;
                            var endCycle = false;
                            while (!endCycle) {
                                if ($("#BookName" + j).val() != null || $("#TotalPages" + j).val() != null || $("#Genre" + j).val() != null)
                                    j++;
                                else {
                                    endCycle = true;
                                }
                            }
                            var $table = $("<table>", { class: "t1", border: "0", cellpadding: "0", cellspacing: "0", style: "margin-right: auto; margin-left: auto" });
                            for (var i = 1; i < 4; i++) {
                                window['$tr'+i] = $("<tr>");
                                window['$td'+i+'l'] = $("<td width='50%'>", { class: "l" });
                                window['$td'+i+'label'] = $("<label>");
                                window['$td' + i + 'r'] = $("<td width='50%'>", { class: "r" });
                                switch (i) {
                                    case 1:
                                        window['$span' + i] = $("<span>", { id: "BookName" + j });
                                        window['$input' + i] = $("<input>", { type: "text", name: "BookName" + j, hidden : "true", value: $("#AddBook_BookName").val() });
                                        break;
                                    case 2:
                                        window['$span' + i] = $("<span>", { id: "TotalPages" + j });
                                        window['$input' + i] = $("<input>", { type: "text", name: "TotalPages" + j, hidden: "true", value: $("#AddBook_Pages").val() });
                                        break;
                                    case 3:
                                        window['$span' + i] = $("<span>", { id: "Genre" + j });
                                        window['$input' + i] = $("<input>", { type: "text", name: "Genre" + j, hidden: "true", value: $("#AddBook_Genre").val() });
                                        break;
                                default:
                                }
                                
                            }
                            $("#AllInfo").append($table);
                            $table.append($tr1);
                            $table.append($tr2);
                            $table.append($tr3);
                            $tr1.append($td1l);
                            $tr1.append($td1r);
                            $td1r.append($span1);
                            $td1r.append($input1);
                            $td1l.append($td1label);
                            $td1label.append("Название:&nbsp;&nbsp;");
                            $span1.append($("#AddBook_BookName").val());

                            $tr2.append($td2l);
                            $tr2.append($td2r);
                            $td2r.append($span2);
                            $td2r.append($input2);
                            $td2l.append($td2label);
                            $td2label.append("Жанр:&nbsp;&nbsp;");
                            $span2.append($("#AddBook_Genre").val());

                            $tr3.append($td3l);
                            $tr3.append($td3r);
                            $td3r.append($span3);
                            $td3r.append($input3);
                            $td3l.append($td3label);
                            $td3label.append("Кол-во страниц:&nbsp;&nbsp;");
                            $span3.append($("#AddBook_Pages").val());
                            $("#AllInfo").append("<br />");

                            $(this).dialog('close');
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
            <div id="AllInfo">
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
            <asp:Repeater ID="SubRepeater" runat="server">
                <ItemTemplate>
                    <table class="t1" border="0" cellpadding="0" cellspacing="0" style="margin-right: auto; margin-left: auto">
                    <tbody>
                    <tr>
                        <td class="l" width="50%">
                            <label>Название:&nbsp;&nbsp;</label>
                        </td>
                        <td class="r" width="50%">
                            <span id="BookName<%# Container.ItemIndex + 1 %>"><%# Eval("Name") %></span>
                            <input type="text" value="<%# Eval("Name") %>" name="BookName<%# Container.ItemIndex + 1 %>" hidden="true"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="l" width="50%">
                            <label>Жанр:&nbsp;&nbsp;</label>
                        </td>
                        <td width="50%">
                            <span id="Genre<%# Container.ItemIndex + 1 %>"><%# Eval("Genre") %></span>
                            <input type="text" value="<%# Eval("Genre") %>" name="Genre<%# Container.ItemIndex + 1 %>" hidden="true"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="l" width="50%">
                            <label>Кол-во страниц:&nbsp;&nbsp;</label>
                        </td>
                        <td class="r" width="50%">
                            <span id="TotalPages<%# Container.ItemIndex + 1 %>"><%# Eval("TotalPages") %></span>
                            <input type="text" value="<%# Eval("TotalPages") %>" name="TotalPages<%# Container.ItemIndex + 1 %>" hidden="true"/>
                        </td>
                    </tr>
                    </tbody>
                    </table>
                    <br/>
                </ItemTemplate>
            </asp:Repeater>
            </div>
            <asp:Button runat="server" Text="Сохранить" ID="Save" OnClick="Save_OnClick"/>
        </div>
        <div>
        <div id="popup" title="Добавить книгу" style="display: none">
            <uc1:AddBook runat="server" ID="AddBook" />
            <%--<h>BooksName</h><input id="BookName" type="text"/><br/>--%>
        </div>
            <%--<input id="btnAddBook" type="button" value="AddBook"/>--%>
        </div>
    </form>   
</body> 
