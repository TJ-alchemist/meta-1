using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoUpdater : MonoBehaviour
{
    public Text displayUsername;

    void Start() {

    }
    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            Debug.LogError("Failed to find the scene1Object");
            this.enabled = false;
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        displayUsername.text = "USERNAME: " + sc1Obj.username;
        // GetComponent<Text>().text = "AccountId:: " + sc1Obj.AccountId;       
    }
}

