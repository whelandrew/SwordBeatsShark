using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Vector2 objectPos;
    private Vector2 newPos;

    private void Start()
    {
        objectPos = transform.localPosition;
    }
    private void Update()
    {
        MoveObject();
        //Debug.Log(Camera.main.WorldToViewportPoint(transform.position).x);
        if(Camera.main.WorldToViewportPoint(transform.position).x<-0.1)
        {
            ResetObject();
        }
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector2.MoveTowards(objectPos, newPos, 1 * Time.deltaTime);
        objectPos = transform.localPosition;
    }

    private void ResetObject()
    {
        gameObject.SetActive(false);
    }

    private void MoveObject()
    {
        newPos = objectPos-new Vector2(100,0);
    }

}
