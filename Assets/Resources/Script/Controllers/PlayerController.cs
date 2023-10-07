using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PlayerController : MonoBehaviour
{
    private Vector2 playerPos;
    private Vector2 touchPosition;

    private float newX;

    public float moveSpeed;
    public float offsetXPosition;

    private void Start()
    {
        playerPos = transform.localPosition;
    }

    private void Update()
    {
        playerPos = transform.localPosition;
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            touchPosition = Camera.main.ScreenToWorldPoint(mousePos);
            MovePlayer();
        }
#else

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
        }
#endif
    }

    private void FixedUpdate()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButton(0))
        {
            transform.rotation = Quaternion.identity;
            transform.localPosition = Vector2.MoveTowards(playerPos, new Vector2(newX, touchPosition.y), moveSpeed * Time.deltaTime);
            playerPos = transform.localPosition;
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
        }
#endif
    }

    private void MovePlayer()
    {     
        float newPos = touchPosition.x - playerPos.x- offsetXPosition;
        //if (newPos >.001)
            newX = touchPosition.x - playerPos.x;
    }

    public Vector2 TouchPosition()
    {
        return touchPosition;
    }
    public Vector2 PlayerPosition()
    {
        return playerPos;
    }
}