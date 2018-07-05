using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedH = 3.0f;
    public float speedV = 3.0f;
    public bool lockedView = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speedH;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speedV;

        //transform.Rotate(0, x, 0);
        transform.Translate(z, 0, -x);

        if (Input.mousePosition.x < 450 && Input.mousePosition.x > 0 && Input.mousePosition.x > 300 && Input.mousePosition.y < 800 && lockedView == false)
        {
            transform.Rotate(0, -speedH * Time.deltaTime * 75, 0);
        }
        if (Input.mousePosition.x > Screen.width - 150 && Input.mousePosition.x < Screen.width && lockedView == false)
        {
            transform.Rotate(0, speedH * Time.deltaTime * 75, 0);
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            lockedView = !lockedView;
            // else transform.rotation=new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }
    }
}

