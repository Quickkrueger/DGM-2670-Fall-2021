using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigData", menuName = "ScriptableObjects/Entity/PlayerConfigData", order = 1)]
public class PlayerConfigData : ScriptableObject
{
    public CharacterData visualData;
    public ControlsData controlData;

}
