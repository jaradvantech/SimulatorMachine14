using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LampIndicator : MonoBehaviour {


    //Every photoElectric sensor has a value

    public bool LightValue;
    private bool pastLightValue;
    private bool HasNegateLogic = false;

    public int LightByte;
    public int LightBit;

    public Material MaterialOn;
    public Material MaterialOff;


    private GameObject m_LineVariables;  //need to initialize at start
    LineVariables m_LineVariables_script; //need to initialize at start

    // Use this for initialization
    void Start () {
        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();
    }
	
	// Update is called once per frame
	void Update () {
        //OUTPUT LIGHT WORKING PRINCIPLE

        LightValue = m_LineVariables_script.GetBool(LightByte, LightBit);//We get the actual value

        if (LightValue != pastLightValue) //We compare the actual value with the old one.
        {
            if (LightValue == true)
            {
                this.gameObject.GetComponent<MeshRenderer>().material = MaterialOn; //If it's different, change the lamp colour
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material = MaterialOff; //If it's different, change the lamp colour
            }
            pastLightValue = LightValue;                                //And then, we update to the new value.
        }
    }
}
