using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using DefensesFeatures;

public class InfrastructureController : Component, DropArea
{
    public int activeAntiVirus;
    public int activeFirewall;
    public int activeIDPS;
    public int activeBackup;

    public float efficiency;
    public float falsePositives;

    public List<DefenseController> defenses;

    public static event Action<String> ElementOverflow;
    
    
    private GameObject antiVirusModel;
    private GameObject firewallModel;

    public override void Start()
    {
    }

    public override void Awake()
    {
        this.category = "Infrastructure";
        
        base.Awake();

        defenses = new List<DefenseController>();

        activeAntiVirus=0;
        activeFirewall=0;
        activeIDPS=0;
        activeBackup=0;

        efficiency = 0;
        falsePositives = 0;

        //Load Prefab
        antiVirusModel = Resources.Load("Models/Defenses/AntiVirus") as GameObject;
        firewallModel = Resources.Load("Models/Defenses/FireWall") as GameObject;
    }

    public void updateDefensesFeatures()
    {
        //update total efficiency/false positives for each defense
        foreach (DefenseController defense in defenses) {
           this.efficiency = this.efficiency + ((1 - this.efficiency) * (float)defense.features[DefensesFeatures.DefenseFeature.FeatureType.FT_EFFICIENCY].currentValue);
           this.falsePositives = this.falsePositives + ((1 - this.falsePositives) * (float)defense.features[DefensesFeatures.DefenseFeature.FeatureType.FT_FALSE_POSITIVES].currentValue);
           
        }
    }



    public override void setFeatures()
    {

    }

    public override void initializeFeatures()
    {

    }

    public override void Update()
    {
        base.Update();
    }


    private void createAntiVirus() {
        //Create new antivirus
        GameObject antiVirus = Instantiate(antiVirusModel);
        defenses.Add(antiVirus.GetComponent<AntiVirusController>());
        Vector3 position = gameObject.transform.position;
        antiVirus.transform.position = new Vector3(position.x-0.66f, position.y + 0.908f, position.z-0.48f);
        antiVirus.SetActive(true);

        //HANDLE MORE THAN ONE AV CREATION ON SAME PC
    }

    private void createFirewall() {
        GameObject firewall = Instantiate(firewallModel);
        defenses.Add(firewall.GetComponent<FirewallController>());
        Vector3 position = gameObject.transform.position;
        firewall.transform.position = new Vector3(position.x - 0.66f, position.y + 0.908f, position.z - 0.48f);
        firewall.SetActive(true);
    }


    private String generateOverflowMex(String defense, String defenses, int max) {
        string message = "No more than ";
        switch (max) {
            case 0:
                message += defense + " not allowed on this element.";
                break;

            case 1:
                message += "a single " + defense + " is allowed on this element.";
                break;

            default:
                message += max + " " + defenses + " are allowed on this element.";
                break;
        }
        return message;
    }

    public void onDrop(GameObject dropped)
    {
        if(dropped.CompareTag("AntiVirus")){
            int maxAV = (int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS].currentValue;
            if (activeAntiVirus<maxAV){
                activeAntiVirus+=1;
                createAntiVirus();
            }
            else ElementOverflow.Invoke(generateOverflowMex("AV", "AVs", maxAV));
           
        }
        else if(dropped.CompareTag("Firewall")){
            int maxFW = (int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_FIREWALL].currentValue;
            if (activeFirewall<maxFW){
                activeFirewall+=1;
                createFirewall();
            }
            else ElementOverflow.Invoke(generateOverflowMex("FW", "FWs", maxFW));
        
        }
        else if(dropped.CompareTag("IDPS"))
        {
            if(activeIDPS<(int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_IDPS].currentValue){
                activeIDPS+=1;
                //defenses.Add(new IDPSController());
                //tocomplete
            }
            else{
                //toast massimo numero 
            }

        }
        else if(dropped.CompareTag("Backup"))
        {
            //definire backup
        }

        updateDefensesFeatures();
    }

}
