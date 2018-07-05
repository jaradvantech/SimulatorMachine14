using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Every manipulator has:
//
//  Inputs to feed to the PLC:                                  //Defined at
//-Manipulator x-Axis positioning proximity sensor 1.           GameObject_x
//-Manipulator x-Axis positioning proximity sensor 2.           GameObject_x
//-Manipulator x-Axis deceleration proximity sensor.            GameObject_x
//-Manipulator x-Axis mechanical limit.                         GameObject_x
//
//-Manipulator z-Axis origin photosensor.                       GameObject_x
//-Manipulator z-Axis mechanical limit.                         GameObject_x
//
//-Manipulator w-Axis origin photosensor.                       GameObject_z
//-Manipulator w-Axis mechanical limit.                         GameObject_w
//-Manipulator grab limit photosensor.                          GameObject_w
//-Manipulator w-Axis grab bricks wait position.                GameObject_z
//-Manipulator w-Axis stop position.                            GameObject_z
//-Manipulator w-Axis grab photosensor.                         GameObject_w
//
//Manipulator negative pressure detection 1.                    Manipulator.cs
//Manipulator negative pressure detection 2.                    Manipulator.cs
//Manipulator negative pressure detection 3.                    Manipulator.cs
//Manipulator negative pressure detection 4.                    Manipulator.cs
//
//
//
//
//
//
//
//
//
//


public class Manipulator : MonoBehaviour {
    public GameObject parentGameObject;
    public GameObject GameObject_bar;
    public GameObject GameObject_x;
    public GameObject GameObject_z;
    public GameObject GameObject_w;
    public GameObject[] GameObject_sucker;
    public SuckerScript GameObject_sucker_script;

    //-----------------------------------------------
    //PLC Inputs


    public int Manipulator_HighSpeedCounterValue=20;
    public int Manipulator_HighSpeedCounterByte;
    //-----------------------------------------------
    //PLC Outputs
    //x
    public bool Manipulator_xAxisMotorForwardValue;
    public int Manipulator_xAxisMotorForwardByte;
    public int Manipulator_xAxisMotorForwardBit;

    public bool Manipulator_xAxisMotorReversalValue;
    public int Manipulator_xAxisMotorReversalByte;
    public int Manipulator_xAxisMotorReversalBit;

    public bool Manipulator_xAxisMotorLowSpeedValue;
    public int Manipulator_xAxisMotorLowSpeedByte;
    public int Manipulator_xAxisMotorLowSpeedBit;

    //z
    public bool Manipulator_zAxisMotorForwardValue;
    public int Manipulator_zAxisMotorForwardByte;
    public int Manipulator_zAxisMotorForwardBit;

    public bool Manipulator_zAxisMotorReversalValue;
    public int Manipulator_zAxisMotorReversalByte;
    public int Manipulator_zAxisMotorReversalBit;

    public bool Manipulator_zAxisMotorSpeed1Value;
    public int Manipulator_zAxisMotorSpeed1Byte;
    public int Manipulator_zAxisMotorSpeed1Bit;

    public bool Manipulator_zAxisMotorSpeed2Value;
    public int Manipulator_zAxisMotorSpeed2Byte;
    public int Manipulator_zAxisMotorSpeed2Bit;

    public bool Manipulator_zAxisMotorSpeed3Value;
    public int Manipulator_zAxisMotorSpeed3Byte;
    public int Manipulator_zAxisMotorSpeed3Bit;

    //brake
    public bool Manipulator_xAxisMotorBrakeValue;
    public int Manipulator_xAxisMotorBrakeByte;
    public int Manipulator_xAxisMotorBrakeBit;

    public bool Manipulator_zAxisMotorBrakeValue;
    public int Manipulator_zAxisMotorBrakeByte;
    public int Manipulator_zAxisMotorBrakeBit;

    //Servo Motor Start
    public bool Manipulator_ServoMotorStartValue;
    public int Manipulator_ServoMotorStartByte;
    public int Manipulator_ServoMotorStartBit;
    //w Axis speed
    public int Manipulator_wAxisSpeedWriteValue;
    public int Manipulator_wAxisSpeedWriteByte;

