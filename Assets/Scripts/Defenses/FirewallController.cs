using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FirewallController : DefenseController
{
    public override void Awake()
    {
        base.Awake();

        string featuresFile = new StreamReader("Assets/PushToData/Features/Defenses/firewall.json").ReadToEnd();
        mapper = JsonUtility.FromJson<DefensesFeaturesJsonMap>(featuresFile);

        this.features = mapper.todict();
    }

    public override void Update()
    {
        base.Update();
    }
}
