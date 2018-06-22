﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CKEditorDemo.aspx.cs" Inherits="book_shop.Web.Test.CKEditorDemo" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../ckeditor/ckeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <textarea cols="100" id="editor1" name="editor1" rows="10">&lt;p&gt;This is some &lt;strong&gt;sample text&lt;/strong&gt;. You are using &lt;a href="http://ckeditor.com/"&gt;CKEditor&lt;/a&gt;.&lt;/p&gt;</textarea>

            <script type="text/javascript">
                //<![CDATA[
                // Replace the <textarea id="editor1"> with an CKEditor instance.
                var editor = CKEDITOR.replace('editor1');
                //]]>
            </script>
            <input type="submit" value="提交" />
        </div>
    </form>
</body>
</html>
