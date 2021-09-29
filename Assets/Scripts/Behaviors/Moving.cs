using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody2D movingRigidbody;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        movingRigidbody = GetComponent<Rigidbody2D>();
        Move();
    }

    void Move()
    {
        movingRigidbody.velocity = Vector2.left * speed;
    }
}
