using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 代码生成字段表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class gen_table_column {

		/// <summary>
		/// 编号
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long columnId { get; set; }

		/// <summary>
		/// 列描述
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string columnComment { get; set; }

		/// <summary>
		/// 列名
		/// </summary>
		[JsonProperty, Column(StringLength = 200)]
		public string columnName { get; set; }

		/// <summary>
		/// 列类型
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string columnType { get; set; }

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
		/// 字典类型
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string dictType { get; set; }

		/// <summary>
		/// 显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）
		/// </summary>
		[JsonProperty, Column(StringLength = 200)]
		public string htmlType { get; set; }

		/// <summary>
		/// 是否编辑字段（1是）
		/// </summary>
		[JsonProperty, Column(DbType = "char(2)")]
		public string isEdit { get; set; }

		/// <summary>
		/// 是否为插入字段（1是）
		/// </summary>
		[JsonProperty, Column(DbType = "char(2)")]
		public string isInsert { get; set; }

		/// <summary>
		/// 是否列表字段（1是）
		/// </summary>
		[JsonProperty, Column(DbType = "char(2)")]
		public string isList { get; set; }

		/// <summary>
		/// 是否查询字段（1是）
		/// </summary>
		[JsonProperty, Column(DbType = "char(2)")]
		public string isQuery { get; set; }

		/// <summary>
		/// net字段名
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string netField { get; set; }

		/// <summary>
		/// net 类型
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string netType { get; set; }

		/// <summary>
		/// 查询方式（等于、不等于、大于、小于、范围）
		/// </summary>
		[JsonProperty, Column(StringLength = 200)]
		public string queryType { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? sort { get; set; }

		/// <summary>
		/// 表Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? tableId { get; set; }

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
