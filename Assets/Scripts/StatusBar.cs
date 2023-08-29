using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;

public class StatusBar : MonoBehaviour
{
    public Fighter parentFighter;
    
    FieldInfo targetFieldValue;
    FieldInfo targetFieldOutOf;

    public string valueName;
    public string outOfName;

    float statValue;
    float statOutOf;

    float newScale;
    float oldScale;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // setting up targetField to use reflection
        targetFieldValue = parentFighter.GetType().GetField(valueName);
        targetFieldOutOf = parentFighter.GetType().GetField(outOfName);

        // finding the stats from our parentFighter
        statValue = (float)targetFieldValue.GetValue(parentFighter);
        statOutOf = (float)targetFieldOutOf.GetValue(parentFighter);

        // determining the scale of our stats
        newScale = statValue / statOutOf;
        
        // testing if the scale has changed
        if (oldScale != newScale)
        {
            // if so, we set the fillamount of the stat bar, and set the scales equal to one another
            slider.value = newScale;
            oldScale = newScale;
        }

        // testing death
        if (parentFighter.isDead)
        {
            this.gameObject.SetActive(false);
        }    
    }
}
