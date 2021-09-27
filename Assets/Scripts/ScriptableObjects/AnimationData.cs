using UnityEngine;

[CreateAssetMenu(fileName = "AnimationData", menuName = "ScriptableObjects/SpriteInfo/AnimationData", order = 1)]
public class AnimationData : ScriptableObject
{
    public Vector2Int[] spriteCoords;
    public float durationInSeconds = 1f;
}
