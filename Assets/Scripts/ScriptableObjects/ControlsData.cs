using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ControlsData", menuName = "ScriptableObjects/Utility/ControlsData", order = 1)]
public class ControlsData : ScriptableObject
{
    public ControlPairing left;
    public ControlPairing right;
    public ControlPairing jump;
    public ControlPairing attack;

    public int maxJumps = 1;

    public int jumpsAvailable;

    public bool UseTouch;

    public ControlsData()
    {
        jumpsAvailable = maxJumps;
    }

    public void UseJump()
    {
        jumpsAvailable--;
    }

    public bool HasMoreJumps()
    {
        if (jumpsAvailable > 0)
        {
            return true;
        }

        return false;
    }

    public bool Grounded()
    {
        if (maxJumps == jumpsAvailable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetJumps()
    {
        jumpsAvailable = maxJumps;
    }
    
    
[System.Serializable]
    public struct ControlPairing
    {
        public string controlName;
        public InputAction action;
    }

}
