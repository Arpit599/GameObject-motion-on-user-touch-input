using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRope : MonoBehaviour
{ 
    bool GameOver = false;

    private void Update()
    {
        if (Input.touchCount >= 2 && !GameOver)
        {
            Touch touch1 = Input.GetTouch(0);
            Vector3 touch1pos = Camera.main.ScreenToWorldPoint(touch1.position);
            touch1pos.z = 0;
            Touch touch2 = Input.GetTouch(1);
            Vector3 touch2pos = Camera.main.ScreenToWorldPoint(touch2.position);
            touch2pos.z = 0;
            RaycastHit2D hit1 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            RaycastHit2D hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position), Vector2.zero);

            if ((hit1.collider.name == "bomb" && hit2.collider.name == "rope") || (hit2.collider.name == "bomb" && hit1.collider.name == "rope"))
            {
                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    hit1.collider.gameObject.transform.position = touch1pos;
                    hit2.collider.gameObject.transform.position = touch2pos;
                }
            }

            if (Mathf.Abs(hit1.collider.transform.position.x - hit2.collider.transform.position.x) > 1.5f)
            {
                GameOver = true;
                Debug.Log("Level Completed");
            }
        }
    }
}
