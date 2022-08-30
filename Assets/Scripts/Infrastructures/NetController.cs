using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : InfrastructureController {

    private GameObject firewallModel;
   
    [SerializeField] public int maxFW;
    private int activeFW;

    public override void Awake()
    {
        base.Awake();
        
        //Load Prefab
        firewallModel = Resources.Load("Models/Defenses/FireWall") as GameObject;
        activeFW = 0;
    }
    public void createFirewall()
    {
        GameObject firewall = Instantiate(firewallModel);
        defenses.Add(firewall.GetComponent<FirewallController>());
        Vector3 position = gameObject.transform.position;
        firewall.transform.position = new Vector3(position.x - 0.66f, position.y + 0.908f, position.z - 0.48f);
        firewall.SetActive(true);
    }

    public override void Update()
    {
       base.Update();
    }

    public override void OnDrop(GameObject dropped)
    {
        if (dropped.CompareTag("Firewall"))
        {
            if (activeFW < maxFW)
            {
                activeFW += 1;
                createFirewall();
            }
            else handleElementOverflow(generateOverflowMex("FW", "FWs", maxFW));
        }else if (dropped.CompareTag("IDPS"))
        {
            // TO COMPLETE
        }

        updateDefensesFeatures();
    }
}
