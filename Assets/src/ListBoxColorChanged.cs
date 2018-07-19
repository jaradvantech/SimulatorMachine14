using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ListBoxColorChanged : MonoBehaviour
{

    public Dropdown dropdown;
    public TileManager tileManager;

    void Start()
    {
        /*
        dropdown.onValueChanged.AddListener(delegate
        {
            myDropdownValueChangedHandler(dropdown);
        });
        */
    }
    void Destroy()
    {
        //dropdown.onValueChanged.RemoveAllListeners();
    }

    public void myDropdownValueChangedHandler(Dropdown target)
    {
        // Debug.Log("selected: " + target.value);
    }

    public void SetDropdownIndex(int index)
    {
        //dropdown.value == index;
        tileManager.SetColor(index);
    }
}
