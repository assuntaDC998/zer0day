using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseController : Component
{

    private int duration;
    private int timer;

    public override void Awake()
    {
        this.category = "Defense";
        base.Awake();
       
        //duration = (int)features[DefensesFeatures.DefenseFeature.FeatureType.FT_DURATION].currentValue;
        timer = 0;
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
        timer += 1;
        //if (timer > duration) Destroy(gameObject);

        // COMPLETE WITH EVENT DESTROY GENERATION
    }

    public void OnDestroy()
    {
        Debug.Log("Put fading effect");
    }
}
