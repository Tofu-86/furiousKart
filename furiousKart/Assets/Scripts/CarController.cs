using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{



    public WheelColliders colliders;
    public WheelMeshes wheelMeshes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWheelPos();
    }

    void UpdateWheelPos()

    {


        //using function to move wheels to given position
        UpdateWheel(colliders.FRwheel, wheelMeshes.FRwheel);
        UpdateWheel(colliders.FLwheel, wheelMeshes.FLwheel);
        UpdateWheel(colliders.RRwheel, wheelMeshes.RRwheel);
        UpdateWheel(colliders.RLwheel, wheelMeshes.RLwheel);

    }

    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat; //rotation
        Vector3 position;  

        coll.GetWorldPose(out position, out quat); //unity function to get rotation and position of wheels
        wheelMesh.transform.position = position;  //moving wheels to position and rotation according to getwoldpos.
        wheelMesh.transform.rotation = quat;
    }


}

//class to hold wheels, serializable field to make it editble in unity.
[System.Serializable]
public class WheelColliders //holds wheelcolliders
{
    public WheelCollider FRwheel;
    public WheelCollider FLwheel;
    public WheelCollider RRwheel;
    public WheelCollider RLwheel;
}
[System.Serializable]
public class WheelMeshes //holds wheelmeshes or the art
{
    public MeshRenderer FRwheel;
    public MeshRenderer FLwheel;
    public MeshRenderer RRwheel;
    public MeshRenderer RLwheel;
}
