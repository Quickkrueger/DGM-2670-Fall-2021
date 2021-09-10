using UnityEngine;

[CreateAssetMenu(fileName = "ControlsData", menuName = "ScriptableObjects/Utility/ControlsData", order = 1)]
public class ControlsData : ScriptableObject
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;

    public bool usesTouch;

    


}

struct TouchControls
{
    public KeyCode jump;
    public KeyCode attack;
    public void Attack()
    {

    }
}