    public int Check_case;
    public int Check_case1;
    public int Check_case2;
    public int Check_case3;
    public int Check_case1_DISP;
    public int Check_case2_DISP;

    //-----------------------------------------------
    private GameObject m_LineVariables;  //need to initialize at start
    LineVariables m_LineVariables_script; //need to initialize at start

    public GameObject m_Z_Origin; //need to initialize at start
    //PhotoElectricSensor m_Z_Origin_script; //need to initialize at start

    float GameObject_x_movement;
    float GameObject_y_movement;
    float GameObject_z_movement;
    float GameObject_y_suckers_movement;


    // Use this for initialization
    public float StartingZPosition;

    void Start () {
        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();

        //m_Z_Origin_script = m_Z_Origin.GetComponent<PhotoElectricSensor>();

        StartingZPosition = GameObject_z.GetComponent<Rigidbody>().position.y;
    }

   
	
	// Update is called once per frame
	void Update () {
        //Write PLC inputs
        //m_LineVariables_script.SetIntDec(Manipulator_HighSpeedCounterByte, Manipulator_HighSpeedCounterValue); //Write it down in the LineVariables to be exchanged with the PLC
        //Read PLC outputs
        //-----------------------------------------------

        Manipulator_xAxisMotorForwardValue = m_LineVariables_script.GetBool(Manipulator_xAxisMotorForwardByte, Manipulator_xAxisMotorForwardBit);//We get the actual value
        Manipulator_xAxisMotorReversalValue = m_LineVariables_script.GetBool(Manipulator_xAxisMotorReversalByte, Manipulator_xAxisMotorReversalBit);//We get the actual value
        Manipulator_xAxisMotorLowSpeedValue = m_LineVariables_script.GetBool(Manipulator_xAxisMotorLowSpeedByte, Manipulator_xAxisMotorLowSpeedBit);//We get the actual value
        Manipulator_zAxisMotorForwardValue = m_LineVariables_script.GetBool(Manipulator_zAxisMotorForwardByte, Manipulator_zAxisMotorForwardBit);//We get the actual value
        Manipulator_zAxisMotorReversalValue = m_LineVariables_script.GetBool(Manipulator_zAxisMotorReversalByte, Manipulator_zAxisMotorReversalBit);//We get the actual value
        Manipulator_zAxisMotorSpeed1Value = m_LineVariables_script.GetBool(Manipulator_zAxisMotorSpeed1Byte, Manipulator_zAxisMotorSpeed1Bit);//We get the actual value
        Manipulator_zAxisMotorSpeed2Value = m_LineVariables_script.GetBool(Manipulator_zAxisMotorSpeed2Byte, Manipulator_zAxisMotorSpeed2Bit);//We get the actual value
        Manipulator_zAxisMotorSpeed3Value = m_LineVariables_script.GetBool(Manipulator_zAxisMotorSpeed3Byte, Manipulator_zAxisMotorSpeed3Bit);//We get the actual value
        Manipulator_xAxisMotorBrakeValue = m_LineVariables_script.GetBool(Manipulator_xAxisMotorBrakeByte, Manipulator_xAxisMotorBrakeBit);//We get the actual value
        Manipulator_zAxisMotorBrakeValue = m_LineVariables_script.GetBool(Manipulator_zAxisMotorBrakeByte, Manipulator_zAxisMotorBrakeBit);//We get the actual value
        Manipulator_ServoMotorStartValue = m_LineVariables_script.GetBool(Manipulator_ServoMotorStartByte, Manipulator_ServoMotorStartBit);//We get the actual value
        Manipulator_wAxisSpeedWriteValue = m_LineVariables_script.GetInt(Manipulator_wAxisSpeedWriteByte);//We get the actual value                                                                                                       //-----------------------------------------------
       
    }


