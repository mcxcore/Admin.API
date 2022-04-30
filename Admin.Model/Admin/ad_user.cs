using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Admin.Model {

	/// <summary>
	/// 用户
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class ad_user {

		/// <summary>
		/// 用户Id
		/// </summary>
		[  Column(DbType = "bigint", IsPrimary = true, IsIdentity = true)]
		public long userId { get; set; }

		/// <summary>
		/// 头像地址
		/// </summary>
		[  Column(StringLength = 100)]
		public string avatar { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		[  Column(StringLength = 64)]
		public string createBy { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime createTime { get; set; }

		/// <summary>
		/// 删除标志（0代表存在 2代表删除）
		/// </summary>
		[  Column(StringLength = 1)]
		public string delFlag { get; set; }

		/// <summary>
		/// 部门ID
		/// </summary>
		[  Column(DbType = "bigint")]
		public long? deptId { get; set; }

		/// <summary>
		/// 用户邮箱
		/// </summary>
		[  Column(StringLength = 50)]
		public string email { get; set; }

		/// <summary>
		/// 最后登录时间
		/// </summary>
		[JsonProperty]
		public DateTime? loginDate { get; set; }

		/// <summary>
		/// 最后登录IP
		/// </summary>
		[  Column(StringLength = 50)]
		public string loginIp { get; set; }

		/// <summary>
		/// 用户昵称
		/// </summary>
		[  Column(StringLength = 30)]
		public string nickName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[  Column(StringLength = 100)]
		public string password { get; set; }

		/// <summary>
		/// 手机号码
		/// </summary>
		[  Column(StringLength = 11)]
		public string phoneNumber { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[  Column(StringLength = 500)]
		public string remark { get; set; }

		/// <summary>
		/// 用户性别（0男 1女 2未知）
		/// </summary>
		[  Column(StringLength = 1)]
		public string sex { get; set; }

		/// <summary>
		/// 帐号状态（0正常 1停用）
		/// </summary>
		[  Column(StringLength = 1)]
		public string status { get; set; }

		/// <summary>
		/// 更新者
		/// </summary>
		[  Column(StringLength = 64)]
		public string updateBy { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		[JsonProperty]
		public DateTime? updateTime { get; set; }

		/// <summary>
		/// 用户账号
		/// </summary>
		[  Column(StringLength = 30)]
		public string userName { get; set; }

		/// <summary>
		/// 用户类型（00系统用户）
		/// </summary>
		[  Column(StringLength = 2)]
		public string userType { get; set; }

	}

}
