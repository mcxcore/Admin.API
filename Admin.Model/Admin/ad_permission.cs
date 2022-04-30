using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 权限
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_permission {

		/// <summary>
		/// 主键Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 接口
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? ApiId { get; set; }

		/// <summary>
		/// 可关闭
		/// </summary>
		[JsonProperty]
		public bool? Closable { get; set; }

		/// <summary>
		/// 权限编码
		/// </summary>
		[JsonProperty, Column(StringLength = 550)]
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
		[JsonProperty, Column(StringLength = 100)]
		public string Description { get; set; }

		/// <summary>
		/// 启用
		/// </summary>
		[JsonProperty]
		public bool Enabled { get; set; }

		/// <summary>
		/// 链接外显
		/// </summary>
		[JsonProperty]
		public bool? External { get; set; }

		/// <summary>
		/// 隐藏
		/// </summary>
		[JsonProperty]
		public bool Hidden { get; set; }

		/// <summary>
		/// 图标
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string Icon { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		[JsonProperty]
		public bool IsDeleted { get; set; }

		/// <summary>
		/// 权限名称
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string Label { get; set; }

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
		/// 打开新窗口
		/// </summary>
		[JsonProperty]
		public bool? NewWindow { get; set; }

		/// <summary>
		/// 打开组
		/// </summary>
		[JsonProperty]
		public bool? Opened { get; set; }

		/// <summary>
		/// 父级节点
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long ParentId { get; set; }

		/// <summary>
		/// 菜单访问地址
		/// </summary>
		[JsonProperty]
		public string Path { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int? Sort { get; set; }

		/// <summary>
		/// 租户Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? TenantId { get; set; }

		/// <summary>
		/// 权限类型
		/// </summary>
		[JsonProperty, Column(DbType = "int")]
		public int Type { get; set; }

		/// <summary>
		/// 版本
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long Version { get; set; }

		/// <summary>
		/// 视图
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? ViewId { get; set; }

	}

}