    //void FixedUpdate() { 
    public float Manipulator_wAxisSpeedWriteValue_CASTED;
    void FixedUpdate() {



        //Make the movement!
        //------------------------------------------------------------
        //X movement
        float xSpeed=0.85f;
        if (Manipulator_xAxisMotorLowSpeedValue) xSpeed = 0.2f;
        else xSpeed = 0.5f;
        if (Manipulator_xAxisMotorForwardValue) AddMoveX(1 * xSpeed);
        if (Manipulator_xAxisMotorReversalValue) AddMoveX(-1 * xSpeed);
        //------------------------------------------------------------
        //Z movement
        float zSpeed=0.0120f;
        Check_case1 = System.Convert.ToInt32(Manipulator_zAxisMotorSpeed1Value);
        Check_case2 = System.Convert.ToInt32(Manipulator_zAxisMotorSpeed2Value);
        Check_case3 = System.Convert.ToInt32(Manipulator_zAxisMotorSpeed3Value);
        Check_case1_DISP = System.Convert.ToInt32(Manipulator_zAxisMotorSpeed1Value)<<2;
        Check_case2_DISP = System.Convert.ToInt32(Manipulator_zAxisMotorSpeed2Value)<<1;
        Check_case = Check_case1_DISP + Check_case2_DISP  + Check_case3;
        switch (Check_case)
        {
            case 0://0 0 0  -> 12Hz
                zSpeed=zSpeed * 10f;
                break;
            case 1://0 0 1
                break;
            case 2://0 1 0  -> 6.3Hz
                zSpeed = zSpeed * 5.3f;
                break;
            case 3://0 1 1  ->
                break;
            case 4://1 0 0  ->
                zSpeed = zSpeed * 50f;
                break;
            case 5://1 0 1  -> 45Hz
                zSpeed = zSpeed * 45f;
                break;
            case 6://1 1 0  ->
                break;
            case 7://1 1 1  ->
                break;
            default://wutt?
                break;
        }

        if (Manipulator_zAxisMotorForwardValue)
        {
            AddMoveZ(-1 * zSpeed);
            if (GameObject_sucker_script.Collision == false) AddMoveZ_Suckers(-1 * zSpeed);
        }
        if (Manipulator_zAxisMotorReversalValue)
        {
            AddMoveZ(1 * zSpeed);
            if ((GameObject_sucker[0].transform.position.y - GameObject_w.transform.position.y) < 0)
                AddMoveZ_Suckers(1 * zSpeed);
        }
        //------------------------------------------------------------
        //W movement
        float wSpeedF = -3f;
        float wSpeedB = -3f;

        Manipulator_wAxisSpeedWriteValue_CASTED = Manipulator_wAxisSpeedWriteValue;
        if (Manipulator_wAxisSpeedWriteValue > 33268)
        {
            Manipulator_wAxisSpeedWriteValue_CASTED = (Manipulator_wAxisSpeedWriteValue - 65536);
        }
        if (Manipulator_ServoMotorStartValue && Manipulator_wAxisSpeedWriteValue_CASTED > 0)            AddMoveW(wSpeedF * Manipulator_wAxisSpeedWriteValue_CASTED / 33268f); //FORWARD
        if (Manipulator_ServoMotorStartValue && Manipulator_wAxisSpeedWriteValue_CASTED < 0)            AddMoveW(wSpeedB * Manipulator_wAxisSpeedWriteValue_CASTED / 33268f); //bACKWARS
        //------------------------------------------------------------

        float ZAdjustFactor = 1f;
        if (Manipulator_zAxisMotorForwardValue && !Manipulator_zAxisMotorReversalValue)
        {
            //Manipulator_HighSpeedCounterValue = Manipulator_HighSpeedCounterValue + (int)(ZAdjustFactor * 2048 * (Time.deltaTime * zSpeed) / 0.2805f);
            Manipulator_HighSpeedCounterValue =(int) (2048 * (StartingZPosition - GameObject_z.GetComponent<Rigidbody>().position.y ) / 0.2805f);
        }
        else if (Manipulator_zAxisMotorReversalValue && !Manipulator_zAxisMotorForwardValue)
        {
            //Manipulator_HighSpeedCounterValue = Manipulator_HighSpeedCounterValue - (int)(ZAdjustFactor * 2048 * (Time.deltaTime * zSpeed) / 0.2805f);
            Manipulator_HighSpeedCounterValue = (int)(2048 * (StartingZPosition - GameObject_z.GetComponent<Rigidbody>().position.y) / 0.2805f);
        }
        //if (m_Z_Origin_script.SensorValue == true) Manipulator_HighSpeedCounterValue = 0;
        if (Manipulator_HighSpeedCounterValue < 0) Manipulator_HighSpeedCounterValue = -1;
        m_LineVariables_script.SetIntDec(Manipulator_HighSpeedCounterByte, (int)(ZAdjustFactor * Manipulator_HighSpeedCounterValue)); // We set the encoder value

            //currentScroll = currentScroll + Time.deltaTime * desiredspeed * visualSpeedScalar;
            //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, currentScroll);


        if (Input.GetKey("t"))
        {
            AddMoveZ(1 * zSpeed);
            //if()
            if ((GameObject_sucker[0].transform.position.y - GameObject_w.transform.position.y) < 0)
                AddMoveZ_Suckers(1 * zSpeed);
        }
        else if (Input.GetKey("g"))
        {
            AddMoveZ(-1* zSpeed);
            if(GameObject_sucker_script.Collision == false)  AddMoveZ_Suckers(-1 * zSpeed);
        }
        else if (Input.GetKey("f"))
        {
            AddMoveX(1 * xSpeed);
        }
        else if (Input.GetKey("h"))
        {
            AddMoveX(-1 * xSpeed);
        }
        else if (Input.GetKey("y"))
        {
            AddMoveW(0.08f * wSpeedF);
        }
        else if (Input.GetKey("v"))
        {
            AddMoveW(-0.08f * wSpeedF);
        }


        Vector3 Movement_x= new Vector3(GameObject_x_movement, 0, 0);
        Vector3 Movement_z = new Vector3(GameObject_x_movement, GameObject_y_movement, 0);
        Vector3 Movement_w = new Vector3(GameObject_x_movement, GameObject_y_movement, GameObject_z_movement);


        Vector3 Movement_sucker = new Vector3(GameObject_x_movement, GameObject_y_suckers_movement, GameObject_z_movement);

        GameObject_x.GetComponent<Rigidbody>().MovePosition(GameObject_x.GetComponent<Rigidbody>().position + Movement_x);
        GameObject_z.GetComponent<Rigidbody>().MovePosition(GameObject_z.GetComponent<Rigidbody>().position + Movement_z);
        GameObject_w.GetComponent<Rigidbody>().MovePosition(GameObject_w.GetComponent<Rigidbody>().position + Movement_w);
        for (int i = 0; i < GameObject_sucker.Length; i++)
        {
            GameObject_sucker[i].GetComponent<Rigidbody>().MovePosition(GameObject_sucker[i].GetComponent<Rigidbody>().position + Movement_sucker);
        }

        GameObject_x_movement = 0;
        GameObject_y_movement = 0;
        GameObject_z_movement = 0;
        GameObject_y_suckers_movement = 0;
}



