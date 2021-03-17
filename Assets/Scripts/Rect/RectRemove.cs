using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectRemove: MonoBehaviour
{
    private int clickCounter = 0;

    private void LateUpdate()
    {
        if (clickCounter >= 2)
            Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        clickCounter++;
        StartCoroutine(DoubleClick());
    }
    IEnumerator DoubleClick()
    {
        yield return new WaitForSeconds(0.5f);
        clickCounter--;
    }
}
