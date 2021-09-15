using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ControlsData", menuName = "ScriptableObjects/Utility/ControlsData", order = 1)]
public class ControlsData : ScriptableObject
{
    public ControlPairing left;
    public ControlPairing right;
    public ControlPairing jump;
    public ControlPairing attack;

    public bool UseTouch;
    
    
[System.Serializable]
    public struct ControlPairing
    {
        public string controlName;
        public InputAction action;
    }

}
