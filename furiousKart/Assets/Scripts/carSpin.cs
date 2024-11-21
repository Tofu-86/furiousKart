using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpin : MonoBehaviour
{

    void Update()
    {
        //Rotation every frame in the Y direction
        this.transform.Rotate(0,0.5f,0);
    }
}
