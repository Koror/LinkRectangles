using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectDrag : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnMouseDrag()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(worldPoint);
    }

    private void OnMouseUp()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
