using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace ConsoleApplication1
{
    public class McHostLogger
    {
      
        public static string setupSession(String email, String password)
        {
         
            HttpWebRequest requ = (HttpWebRequest) WebRequest.Create( "https://mc-host24.de/login");
            requ.Method = "POST";
            string datastr = "token=" +"ig7SdUGr54s3ymXK63I3pjB0oo26Gv3WJrdj5IrJ" +  "&email=" + email + "&password=" + password + "&sideurl=/";
            requ.CookieContainer = new CookieContainer();
            requ.Headers.Add("authority", "mc-host24.de");
            requ.Headers.Add("pragma", "no-cache");
            requ.Headers.Add("cache-control", "no-cache");
            requ.Headers.Add("upgrade-insecure-requests", "1");
            requ.Headers.Add("origin", "https://mc-host24.de");
            requ.UserAgent = ( "Sownloader/Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.135 Safari/537.36");
            requ.Accept = ( "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            requ.Headers.Add("sec-fetch-site", "same-origin");
            requ.Headers.Add("sec-fetch-mode", "navigate");
            requ.Headers.Add("sec-fetch-user", "?1");
            requ.Headers.Add("sec-fetch-dest", "document");
            
            requ.Referer = ( "https://mc-host24.de/");
            requ.ContentLength = datastr.Length;
            requ.Headers.Add("accept-language", "de,en-US;q=0.9,en;q=0.8,de-DE;q=0.7,ro;q=0.6");
    

           
            byte[] data = Encoding.ASCII.GetBytes(datastr);
            
          

            using (var stream = requ.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var resp = (HttpWebResponse)requ.GetResponse();
       
            
            var headers =  resp.Headers;
            String token = "s";
            Console.WriteLine(resp.StatusCode);
            foreach (Cookie respCookie in resp.Cookies)
            {
                Console.WriteLine(respCookie  + " || " + resp.Headers.Get("status"));
            }

            return token;
        }
    }
}