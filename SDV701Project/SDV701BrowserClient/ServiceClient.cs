using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SDV701BrowserClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Provides a utilites and a connection to the data server.
    /// </summary>
    public static class ServiceClient
    {

        private static string constructServiceURI(string command, Dictionary<string, Object> parameters)
        {
            string paramString = "";
            if (parameters != null)
            {
                paramString += "?";
                foreach (string s in parameters.Keys)
                {
                    paramString += $"{s}={parameters[s]}";
                    if (s != parameters.Keys.Last())
                        paramString += "&";
                }
            }
            return $"http://localhost:60064/api/Inventory/{command}{paramString}";
        }

        internal async static Task<bool> getConnectionTestAsync()
        {
            bool result;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    result = JsonConvert.DeserializeObject<bool>(await client.GetStringAsync(constructServiceURI("getConnectionTest", null)));
                }
                catch (HttpRequestException)
                {
                    result = false;
                }
            }
            return result;
        }

        internal async static Task<Dictionary<int, string>> getManufacturersNamesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<Dictionary<int, string>>(await client.GetStringAsync(constructServiceURI("GetManufacturersNames", null)));
            }
        }

        internal async static Task<ComputerManufacturer> GetManufacturerAsync(int code)
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<ComputerManufacturer>(await client.GetStringAsync(constructServiceURI("GetManufacturer", new Dictionary<string, object>() { { "code", code } })));
            }
        }

        internal async static Task<ComputerModel> GetComputerModelAsync(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<ComputerModel>(await client.GetStringAsync(constructServiceURI("GetComputerModel", new Dictionary<string, object>() { { "name", name } })));
            }
        }

        internal async static Task<bool> GetComputerModelExistsAsync(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<bool>(await client.GetStringAsync(constructServiceURI("GetComputerModelExists", new Dictionary<string, object>() { { "name", name } })));
            }
        }

        internal async static Task<DateTime> GetModifiedDateAsync(string modelName)
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<DateTime>(await client.GetStringAsync(constructServiceURI("GetModifiedDate", new Dictionary<string, object>() { { "modelName", modelName } })));
            }
        }

        internal async static Task<int> GetComputerModelStockQuantityAsync(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<int>(await client.GetStringAsync(constructServiceURI("GetComputerModelStockQuantity", new Dictionary<string, object>() { { "name", name } })));
            }
        }


        private async static Task<string> insertOrUpdateAsync<TItem>(TItem item, string url, string request)
        {
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(request), url))
            using (requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"))
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        internal async static Task<string> PostPurchaseOrder(PurchaseOrder order)
        {
            return await insertOrUpdateAsync<PurchaseOrder>(order, constructServiceURI("PostPurchaseOrder", new Dictionary<string, object>() { { "order", order } }), "POST");
        }
    }
}
