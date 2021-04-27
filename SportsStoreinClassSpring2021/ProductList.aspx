<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="SportsStoreinClassSpring2021.ProductList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:DataList ID="DataList1" runat="server"> 
        <ItemTemplate>
            <h3>
                <a href="ProductDetail.aspx?ProductID=<%#Eval("ProductID").ToString() %>">
                    <%#Eval("Name").ToString() %>
                </a>
            </h3>

          
                <a href="ProductDetail.aspx?ProductID=<%#Eval("ProductID").ToString() %>">
                    <img src="Images/<%#Eval("Thumbnail").ToString() %>" />
                </a>
           
            <p>
                <%#Eval("Description").ToString() %>
                </p>

            <p>
                <%#Eval("Price").ToString() %> 
                </p>

        </ItemTemplate>
    </asp:DataList>


</asp:Content>

