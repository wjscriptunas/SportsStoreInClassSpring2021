<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="SportsStoreinClassSpring2021.ProductDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
  <div>

    <asp:Label ID="titleLabel" runat="server" Text="Label"></asp:Label>

    <asp:Image ID="prodImage" runat="server" />

    <asp:Label ID="descLabel" runat="server" Text="Label"></asp:Label>

    <asp:Label ID="priceLabel" runat="server" Text="Label"></asp:Label>

  </div>

    <asp:Button ID="addToCart_Btn" runat="server" Text="Add To Cart" OnClick="addToCart_Btn_Click" />


</asp:Content>
