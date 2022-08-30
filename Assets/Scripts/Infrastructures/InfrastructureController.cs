using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using DefensesFeatures;

public class InfrastructureController : Component, DropArea
{
    public float efficiency;
    public float falsePositives;

    public List<DefenseController> defenses;

    public static event Action<String> ElementOverflow;
    
    public override void Awake()
    {
        this.category = "Infrastructure";
        base.Awake();

        defenses = new List<DefenseController>();

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

    public String generateOverflowMex(String defense, String defenses, int max) {
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

    public virtual void OnDrop(GameObject dropped) {
    }

    public void handleElementOverflow(string message) {
        ElementOverflow.Invoke(message);
    }

}
