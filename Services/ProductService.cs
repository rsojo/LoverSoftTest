
using System;
using System.IO;
using System.Net;
using Business.Helpers.Constants;

namespace Services
{
    public class ProductService
    {
        public static string getProducts()
        {
            string url = General.ProductServiceURL;
            string response = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                // Log the exception details
                Console.WriteLine($"WebException: {ex.Message}");
                // Handle specific status codes if necessary
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return response;
        }

    }
}
