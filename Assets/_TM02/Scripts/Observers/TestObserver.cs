using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observer.AddObserver(IMessages.ObserverNotify.UpdateUI.ToString(), onUpdateUI);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDestroy()
    {
        Observer.RemoveListener(IMessages.ObserverNotify.UpdateUI.ToString(), onUpdateUI);
    }

    void onUpdateUI()
    {
        Debug.LogError(IMessages.ObserverNotify.UpdateUI.ToString());
    }
}
