<%@ Page Title="" Language="C#" MasterPageFile="/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="book_shop.Web.Member.Register1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }

        .regnow {
            width: 300px;
            margin-left: 30px;
            height: 40px;
            background: #db2f2f;
            border: none;
            color: #FFF;
            font-size: 15px;
            font-weight: 700;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#userMail").blur(function () {
                validateEmail();
            });
            $("#validateCode").blur(function () {
                validateUserCode();
            });
            $("#btnRegister").click(function () {//注册
                if ($("#userMail").val() == "") { $("#msg").text("邮箱不能为空!!"); return false }
                if ($("#validateCode").val() == "") { $("#validateCodeMsg").text("验证码不能为空!!"); return false }
                var par = $("#aspnetForm").serializeArray();
                //$.post("/ashx/UserRegister.ashx", par, function (data) {
                //    $("#validateCodeMsg").text(data);
                //});
                $.ajax({
                    url: "/ashx/UserRegister.ashx",
                    type: "POST",
                    data: par,
                    success: function (data) {
                        var serverdata = data.split(":");
                        if (serverdata[0] == "ok") {
                            window.location.href = "/Default.aspx";
                        } else {
                            window.location.href = "/ShowMsg.aspx?msg=" + serverdata[1] + "&txt=首页" + "&redirect=/Default.aspx"
                        }
                    }
                });

            });
            $("#ValidateCode").bind("click", function () {
                this.src = "/ashx/ValidateCode.ashx?time=" + new Date().getMilliseconds();
            });
            //$("#ValidateCode").click(function () {
            //    $("#ValidateCode").attr("src", "/ashx/ValidateCode.ashx?time=" + new Date().getMilliseconds());
            //})
        });
        //验证邮箱
        function validateEmail() {
            var val = $("#userMail").val();
            if (val != "") {
                var reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                if (reg.test(val)) {
                    $("#msg").css("display", "none");
                    //$.post("/ashx/ValidateReg.ashx", { "action": "mail", "userMail": val }, function (data) {
                    //    $("#msg").css("display", "block");
                    //    $("#msg").text(data);
                    //});
                    $.ajax({
                        url: "/ashx/ValidateReg.ashx",
                        type: "POST",
                        data: { "action": "mail", "userMail": val },
                        success: function (data) {
                            $("#msg").css("display", "block");
                            $("#msg").text(data);
                        }
                    })
                } else {
                    $("#msg").text("邮箱格式错误!!");

                }

            } else {
                $("#msg").text("邮箱不能为空!!");
            }
        }
        //验证校验码
        function validateUserCode() {
            var code = $("#validateCode").val();
            if (code != "") {
                var reg = /^[0-9]*$/;
                if (reg.test(code)) {
                    //$.post("/ashx/ValidateReg.ashx", { "action": "code", "validateCode": code }, function (data) {
                    //    $("#validateCodeMsg").text(data);
                    //});
                    $.ajax({
                        url: "/ashx/ValidateReg.ashx",
                        type: "POST",
                        data: { "action": "code", "validateCode": code },
                        success: function (data) {
                            $("#validateCodeMsg").text(data);
                        }
                    });
                }
                else {
                    $("#validateCodeMsg").text("请按验证码图片填写!!");
                }

            } else {
                $("#validateCodeMsg").text("验证码不能为空!!");
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: small">
        <table width="80%" height="28" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 10px">
                    <img src="/Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
                <td bgcolor="#DDDDCC"><span class="STYLE1" style="height:22px">注册新用户</span></td>
                <td width="10">
                    <img src="/Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
            </tr>
        </table>

        <table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
        </table>
        <center>
        <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
            <tr>
                <td height="33" colspan="2">
                    <p class="STYLE2" style="text-align: center">注册新帐户方便又容易</p>
                </td>
            </tr>
            <tr>
                <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
                <td valign="top" width="37%" align="left" style="height: 26px">
                    <input type="text" name="txtName" /></td>
            </tr>
            <tr>
                <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
                <td valign="top" width="37%" align="left">
                    <input type="text" name="txtRealName" /></td>
            </tr>
            <tr>
                <td width="24%" height="26" align="center" valign="top">密码：</td>
                <td valign="top" width="37%" align="left">
                    <input type="password" name="txtPwd" /></td>
            </tr>
            <tr>
                <td width="24%" height="26" align="center" valign="top">确认密码：</td>
                <td valign="top" width="37%" align="left">
                    <input type="password" name="txtConfirmPwd" /></td>
            </tr>
            <tr>
                <td width="24%" height="26" align="center" valign="top">Email：</td>
                <td valign="top" width="37%" align="left">
                    <input type="text" name="txtEmail" id="userMail" /><span id="msg" style="font-size: 14px; color: red"></span></td>
            </tr>
            <tr>
                <td width="24%" height="26" align="center" valign="top">地址：</td>
                <td valign="top" width="37%" align="left">
                    <input type="text" name="txtAddress" /></td>
            </tr>
            <tr>
                <td width="24%" height="26" align="center" valign="top">手机：</td>
                <td valign="top" width="37%" align="left">
                    <input type="text" name="txtPhone" /></td>
            </tr>
            <tr>
                <td width="24%" align="center" valign="top" class="auto-style1">验证码：</td>
                <td valign="top" width="37%" align="left" class="auto-style1">
                    <input type="text" name="txtCode" id="validateCode" /><span id="validateCodeMsg" style="font-size: 14px; color: red"></span><img src="/ashx/ValidateCode.ashx" id="ValidateCode" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="button" value="注册" class="regnow" id="btnRegister" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center">&nbsp;</td>
            </tr>
        </table>
            </center>
    </div>
</asp:Content>
