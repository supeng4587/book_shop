﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace book_shop.DAL
{
	/// <summary>
	/// 数据访问类:RoleDepartmentDAL
	/// </summary>
	public partial class RoleDepartmentDAL
	{
		public RoleDepartmentDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Role_ID", "RoleDepartment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Role_ID,int Department_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RoleDepartment");
			strSql.Append(" where Role_ID=@Role_ID and Department_ID=@Department_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Department_ID", SqlDbType.Int,4)			};
			parameters[0].Value = Role_ID;
			parameters[1].Value = Department_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(book_shop.Model.RoleDepartmentModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RoleDepartment(");
			strSql.Append("Role_ID,Department_ID)");
			strSql.Append(" values (");
			strSql.Append("@Role_ID,@Department_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Department_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Role_ID;
			parameters[1].Value = model.Department_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(book_shop.Model.RoleDepartmentModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RoleDepartment set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("Role_ID=@Role_ID,");
			strSql.Append("Department_ID=@Department_ID");
			strSql.Append(" where Role_ID=@Role_ID and Department_ID=@Department_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Department_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Role_ID;
			parameters[1].Value = model.Department_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Role_ID,int Department_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoleDepartment ");
			strSql.Append(" where Role_ID=@Role_ID and Department_ID=@Department_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Department_ID", SqlDbType.Int,4)			};
			parameters[0].Value = Role_ID;
			parameters[1].Value = Department_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.RoleDepartmentModel GetModel(int Role_ID,int Department_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Role_ID,Department_ID from RoleDepartment ");
			strSql.Append(" where Role_ID=@Role_ID and Department_ID=@Department_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Department_ID", SqlDbType.Int,4)			};
			parameters[0].Value = Role_ID;
			parameters[1].Value = Department_ID;

			book_shop.Model.RoleDepartmentModel model=new book_shop.Model.RoleDepartmentModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.RoleDepartmentModel DataRowToModel(DataRow row)
		{
			book_shop.Model.RoleDepartmentModel model=new book_shop.Model.RoleDepartmentModel();
			if (row != null)
			{
				if(row["Role_ID"]!=null && row["Role_ID"].ToString()!="")
				{
					model.Role_ID=int.Parse(row["Role_ID"].ToString());
				}
				if(row["Department_ID"]!=null && row["Department_ID"].ToString()!="")
				{
					model.Department_ID=int.Parse(row["Department_ID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Role_ID,Department_ID ");
			strSql.Append(" FROM RoleDepartment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Role_ID,Department_ID ");
			strSql.Append(" FROM RoleDepartment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM RoleDepartment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Department_ID desc");
			}
			strSql.Append(")AS Row, T.*  from RoleDepartment T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "RoleDepartment";
			parameters[1].Value = "Department_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