    private void AddMoveX(float direction) //Moves to the left and rightf
    {
        //To the left and rigth we have to move everything
        //GameObject_x.GetComponent<Rigidbody>().MovePosition(GameObject_x.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);
        //GameObject_z.GetComponent<Rigidbody>().MovePosition(GameObject_z.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);
        //GameObject_w.GetComponent<Rigidbody>().MovePosition(GameObject_w.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);
        GameObject_x_movement = direction * Time.deltaTime * 1f;
        //GameObject_suckers.GetComponent<Rigidbody>().isKinematic = true;
        //GameObject_suckers.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //GameObject_suckers.GetComponent<Rigidbody>().MovePosition(GameObject_suckers.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);


        //GameObject_sucker2.GetComponent<Rigidbody>().MovePosition(GameObject_sucker2.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);
        //GameObject_sucker3.GetComponent<Rigidbody>().MovePosition(GameObject_sucker3.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);
        //GameObject_sucker4.GetComponent<Rigidbody>().MovePosition(GameObject_sucker4.GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * Time.deltaTime * 1f * direction);
        //transform.localPosition += transform.forward * Time.deltaTime * 0.05f;
    }

    private void AddMoveZ(float direction) //Moves up and downIs not Z, for unity is the Y axis
    {
        //Up and down we move everything but not "x"
        //GameObject_z.GetComponent<Rigidbody>().MovePosition(GameObject_z.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        //GameObject_w.GetComponent<Rigidbody>().MovePosition(GameObject_w.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        GameObject_y_movement = direction * Time.deltaTime * 1f;
        //GameObject_suckers.GetComponent<Rigidbody>().isKinematic = false;
        //GameObject_suckers.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //GameObject_suckers.GetComponent<Rigidbody>().MovePosition(GameObject_suckers.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);


        //GameObject_sucker2.GetComponent<Rigidbody>().MovePosition(GameObject_sucker2.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        //GameObject_sucker3.GetComponent<Rigidbody>().MovePosition(GameObject_sucker3.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        //GameObject_sucker4.GetComponent<Rigidbody>().MovePosition(GameObject_sucker4.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
    }
    private void AddMoveZ_Suckers(float direction) //Moves up and downIs not Z, for unity is the Y axis
    {
        //Up and down we move everything but not "x"
        //GameObject_z.GetComponent<Rigidbody>().MovePosition(GameObject_z.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        //GameObject_w.GetComponent<Rigidbody>().MovePosition(GameObject_w.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        GameObject_y_suckers_movement = direction * Time.deltaTime * 1f;
        //GameObject_suckers.GetComponent<Rigidbody>().isKinematic = false;
        //GameObject_suckers.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //GameObject_suckers.GetComponent<Rigidbody>().MovePosition(GameObject_suckers.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);


        //GameObject_sucker2.GetComponent<Rigidbody>().MovePosition(GameObject_sucker2.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        //GameObject_sucker3.GetComponent<Rigidbody>().MovePosition(GameObject_sucker3.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
        //GameObject_sucker4.GetComponent<Rigidbody>().MovePosition(GameObject_sucker4.GetComponent<Rigidbody>().position + new Vector3(0, 1, 0) * Time.deltaTime * 1f * direction);
    }
    private void AddMoveW(float direction) //Moves forward and backwards
    {
        //Forward and backwards we move just the "w", and the suckers.
        //GameObject_w.GetComponent<Rigidbody>().MovePosition(GameObject_w.GetComponent<Rigidbody>().position + new Vector3(0, 0, 1) * Time.deltaTime * 1f * direction);
        GameObject_z_movement = direction * Time.deltaTime * 1f;
        //GameObject_suckers.GetComponent<Rigidbody>().isKinematic = true;
        //GameObject_suckers.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //GameObject_suckers.GetComponent<Rigidbody>().MovePosition(GameObject_suckers.GetComponent<Rigidbody>().position + new Vector3(0, 0, 1) * Time.deltaTime * 1f * direction);
        //GameObject_sucker2.GetComponent<Rigidbody>().MovePosition(GameObject_sucker2.GetComponent<Rigidbody>().position + new Vector3(0, 0, 1) * Time.deltaTime * 1f * direction);
        //GameObject_sucker3.GetComponent<Rigidbody>().MovePosition(GameObject_sucker3.GetComponent<Rigidbody>().position + new Vector3(0, 0, 1) * Time.deltaTime * 1f * direction);
        //GameObject_sucker4.GetComponent<Rigidbody>().MovePosition(GameObject_sucker4.GetComponent<Rigidbody>().position + new Vector3(0, 0, 1) * Time.deltaTime * 1f * direction);
    }
}
