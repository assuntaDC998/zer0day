using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class EventJsonMap 
{
    public List<Event> events;

    

    public Event getEventbyName(String name)
    {
        foreach (Event  e in events)
        {
            if (e.eventName == name)
            {
                return e;
            }
        }
        return null;
    }


}
[Serializable]
public class Event
{
    public String eventName;
    public List<String> modificatorCIDS;
    public String message;


}
