using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLine : MonoBehaviour {

    public bool ConveyorLineMotorValue = false;
    public int ConveyorLineMotorByte;
    public int ConveyorLineMotorBit;

    public int HighSpeedCounterLineValue = 0;
    public int HighSpeedCounterLineByte;

    public float desiredspeed = 0.3f;
    public float visualSpeedScalar = 1;

    private Vector3 forcedirection;
    private float currentScroll;
    private GameObject m_LineVariables;  //need to initialize at start
    LineVariables m_LineVariables_script; //need to initialize at start
    public bool AllowTheMovement = true;

    public bool SomethingOnTheLine = false;
    // Use this for initialization
    void Start()
    {

        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();

    }
    private void Update()
    {
        ConveyorLineMotorValue = m_LineVariables_script.GetBool(ConveyorLineMotorByte, ConveyorLineMotorBit);//We get the actual value
        // Scroll texture to fake it moving
        if (ConveyorLineMotorValue)
        {
            if (HighSpeedCounterLineValue + (int)(2048 * (Time.deltaTime * desiredspeed) / 0.942f) < 100000)
            {
                HighSpeedCounterLineValue = HighSpeedCounterLineValue + (int)(2048 * (Time.deltaTime * desiredspeed * 2) / 0.942f);
            }
            else
            {
                HighSpeedCounterLineValue = HighSpeedCounterLineValue + (int)(2048 * (Time.deltaTime * desiredspeed * 2) / 0.942f) - 100000;
            }

            m_LineVariables_script.SetIntDec(HighSpeedCounterLineByte, HighSpeedCounterLineValue); // We set the encoder value

            //currentScroll = currentScroll + Time.deltaTime * desiredspeed * visualSpeedScalar;
            //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, currentScroll);
        }
        if (Input.GetKeyDown("o"))
        {
            AllowTheMovement = !AllowTheMovement;
        }
    }

    // Anything that is touching will move
    // This function repeats as long as the object is touching
    void OnTriggerStay(Collider otherThing)
    {
        SomethingOnTheLine = true;
        if (ConveyorLineMotorValue && AllowTheMovement && otherThing.gameObject.CompareTag("BrickOnTheLine"))
        {
            // Get the direction of the conveyor belt 
            // (transform.forward is a built in Vector3 
            // which is used to get the forward facing direction)
            // * Remember Vector3's can used for position AND direction AND rotation
            float actualspeed = otherThing.GetComponent<Rigidbody>().velocity.magnitude;
            forcedirection = -transform.forward;
            forcedirection = forcedirection * (desiredspeed - actualspeed);



            // Add a WORLD force to the other objects
            // Ignore the mass of the other objects so they all go the same speed (ForceMode.Acceleration)
            //otherThing.rigidbody.AddForce(direction, ForceMode.Acceleration);
            //    otherThing.rigidbody

            //if (actualspeed <= desiredspeed)
            //{
            //    otherThing.GetComponent<Rigidbody>().AddForce(forcedirection/10, ForceMode.VelocityChange);
            //}

            Vector3 speedvector;
            speedvector.x = 0;
            speedvector.y = 0;
            speedvector.z = -desiredspeed;
            otherThing.GetComponent<Rigidbody>().position = otherThing.GetComponent<Rigidbody>().position + speedvector * Time.deltaTime;

        }
    }
}
