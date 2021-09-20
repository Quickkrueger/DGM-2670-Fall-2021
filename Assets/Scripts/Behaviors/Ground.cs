using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        InputBehavior behavior = other.gameObject.GetComponent<InputBehavior>();
        if (behavior != null)
        {
            behavior.controlsData.ResetJumps();
        }
    }
}
