using UnityEngine;

[CreateAssetMenu(fileName = "ControlsData", menuName = "ScriptableObjects/Utility/ControlsData", order = 1)]
public class ControlsData : ScriptableObject
{
    public ControlPairing left;
    public ControlPairing right;
    public ControlPairing jump;
    public ControlPairing attack;

    public bool UseTouch;

    public float interactionMinimum;
    private Vector2 interactionOffset;

    public void StartTouch(Vector2 initial)
    {
        interactionOffset = initial;
    }

    public ControlPairing EndTouch(Vector2 final)
    {
        interactionOffset -= final;

        if (interactionMinimum > interactionOffset.magnitude)
        {
            return attack;
        }

        return jump;
    }
    
    
[System.Serializable]
    public struct ControlPairing
    {
        public string controlName;
        public KeyCode controlKey;
    }

}
