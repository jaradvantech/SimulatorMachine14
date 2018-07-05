using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertTile : MonoBehaviour {
    private GameObject m_someOtherScript;
    TileManager scriptToAccess;

    private Dropdown Dropdown_Colour;
    private Dropdown Dropdown_Grade;

    private GameObject m_LineVariables;  //need to initialize at start
    private LineVariables m_LineVariables_script; //need to initialize at start

    public Stack<int> ListOfBricks = new Stack<int>();



    private void Start()
    {
        m_someOtherScript = GameObject.Find("TileFactoryObject");
        scriptToAccess = m_someOtherScript.GetComponent<TileManager>();

        Dropdown_Colour = GameObject.Find("Dropdown_Colour").GetComponent<Dropdown>();
        Dropdown_Grade = GameObject.Find("Dropdown_Grade").GetComponent<Dropdown>();
    }
    private IEnumerator coroutine;
    private IEnumerator ExecuteCoroutine(float waitTime)
    {
        while (ListOfBricks.Count>0)
        {
            yield return new WaitForSeconds(waitTime);
            int Value = ListOfBricks.Pop();
            scriptToAccess.AddBrick(0, 0);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            scriptToAccess.AddBrick(Dropdown_Colour.value, Dropdown_Grade.value);
        }
        else if (Input.GetKeyDown(KeyCode.Insert))
        {
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            ListOfBricks.Push(17);
            coroutine = ExecuteCoroutine(4.0f);
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown("i"))
        {
            Dropdown_Colour.value++;
        }
        else if (Input.GetKeyDown("k"))
        {
            Dropdown_Colour.value--;
        }
        else if (Input.GetKeyDown("o"))
        {
            Dropdown_Grade.value++;
        }
        else if (Input.GetKeyDown("l"))
        {
            Dropdown_Grade.value--;
        }
    }
    public void Button_InsertTile_OnClick()
    {
        //Call the Tile Manager

        scriptToAccess.AddBrick(Dropdown_Colour.value, Dropdown_Grade.value);

        Debug.Log("Button clicked");
    }
}
