using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public String name;

    // bools for if we're idle, charging up, attacking, dead, etc
    public bool isCharging;
    public bool isIdle;
    public bool isAttacking;
    public bool isTakingDamage;

    public bool isAlive;
    public bool isDead;

    // reference for battleBrain
    public BattleBrain battleBrain;
    public Fighter targetFighter;

    // player stats for HP, MP, and ENERGY
    public float health;
    public float healthMax;

    public float startEnergy;
    public float energy;
    public float energyMax;
    public float energySpeed;

    public float magic;
    public float magicMax;

    public float attackPower;
    public float defencePower;

    // the set of enemies we are targetting
    public List<Enemy> enemiesOnScreen;

    // to track ticking (how long between ticks)
    public int statTickMax;
    public int statTicks;

    // Start is called before the first frame update
    protected void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    protected void Update()
    {
        HealthCheck();
        MagicCheck();
        EnergyCheck();
        DeathCheck();

        EnergyTick();
    }

    public virtual void Initialize()
    {
        this.isAlive = true;
        this.isDead = false;

        this.energy = this.startEnergy;
    }

    // CHECKERS, TO MAKE SURE HEALTH, MAGIC, AND ENERGY ARE OPERATING CORRECTLY

    public virtual void HealthCheck()
    {
        if (health < 0.0f) // making sure it's not less than zero
        {
            health = 0.0f;
        }
        else if (health >= healthMax) // if playerEnergy has equalled or surpassed the max ammount,
        {
            // set playerEnergy to playerEnergyMax
            health = healthMax;
        }
    }

    public virtual void MagicCheck()
    {
        if (magic < 0.0f) // making sure it's not less than zero
        {
            magic = 0.0f;
        }
        else if (magic >= magicMax) // if playerEnergy has equalled or surpassed the max ammount,
        {
            // set playerEnergy to playerEnergyMax
            magic = magicMax;
        }
    }

    public virtual void EnergyCheck()
    {
        if (energy < 0.0f) // making sure it's not less than zero
        {
            this.energy = 0.0f;
        }

        if (energy >= energyMax) // if playerEnergy has equalled or surpassed the max ammount,
        {
            // set playerEnergy to playerEnergyMax
            this.energy = energyMax;
        }
    }

    public virtual void DeathCheck()
    {
        if (health <= 0.0f)
        {
            isDead = true;
            isAlive = false;
        }
    }

    // TICKING

    public virtual void EnergyTick()
    {
        if (this.isAlive && !this.isDead) // don't tick if we're dead!
        {
            // calculating the ticking. This is for increasing health, magic, etc
            statTicks++;
            if (statTicks >= statTickMax)
            {
                IncreaseEnergy();

                // reset ticks
                statTicks = 0;
            }
        }
    }

    public virtual void IncreaseEnergy()
    {
        if (energy <= energyMax - energySpeed)
        {
            energy += energySpeed;
        }
        else if (energy > energyMax - energySpeed)
        {
            energy = energyMax;
        }
        
    }

    // METHOD TO TAKE DAMAGE
    public virtual void TakeDamage(float attackValue, Equipment attackEquipment)
    {
        Debug.Log(this.name);

        float damage = attackValue - this.defencePower;
        Debug.Log("taken:" + damage.ToString() + "damage");
        
        this.health -= damage;
        Debug.Log("health:" + this.health);
    }
}
