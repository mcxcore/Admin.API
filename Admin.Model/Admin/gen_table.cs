using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 代码生成表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class gen_table {

		/// <summary>
		/// 主键
		/// </summary>
		[JsonProperty, Column(DbType = "int", IsPrimary = true, IsIdentity = true)]
		public int tableId { get; set; }

		/// <summary>
		/// 表名
		/// </summary>
		[JsonProperty, Column(IsPrimary = true, IsNullable = false)]
		public string tableName { get; set; }

		/// <summary>
		/// 业务名
		/// </summary>
		[JsonProperty]
		public string businessName { get; set; }

		/// <summary>
		/// 类名
		/// </summary>
		[JsonProperty]
		public string className { get; set; }

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
		/// 功能作者
		/// </summary>
		[JsonProperty]
		public string functionAuthor { get; set; }

		/// <summary>
		/// 功能名
		/// </summary>
		[JsonProperty]
		public string functionName { get; set; }

		/// <summary>
		/// 生成路径
		/// </summary>
		[JsonProperty]
		public string genPath { get; set; }

		/// <summary>
		/// 生成代码方式（0zip压缩包 1自定义路径）
		/// </summary>
		[JsonProperty, Column(DbType = "char(1)")]
		public string genType { get; set; }

		/// <summary>
		/// 模块名
		/// </summary>
		[JsonProperty]
		public string moduleName { get; set; }

		/// <summary>
		/// 其他生成选项
		/// </summary>
		[JsonProperty]
		public string options { get; set; }

		/// <summary>
		/// 生成包路径
		/// </summary>
		[JsonProperty]
		public string packageName { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 表描述
		/// </summary>
		[JsonProperty]
		public string tableComment { get; set; }

		/// <summary>
		/// 使用的模板（crud单表操作 tree树表操作）
		/// </summary>
		[JsonProperty]
		public string tplCategory { get; set; }

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
