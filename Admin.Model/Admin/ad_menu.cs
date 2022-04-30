using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 菜单权限点管理
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_menu {

		/// <summary>
		/// 主键Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long menuId { get; set; }

		/// <summary>
		/// 组件
		/// </summary>
		[JsonProperty]
		public string component { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		[JsonProperty, Column(StringLength = 64)]
		public string createBy { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime createTime { get; set; }

		/// <summary>
		/// 菜单图标
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string icon { get; set; }

		/// <summary>
		/// 是否缓存
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string isCache { get; set; }

		/// <summary>
		/// 是否为外链
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string isFrame { get; set; }

		/// <summary>
		/// 菜单名
		/// </summary>
		[JsonProperty, Column(StringLength = 50, IsNullable = false)]
		public string menuName { get; set; }

		/// <summary>
		/// 菜单类型（M目录 C菜单 F按钮）
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string menuType { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int? orderNum { get; set; }

		[JsonProperty, Column(DbType = "bigint")]
		public long parentId { get; set; }

		/// <summary>
		/// 路径
		/// </summary>
		[JsonProperty, Column(StringLength = 200)]
		public string path { get; set; }

		/// <summary>
		/// 权限标识
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string perms { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 菜单状态（0正常 1停用）
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string status { get; set; }

		/// <summary>
		/// 更新者
		/// </summary>
		[JsonProperty, Column(StringLength = 64)]
		public string updateBy { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		[JsonProperty]
		public DateTime? updateTime { get; set; }

		/// <summary>
		/// 菜单状态（0显示 1隐藏）
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string visible { get; set; }

	}

}
