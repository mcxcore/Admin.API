using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 角色部门关联
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_role_dept {

		/// <summary>
		/// 部门ID
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long deptId { get; set; }

		/// <summary>
		/// 角色ID
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long roleId { get; set; }

	}

}
