using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerScript : MonoBehaviour {

    // Use this for initialization

    //public GameObject w;
    //public Transform w_transform;

    public GameObject PickedBrick;
    public Transform PickedBrickPreviousParent;

    public Collider SuckerCollider;

    public bool Pick;
    public bool Picked;
    public bool Collision;

    public bool VacuumActive;

    /*
    public bool Manipulator_zAxisMotorReversalValue;
    public int Manipulator_zAxisMotorReversalByte;
    public int Manipulator_zAxisMotorReversalBit;
    */
    public bool Manipulator_VacuumValveClosedValue;
    public int Manipulator_VacuumValveClosedByte;
    public int Manipulator_VacuumValveClosedBit;

    public bool Manipulator_VacuumValveOpenValue;
    public int Manipulator_VacuumValveOpenByte;
    public int Manipulator_VacuumValveOpenBit;

    public bool NegativePressureDetection1Value;
    public int NegativePressureDetection1Byte;
    public int NegativePressureDetection1Bit;

    public bool NegativePressureDetection2Value;
    public int NegativePressureDetection2Byte;
    public int NegativePressureDetection2Bit;

    public bool NegativePressureDetection3Value;
    public int NegativePressureDetection3Byte;
    public int NegativePressureDetection3Bit;

    public bool NegativePressureDetection4Value;
    public int NegativePressureDetection4Byte;
    public int NegativePressureDetection4Bit;
    //-----------------------------------------------
    private GameObject m_LineVariables;  //need to initialize at start
    LineVariables m_LineVariables_script; //need to initialize at start

    void Start () {
        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();
    }
	
	// Update is called once per frame
    void Update()
    {
        m_LineVariables_script.SetBool(NegativePressureDetection1Byte, NegativePressureDetection1Bit, NegativePressureDetection1Value); //Write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(NegativePressureDetection2Byte, NegativePressureDetection2Bit, NegativePressureDetection2Value); //Write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(NegativePressureDetection3Byte, NegativePressureDetection3Bit, NegativePressureDetection3Value); //Write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(NegativePressureDetection4Byte, NegativePressureDetection4Bit, NegativePressureDetection4Value); //Write it down in the LineVariables to be exchanged with the PLC


        Manipulator_VacuumValveClosedValue = m_LineVariables_script.GetBool(Manipulator_VacuumValveClosedByte, Manipulator_VacuumValveClosedBit);//We get the actual value
        Manipulator_VacuumValveOpenValue = m_LineVariables_script.GetBool(Manipulator_VacuumValveOpenByte, Manipulator_VacuumValveOpenBit);//We get the actual value
        //Manipulator_zAxisMotorReversalValue = m_LineVariables_script.GetBool(Manipulator_zAxisMotorReversalByte, Manipulator_zAxisMotorReversalBit);//We get the actual value

        VacuumActive = !Manipulator_VacuumValveClosedValue && Manipulator_VacuumValveOpenValue;

        NegativePressureDetection1Value = Picked;
        NegativePressureDetection2Value = Picked;
        NegativePressureDetection3Value = Picked;
        NegativePressureDetection4Value = Picked;

        if (Input.GetKey("p")) Pick = !Pick;

        if (!Pick && !VacuumActive && Picked)
        {


            PickedBrick.tag = "BrickOnTheLine";
            PickedBrick.transform.SetParent(PickedBrickPreviousParent);
            PickedBrick.AddComponent<Rigidbody>();
            PickedBrick.GetComponent<Rigidbody>().mass = 10;
            PickedBrick.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
            PickedBrick.GetComponent<Collider>().isTrigger = false;
            Picked = false;
            SuckerCollider.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BrickOnTheLine") && (Pick || VacuumActive) && Picked == false)
        {

            SuckerCollider.enabled = false;

            PickedBrick = other.gameObject;
            Destroy(PickedBrick.GetComponent<Rigidbody>());
            PickedBrick.GetComponent<Collider>().isTrigger = true;
            PickedBrickPreviousParent = PickedBrick.transform.parent;
            PickedBrick.transform.SetParent(transform);
            PickedBrick.tag = "PickedBrick";
            Picked = true;
        }
        else if(other.gameObject.CompareTag("LineCollider")==false)
        {
            Collision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LineCollider") == false) Collision = false;
    }
}
