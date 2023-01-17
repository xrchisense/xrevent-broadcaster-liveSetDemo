using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveKitURLProvider : MonoBehaviour
{
    public string roomName = "GasStation";

    
    

    void Start()
    {
        // Create a temporary username for the subscriber and save it locally
        if (!PlayerPrefs.HasKey("livekit_subscriber"))
        {
            string uname = "Viewer_" + System.Guid.NewGuid().ToString().Substring(1, 6);
            PlayerPrefs.SetString("livekit_subscriber", uname);
            PlayerPrefs.Save();
        }
        
        string token = createToken();
        
        // https://xrevent-creator.de/livekit/#/room?url=wss%3A%2F%2Fxrevent.livekit.cloud&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDIzMTU4NDYsImlzcyI6IkFQSXJNYXRnYkJ3Tm50eCIsIm5iZiI6MTY3MjMxNTg0Niwic3ViIjoiVmlld2VyXzAyIiwidmlkZW8iOnsiY2FuUHVibGlzaCI6ZmFsc2UsImNhblB1Ymxpc2hEYXRhIjp0cnVlLCJjYW5TdWJzY3JpYmUiOnRydWUsInJvb20iOiJHYXNTdGF0aW9uIiwicm9vbUpvaW4iOnRydWV9fQ.F9n-9J6NYdPWDlpBKaFcIi1tWqBgFcRhBfpEFDjkYXE&videoEnabled=0&audioEnabled=0&producerEnabled=0&simulcast=1&dynacast=1&adaptiveStream=1
        string url =  "https://xrevent-creator.de/livekit/#/room?url=wss%3A%2F%2Fxrevent.livekit.cloud&token=" + token + "&videoEnabled=0&audioEnabled=0&producerEnabled=0&simulcast=1&dynacast=1&adaptiveStream=1";
        GetComponent<XrEventBroadcaster>().playerURL = url;
        GetComponent<XrEventBroadcaster>().InvokeLoadURL();
    }


    void Update()
    {
        
    }


    private string createToken()
    {
        var payload = new Dictionary<string, object>()
            {
                { "exp", 1702315846 },
                { "iss", "APITKsecHQHrhG4" },
                { "nbf", 1672315846 },
                { "sub", PlayerPrefs.GetString("livekit_subscriber") },
                { "video", new Dictionary<string, object>(){
                                { "room", roomName },
                                { "roomJoin", true },
                                { "canSubscribe", true},
                                { "canPublish", false },
                                { "canPublishDate", false }
                    } }
            };
        var secretKey = "9fUchfZ0R48opvc3FPcZskTebWAH1lfu1fjxkSFy5wfM";
        string token = JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256);
        return token;
    }


}
