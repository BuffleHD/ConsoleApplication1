using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class EmailGenerator
    {
        
        
        public static Collection<String> generatedEmails = new Collection<string>();
        
        public static string MailToken;

        public static void RefreshMailToken()
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://10minutenmail.org/mailbox/");
            request.Method = "GET";
            request.Headers.Add("authority", "10minutenmail.org");
            request.Headers.Add("pragma", "no-cache");
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.135 Safari/537.36";
            request.Accept =
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.Headers.Add("Cookie",
                " __cfduid=dbd4f79550d8b819a77c5d94ce9b6ba481598786305; expires=Tue, 29-Sep-20 11:18:25 GMT; path=/; domain=.10minutenmail.org; HttpOnly; SameSite=Lax,XSRF-TOKEN=eyJpdiI6IjFGWit6UnByRkVWQktCUG1jZFwvejVBPT0iLCJ2YWx1ZSI6InQrcU5SUDJTbFwvTkpKTUFcL1RrZUhjSkpqcFdjZzRLbmR6Z3B3cFp5cXFlellnMkhqcDRjeHhINnV2K3pLUEQ3eCIsIm1hYyI6IjEzZWM2N2NkZGIzZmZmNzg0ODFlYmVmZjlmMDQxYjUwMGJmZmM2ZWQxNjY1YzJmZWRkMGNhZGQ4NTc1YTgxNWEifQ%3D%3D; expires=Sun, 30-Aug-2020 13:18:25 GMT; Max-Age=7200; path=/,10_minuten_mail_session=eyJpdiI6InQ0UGNnNVdsUU1sbENwTXNMRGY2TUE9PSIsInZhbHVlIjoibVhwUkFKa3ZlZTMweURScm1jaUNRNXUzcHRKTVV4YVEyZUtMenpNU3dBaXZ3dEFRekp1T3FzeVZ5eGpydGQrcSIsIm1hYyI6ImJlMDRmODM3MGViMGFiYjBiN2YxY2NmNjQ5OGFiN2VkZDlkYjc1Nzc1NWYzMmRiZDNkYzMzY2Q5OGMyZmNmNTQifQ%3D%3D; expires=Sun, 30-Aug-2020 13:18:25 GMT; Max-Age=7200; path=/; httponly");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Referer = "https://10minutenmail.org/";
            request.Headers.Add("accept-language", "de,en-US;q=0.9,en;q=0.8,de-DE;q=0.7,ro;q=0.6");

            var response = request.GetResponse();
            var encoding = ASCIIEncoding.ASCII;
            string responseText;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
               
            }

            string[] stringSeparators = new string[] {"name=\"_token\" value=\""};

         
            responseText = responseText.Split(stringSeparators, StringSplitOptions.None)[1];
            stringSeparators = new string[] {"\">"};

            responseText = responseText.Split(stringSeparators, StringSplitOptions.None)[0];


            //        MailToken = response.Headers.Get("Location").Split('/').Last();
            MailToken = responseText;
        }


        public static void genEmails(int count)
        {
            for (int i = 0; i < count; i++)
            {

                String msuffix = "RaresBaresDares";
                string mpraffix = "klose.cf";
                byte[] data = Encoding.ASCII.GetBytes("_token=" + MailToken + "&email=" + msuffix + "&domain= " + mpraffix);
                
                  HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://10minutenmail.org/mailbox/create/custom");
            request.Method = "GET";
            request.Headers.Add("authority", "10minutenmail.org");
            request.Headers.Add("pragma", "no-cache");
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.135 Safari/537.36";
            request.Accept =
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.Headers.Add("Cookie",
                " __cfduid=dbd4f79550d8b819a77c5d94ce9b6ba481598786305; expires=Tue, 29-Sep-20 11:18:25 GMT; path=/; domain=.10minutenmail.org; HttpOnly; SameSite=Lax,XSRF-TOKEN=eyJpdiI6IjFGWit6UnByRkVWQktCUG1jZFwvejVBPT0iLCJ2YWx1ZSI6InQrcU5SUDJTbFwvTkpKTUFcL1RrZUhjSkpqcFdjZzRLbmR6Z3B3cFp5cXFlellnMkhqcDRjeHhINnV2K3pLUEQ3eCIsIm1hYyI6IjEzZWM2N2NkZGIzZmZmNzg0ODFlYmVmZjlmMDQxYjUwMGJmZmM2ZWQxNjY1YzJmZWRkMGNhZGQ4NTc1YTgxNWEifQ%3D%3D; expires=Sun, 30-Aug-2020 13:18:25 GMT; Max-Age=7200; path=/,10_minuten_mail_session=eyJpdiI6InQ0UGNnNVdsUU1sbENwTXNMRGY2TUE9PSIsInZhbHVlIjoibVhwUkFKa3ZlZTMweURScm1jaUNRNXUzcHRKTVV4YVEyZUtMenpNU3dBaXZ3dEFRekp1T3FzeVZ5eGpydGQrcSIsIm1hYyI6ImJlMDRmODM3MGViMGFiYjBiN2YxY2NmNjQ5OGFiN2VkZDlkYjc1Nzc1NWYzMmRiZDNkYzMzY2Q5OGMyZmNmNTQifQ%3D%3D; expires=Sun, 30-Aug-2020 13:18:25 GMT; Max-Age=7200; path=/; httponly");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Referer = "https://10minutenmail.org/";
            request.Headers.Add("accept-language", "de,en-US;q=0.9,en;q=0.8,de-DE;q=0.7,ro;q=0.6");
            request.ContentLength = data.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            
            
            
            generatedEmails.Add(msuffix + "@" + mpraffix);

           

         
         

           

            }
        }
    }
}