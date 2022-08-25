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
    
    public GameObject antiVirus_base;

    public override void Start()
    {
        //Load Prefab
        antiVirus_base = Resources.Load("Models/Defenses/AntiVirus") as GameObject;
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
        GameObject antiVirus = Instantiate(antiVirus_base);
        defenses.Add(antiVirus.GetComponent<AntiVirusController>());
        antiVirus.transform.position = gameObject.transform.position;
        antiVirus.SetActive(true);
    }

    public void onDrop(GameObject dropped)
    {
        if(dropped.CompareTag("AntiVirus")){
            int maxAV = (int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS].currentValue;
            if (activeAntiVirus<maxAV){
                activeAntiVirus+=1;
                createAntiVirus();
            }
            else{
                string message = "You can't add more than one antivirus on this element.";
                ElementOverflow.Invoke(message);
            }
        }
        else if(dropped.CompareTag("Firewall")){
            if(activeFirewall<(int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_FIREWALL].currentValue){
                activeFirewall+=1;
                //defenses.Add(new FirewallController());
                //tocomplete
            }
            else{
                //toast massimo numero 
            }
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
