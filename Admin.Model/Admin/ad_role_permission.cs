using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 角色权限
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_role_permission {

		/// <summary>
		/// 主键Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

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
		/// 权限Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long PermissionId { get; set; }

		/// <summary>
		/// 角色Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long RoleId { get; set; }

		/// <summary>
		/// 租户Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint")]
		public long? TenantId { get; set; }

	}

}
