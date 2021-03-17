using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject rect1;
    public GameObject rect2;

    private LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetUpLine(GameObject rect1, GameObject rect2)
    {
        lineRenderer.positionCount = 2;
        this.rect1 = rect1;
        this.rect2 = rect2;

        rect1.GetComponent<RectLink>().lines.Add(gameObject);
        rect2.GetComponent<RectLink>().lines.Add(gameObject);
    }
    private void Update()
    {
        if (rect1 != null && rect2 != null)
        {
            lineRenderer.SetPosition(0, rect1.transform.position);
            lineRenderer.SetPosition(1, rect2.transform.position);
        }
    }

    private void OnDestroy()
    {
        if(rect1!= null)
            rect1.GetComponent<RectLink>().lines.Remove(gameObject);
        if (rect2 != null)
            rect2.GetComponent<RectLink>().lines.Remove(gameObject);
    }

}
