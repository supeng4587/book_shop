<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="book_shop.Web.Member.ShoppingCart" %>

<%@ Import Namespace="book_shop.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script type="text/javascript">
        function changeBar(opertor, cartId, bookId) {
            var count = $("#txtCount" + bookId).val();
            count = parseInt(count);
            if (opertor == "-") {
                count--;
                if (count < 1) {
                    alert("商品数量最少为'1'");
                    return false;
                }
            } else if (opertor == "+") {
                count++;
                if (count > 200) {
                    alert("商品数量不能大于200");
                    return false;
                }
            } else {
                alert("参数异常");
            }

            $.ajax({
                type: "POST",
                datatype:"text",
                url: "/ashx/EidtCart.ashx",
                data: { "cartId": cartId, "Count": count },
                success:function (data) {
                    if (data == "ok") {
                        //1.刷新数量或者重新给文本框赋值
                        $("#txtCount" + bookId).val(count);
                        //2.总价更新

                    } else {
                        alert("数量更新失败");
                    }
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="98%">
            <tr>
                <td colspan="2">
                    <img height="27"
                        src="/Images/shop-cart-header-blue.gif" width="206" /><img alt=""
                            src="/Images/png-0170.png" /><asp:HyperLink ID="HyperLink1" runat="server"
                                NavigateUrl="~/myorder.aspx">我的订单</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" width="98%">

                    <table cellpadding='0' cellspacing='0' width='100%'>
                        <tr class='align_Center Thead'>
                            <td width='7%' style='height: 30px'>图片</td>
                            <td>图书名称</td>
                            <td width='14%'>单价</td>
                            <td width='11%'>购买数量</td>
                            <td width='7%'>删除图书</td>
                        </tr>


                        <%foreach (CartModel cartModel in CartList)
                            {%>
                        <!--一行数据的开始 -->
                        <tr class='align_Center'>
                            <td style='padding: 5px 0 5px 0;'>
                                <img src='/images/bookcovers/<%=cartModel.Book.ISBN%>.jpg' width="40" height="50" border="0" /></td>
                            <td class='align_Left'><%=cartModel.Book.Title %></td>
                            <td>
                                <span class='price'><%=cartModel.Book.UnitPrice.ToString("0.00")%></span>
                            </td>
                            <td><a href='#none' title='减一' onclick="changeBar('-',<%=cartModel.Id%>,<%=cartModel.Book.Id %>)" style='margin-right: 2px;'>
                                <img src="/Images/bag_close.gif" width="9" height="9" border='none' style='display: inline' /></a>
                                <input type='text' id='txtCount<%=cartModel.Book.Id%>' name='txtCount4945' maxlength='3' style='width: 30px' onkeydown='if(event.keyCode == 13) event.returnValue = false' value='<%=cartModel.Count %>' onfocus='changeTxtOnFocus(this);' onblur="changeTextOnBlur(<%=cartModel.Id%>,this);" />
                                <a href='#none' title='加一' onclick="changeBar('+',<%=cartModel.Id%>,<%=cartModel.Book.Id %>)" style='margin-left: 2px;'>
                                    <img src='/images/bag_open.gif' width="9" height="9" border='none' style='display: inline' /></a>
                            </td>
                            <td>
                                <a href='#none' id='btn_del_1000357315' onclick="removeProductOnShoppingCart(<%=cartModel.Id%>,this)">删除</a></td>
                        </tr>
                        <!--一行数据的结束 -->
                        <%} %>





                        <tr>
                            <td class='align_Right Tfoot' colspan='5' style='height: 30px'>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">&nbsp;&nbsp;&nbsp; 商品金额总计：<span id="tMoney" style="font-size: 20px; color: red; font-weight: bold"> 
                   >0</span>元</td>
                <td>&nbsp;
               <a href="/Member/BookList.aspx">
                   <img alt="" src="/Images/gobuy.jpg" width="103" height="36" border="0" />
               </a><a href="OrderConfirm.aspx">
                   <img src="/Images/balance.gif"
                       border="0" /></a>

                </td>
            </tr>
        </table>
    </div>
    <div id="showResult" style="display: none">
        <span id="errorMsg" style="font-size: 20px; color: red"></span>
    </div>
    <input type="hidden" id="pCount" />
</asp:Content>
