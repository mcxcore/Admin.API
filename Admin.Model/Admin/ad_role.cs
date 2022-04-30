using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 角色
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_role {

		/// <summary>
		/// 角色ID
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long roleId { get; set; }

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
		/// 数据范围（1：全部数据权限 2：自定数据权限 3：本部门数据权限 4：本部门及以下数据权限）
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string dataScope { get; set; }

		/// <summary>
		/// 删除标志（0代表存在 2代表删除）
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string delFlag { get; set; }

		/// <summary>
		/// 部门树选择项是否关联显示
		/// </summary>
		[JsonProperty]
		public bool? deptCheckStrictly { get; set; }

		/// <summary>
		/// 菜单树选择项是否关联显示
		/// </summary>
		[JsonProperty]
		public bool? menuCheckStrictly { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 角色权限字符串
		/// </summary>
		[JsonProperty, Column(StringLength = 100, IsNullable = false)]
		public string roleKey { get; set; }

		/// <summary>
		/// 角色名称
		/// </summary>
		[JsonProperty, Column(StringLength = 30, IsNullable = false)]
		public string roleName { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int roleSort { get; set; }

		/// <summary>
		/// 角色状态（0正常 1停用）
		/// </summary>
		[JsonProperty, Column(StringLength = 1, IsNullable = false)]
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

	}

}
