using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.LogError("hi");
    }
}
