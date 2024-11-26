using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{


    public checkpoints[] checkPoint; // Check point array with all checkpoints.


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < checkPoint.Length; i++) // starting at pos 0 , checks that i is less than the array, looping through and adding one each time.
        {
            checkPoint[i].checkPointNum = i; // each checkpoint item in the array is checked against the checkpoints numbers and set to i.
        }   


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
