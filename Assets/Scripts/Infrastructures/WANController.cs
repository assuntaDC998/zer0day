using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class WANController : NetController
{

    public override void Awake()
    {
        base.Awake();

        string featuresFile = new StreamReader("Assets/PushToData/Features/Infrastructures/externalnet.json").ReadToEnd();
        mapper = JsonUtility.FromJson<InfrastructuresFeaturesJsonMap>(featuresFile);
        this.features = mapper.todict();
    }

    public override void Update()
    {
        base.Update();
    }

}
