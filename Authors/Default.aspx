<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Authors.Default" %>

<head>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css"/>
</head>

<body>
    <form>
        <asp:Repeater ID="SubRepeater" runat="server">
            <HeaderTemplate>
                       <table class="table table-bordered" border="0" cellpadding="0" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>Authors:</th>
                                </tr>
                            </thead>
                            <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><span><a href="EditAuthor.aspx?AuthId=<%# Eval("AuthorID")%>"><%# Eval("FirstName") %> <%# Eval("LastName") %></a></span></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                        <tr class="danger">
                            <td><span><a href="EditAuthor.aspx">Добавить автора</a></span></td>
                        </tr>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>


