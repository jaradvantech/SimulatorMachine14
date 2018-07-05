using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeleteTile : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BrickOnTheLine"))
        { 
        GameObject m_someOtherScript;
        TileManager scriptToAccess;


        m_someOtherScript = GameObject.Find("TileFactoryObject");
        scriptToAccess = m_someOtherScript.GetComponent<TileManager>();
        scriptToAccess.DeleteBrick(other.gameObject);
        }
    }
}
