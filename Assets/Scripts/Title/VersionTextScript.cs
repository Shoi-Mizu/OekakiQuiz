using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class VersionTextScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        var version = Application.version; 
        GetComponent<Text>().text = "Ver : " + version;
    }
}
