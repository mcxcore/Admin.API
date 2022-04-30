using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 部门
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_dept {

		/// <summary>
		/// 主键Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long deptId { get; set; }

		/// <summary>
		/// 祖级列表
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string ancestors { get; set; }

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
		/// 删除标志（0代表存在 2代表删除）
		/// </summary>
		[JsonProperty, Column(StringLength = 1)]
		public string delFlag { get; set; }

		/// <summary>
		/// 部门名称
		/// </summary>
		[JsonProperty, Column(StringLength = 30)]
		public string deptName { get; set; }

		/// <summary>
		/// 邮箱
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string email { get; set; }

		/// <summary>
		/// 负责人
		/// </summary>
		[JsonProperty, Column(StringLength = 20)]
		public string leader { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int? orderNum { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? parentId { get; set; }

		/// <summary>
		/// 联系电话
		/// </summary>
		[JsonProperty, Column(StringLength = 11)]
		public string phone { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 部门状态（0正常 1停用）
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

	}

}
