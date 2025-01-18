using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitSetActiveOff());
    }

    private IEnumerator WaitSetActiveOff()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
