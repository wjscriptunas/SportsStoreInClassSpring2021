<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SportsStoreinClassSpring2021.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>

    <p>
        <asp:Label ID="cartUpdateStatusLabel" runat="server"></asp:Label>
    </p>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID " ReadOnly="True" />
            <asp:BoundField DataField="Productname" HeaderText="Product Name" ReadOnly="True" />
            
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="editQty" runat="server" Text='<%#("Quantity").ToString() %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" ReadOnly="True" />
            <asp:BoundField DataField="Subtotal" DataFormatString="{0:c}" HeaderText="Subtotal" ReadOnly="True" />
        </Columns>



    </asp:GridView>
    
    <p> // your cart status
        <asp:Label ID="cartTotalLabel" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Button ID="UpdateQty_Btn" runat="server" Text="Update Cart Quantities" OnClick="UpdateQty_Btn_Click" />

        <asp:Button ID="Checkout_Btn" runat="server" Text="Checkout" OnClick="Checkout_Btn_Click" />
    </p>

</asp:Content>
