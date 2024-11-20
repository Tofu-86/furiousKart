using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpin : MonoBehaviour
{

    void Update()
    {
        //Rotation every frame in the Y direction
        this.transform.Rotate(0,2,0);
    }
}
