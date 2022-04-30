using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 操作日志
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_login_log {

		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 浏览器
		/// </summary>
		[JsonProperty]
		public string Browser { get; set; }

		/// <summary>
		/// 浏览器信息
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string BrowserInfo { get; set; }

		/// <summary>
		/// 城市
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string City { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		[JsonProperty, Column(StringLength = 64)]
		public string createBy { get; set; }

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
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime createTime { get; set; }

		/// <summary>
		/// 设备
		/// </summary>
		[JsonProperty]
		public string Device { get; set; }

		/// <summary>
		/// 耗时（毫秒）
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long ElapsedMilliseconds { get; set; }

		/// <summary>
		/// IP
		/// </summary>
		[JsonProperty, Column(StringLength = 100)]
		public string IP { get; set; }

		/// <summary>
		/// 操作消息
		/// </summary>
		[JsonProperty]
		public string Msg { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		[JsonProperty, Column(StringLength = 60)]
		public string NickName { get; set; }

		/// <summary>
		/// 操作系统
		/// </summary>
		[JsonProperty]
		public string Os { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 操作结果
		/// </summary>
		[JsonProperty, Column(StringLength = -1)]
		public string Result { get; set; }

		/// <summary>
		/// 操作状态
		/// </summary>
		[JsonProperty]
		public string Status { get; set; }

		/// <summary>
		/// 租户Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? TenantId { get; set; }

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
