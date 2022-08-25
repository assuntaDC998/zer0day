using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DefensesFeatures
{
	public abstract class DefenseFeature : Feature
	{	public enum FeatureType 
        {
			FT_EFFICIENCY,
    		FT_FALSE_POSITIVES,
    		FT_DURATION,
            FT_COST
		}

		public DefenseFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
		{
           
		}
	}

	public class EfficiencyDefenseFeature : DefenseFeature
	{

        public EfficiencyDefenseFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {
            Debug.Log(baseValue);
        }

		public override void performeModifier(Modifier m) 
        {
            this.currentValue = (float)this.currentValue + ((1-(float)this.currentValue) * float.Parse(m.m_fFactor));

        }

        public override void removeModifier(Modifier m)
        {
            this.currentValue = ((float)this.currentValue - float.Parse(m.m_fFactor))/(1-float.Parse(m.m_fFactor));
        }
        public override void applyFactor(System.Object factor)
        {
            this.currentValue = (float)factor;
        }

        public override System.Object updateFactor(System.Object factor)
        {
            return (float)this.currentValue + ((1-(float)this.currentValue) * (float)factor);;
        }

        public override System.Object initializeFactor()
        {
            return 0.0f;
        }
	}

    public class FalsePositivesDefenseFeature : DefenseFeature
	{

        public FalsePositivesDefenseFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {
        }

		public override void performeModifier(Modifier m)
        {
            this.currentValue = (float)this.currentValue + ((1-(float)this.currentValue) * float.Parse(m.m_fFactor));

        }

        public override void removeModifier(Modifier m)
        {
            this.currentValue = ((float)this.currentValue - float.Parse(m.m_fFactor))/(1-float.Parse(m.m_fFactor));
        }
        public override void applyFactor(System.Object factor)
        {
            this.currentValue = (float)factor;
        }

        public override System.Object updateFactor(System.Object factor)
        {
            return (float)this.currentValue + ((1-(float)this.currentValue) * (float)factor);
        }

        public override System.Object initializeFactor()
        {
            return 0.0f;
        }
	}

	public class DurationDefenseFeature : DefenseFeature
	{

        public DurationDefenseFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {
        }

        public override void performeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue + int.Parse(m.m_fFactor);

        }

        public override void removeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue - int.Parse(m.m_fFactor);

        }
        public override void applyFactor(System.Object factor)
        {
            this.currentValue = (int)this.baseValue + (int)factor;
        }

        public override System.Object updateFactor(System.Object factor)
        {
            return (int)factor + (int)currentValue;
        }

        public override System.Object initializeFactor()
        {
            return 0;
        }
	}

    public class CostDefenseFeature : DefenseFeature
    {

        public CostDefenseFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {
        }

        public override void performeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue + int.Parse(m.m_fFactor);

        }

        public override void removeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue - int.Parse(m.m_fFactor);

        }
        public override void applyFactor(System.Object factor)
        {
            this.currentValue = (int)this.baseValue + (int)factor;
        }

        public override System.Object updateFactor(System.Object factor)
        {
            return (int)factor + (int)currentValue;
        }

        public override System.Object initializeFactor()
        {
            return 0;
        }
    }



}