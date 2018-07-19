using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject prefab_beginning;
    public GameObject prefab_manipulator1;
    public GameObject prefab_manipulator2;
    public GameObject prefab_manipulator3;
    public GameObject prefab_manipulator4;
    public GameObject prefab_manipulator5;
    public GameObject prefab_pallet1;
    public GameObject prefab_pallet2;
    public GameObject prefab_pallet3;
    public GameObject prefab_pallet4;
    public GameObject prefab_pallet5;
    public GameObject prefab_pallet6;
    public GameObject prefab_pallet7;
    public GameObject prefab_pallet8;
    public GameObject prefab_pallet9;
    public GameObject prefab_pallet10;
    public GameObject tile;


    int SelectedColor=0;
    public void SetColor(int Color) {SelectedColor = Color;}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) CreatePrefab(SelectedColor, 0, prefab_manipulator1);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) CreatePrefab(SelectedColor, 1, prefab_manipulator2);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) CreatePrefab(SelectedColor, 1, prefab_manipulator3);
            else if (Input.GetKeyDown(KeyCode.Alpha4)) CreatePrefab(SelectedColor, 1, prefab_manipulator4);
            else if (Input.GetKeyDown(KeyCode.Alpha5)) CreatePrefab(SelectedColor, 1, prefab_manipulator5);
            else if (Input.GetKeyDown(KeyCode.Keypad1)) CreatePrefab(SelectedColor, 1, prefab_pallet1);
            else if (Input.GetKeyDown(KeyCode.Keypad2)) CreatePrefab(SelectedColor, 1, prefab_pallet2);
            else if (Input.GetKeyDown(KeyCode.Keypad3)) CreatePrefab(SelectedColor, 1, prefab_pallet3);
            else if (Input.GetKeyDown(KeyCode.Keypad4)) CreatePrefab(SelectedColor, 1, prefab_pallet4);
            else if (Input.GetKeyDown(KeyCode.Keypad5)) CreatePrefab(SelectedColor, 1, prefab_pallet5);
            else if (Input.GetKeyDown(KeyCode.Keypad6)) CreatePrefab(SelectedColor, 1, prefab_pallet6);
            else if (Input.GetKeyDown(KeyCode.Keypad7)) CreatePrefab(SelectedColor, 1, prefab_pallet7);
            else if (Input.GetKeyDown(KeyCode.Keypad8)) CreatePrefab(SelectedColor, 1, prefab_pallet8);
            else if (Input.GetKeyDown(KeyCode.Keypad9)) CreatePrefab(SelectedColor, 1, prefab_pallet9);
            else if (Input.GetKeyDown(KeyCode.Keypad0)) CreatePrefab(SelectedColor, 1, prefab_pallet10);
        }
    }

    public void AddBrick(int Colour, int Grade)
    {
        CreatePrefab(Colour, Grade, prefab_beginning);
        Debug.Log("AddBrick called");
    }
    public void DeleteBrick(GameObject tiletodelete)
    {
        Destroy(tiletodelete);
    }

    void CreatePrefab(int Colour, int Grade, GameObject prefab)
    {

        tile = Instantiate(prefab);
        Material m_material = tile.GetComponent<Renderer>().material;

        //m_material.color = Resources.LoadAssetAtPath("Colours")
        if(Colour==0)m_material.color = (Resources.Load("Red", typeof(Material)) as Material).color;
        else if (Colour == 1) m_material.color = (Resources.Load("Orange", typeof(Material)) as Material).color;
        else if (Colour == 2) m_material.color = (Resources.Load("Yellow", typeof(Material)) as Material).color;
        else if (Colour == 3) m_material.color = (Resources.Load("PaleGreen", typeof(Material)) as Material).color;
        else if (Colour == 4) m_material.color = (Resources.Load("Green", typeof(Material)) as Material).color;
        else if (Colour == 5) m_material.color = (Resources.Load("BlueGreen", typeof(Material)) as Material).color;
        else if (Colour == 6) m_material.color = (Resources.Load("LightBlue", typeof(Material)) as Material).color;
        else if (Colour == 7) m_material.color = (Resources.Load("Blue", typeof(Material)) as Material).color;
        else if (Colour == 8) m_material.color = (Resources.Load("Yellow", typeof(Material)) as Material).color;
        else if (Colour == 9) m_material.color = (Resources.Load("Yellow", typeof(Material)) as Material).color;
        else if (Colour == 10) m_material.color = (Resources.Load("Yellow", typeof(Material)) as Material).color;
        else if (Colour == 11) m_material.color = (Resources.Load("Yellow", typeof(Material)) as Material).color;
    }
}
