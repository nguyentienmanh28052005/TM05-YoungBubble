using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Observer.Notify(IMessages.ObserverNotify.UpdateUI.ToString());
        }
    }
}
