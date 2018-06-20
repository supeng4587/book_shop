<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="AddCode.aspx.cs" Inherits="book_shop.Web.AdminManager.AddCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <textarea name="txtMsg" rows="20" cols="100">
    </textarea><br />
    <input type="submit" value="添加词库" />
</asp:Content>
