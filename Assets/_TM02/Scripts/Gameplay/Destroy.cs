using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
                 Destroy(gameObject);
        }
    }
}
