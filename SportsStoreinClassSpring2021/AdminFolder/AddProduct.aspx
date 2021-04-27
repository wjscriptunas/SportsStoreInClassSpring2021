<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SportsStoreinClassSpring2021.AdminFolder.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="form-horizontal">

        <div class ="form-group">

            <asp:Label ID="Label1" runat="server" Text="Product Name: " CssClass="col-md-2">
            </asp:Label>

            <asp:TextBox ID="prodNameTxtbox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Product name must be provided" ControlToValidate="prodNameTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

        <div class ="form-group">

            <asp:Label ID="Label2" runat="server" Text="Product Category: " CssClass="col-md-2">
            </asp:Label>

            <asp:DropDownList ID="prodCatDDL" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CategoryID" runat="server"></asp:DropDownList>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [CategoryID], [Name] FROM [Category]"></asp:SqlDataSource>


        </div>

        <div class ="form-group">

            <asp:Label ID="Label3" runat="server" Text="Product Description: " CssClass="col-md-2">
            </asp:Label>

            <asp:TextBox ID="prodDescTxtbox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Product description must be provided" ControlToValidate="prodDescTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

        <div class ="form-group">

            <asp:Label ID="Label4" runat="server" Text="Product Price: " CssClass="col-md-2">
            </asp:Label>

            <asp:TextBox ID="prodPriceTxtbox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Product price must be provided" ControlToValidate="prodPriceTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

        <div class ="form-group">

            <asp:Label ID="Label5" runat="server" Text="Product Name: " CssClass="col-md-2">
            </asp:Label>

            <asp:FileUpload ID="prodImage" runat="server" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product image must be provided" ControlToValidate="prodImage" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

    </div>

    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" OnClick="AddProductButton_Click" CausesValidation="true" CssClass="btn btn-default"/>

    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>


</asp:Content>
