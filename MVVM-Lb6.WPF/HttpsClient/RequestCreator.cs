using System;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVM_lb6.Domain.Responses.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb6.HttpsClient;

public static class RequestCreator
{
    private const string BaseURL = @"https://localhost:7148/";
    public static string Token = "";

    public static async Task<T> Request<T>(HttpMethod method, string endpoint, object? data = null) where T : ResponseBase
    {
        
        HttpClient httpClient = new HttpClient();

        try
        {
            HttpRequestMessage request = new HttpRequestMessage(method, new Uri(BaseURL + endpoint));

            if (!String.IsNullOrEmpty(Token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            if (data is not null)
            {
                string json = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await httpClient.SendAsync(request);
            
            string responseBody = await response.Content.ReadAsStringAsync();
                
            T result = JsonConvert.DeserializeObject<T>(responseBody) ?? throw new Exception();

            if (response.IsSuccessStatusCode)
            {
                return result;
            }
            else
            {
                string[] errorMassage = result?.Info ?? throw new DataException();

                MessageBox.Show($"Error: {errorMassage[0]}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"HTTP Request Exception: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            httpClient.Dispose();
        }
        
        return null;
    }
}