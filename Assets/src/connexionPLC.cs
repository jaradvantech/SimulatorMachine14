using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sharp7;
public class connexionPLC : MonoBehaviour {

    //Need to function
    static S7Client Plc14;
    public bool Connected;

    //Implemented Routines
    static bool Check(int Result, string FunctionPerformed)
    {
        Debug.Log("+-----------------------------------------------------\n"+
                  "| " + FunctionPerformed + "\n" +
                  "+-----------------------------------------------------");
        if (Result == 0)
        {
            int ExecTime = Plc14.ExecTime();
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
                Debug.Log("| " + Plc14.ErrorText(Result));
            Debug.Log("+-----------------------------------------------------\n");
        }
        return Result == 0;
    }

    static bool PlcConnect(string Address, int Rack, int Slot)
    {
        int res = Plc14.ConnectTo(Address, Rack, Slot);
        if (Check(res, "UNIT Connection"))
        {
            int Requested = Plc14.RequestedPduLength();
            int Negotiated = Plc14.NegotiatedPduLength();
            Debug.Log("  Connected to   : " + Address + " (Rack=" + Rack.ToString() + ", Slot=" + Slot.ToString() + ")");
            Debug.Log("  PDU Requested  : " + Requested.ToString());
            Debug.Log("  PDU Negotiated : " + Negotiated.ToString());
        }
        return res == 0;
    }

    public S7Client GetPlc14() { return Plc14; }

    // Use this for initialization
    void Start () {
        //Initialize client
        Plc14 = new S7Client();
        //Connect to the PLC
        Connected = PlcConnect("192.168.1.199", 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        if (Connected)
        {
            Plc14.Disconnect();
        }
    }
}
