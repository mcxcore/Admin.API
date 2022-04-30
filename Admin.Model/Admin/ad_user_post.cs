using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 用户岗位
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_user_post {

		/// <summary>
		/// 岗位Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long postId { get; set; }

		/// <summary>
		/// 用户Id
		/// </summary>
		[JsonProperty, Column(DbType = "bigint", IsPrimary = true)]
		public long userId { get; set; }

	}

}
