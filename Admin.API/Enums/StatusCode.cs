using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum StatusCode
    {
        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        StatusNotOk = 0,

        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功")]
        Status1Ok = 200,

        /// <summary>
        /// 未登录(需要重新登录)
        /// </summary>
        [Description("未登录")]
        Status401Unauthorized = 401,

        /// <summary>
        /// 权限不足
        /// </summary>
        [Description("权限不足")]
        Status403Forbidden = 403,

        /// <summary>
        /// 资源不存在
        /// </summary>
        [Description("资源不存在")]
        Status404NotFound = 404,

        /// <summary>
        /// 系统内部错误（非业务代码里显式抛出的异常，例如由于数据不正确导致空指针异常、数据库异常等等）
        /// </summary>
        [Description("系统内部错误")]
        Status500InternalServerError = 500
    }
}
