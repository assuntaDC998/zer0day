using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image bar;
    public TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill() {
        // Range check
        if (current < 0f) current = 0;
        if (current > maximum) current = maximum;

        // Fill progress and show percentage
        bar.fillAmount = (float)current / (float)maximum;
        label.text = current + "%";
    }
}
