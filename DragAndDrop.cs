using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col; //I dunno if this works with 3D
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //This will allow players to only use the device one at a time
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);//Vector2 should be Vector3 I think?
            //Checks touch position on screen
            if (touch.phase == TouchPhase.Began)//Reacts to first touch
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true; 
                }
            }
            if (touch.phase == TouchPhase.Moved)//Dragging with the finger
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if (touch.phase == TouchPhase.Ended)//stops moving with touch lift
            {
                moveAllowed = false;
            }
        }
    }
}
