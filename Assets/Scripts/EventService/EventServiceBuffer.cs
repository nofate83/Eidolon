using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class EventServiceBuffer
{
    private readonly string bufferPath;
    System.Object _lock;
    public EventServiceBuffer()
    {
        bufferPath = Application.dataPath + "\\events.buf";
    }
    public Task AddEventToBuffer(string _type, string _data)
    {
        EventsBuffer current = JsonUtility.FromJson<EventsBuffer>(GetBufferJson());
        current.events.Add(new SimpleEvent() { type = _type, data = _data });
        string actual = JsonUtility.ToJson(current);
        lock (_lock)
        {
            File.WriteAllText(bufferPath, actual);
        }
        return Task.CompletedTask;
    }

    public string GetBufferJson()
    {
        return File.ReadAllText(bufferPath);
    }

    public void ClearBuffer()
    {
        lock (_lock)
        {
            File.WriteAllText(bufferPath, string.Empty);
        }
    }

}

