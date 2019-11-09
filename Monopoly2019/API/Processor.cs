using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2019.API
{
    class Processor
    {

        public static async Task LoadData(string apiUrl, Action<string> onSuccess, Action<string> onFailure)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiHelper.ApiClient.BaseAddress + apiUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    onSuccess?.Invoke(data);
                }
                else
                {
                    onFailure?.Invoke(response.ReasonPhrase);
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async void PostData(string apiUrl, HttpContent data, Action onSuccess = null, Action<string> onFailure = null)
        {
          //  var content = new FormUrlEncodedContent(data);

            using (var response = await ApiHelper.ApiClient.PostAsync(ApiHelper.ApiClient.BaseAddress + apiUrl, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    onSuccess?.Invoke();
                }
                else
                {
                    onFailure?.Invoke(response.ReasonPhrase);
                }
            }
        }
        public static async void UpdateData(string apiUrl, HttpContent data, Action onSuccess = null, Action<string> onFailure = null)
        {
            //  var content = new FormUrlEncodedContent(data);

            using (var response = await ApiHelper.ApiClient.PutAsync(ApiHelper.ApiClient.BaseAddress + apiUrl, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    onSuccess?.Invoke();
                }
                else
                {
                    onFailure?.Invoke(response.ReasonPhrase);
                }
            }
        }



    }
}
