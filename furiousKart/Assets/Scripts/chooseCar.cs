using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCar : MonoBehaviour
{

    public GameObject[] karts;
    int currentKart = 0;

    public float cameraSpeed = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerKart"))
            currentKart = PlayerPrefs.GetInt("PlayerKart");
        

        this.transform.LookAt(karts[currentKart].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentKart++;
            if (currentKart > karts.Length - 1)
                currentKart = 0;

            PlayerPrefs.SetInt("PlayerKart", currentKart);
        }

           Quaternion lookDirection = Quaternion.LookRotation(karts[currentKart].transform.position - this.transform.position);
           this.transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, cameraSpeed);
        

        }
}
