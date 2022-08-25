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
    public List<DefenseController> defenses;

    public GameObject antiVirus_base;

    public override void Start()
    {
        antiVirus_base = Resources.Load("AntiVirus") as GameObject;
        //antiVirus_base = GameObject.Find("AntiVirus");
        //antiVirus_base.SetActive(true);
        if (antiVirus_base==null) Debug.Log("NULL AV BASE");

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
            int maxAV = (int)features[InfrastructuresFeatures.InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS].currentValue;
            if (activeAntiVirus<maxAV){
                activeAntiVirus+=1;
                Debug.Log("AV added");
                //tocomplete
               
                GameObject antiVirus = Instantiate(antiVirus_base);
                antiVirus.transform.position = new Vector3(42f, 0f, 40f);
                antiVirus.SetActive(true);
               
            }
            else{
                string message = "You can't add more than one AV on this element.";
                GameObject.Find("NotificationMessage").GetComponent<Notification>().NotifyUser(message);
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
    }

}
