<%@ Page Title="" Language="C#" MasterPageFile="/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="ShowMsg.aspx.cs" Inherits="book_shop.Web.ShowMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css">
        .style1 {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            setTimeout(change, 1000)
        })
        function change() {
            var time = $("#second").text();
            time = parseInt(time);
            time--;
            if (time < 1) {
                location.href = "<%=Url%>";
            } else {
                $("#second").text(time);
                setTimeout(change, 1000);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div>  
      <table style="width:490px;height:325px;border:0px;align-content:center;background-image:url(/Images/showinfo.png);padding:0px;border-spacing:0px" >
      <tr>
        <td><table style="width:100%;border:0;padding:0;border-spacing:0;">
          <tr>
            <td style="width:50px;">&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width:40px;">&nbsp;</td>
          </tr>
          <tr>
            <td style="width:50px;">&nbsp;</td>
            <td style="text-align: center">
               
                <%=Msg%>

              </td>
            <td style="width:50px;">&nbsp;</td>
          </tr>
          <tr>
            <td style="width:50px;">&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width:50px;">&nbsp;</td>
          </tr>
          <tr>
            <td style="width:50px;" class="style1">&nbsp;</td>
            <td style="text-align: center">
              <span id="second" style="color:red;font-size:20px;">5</span>秒钟以后自动跳转到 <a href="<%=Url%>"> <%=PageTitle %></a>
                                </td>
            <td style="width:40px;">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table>
    </div>
    </center>
</asp:Content>
