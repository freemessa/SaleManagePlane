﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Jium.Model;
namespace Jium.BLL
{
	/// <summary>
	/// plib
	/// </summary>
	public partial class plib
	{
		private readonly Jium.DAL.plib dal=new Jium.DAL.plib();
		public plib()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id,string pcode)
		{
			return dal.Exists(id,pcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Jium.Model.plib model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Jium.Model.plib model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long id,string pcode)
		{
			
			return dal.Delete(id,pcode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Jium.Model.plib GetModel(long id,string pcode)
		{
			
			return dal.GetModel(id,pcode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Jium.Model.plib GetModelByCache(long id,string pcode)
		{
			
			string CacheKey = "plibModel-" + id+pcode;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id,pcode);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Jium.Model.plib)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Jium.Model.plib> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Jium.Model.plib> DataTableToList(DataTable dt)
		{
			List<Jium.Model.plib> modelList = new List<Jium.Model.plib>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Jium.Model.plib model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
