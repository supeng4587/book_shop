﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="FindPwd.aspx.cs" Inherits="book_shop.Web.Member.FindPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnFindPwd").click(function () {
                findPwd();
            });
        });

        function findPwd() {
            var userName = $("#txtName").val();
            var userMail = $("#txtMail").val();
            if (userName != null && userMail != null) {
                $.ajax({
                    url: "/ashx/FindPwd.ashx",
                    type: "POST",
                    data: { "name": userName, "mail": userMail },
                    success: function (data) {
                        alert(data);
                        window.location.href = "/Member/Login.aspx";
                    }
                });
            } else {
                alert("用户名和邮箱不能为空");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>用户名</td>
            <td>
                <input type="text" id="txtName" /></td>
        </tr>
        <tr>
            <td>邮箱</td>
            <td>
                <input type="email" id="txtMail" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <input type="button" id="btnFindPwd" value="找回密码" /></td>
        </tr>
    </table>
</asp:Content>
