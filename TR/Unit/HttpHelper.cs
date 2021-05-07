namespace TR.Unit
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public static class HttpHelper
    {

        /// <summary>
        /// httpGet请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGet(this Uri url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "GET";
                using (var response = webRequest.GetResponse())
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        /// <summary>
		/// 模拟post表单请求
		/// </summary>
		/// <param name="url">url</param>
		/// <param name="postData">参数</param>
		/// <returns>String</returns>
		public static string HttpPost(Uri url, string postData)
        {
            string result = string.Empty;
            try
            {
                var data = Encoding.ASCII.GetBytes(postData);
                WebRequest res = WebRequest.Create(url);
                res.ContentType = "application/x-www-form-urlencoded";
                res.Method = "post";
                res.UseDefaultCredentials = true;
                res.ContentLength = data.Length;
                var task = res.GetResponseAsync();
                using (var stream = res.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                WebResponse rep = task.Result;
                Stream respStream = rep.GetResponseStream();
                using (StreamReader reader = new StreamReader(respStream, Encoding.Default))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
