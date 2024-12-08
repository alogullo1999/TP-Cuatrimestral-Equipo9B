﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionProveedor.aspx.cs" Inherits="Heladeria.GestionProveedor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-center">
     
                <div class="row mb-3">
                    <div class="col text-center">
                        <asp:Label ID="lblIngresarID" runat="server" CssClass="form-label" Text="Ingresar ID:"></asp:Label>
                        <asp:TextBox ID="txtID" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" />
                    </div>
                </div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success mx-2" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning mx-2" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminar_Click" />
            </div>
        </div>

        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False"  CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="IdProveedor" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>