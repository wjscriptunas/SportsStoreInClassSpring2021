<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="SportsStoreinClassSpring2021.ProductDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
  <div>
      
      <p><asp:Label ID="titleLabel" runat="server" Text="Label"></asp:Label>
      </p>
      
      <p><asp:Image ID="prodImage" runat="server" />
      </p>
      
      <p><asp:Label ID="descLabel" runat="server" Text="Label"></asp:Label>
      </p>
    
      <p><asp:Label ID="priceLabel" runat="server" Text="Label"></asp:Label>
      </p>

  </div>

    <asp:Button ID="addToCart_Btn" runat="server" Text="Add To Cart" OnClick="addToCart_Btn_Click" />


</asp:Content>
