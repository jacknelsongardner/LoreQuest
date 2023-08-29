using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    public float energyCost;
    public float damageToCause;

    // Start is called before the first frame update
    void Start()
    {
        this.itemType = "melee";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        user.targetFighter.TakeDamage(this.damageToCause, this);
        user.energy = user.energy - this.energyCost;
        Debug.Log("!!!used!!!");
    }

    public override bool TestCanUse()
    {
        if (user.targetFighter is PlayerFighter || user.targetFighter is Enemy) // if it's a player or enemy, then return true (we can target it). Otherwise...
        {
            if (user.energy >= this.energyCost && user.targetFighter.isAlive && this.user.isAlive) // if the user, enemy are alive and the user has enough energy
            {
                return true;
            }
            return false;
        }
        else { return false; } // ...return false.
    }
}
