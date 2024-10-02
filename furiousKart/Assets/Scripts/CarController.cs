using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarController : MonoBehaviour
{


    private Rigidbody rb;
    public WheelColliders colliders;
    public WheelMeshes wheelMeshes;


    //Two float variables to hold keyboard input values between -1 and 1
    public float throttleInput;
    public float steeringInput;


    //Variable controlling how strong much power the engine will provide to the rear wheels.
    public float engineStrength;

    private float speed;



    //Animation curve to change the steering sensitivity based on speed to allow for smoother wheel movements.
    //dynamically changing it
    public AnimationCurve steeringCurve;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        speed = rb.velocity.magnitude;

        CheckInput();
        applyPower();
        applySteering();
        UpdateWheelPos();
    }


    void CheckInput()
        
    {

        //checks for keyboard inputs between -1 and 1
        throttleInput = Input.GetAxis("Vertical"); // checks W and S or Up arrow and Down arrow
        steeringInput = Input.GetAxis("Horizontal");// checks A or D or right arrow and left arrow
    }


    void applyPower() 
    {
        //motorTorque is a property of WheelCollider
        //value of motorTorque updated for each collider when a throttleInput is detected
        //times by the constant engineStrength variable 
        //allowing the rearwheels to get power and move the vehicle
        colliders.RLwheel.motorTorque = engineStrength * throttleInput;
        colliders.RRwheel.motorTorque = engineStrength * throttleInput;
    }

    void applySteering()
    {


        //generates steeringAngle based on the speed and steeringInput
        //steeringcurve.evaluate(speed) will dynamically adjust steering sensitivity
        //based ont the speed of the rigidbody.
        //as steeringInput is a range from -1 and 1, the angles will adjust for the ranges between total left and right.
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        
        //WheelCollider has the property of steerAngle
        //steerAngle for each collider on the front two wheels is set to the calculated steeringAngle 
        //when a steeringInput is detected
        colliders.FRwheel.steerAngle = steeringAngle;
        colliders.FLwheel.steerAngle = steeringAngle;
    }


    void UpdateWheelPos()

    {
        //using function to move wheels to given position
        UpdateWheel(colliders.FRwheel, wheelMeshes.FRwheel);
        UpdateWheel(colliders.FLwheel, wheelMeshes.FLwheel);
        UpdateWheel(colliders.RRwheel, wheelMeshes.RRwheel);
        UpdateWheel(colliders.RLwheel, wheelMeshes.RLwheel);

    }

    void UpdateWheel(WheelCollider wheelC, MeshRenderer wheelM) //Wheelcollider wheelC represents the physics wheel,
                                                                //meshrender reprents the visual model of the wheel. 
    {
        Quaternion quat; //rotation of the wheel
        Vector3 position;  //position of the wheel 

        wheelC.GetWorldPose(out position, out quat); //unity function to get rotation and position of wheels
        wheelM.transform.position = position;  //matches wheels to position and rotation according to getwoldpos.
        wheelM.transform.rotation = quat;      //matches the wheelcollider rotation to the visual model of the wheel. 
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
