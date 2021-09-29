using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float delayToDestroy;
    void Start()
    {
        Destroy(gameObject, delayToDestroy);
    }
    
    
}
