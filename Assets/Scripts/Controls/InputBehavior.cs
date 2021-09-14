using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputBehavior : MonoBehaviour
{

    public UnityEvent mouseDown;
    public UnityEvent mouseUp;
    public UnityEvent<KeyCode> keyDown;
    public UnityEvent<KeyCode> keyPressed;
    public UnityEvent<KeyCode> keyUp;

    private void OnMouseDown()
    {
        mouseDown.Invoke();
    }

    private void OnMouseUp()
    {
        mouseUp.Invoke();
    }
    
    
}
