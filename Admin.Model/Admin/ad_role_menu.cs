using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 角色菜单权限表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_role_menu {

		/// <summary>
		/// 菜单ID
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long menuId { get; set; }

		/// <summary>
		/// 角色ID
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long roleId { get; set; }

	}

}
