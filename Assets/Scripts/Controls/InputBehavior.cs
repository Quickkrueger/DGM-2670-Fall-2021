using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputBehavior : MonoBehaviour
{

    public UnityEvent mouseDown;
    public UnityEvent mouseUp;
    public UnityEvent<KeyCode> keyDown;
    public UnityEvent<KeyCode> keyPressed;
    public UnityEvent<KeyCode> keyUp;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyCode currentKey;
            
            if (KeyCode.TryParse(Input.inputString, out currentKey))
            {
                Debug.Log(currentKey);
                keyDown.Invoke(currentKey);
            }
            
        }
        
        if (Input.anyKey)
        {
            KeyCode currentKey;
            Debug.Log("Pressing");
            if (KeyCode.TryParse(Input.inputString, out currentKey))
            {
                Debug.Log(currentKey);
                keyDown.Invoke(currentKey);
            }
        }
        
        if (!Input.GetKeyUp(KeyCode.None))
        {
            KeyCode currentKey;
            
            if (KeyCode.TryParse(Input.inputString, out currentKey))
            {
                keyDown.Invoke(currentKey);
            }
        }
    }

    private void OnMouseDown()
    {
        mouseDown.Invoke();
    }

    private void OnMouseUp()
    {
        mouseUp.Invoke();
    }
    
    
}
