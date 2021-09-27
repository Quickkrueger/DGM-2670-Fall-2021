using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody2D movingRigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        movingRigidbody = GetComponent<Rigidbody2D>();
        WaitForSeconds delay = new WaitForSeconds(0.01f);
        

        StartCoroutine(Move(delay));
    }

    IEnumerator Move(WaitForSeconds delay)
    {
            transform.Translate(Vector2.left * 0.2f);
            yield return delay;

        StartCoroutine(Move(delay));
    }
}
