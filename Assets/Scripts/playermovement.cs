using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   [Header("Movement")]
   public float forwardspeed=5f;
   public float horizontalspeed=5f;
   public float xlimit=2.5f;


   private Vector3 starttouchpos;
   private bool isDragging;


    void Start()
    {
        
    }

   
    void Update()
    {
        Moveforward();
        HandleSwipe();
    }


    void Moveforward()
    {
        transform.Translate(Vector3.forward*forwardspeed*Time.deltaTime);
    }

    void HandleSwipe()
{
    if (Input.GetMouseButtonDown(0))
    {
        starttouchpos = Input.mousePosition;
        isDragging = true;
    }
    else if (Input.GetMouseButtonUp(0))
    {
        isDragging = false;
    }

    if (isDragging)
    {
        float deltaX = Input.mousePosition.x - starttouchpos.x;
        MoveHorizontal(deltaX);
        starttouchpos = Input.mousePosition;
    }
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            starttouchpos = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            float deltaX = touch.position.x - starttouchpos.x;
            MoveHorizontal(deltaX);
            starttouchpos = touch.position;
        }
    }


void MoveHorizontal(float deltaX)
{
    float moveX = deltaX * horizontalspeed * Time.deltaTime;

    Vector3 newPos = transform.position;
    newPos.x += moveX;
    newPos.x = Mathf.Clamp(newPos.x, -xlimit, xlimit);
    transform.position = newPos;
}
}
}
