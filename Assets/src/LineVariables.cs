using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sharp7;



public class LineVariables : MonoBehaviour {


    #region [PLC INPUT TABLE]
    //Buffers
    byte[] BufferBoolInputs;    //%I FROM 0.0 TO 19.7
    byte[] BufferDecimalInputs; //%ID FROM 1000 TO 1024
    #endregion

    #region [PLC OUTPUT TABLE]
    public byte[] BufferBoolOutputs;
    public byte[] BufferWordOutputs;  //%ID FROM 256 TO 266

    #endregion


    // Use this for initialization
    void Start () {
        BufferBoolInputs = new byte[20];    //%I FROM 0.0 TO 19.7
        BufferDecimalInputs = new byte[24]; //%ID FROM 1000 TO 1024

        BufferBoolOutputs = new byte[18];
        BufferWordOutputs = new byte[16];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //PerformGlobalRead() Allows us to import all the PLC outputs.
    public void PerformGlobalRead(S7Client a_Client) 
    {
        S7MultiVar Reader = new S7MultiVar(a_Client);
        //Buffers

        //BoolInputs
        Reader.Add(S7Consts.S7AreaPA,             //Area
                   S7Consts.S7WLByte,
                   0,                             //DB, 0 if it's not a db
                   0,                             //Starting byte
                   20,                            //Length of bytes
                   ref BufferBoolOutputs);         //Where to assign
        Reader.Add(S7Consts.S7AreaPA,             //Area
                   S7Consts.S7WLByte,
                   0,                             //DB, 0 if it's not a db
                   256,                             //Starting byte
                   16,                            //Length of bytes
                   ref BufferWordOutputs);         //Where to assign
        int Result = Reader.Read();

    }

    //PerformGlobalWrite() Allows us to write at the PLC all the inputs as if they were real inputs
    public void PerformGlobalWrite(S7Client a_Client)
    {
        S7MultiVar Writer = new S7MultiVar(a_Client);

        //BoolInputs
        Writer.Add(S7Consts.S7AreaPE,             //Area
                   S7Consts.S7WLByte,               
                   0,                             //DB, 0 if it's not a db
                   0,                             //Starting byte
                   20,                            //Length of bytes
                   ref BufferBoolInputs);         //Where to assign
        Writer.Add(S7Consts.S7AreaPE,             //Area
                   S7Consts.S7WLByte,
                   0,                             //DB, 0 if it's not a db
                   1000,                             //Starting byte
                   24,                            //Length of bytes
                   ref BufferDecimalInputs);         //Where to assign


        int Result = Writer.Write();
        //Check(a_Client, Result, "Writing Operation");
        //Debug.Log("Writer finished with a value of " + Result);


    }

    public void SetBool(int Byte, int Bit, bool Value)    {
        //Debug.Log("Bool added at " + Byte + "." + Bit + " -> " + Value);
        S7.SetBitAt(ref BufferBoolInputs, Byte, Bit, Value);
    }
    public void SetIntDec(int Byte, int Value)
    {
       // Debug.Log("Int added at " + Byte + "." + " -> " + Value);
        S7.SetDIntAt(BufferDecimalInputs, Byte - 1000, Value);
    }
    public bool GetBool(int Byte, int Bit)
    {
        return S7.GetBitAt(BufferBoolOutputs, Byte, Bit);
    }
    public int GetInt(int Byte)
    {
        return S7.GetWordAt(BufferWordOutputs, Byte - 256);
    }
    static bool Check(S7Client a_Client, int Result, string FunctionPerformed)
    {
        Debug.Log("+-----------------------------------------------------\n" +
                  "| " + FunctionPerformed + "\n" +
                  "+-----------------------------------------------------");
        if (Result == 0)
        {
            int ExecTime = a_Client.ExecTime();
            Debug.Log("| Result         : OK");
            Debug.Log("| Execution time : " + ExecTime.ToString() + " ms"); //+ Client.getex->ExecTime());
            Debug.Log("+-----------------------------------------------------");
        }
        else
        {
            Debug.Log("| ERROR !!! \n");
            if (Result < 0)
                Debug.Log("| Library Error (-1)\n");
            else
                Debug.Log("| " + a_Client.ErrorText(Result));
            Debug.Log("+-----------------------------------------------------\n");
        }
        return Result == 0;
    }
}
