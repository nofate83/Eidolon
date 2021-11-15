using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    [SerializeField]
    private Text eventType;
    [SerializeField]
    private Text eventData;
    [SerializeField]
    private Button sendButton;
    
    void Start()
    {
        sendButton.onClick.AddListener(AddEvent);
    }

    private void AddEvent()
    {
        EventService.Instance.TrackEvent(eventType.text, eventData.text);
    }

    
    void Update()
    {
        
    }
}

