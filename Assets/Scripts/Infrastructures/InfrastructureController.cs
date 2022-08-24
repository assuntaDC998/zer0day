using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class InfrastructureController : Component, DropArea
{
    public int activeAntiVirus;
    public int activeFirewall;
    public int activeIDPS;
    public int activeBackup;
    public DefensesController[] defenses;


    public override void Awake()
    {
        this.category = "Infrastructure";
        base.Awake();
        activeAntiVirus=0;
        activeFirewall=0;
        activeIDPS=0;
        activeBackup=0;

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

    public void onDrop(GameObject dropped)
    {
        if(dropped.CompareTag("AntiVirus")){
            if(activeAntiVirus<(int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS].currentValue){
                activeAntiVirus+=1;
                defenses.add(new AntiVirusController());
                //tocomplete
            }
            else{
                //toast massimo numero 
            }
        }
        else if(dropped.CompareTag("Firewall")){
            if(activeFirewall<(int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_FIREWALL].currentValue){
                activeFirewall+=1;
                defenses.add(new FirewallController());
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
                defenses.add(new IDPSController());
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
    }

}
