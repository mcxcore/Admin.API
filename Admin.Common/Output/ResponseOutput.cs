using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Output
{
    public class ResponseOutput<T>:IResponseOutput
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; private set; }

        public T Data { get; private set; }

        public string Msg { get; private set; }

        public ResponseOutput<T> Ok(T data,string msg=null) {
            Code = 200;
            Data = data;
            Msg = msg;
            return this;
        }

        public ResponseOutput<T> OkMsg(string msg = null) {
            Code = 200;
            Data =(T)Enumerable.Empty<string>();
            Msg = msg;
            return this;
        }

        public ResponseOutput<T> NotOk(string msg=null,T data=default) {
            Code = 500;
            Data = data;
            Msg = msg;
            return this;
        }

        public ResponseOutput<T> NotOkMsg(string msg = null)
        {
            Code = 500;
            Data = (T)Enumerable.Empty<string>();
            Msg = msg;
            return this;
        }

        public ResponseOutput<T> OtherCode(int code,string msg = "") {
            Code = code;
            Data = (T)Enumerable.Empty<string>();
            Msg = msg;
            return this;
        }
    }

    public static partial class ResponseOutput {
        public static IResponseOutput Ok<T>(T data = default(T), string msg = "") {
            return new ResponseOutput<T>().Ok(data, msg);
        }

        public static IResponseOutput Ok(string msg = "") {
            return new ResponseOutput<IEnumerable<string>>().OkMsg(msg);
        }

        public static IResponseOutput NotOk<T>(string msg = "",T data = default(T)){
            return new ResponseOutput<T>().NotOk(msg, data);
        }

        public static IResponseOutput NotOk(string msg = "")
        {
            return new ResponseOutput<IEnumerable<string>>().NotOkMsg(msg);
        }

        public static IResponseOutput NotLogin(string msg="") {
            return new ResponseOutput<IEnumerable<string>>().OtherCode(401,msg);
        }

        public static IResponseOutput NotPermission(string msg = "") {
            return new ResponseOutput<IEnumerable<string>>().OtherCode(403, msg);
        }
    }
}
