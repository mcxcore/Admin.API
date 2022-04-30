using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 用户角色
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_user_role {

		/// <summary>
		/// 角色Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long roleId { get; set; }

		/// <summary>
		/// 用户Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long userId { get; set; }

	}

}
