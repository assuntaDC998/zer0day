using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour, Notifier
{
    private TextMeshProUGUI notification;
   
    [SerializeField]
    public int time; 
    void Start()
    {
        notification = gameObject.GetComponent<TextMeshProUGUI>();
        notification.text = "";
    }


    IEnumerator sendNotification(string text, int time)
    {
        notification.text = text;
        yield return new WaitForSeconds(time);
        notification.text = "";
    }

    public void NotifyUser(string message)
    {
        StartCoroutine(sendNotification(message, time));
    }
}
