using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    Vector2 startPosition, endPosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("touching");
            startPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log("Is Swiping. distance = " + Vector2.Distance(startPosition, endPosition));
        }

        if (Input.touchCount > 0)
        {
            Debug.Log("touching");
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPosition = new Vector2(touch.position.x, touch.position.y);

            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                endPosition = new Vector2(touch.position.x, touch.position.y);
                Debug.Log("Is Swiping, distance = " + Vector2.Distance(startPosition, endPosition));
            }
        }
    }

}
