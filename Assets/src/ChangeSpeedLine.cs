using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeedLine : MonoBehaviour
{
    private GameObject m_someOtherScript;
    ConveyorLine scriptToAccess;

    private InputField LineSpeedInput;

    private GameObject m_LineVariables;  //need to initialize at start
    private LineVariables m_LineVariables_script; //need to initialize at start
    private void Start()
    {
        m_someOtherScript = GameObject.Find("ConveyorLine");
        scriptToAccess = m_someOtherScript.GetComponent<ConveyorLine>();

        LineSpeedInput = GameObject.Find("InputField_LineSpeed").GetComponent<InputField>();
    }
    private void Update()
    {

    }
    public void Button_SetLineSpeed_OnClick()
    {
        scriptToAccess.desiredspeed = (float)int.Parse(LineSpeedInput.text)/100f;
    }
}
