using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canvasManager : MonoBehaviour
{
    public static canvasManager instance;


    public TMP_Text LapDisplay, currentLapTimeText, bestLapTimeText;


    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
