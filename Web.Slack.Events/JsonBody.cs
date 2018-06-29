using Newtonsoft.Json;

public class JsonBody
{
    [JsonProperty("text")]
    public string Text { get; set; }
}