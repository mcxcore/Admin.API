using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 岗位类
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_post {

		/// <summary>
		/// 岗位ID
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long postId { get; set; }

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
		/// 岗位编码
		/// </summary>
		[JsonProperty, Column(StringLength = 64, IsNullable = false)]
		public string postCode { get; set; }

		/// <summary>
		/// 岗位名称
		/// </summary>
		[JsonProperty, Column(StringLength = 50, IsNullable = false)]
		public string postName { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int postSort { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 状态（0正常 1停用）
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
