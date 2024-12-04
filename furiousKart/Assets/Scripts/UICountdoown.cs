using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UICountdoown : MonoBehaviour
{
    public static UICountdoown instance; // making it accessible from anywhere.

    public TMP_Text countDownText; // reference to countDownText

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
