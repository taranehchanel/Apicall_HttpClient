using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarService.Api;

//[Authorize]
[Route("api/v2/HomePage/Services")]
public class OmidbnkController(IHttpClientFactory factory)
{
    [HttpPost(template: "Register")]
    public async Task Register()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://omidbnk.ir/gateway/identity/");
        httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header  

        httpClient.DefaultRequestHeaders.Add("AppId", "1");
        httpClient.DefaultRequestHeaders.Add("DeviceTypeId", "1");
        httpClient.DefaultRequestHeaders.Add("DeviceId", "09128014549");
        httpClient.DefaultRequestHeaders.Add("AppLanguage", "fa");
        httpClient.DefaultRequestHeaders.Add("DeviceVersion", "1.7");

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v2/Identity/Register");
        request.Content = new StringContent(
            "{\"mobileNumber\":\"09128014549\",\"nationalCode\":\"0080887945\",\"invitedCode\":null}",
            Encoding.UTF8,
            "application/json"); //CONTENT-TYPE header

        var response = await httpClient.SendAsync(request);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == HttpStatusCode.OK &&
            string.IsNullOrWhiteSpace(responseContent) == false)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<Response>(responseContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // .ContinueWith(responseTask =>
        // {
        //     Console.WriteLine("Response: {0}", responseTask.Result);
        // });
    }

    [HttpPost(template: "Login")]
    public async Task<Response> Login()
    {
        Response result = new Response();
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://omidbnk.ir/gateway/identity/");
        httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header  

        httpClient.DefaultRequestHeaders.Add("AppId", "1");
        httpClient.DefaultRequestHeaders.Add("DeviceTypeId", "1");
        httpClient.DefaultRequestHeaders.Add("DeviceId", "09128014549");
        httpClient.DefaultRequestHeaders.Add("AppLanguage", "fa");
        httpClient.DefaultRequestHeaders.Add("DeviceVersion", "1.7");

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v2/Identity/Login");
        request.Content = new StringContent(
            "{\"mobileNumber\":\"09128014549\"}",
            Encoding.UTF8,
            "application/json"); //CONTENT-TYPE header

        var response = await httpClient.SendAsync(request);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == HttpStatusCode.OK &&
            string.IsNullOrWhiteSpace(responseContent) == false)
        {
            try
            {
                result = JsonConvert.DeserializeObject<Response>(responseContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return result;
        // .ContinueWith(responseTask =>
        // {
        //     Console.WriteLine("Response: {0}", responseTask.Result);
        // });
    }


    [HttpGet("services2")]
    public async Task<Service> GetServices()
    {
        var result = new Service();
        //var baseUrl = "https://omidbnk.ir/gateway";
        // string queryString = "?AppId=1&DeviceTypeId=1&DeviceId=09128014549&AppLanguage=fa&DeviceVersion=1.7";
        var httpClient = factory.CreateClient("services_client");
        //httpClient.BaseAddress = new Uri(baseUrl);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        httpClient.DefaultRequestHeaders.Add("AppId", "1");
        httpClient.DefaultRequestHeaders.Add("DeviceTypeId", "1");
        httpClient.DefaultRequestHeaders.Add("DeviceId", "09128014549");
        httpClient.DefaultRequestHeaders.Add("AppLanguage", "fa");
        httpClient.DefaultRequestHeaders.Add("DeviceVersion", "1.7");

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "89f20427-c10e-4ce5-8c73-26f3a2a4b208");

        using (var response = await httpClient.GetAsync("v2/HomePage/Services"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<Service>(apiResponse);
        }

        result = await httpClient.GetFromJsonAsync<Service>("v2/HomePage/Services");
        return result;
    }


    [HttpGet]
    public async Task<Service> Get()
    {
        var result = new Service();
        // var baseUrl = "https://omidbnk.ir/gateway/services";

        using (var httpClient = new HttpClient())
        {
            //string queryString = "?AppId=1&DeviceTypeId=1&DeviceId=09128014549&AppLanguage=fa&DeviceVersion=1.7";
            httpClient.BaseAddress = new Uri("https://omidbnk.ir/gateway/services/");
            // HttpRequestMessage request = new HttpRequestMessage();
            // request.Headers.Add("Accept-Language", "en"); 

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//             HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "v2/HomePage/Services/");
//             //requestMessage.Headers.Add("User-Agent", "User-Agent-Here");
//             requestMessage.Headers.Add("AppId", "1");
//             requestMessage.Headers.Add("DeviceTypeId", "1");
//             requestMessage.Headers.Add("DeviceId", "09128014549");
//             requestMessage.Headers.Add("AppLanguage", "fa");
//             requestMessage.Headers.Add("DeviceVersion", "1.7");
//             httpClient.DefaultRequestHeaders.Authorization =
//                 new AuthenticationHeaderValue("Bearer", "89f20427-c10e-4ce5-8c73-26f3a2a4b208");
//
//             HttpResponseMessage response2 = await httpClient.SendAsync(requestMessage);
//
// // Just as an example I'm turning the response into a string here
//             string responseAsString = await response2.Content.ReadAsStringAsync();

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            httpClient.DefaultRequestHeaders.Add("AppId", "1");
            httpClient.DefaultRequestHeaders.Add("DeviceTypeId", "1");
            httpClient.DefaultRequestHeaders.Add("DeviceId", "09128014549");
            httpClient.DefaultRequestHeaders.Add("AppLanguage", "fa");
            httpClient.DefaultRequestHeaders.Add("DeviceVersion", "1.7");

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "89f20427-c10e-4ce5-8c73-26f3a2a4b208");


            //var resultAH = await httpClient.GetFromJsonAsync<Service>("v2/HomePage/Services/");

            using (var responseMessage = await httpClient.GetAsync("v2/HomePage/Services/"))
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                if (responseMessage.StatusCode == HttpStatusCode.OK &&
                    string.IsNullOrWhiteSpace(responseContent) == false)
                {
                    try
                    {
                        result = JsonConvert.DeserializeObject<Service>(responseContent);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    result = JsonConvert.DeserializeObject<Service>(responseContent);
                }
            }
        }

        return result;
    }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Category
{
    public int id { get; set; }
    public string title { get; set; }
    public string enTitle { get; set; }
    public string iconUrl { get; set; }
}

public class Data
{
    public List<Item> items { get; set; }
}

public class Item
{
    public Category category { get; set; }
    public List<ServiceItem> serviceItems { get; set; }
}

public class Service
{
    public Data data { get; set; }
    public int statusCode { get; set; }
    public string message { get; set; }
    public bool isSuccess { get; set; }
}

public class ServiceItem
{
    public int id { get; set; }
    public int categoryId { get; set; }
    public int? parentId { get; set; }
    public string title { get; set; }
    public string enTitle { get; set; }
    public int typeId { get; set; }
    public bool payByWallet { get; set; }
    public bool payByOnline { get; set; }
    public bool isActive { get; set; }
    public bool isOrganizational { get; set; }
    public int merchantTerminalId { get; set; }
    public decimal taxPercentage { get; set; }
    public bool featured { get; set; }
    public string iconUrl { get; set; }
    public string colorName { get; set; }
    public bool hasLog { get; set; }
    public bool payable { get; set; }
    public int dailyTransactionSuccessCount { get; set; }
    public int dailyTransactionFailedCount { get; set; }
    public int hourlyTransactionSuccessCount { get; set; }
    public int hourlyTransactionFailedCount { get; set; }
    public int minutelyTransactionCount { get; set; }
    public string androidAction { get; set; }
    public string iosAction { get; set; }
    public string webUrl { get; set; }
    public string paymentUrl { get; set; }
    public string description { get; set; }
    public string enDescription { get; set; }
    public int terminalCode { get; set; }
    public int merchantCode { get; set; }
    public bool hasChild { get; set; }
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

public class Response
{
    public Data data { get; set; }
    public int statusCode { get; set; }
    public string message { get; set; }
    public bool isSuccess { get; set; }
}