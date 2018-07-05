using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AdquisitionLoop : MonoBehaviour {
    public bool QueryPLC = true;
    private Thread o_PLCAdquisitionThread;

    private GameObject m_connexionPLC;  //need to initialize at start
    private connexionPLC m_connexionPLC_script; //need to initialize at start

    private GameObject m_LineVariables;  //need to initialize at start
    private LineVariables m_LineVariables_script; //need to initialize at start
    // Use this for initialization



    void Start () {
        m_connexionPLC = GameObject.Find("connexionPLC");
        m_connexionPLC_script = m_connexionPLC.GetComponent<connexionPLC>();

        m_LineVariables = GameObject.Find("Line");
        m_LineVariables_script = m_LineVariables.GetComponent<LineVariables>();
        o_PLCAdquisitionThread = new Thread(AdquisitionThread);
        Debug.Log("Starts the adquisition thread");
        o_PLCAdquisitionThread.Start();
        Debug.Log("Should have started");
    }
	
	// Update is called once per frame
	void Update () {

	}



    private void AdquisitionThread()
    {
        Debug.Log("Enters the adquisition thread");
        while (QueryPLC)
        {
            if (m_connexionPLC_script.Connected){
                m_LineVariables_script.PerformGlobalRead(m_connexionPLC_script.GetPlc14());
                System.Threading.Thread.Sleep(7);//10ms sleep
                m_LineVariables_script.PerformGlobalWrite(m_connexionPLC_script.GetPlc14());
            }
            System.Threading.Thread.Sleep(10);//10ms sleep
        }
    }


    private void OnDestroy()
    {


            o_PLCAdquisitionThread.Abort();
    }
}
