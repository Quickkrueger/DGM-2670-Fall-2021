using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        InputBehavior behavior = other.gameObject.GetComponent<InputBehavior>();
        PlayerAppearance appearance = other.gameObject.GetComponent<PlayerAppearance>();
        if (behavior != null)
        {
            RaycastHit2D[] hit;
            Vector2 startPoint = new Vector2(transform.position.x, transform.position.y);
            hit = Physics2D.BoxCastAll(startPoint,transform.localScale, 0f, Vector2.up, 2f);
            
            Debug.DrawRay(startPoint, Vector2.up, Color.green, 5f);

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider != null && hit[i].collider == other.collider)
                {
                    behavior.controlsData.ResetJumps();
                    appearance.StopJump();
                    return;
                }
            }

        }
    }
}
