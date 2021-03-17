using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectLink : MonoBehaviour
{
    [SerializeField]
    private GameObject linePref;

    [HideInInspector]
    public System.Guid id;
    [HideInInspector]
    public List<GameObject> lines;
    [HideInInspector]
    public bool master = false;

    private void Start()
    {
        lines = new List<GameObject>();
        id = System.Guid.NewGuid();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RectLink otherRect = collision.gameObject.GetComponent<RectLink>();
        //make other rectangle master for call function once
        if (!master)
            otherRect.master = true;
        else
        {
            master = false;
            bool isLink = false;
            GameObject lineLink = null;
            //check for link with collision rect
            foreach (GameObject line in lines)
            {
                if ((otherRect.id == line.GetComponent<LineController>().rect1.GetComponent<RectLink>().id) ||
                    (otherRect.id == line.GetComponent<LineController>().rect2.GetComponent<RectLink>().id))
                { 
                    isLink = true;
                    lineLink = line;
                }
            }
            //remove line if linked
            if (isLink && lineLink != null)
            {
                Debug.Log("unlink");
                Destroy(lineLink);
            }
            else //create new link
            {
                var lineInstance = Instantiate(linePref);
                lineInstance.GetComponent<LineController>().SetUpLine(gameObject, collision.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        foreach(GameObject line in lines)
            Destroy(line);
    }


}
