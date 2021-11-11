using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent triggerEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerEvent.Invoke();
        }
    }


}
