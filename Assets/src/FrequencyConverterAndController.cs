using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyConverterAndController : MonoBehaviour {

    public bool EquipmentPressureDetectionValue = true;
    public int EquipmentPressureDetectionByte;
    public int EquipmentPressureDetectionBit;

    public bool TheConveyorLineMotorFrequencyConverterFaultValue = true;
    public int TheConveyorLineMotorFrequencyConverterFaultByte;
    public int TheConveyorLineMotorFrequencyConverterFaultBit;

    public bool M01FrequencyConverterFaultValue=true;
    public int M01FrequencyConverterFaultByte;
    public int M01FrequencyConverterFaultBit;

    public bool M02FrequencyConverterFaultValue = true;
    public int M02FrequencyConverterFaultByte;
    public int M02FrequencyConverterFaultBit;

    public bool M04FrequencyConverterFaultValue = true;
    public int M04FrequencyConverterFaultByte;
    public int M04FrequencyConverterFaultBit;

    public bool M05FrequencyConverterFaultValue = true;
    public int M05FrequencyConverterFaultByte;
    public int M05FrequencyConverterFaultBit;

    public bool M07FrequencyConverterFaultValue = true;
    public int M07FrequencyConverterFaultByte;
    public int M07FrequencyConverterFaultBit;

    public bool M08FrequencyConverterFaultValue = true;
    public int M08FrequencyConverterFaultByte;
    public int M08FrequencyConverterFaultBit;

    public bool M10FrequencyConverterFaultValue = true;
    public int M10FrequencyConverterFaultByte;
    public int M10FrequencyConverterFaultBit;

    public bool M11FrequencyConverterFaultValue = true;
    public int M11FrequencyConverterFaultByte;
    public int M11FrequencyConverterFaultBit;

    public bool M13FrequencyConverterFaultValue = true;
    public int M13FrequencyConverterFaultByte;
    public int M13FrequencyConverterFaultBit;

    public bool M14FrequencyConverterFaultValue = true;
    public int M14FrequencyConverterFaultByte;
    public int M14FrequencyConverterFaultBit;

    public bool M03ServoControllerFaultValue = true;
    public int M03ServoControllerFaultByte;
    public int M03ServoControllerFaultBit;

    public bool M06ServoControllerFaultValue = true;
    public int M06ServoControllerFaultByte;
    public int M06ServoControllerFaultBit;

    public bool M09ServoControllerFaultValue = true;
    public int M09ServoControllerFaultByte;
    public int M09ServoControllerFaultBit;

    public bool M12ServoControllerFaultValue = true;
    public int M12ServoControllerFaultByte;
    public int M12ServoControllerFaultBit;

    public bool M15ServoControllerFaultValue = true;
    public int M15ServoControllerFaultByte;
    public int M15ServoControllerFaultBit;

    private GameObject m_LineVariables;  //need to initialize at start
    LineVariables m_LineVariables_script; //need to initialize at start

    // Use this for initialization
    void Start()
    {
        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();
    }
    
	
	// Update is called once per frame
	void Update () {

        m_LineVariables_script.SetBool(M01FrequencyConverterFaultByte, M01FrequencyConverterFaultBit, M01FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M02FrequencyConverterFaultByte, M02FrequencyConverterFaultBit, M02FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M04FrequencyConverterFaultByte, M04FrequencyConverterFaultBit, M04FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M05FrequencyConverterFaultByte, M05FrequencyConverterFaultBit, M05FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M07FrequencyConverterFaultByte, M07FrequencyConverterFaultBit, M07FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M08FrequencyConverterFaultByte, M08FrequencyConverterFaultBit, M08FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M10FrequencyConverterFaultByte, M10FrequencyConverterFaultBit, M10FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M11FrequencyConverterFaultByte, M11FrequencyConverterFaultBit, M11FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M13FrequencyConverterFaultByte, M13FrequencyConverterFaultBit, M13FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M14FrequencyConverterFaultByte, M14FrequencyConverterFaultBit, M14FrequencyConverterFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M03ServoControllerFaultByte, M03ServoControllerFaultBit, M03ServoControllerFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M06ServoControllerFaultByte, M06ServoControllerFaultBit, M06ServoControllerFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M09ServoControllerFaultByte, M09ServoControllerFaultBit, M09ServoControllerFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M12ServoControllerFaultByte, M12ServoControllerFaultBit, M12ServoControllerFaultValue); //write it down in the LineVariables to be exchanged with the PLC
        m_LineVariables_script.SetBool(M15ServoControllerFaultByte, M15ServoControllerFaultBit, M15ServoControllerFaultValue); //write it down in the LineVariables to be exchanged with the PLC
    }
}
