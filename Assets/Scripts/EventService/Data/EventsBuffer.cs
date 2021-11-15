using System;
using System.Collections.Generic;


[Serializable]
public class EventsBuffer
{
    //using events list as a class field instead a property its becouse JsonUtility not support property serialization
    public List<SimpleEvent> events;

    public EventsBuffer()
    {
        events = new List<SimpleEvent>();
    }
}

