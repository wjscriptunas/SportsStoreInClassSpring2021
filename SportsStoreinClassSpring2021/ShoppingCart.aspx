<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SportsStoreinClassSpring2021.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID " ReadOnly="True" />
            <asp:BoundField DataField="Productname" HeaderText="Product Name" ReadOnly="True" />
            
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="qtyTextBox" runat="server" Text='<%#("Quantity").ToString() %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" ReadOnly="True" />
            <asp:BoundField DataField="Subtotal" DataFormatString="{0:c}" HeaderText="Subtotal" ReadOnly="True" />
        </Columns>



    </asp:GridView>

</asp:Content>
