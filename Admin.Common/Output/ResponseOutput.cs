using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Admin.Common.Output
{
    public class ResponseOutput<T>:IResponseOutput
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public bool Success { get; private set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; private set; }

        public T Data { get; private set; }

        public string Msg { get; private set; }

        public ResponseOutput<T> Ok(T data,string msg=null) {
            Success = true;
            Code = 200;
            Data = data;
            Msg = msg;
            return this;
        }

        public ResponseOutput<T> OkMsg() {
            Success = true;
            Code = 200;
            Data =(T)Enumerable.Empty<string>();
            Msg = "请求成功";
            return this;
        }

        public ResponseOutput<T> NotOk(string msg=null,T data=default) {
            Success = false;
            Code = 500;
            Data = data;
            Msg = msg;
            return this;
        }

        public ResponseOutput<T> NotOkMsg()
        {
            Success = false;
            Code = 500;
            Data = (T)Enumerable.Empty<string>();
            Msg = "请求失败";
            return this;
        }

        public ResponseOutput<T> OtherCode(int code,string msg = "") {
            Success = false;
            Code = code;
            Data = (T)Enumerable.Empty<string>();
            Msg = msg;
            return this;
        }
    }

    public static partial class ResponseOutput {
        public static IResponseOutput Ok<T>(T data = default(T), string msg = "请求成功") {
            return new ResponseOutput<T>().Ok(data, msg);
        }

        public static IResponseOutput Ok()
        {
            return new ResponseOutput<IEnumerable<string>>().OkMsg();
        }

        public static IResponseOutput NotOk<T>(T data = default(T),string msg = "请求失败"){
            return new ResponseOutput<T>().NotOk(msg, data);
        }

        public static IResponseOutput NotOk()
        {
            return new ResponseOutput<IEnumerable<string>>().NotOkMsg();
        }

        public static IResponseOutput NotLogin(string msg="") {
            return new ResponseOutput<IEnumerable<string>>().OtherCode(401,msg);
        }

        public static IResponseOutput NotPermission(string msg = "") {
            return new ResponseOutput<IEnumerable<string>>().OtherCode(403, msg);
        }
    }
}
