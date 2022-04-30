using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 数据字典
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_dictionary {

		/// <summary>
		/// 主键Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 字典编码
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string Code { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime? CreatedTime { get; set; }

		/// <summary>
		/// 创建者Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? CreatedUserId { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string CreatedUserName { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[JsonProperty]
		public string Description { get; set; }

		/// <summary>
		/// 启用
		/// </summary>
		[JsonProperty]
		public bool Enabled { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		[JsonProperty]
		public bool IsDeleted { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[JsonProperty]
		public DateTime? ModifiedTime { get; set; }

		/// <summary>
		/// 修改者Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? ModifiedUserId { get; set; }

		/// <summary>
		/// 修改者
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string ModifiedUserName { get; set; }

		/// <summary>
		/// 字典名称
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string Name { get; set; }

		/// <summary>
		/// 字典父级
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long ParentId { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int Sort { get; set; }

		/// <summary>
		/// 租户Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? TenantId { get; set; }

		/// <summary>
		/// 字典值
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string Value { get; set; }

		/// <summary>
		/// 版本
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long Version { get; set; }

	}

}
