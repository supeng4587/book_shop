<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SWFUpload_Demo.aspx.cs" Inherits="book_shop.Web.Test.SWFUpload_Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../SWFUpload/handlers.js"></script>
    <script src="../SWFUpload/swfupload.js"></script>
    <script type="text/javascript">
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                upload_url:"/ashx/Upload.ashx",
            });
        };
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div id="content">
            <div id="swfu_container" style="margin: 0px 10px;">
                <div>
                    aaaaaaa
				<span id="spanButtonPlaceholder"></span>
                    aaaaaa
                </div>
                ssssssssssssss
		    <div id="divFileProgressContainer" style="height: 75px;"></div>
                sssssssssss
		    <div id="thumbnails"></div>
                <img id="showPhoto"></img>
            </div>
        </div>
    </form>
</body>
</html>
