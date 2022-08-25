using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour, Notifier
{


    [SerializeField]
    Notifier notifier;

    public void NotifyUser(string message) {
        notifier.NotifyUser(message);
    }
}
