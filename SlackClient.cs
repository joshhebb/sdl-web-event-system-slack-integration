using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

/// <summary>
/// Client to submit POST requests to Slack via custom app webhooks.
/// see https://api.slack.com/apps
/// </summary>
public class SlackClient
{
    // Slack extension URLs (webhooks, etc)
    private readonly Uri _uri;

    private readonly Encoding _encoding = new UTF8Encoding();

    public SlackClient(string urlWithAccessToken)
    {
        _uri = new Uri(urlWithAccessToken);
    }

    public void PostMessage(string text)
    {
        JsonBody payload = new JsonBody()
        {
            Text = text
        };

        PostMessage(payload);
    }

    public void PostMessage(JsonBody payload)
    {
        string payloadJson = JsonConvert.SerializeObject(payload);

        using (WebClient client = new WebClient())
        {
            NameValueCollection data = new NameValueCollection();
            data["payload"] = payloadJson;

            var response = client.UploadValues(_uri, "POST", data);

            string responseText = _encoding.GetString(response);
        }
    }
}