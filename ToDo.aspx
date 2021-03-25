<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="ToDoApp.ToDo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form" runat="server">
        <div>
            TODO:<asp:TextBox ID="ToDoTextBox" runat="server" TextChanged="TodoChange"></asp:TextBox><br /><asp:Label ForeColor="#8b0000" ID="ErrorTodo" runat="server" Text=""></asp:Label>
        </div>
        <div>
            カテゴリー:
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1" Text="プライベート"></asp:ListItem>
                <asp:ListItem Value="2" Text="営業"></asp:ListItem>
                <asp:ListItem Value="3" Text="人事"></asp:ListItem>
                <asp:ListItem Value="4" Text="開発"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            期限:<asp:TextBox ID="DeadlineTextBox" runat="server" type="date"></asp:TextBox><br /><asp:Label ForeColor="#8b0000" ID="ErrorDeadline" runat="server" Text=""></asp:Label>
        </div>
        <div>
            予算:<asp:TextBox ID="TextBoxBudget" runat="server"></asp:TextBox>円<br /><asp:Label ForeColor="#8b0000" ID="ErrorBudget" runat="server" Text=""></asp:Label>
        </div>
        <div>
            人数:<asp:TextBox ID="sPeopleNumberTextBox" runat="server"></asp:TextBox>人<br /><asp:Label ForeColor="#8b0000" ID="ErrorPeopleNumber" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonRegist" runat="server" Text="登録" />
        </div>

        <asp:GridView ID="ToDoGridView" runat="server" AllowPaging="false" AutoGenerateColumns="false" ShowHeader="true" Visible="true" ShowFooter="false">
            <Columns>
                <asp:TemplateField>
                        <HeaderTemplate>TODO</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblValue1" Text='<%# DataBinder.Eval(Container.DataItem, "Todo")%>' runat="server" /></p>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                        <HeaderTemplate>カテゴリ</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblValue2" Text='<%# DataBinder.Eval(Container.DataItem, "Category")%>' runat="server" /></p>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                        <HeaderTemplate>期限</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblValue3" Text='<%# DataBinder.Eval(Container.DataItem, "Deadline")%>' runat="server" /></p>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                        <HeaderTemplate>予算</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblValue4" Text='<%# DataBinder.Eval(Container.DataItem, "Budget")%>' runat="server" /></p>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                        <HeaderTemplate>人数</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblValue5" Text='<%# DataBinder.Eval(Container.DataItem, "PeopleNumber")%>' runat="server" /></p>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                        <HeaderTemplate>一人当たり</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblValue6" Text='<%# DataBinder.Eval(Container.DataItem, "PerBudget")%>' runat="server" /></p>
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
