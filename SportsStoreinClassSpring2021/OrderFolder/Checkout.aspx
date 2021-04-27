<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="SportsStoreinClassSpring2021.OrderFolder.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" />
            <asp:BoundField DataField="productname" HeaderText="productname" SortExpression="productname" />
        </Columns>
    </asp:GridView>

        <p>
            <asp:Button ID="Button1" runat="server" Text="Checkout" OnClick="CheckoutBtn_click" />
        </p>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ProductID], [Quantity], [price], [Subtotal], [productname] FROM [ShoppingCart] WHERE ([CartID] = @CartID)">
        <SelectParameters>
            <asp:CookieParameter CookieName="SportsStore_CartID" Name="CartID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
