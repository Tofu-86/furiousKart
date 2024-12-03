using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class CurrentLapCount : MonoBehaviourPunCallbacks
{
    public CarController kartController;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            text.text = kartController.currentLap.ToString();
        }
        
    }
}
