using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public BattleBrain battleBrain;

    public Fighter user; // the object using the item

    public string itemType;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Initialize()
    {
        itemType = "blank";
    }

    public virtual void TryUse()
    {
        if (TestCanUse() == true) // if the test returns true, use the item!
        {
            Use();
        }
    }

    public virtual bool TestCanUse()
    {
        if (user.targetFighter is PlayerFighter || user.targetFighter is Enemy) // if it's a player or enemy, then return true (we can target it). Otherwise...
        {
            return true;
        }
        else { return false; } // ...return false.
    }

    public virtual void Use()
    {
        // do nothing :(
    }
}