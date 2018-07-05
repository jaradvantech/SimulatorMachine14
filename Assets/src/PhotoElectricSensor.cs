using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhotoElectricSensor : MonoBehaviour {


    //Every photoElectric sensor has a value

    public bool SensorValue;
    private bool pastValue;
    public bool HasNegateLogic = false;

    public int collisionCounter=0;

    public bool Forced = false;
    public int Byte;
    public int Bit;

    private GameObject m_LineVariables;  //need to initialize at start
    LineVariables m_LineVariables_script; //need to initialize at start

    // Use this for initialization
    void Start () {
        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();
        SensorValue = HasNegateLogic;
    }
	
	// Update is called once per frame
	void Update () {
        //If the state is forced, it doesn't matter the number of colliding objects.
        if (Forced == false)
        {
            //Check the collision counter. If the number of objects colliding is higher than 0 we can asume that there is something colliding
            if (collisionCounter > 0) { SensorValue = true ^ HasNegateLogic; }
            else { SensorValue = false ^ HasNegateLogic; }
        }


        //We compare the actual value with the old one. 
        if (SensorValue != pastValue)
        {
            m_LineVariables_script.SetBool(Byte, Bit,SensorValue); //If it's different, write it down in the LineVariables to be exchanged with the PLC
            pastValue = SensorValue;                                //And then, we update to the new value.
        }
    }

    private void OnTriggerEnter(Collider someThing)
    {
        if( ! someThing.gameObject.CompareTag("LineCollider")) collisionCounter++;
    }

    private void OnTriggerExit(Collider someThing)
    {
        if (!someThing.gameObject.CompareTag("LineCollider")) collisionCounter--;

    }

}
