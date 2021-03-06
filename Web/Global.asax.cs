﻿using System;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using LTP.Accounts.Bus;
using System.Text.RegularExpressions;

namespace book_shop.Web 
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
        /// <summary>
        /// Web应用程序第一次启动时调用该方法，并且该方法之被调用一次。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void Application_Start(Object sender, EventArgs e)
		{		
           #region 默认蓝
            						
			Application["1xtop1_bgimage"]="images/top-1.gif"; //顶框背景图片
			Application["1xtop2_bgimage"]="images/top-2.gif"; //顶框背景图片
			Application["1xtop3_bgimage"]="images/top-3.gif"; //顶框背景图片
			Application["1xtop4_bgimage"]="images/top-4.gif"; //顶框背景图片
			Application["1xtop5_bgimage"]="images/top-5.gif"; //顶框背景图片
			Application["1xtopbj_bgimage"]="images/top-bj.gif"; //顶框背景图片

			Application["1xtopbar_bgimage"]="images/topbar_01.jpg"; //顶框工具条背景图片
			Application["1xfirstpage_bgimage"]="images/dbsx_01.gif"; //首页背景图片
			Application["1xforumcolor"]="#f0f4fb";
			Application["1xleft_width"]="204"; //左框架宽度
			
			Application["1xtree_bgcolor"]="#e3eeff"; //左框架树背景色
			Application["1xleft1_bgimage"]="images/left-1.gif"; 
			Application["1xleft2_bgimage"]="images/left-2.gif"; 
			Application["1xleft3_bgimage"]="images/left-3.gif"; 
			Application["1xleftbj_bgimage"]="images/left-bj.gif"; 

			Application["1xspliter_color"]="#6B7DDE"; //分隔块色

			Application["1xdesktop_bj"]="";//images/right-bj.gif
			Application["1xdesktop_bgimage"]="images/desktop_01.gif";//right.gif

			Application["1xtable_bgcolor"]="#F5F9FF"; //最外层表格背景
			Application["1xtable_bordercolorlight"]="#4F7FC9"; //中层表格亮边框
			Application["1xtable_bordercolordark"]="#D3D8E0"; //中层表格暗边框
			Application["1xtable_titlebgcolor"]="#E3EFFF"; //中层表格标题栏

			Application["1xform_requestcolor"]="#E78A29"; //表单中必填字段*颜色
			Application["1xfirstpage_topimage"]="images/top_01.gif";
			Application["1xfirstpage_bottomimage"]="images/bottom_01.gif";
			Application["1xfirstpage_middleimage"]="images/bg_01.gif";
			#endregion 		

		}
 
        /// <summary>
        /// 开始会话（用户通过浏览器第一次访问网站的某个页面，这时建立会话，但是当该用户通过浏览器再次访问其他的页面时，该方法不会被执行。SessionId）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void Session_Start(Object sender, EventArgs e)
		{
            ///Application:服务端的状态保持机制，放在该对象中的数据时共享的。Cache
            Application.Lock();
            int count = Convert.ToInt32(Application["count"]);
            count++;
            Application["count"] = count;
            Application.UnLock();
			//Session["Style"]=1;
		}

        //URL重写，有利于seo
        //将带参数的URL改写成不带参数的URL
        //BookDetail.aspx?id=2 BookDetail_2.aspx
        //写在了请求管道的第一个事件中

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
            string url = Request.AppRelativeCurrentExecutionFilePath;
            //有点MVC路由的意思
            Match match = Regex.Match(url, @"~/BookDetail_(\d+).aspx");
            if (match.Success)
            {
                Context.RewritePath("/BookDetail.aspx?id=" + match.Groups[1].Value);
            }
		}
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_Error(Object sender, EventArgs e)
		{
			
		}
		protected void Session_End(Object sender, EventArgs e)
		{		
			
		}
		protected void Application_End(Object sender, EventArgs e)
		{
		}
			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

