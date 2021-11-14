using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EventService : MonoBehaviour
{
    private const string SERVER_URL = "https://www.analytics-server.com/getevent";
    private const float COOLDOWN_PERIOD = 3; //in seconds

    private EventServiceBuffer buffer;

    private float cooldownBeforeSend = COOLDOWN_PERIOD;



    void Start()
    {
        buffer = new EventServiceBuffer();
    }

    public async void TrackEvent(string type, string data)  //Is arguments needs to be checked for empty/null?
    {
        await buffer.AddEventToBuffer(type, data);
    }

    IEnumerator Upload()  //so here is why i cant check this code at all,
                          //cos i havent server(analytics or whatever) that can responce to me 200 OK for my request.
                          //of course at the real project i would check all opportunities and possibilities,
                          //but for now just like this. Have no sure about this code
    {
        UnityWebRequest req = UnityWebRequest.Post(SERVER_URL, buffer.GetBufferJson());
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.responseCode == 200)
        {
            buffer.ClearBuffer();
            yield return null;
        }
        else
        {
            yield return null;
        }

    }

    void Update()
    {
        cooldownBeforeSend -= Time.deltaTime;
        if(cooldownBeforeSend <= 0)
        {
            Upload();
            cooldownBeforeSend += COOLDOWN_PERIOD;
        }
    }
}
