using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ExecutableController : PacketController
{

    public override void Awake()
    {
        base.Awake();

        string featuresFile = new StreamReader("Assets/PushToData/Features/Packets/executable.json").ReadToEnd();
        mapper = JsonUtility.FromJson<PacketsFeaturesJsonMap>(featuresFile);
        this.features = mapper.todict();
    }

    public override void Update()
    {
        base.Update();
    }

}
