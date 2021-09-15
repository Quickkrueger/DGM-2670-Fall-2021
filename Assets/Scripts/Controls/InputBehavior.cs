
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputBehavior : MonoBehaviour
{
    public ControlsData controlsData;

    private InputAction jump;
    private InputAction attack;
    private InputAction right;
    private InputAction left;

    private void Start()
    {
        jump = new InputAction();
        attack = new InputAction();
        right = new InputAction();
        left = new InputAction();
        
        jump = controlsData.jump.action;
        attack = controlsData.attack.action;
        right = controlsData.right.action;
        left = controlsData.left.action;

        jump.performed += Jump;
        attack.performed += Attack;
        right.performed += Right;
        left.performed += Left;

        jump.Enable();
        attack.Enable();
        right.Enable();
        left.Enable();
    }

    private void Left(InputAction.CallbackContext obj)
    {
        
    }

    private void Right(InputAction.CallbackContext obj)
    {
        
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
    }
    
    
}
