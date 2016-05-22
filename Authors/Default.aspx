<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Authors.Default" %>


<asp:Repeater ID="SubRepeater" runat="server">
    <HeaderTemplate>
               <table border="0" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ФИО</th>
                        </tr>
                    </thead>
                    <tbody>
    </HeaderTemplate>
  <ItemTemplate>
      <tr>
          <td><span><%# Eval("FirstName") %> <%# Eval("LastName") %></span></td>
      </tr>
  </ItemTemplate>
    <FooterTemplate>
                    </tbody>
                </table>
    </FooterTemplate>
</asp:Repeater>