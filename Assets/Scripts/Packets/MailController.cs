using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MailController : PacketController
{



    public override void Awake()
    {
        base.Awake();

        string featuresFile = new StreamReader("Assets/PushToData/Features/Packets/mail.json").ReadToEnd();
        mapper = JsonUtility.FromJson<PacketsFeaturesJsonMap>(featuresFile);
        this.features = mapper.todict();
    }

    public override void Update()
    {
        base.Update();
    }

}
