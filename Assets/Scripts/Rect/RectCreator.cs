using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject rectanglePref;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject rectangle = Instantiate(rectanglePref, worldMousePosition, Quaternion.identity);
            //check for overlap with other rectangles
            Collider2D collider2D = rectangle.GetComponent<Collider2D>();
            int count = Physics2D.OverlapCollider(collider2D, new ContactFilter2D(), new List<Collider2D>());
            if (count > 0)
                Destroy(rectangle);
            rectangle.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }

}
