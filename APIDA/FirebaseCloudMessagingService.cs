using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using RestClient;
public class FirebaseCloudMessagingService
{
    private readonly string _serverKey;
    private readonly string _fcmEndpoint = "https://fcm.googleapis.com/fcm/send";

    public FirebaseCloudMessagingService(string serverKey)
    {
        _serverKey = serverKey;
    }

    public async Task<bool> SendNotificationAsync(string deviceToken, string title, string body)
    {
        try
        {
            var payload = new
            {
                to = deviceToken,
                notification = new
                {
                    title,
                    body,
                },
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_fcmEndpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + _serverKey);
                var response = await client.PostAsJsonAsync("", payload);

                if (response.IsSuccessStatusCode)
                {
                    // Gửi thông báo thành công
                    return true;
                }
                else
                {
                    // Gửi thông báo thất bại
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            // Xử lý ngoại lệ
            return false;
        }
    }

}

public class NotificationData
{
    public string Title { get; set; }
    public string Body { get; set; }
}
