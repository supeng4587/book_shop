<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="AuditModWord.aspx.cs" Inherits="book_shop.Web.AdminManager.AuditModWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="../Css/tableStyle.css" rel="stylesheet" />
    <script>
        function auditModWord(id) {
            id = parseInt(id);
            if (confirm("你想审核通过" + id + "的评论吗？审核后这条评论将对外显示！")) {
                $.ajax({
                    url:"/ashx/AuditModWord.ashx",
                    type:"POST",
                    dataType:"JSON",
                    data:{"action":"pass","id":id},
                    success:function(data){
                        if(data.state=="ok"){
                            alert(data.measage);
                            window.location.reload("/AdminManager/AuditModWord.aspx?time="+new Date().getMilliseconds);
                        }else{
                            alert(data.measage)
                        }
                    }
                })
            }
        }
        function deleteModWord(id){
            if (confirm("你确认删除 " + id + "'的评论吗?删除后数据将不可恢复！")) {
                $.ajax({
                    url:"/ashx/AuditModWord.ashx",
                    type:"POST",
                    data:{"action":"delete","id":id},
                    dataType:"JSON",
                    success:function(data){
                        if(data.state=="ok"){
                            alert(data.measage);
                            window.location.reload("/AdminManager/AuditModWord.aspx?time="+new Date().getMilliseconds);
                        }else{
                            alert(data.measage)
                        }
                    }
                })
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr style="height:50px"><th colspan="6" style="text-align:center;font-size:24px;color:azure" >审核敏感词</th></tr>
            <tr><th>评论编号</th><th>评论内容</th><th>创建时间</th><th>评论书籍</th><th>审核</th><th>审核</th></tr>
            <%foreach (var item in List)
                {%>
            <tr>
                <td><%=item.Id%></td>
                <td><%=item.Msg %></td>
                <td><%=item.CreateDateTime %></td>
                <td><%=item.BookId %></td>
                <td><input type="button" value="审核通过" onclick="auditModWord('<%=item.Id%>')" /></td>
                <td><input type="button" value="删除评论" onclick="deleteModWord('<%=item.Id%>    ')" /></td>
            </tr>
                <%} %>
        </table>
    </div>
</asp:Content>
