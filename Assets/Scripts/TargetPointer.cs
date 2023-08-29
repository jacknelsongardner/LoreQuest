using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointer : MonoBehaviour
{
    public PlayerFighter playerFighter;

    // for the glove/pointer offset
    public float offsetY;
    public float offsetX;
    Vector3 offsetVector;


    // Start is called before the first frame update
    void Start()
    {
        offsetVector = new Vector3(offsetX,offsetY,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerFighter.GetTargetEnemy().pointerPosition + offsetVector;
    }
}
