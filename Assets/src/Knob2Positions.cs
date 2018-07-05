using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knob2Positions : MonoBehaviour {


    //Every photoElectric sensor has a value

    public bool SensorValue;
    private bool pastSensorValue;

    public bool HasNegateLogic = false;

    public int ButtonByte;
    public int ButtonBit;

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

        //KNOB INPUT WORKING PRINCIPLE
 
        if (SensorValue != pastSensorValue)        //We compare the actual value with the old one.
        {
            m_LineVariables_script.SetBool(ButtonByte, ButtonBit, SensorValue); //If it's different, write it down in the LineVariables to be exchanged with the PLC
            if (SensorValue == true)
            {
                this.gameObject.GetComponent<Transform>().Rotate(0,90,0);
            }
            else
            {
                this.gameObject.GetComponent<Transform>().Rotate(0, -90, 0);
            }
            pastSensorValue = SensorValue;                                //And then, we update to the new value.
        }
    }
    private void OnMouseDown()
    {
        SensorValue = !SensorValue;
        Debug.Log("Mouse went down");
    }
    private void OnMouseUp()
    {
        //SensorValue = false;
        //Debug.Log("Mouse went up");
    }

}
