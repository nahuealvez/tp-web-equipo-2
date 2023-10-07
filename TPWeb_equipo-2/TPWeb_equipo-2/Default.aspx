<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column pt-3 gap-3">
    <h2>Carrito de compras</h2>
    <div class="d-flex flex-row gap-3">
        <%
            foreach (dominio.Articulo articulo in ListaArticulo)
            {
                %>
                <div class="row g-4">
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%:articulo.UrlImagen %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%: articulo.Nombre %></h5>
                                <p class="card-text"><%: articulo.Descripcion %></p>
                            </div>
                        </div>
                    </div>
                </div>
        <%  } %>

    </div>

    </div>
</asp:Content>
