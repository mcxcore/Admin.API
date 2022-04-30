using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 字段数据
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_dic_data {

		/// <summary>
		/// 字典编码
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long dictCode { get; set; }

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
		/// 样式属性（其他样式扩展）
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string cssClass { get; set; }

		/// <summary>
		/// 字典标签
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string dictLabel { get; set; }

		/// <summary>
		/// 字典排序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int? dictSort { get; set; }

		/// <summary>
		/// 字典类型
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string dictType { get; set; }

		/// <summary>
		/// 字典键值
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string dictValue { get; set; }

		/// <summary>
		/// 是否默认（Y是 N否）
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string isDefault { get; set; }

		/// <summary>
		/// 表格回显样式
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string listClass { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 状态（0正常 1停用）
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
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
