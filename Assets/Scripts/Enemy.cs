using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    // whether we're ready to attack or not
    bool actReady;

    // 
    public int attackTicks;
    public int attackTicksMax;

    // to randomly decide health between two constants
    public int randomHealthTop;
    public int randomHealthBottom;

    // equipment this weapon has on hand
    public List<Equipment> equipment;

    // for random generation
    System.Random random;

    public Vector3 pointerPosition;

    // our spriteRenderer
    public EnemySprite enemySprite;

    public void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        UpdatePointerPosition();
    }

    public override void Initialize()
    {
        base.Initialize();

        targetFighter = battleBrain.playerOne;
        random = new System.Random();

        // setting health, magic, etc to defaults at spawn
        healthMax = random.Next(randomHealthBottom, randomHealthTop);
        health = healthMax;

        //ChanceCheck();
    }

    public override void EnergyTick()
    {
        // ticking energy
        if (this.isAlive && !this.isDead) // don't tick if we're dead or about to attack!
        {
            // calculating the ticking. This is for increasing health, magic, etc
            statTicks++;

            if (statTicks >= statTickMax)
            {
                IncreaseEnergy();

                // reset ticks
                statTicks = 0;

                // try to act
                TryToAct();
            }
        }
    }

    public void TryToAct()
    {
        if (this.energy >= this.energyMax)
        {
            if (actReady == true)
            {
                Act();
            }
            else if (actReady == false)
            {
                if (attackTicks < attackTicksMax)
                {
                    attackTicks++;
                }
                else if (attackTicks == attackTicksMax)
                {
                    actReady = true;
                }
            }
        }
    }

    public void Act()
    {
        if (equipment.Count > 1)
        {
            int indexToUse = random.Next(0, equipment.Count - 1);
            Debug.Log(indexToUse);
            equipment[indexToUse].TryUse();
        }
        else if (equipment.Count == 1)
        {
            equipment[0].TryUse();
        }
        else
        {
            // do nothing
        }

        attackTicks = 0;
        actReady = false;
    }

    // updates the position the pointer should go (changes by spriteRenderers position)
    public void UpdatePointerPosition()
    {
        this.pointerPosition = new Vector3(this.enemySprite.spriteX, this.enemySprite.spriteY + this.enemySprite.spriteHeight / 2, this.enemySprite.spriteZ);
    }
}