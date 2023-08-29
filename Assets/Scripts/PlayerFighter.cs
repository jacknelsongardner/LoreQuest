using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Fighter
{
    public int targetFighterIndex;

    public Equipment EquipA;
    public Equipment EquipB;
    public Equipment EquipC;
    public Equipment EquipD;
    public Equipment EquipE;
    public Equipment EquipF;

    // flags for the keyboard
    public bool aKeyDown;
    public bool sKeyDown;
    public bool dKeyDown;
    public bool qKeyDown;
    public bool wKeyDown;
    public bool eKeyDown;

    public bool leftKeyDown;
    public bool rightKeyDown;
    public bool spaceKeyDown;
    public bool pKeyDown;

    // Start is called before the first frame update
    protected void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();

        // check keyboard input (for if we're going to use item, or if we're going to run, pause, etc)
        CheckKeyboardDown();
        CheckKeyboardUp();

        // updating and checking the targetEnemy stats
        TargetCheck();
        TargetEnemyUpdate();
    }

    public override void Initialize()
    {
        base.Initialize();

        targetFighterIndex = 0;
    }

    // GETTERS

    public Enemy GetTargetEnemy()
    {
        return this.targetFighter as Enemy;
    }

    // INPUT 
    void CheckKeyboardDown()
    {
        // checking for input for using items a,b,c,d,e,f
        if (Input.GetKeyDown(KeyCode.A) && !aKeyDown)
        {
            UseItem('A');
            aKeyDown = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && !sKeyDown)
        {
            UseItem('B');
            sKeyDown = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && !dKeyDown)
        {
            UseItem('C');
            dKeyDown = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && !qKeyDown)
        {
            UseItem('D');
            qKeyDown = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && !wKeyDown)
        {
            UseItem('E');
            wKeyDown = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && !eKeyDown)
        {
            UseItem('F');
            eKeyDown = true;
        }

        // checking for input for using space (to run)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO : BEGIN RUN SEQUENCE
        }

        // checking for input for using p (to pause)
        if (Input.GetKeyDown(KeyCode.P))
        {
            // TODO : IMPLEMENT PAUSE
        }

        // checking for left and right input (for switching enemies to attack)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TargetDown();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TargetUp();
        }
    }

    void CheckKeyboardUp()
    {

        // checking for input for using items a,b,c,d,e,f
        if (Input.GetKeyUp(KeyCode.A))
        {
            aKeyDown = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            dKeyDown = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            sKeyDown = false;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            qKeyDown = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            wKeyDown = false;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            eKeyDown = false;
        }

        // checking for input for using space (to run)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceKeyDown = false;
        }

        // checking for input for using p (to pause)
        if (Input.GetKeyUp(KeyCode.P))
        {
            pKeyDown = false;
        }

        // checking for left and right input (for switching enemies to attack)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftKeyDown = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightKeyDown = false;
        }
    }

    // ITEM USAGE
    void UseItem(char item)
    {
        if (item == 'a' || item == 'A')
        {
            // use a item on targetted enemy
            EquipA.TryUse();
        }
        else if (item == 'b' || item == 'B')
        {
            // use b item on targetted enemy
            EquipB.TryUse();
        }
        else if (item == 'c' || item == 'C')
        {
            // use c item on targetted enemy
            EquipC.TryUse();
        }
        else if (item == 'd' || item == 'D')
        {
            // use d item on targetted enemy
            EquipD.TryUse();
        }
        else if (item == 'e' || item == 'E')
        {
            // use e item on targetted enemy
            EquipE.TryUse();
        }
        else if (item == 'f' || item == 'F')
        {
            // use f item on targetted enemy
            EquipF.TryUse();
        }
    }

    // TARGETTING SYSTEM

    void TargetCheck()
    {
        if (targetFighterIndex > battleBrain.enemiesOnScreen.Count - 1) // checking if targetEnemyIndex is higher than the top of the enemiesOnScreen
        {
            targetFighterIndex = 0;
        }

        if (targetFighterIndex < 0) // checking for if it's less than zero
        {
            targetFighterIndex = enemiesOnScreen.Count - 1;
        }
    }

    void TargetUp()
    {
        if (targetFighterIndex < battleBrain.enemiesOnScreen.Count)
        {
            targetFighterIndex++;
        }
        else if (targetFighterIndex == battleBrain.enemiesOnScreen.Count - 1)
        {
            targetFighterIndex = 0;
        }
    }

    void TargetDown()
    {
        if (targetFighterIndex > 0)
        {
            targetFighterIndex--;
        }
        else if (targetFighterIndex == 0)
        {
            targetFighterIndex = battleBrain.enemiesOnScreen.Count - 1;
        }
    }

    void TargetEnemyUpdate()
    {
        if (battleBrain.enemiesOnScreen.Count > 0)
        {
            targetFighter = battleBrain.enemiesOnScreen[targetFighterIndex];
        }
    }

    // RUNNING AND PAUSING
    void TryRun()
    {
        // TODO : ADD THE RUNNING FUNCTION
    }

    void PauseBattle()
    {
        // TODO : MAKE IT PAUSE
    }
}
