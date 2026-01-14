using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   [Header("Movement")]
   public float forwardSpeed = 8f;
    public float horizontalSpeed = 0.02f;
    public float xLimit = 2.5f;
    public float smoothness = 10f;

    private Vector3 targetPosition;
    private Vector3 startTouchPos;

    private bool isDragging;
    private bool gameStarted;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleInput();

        if (gameStarted)
        {
            MoveForward();
        }

        SmoothMove();
    }
    void MoveForward()
    {
        targetPosition.z += forwardSpeed * Time.deltaTime;
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
            startTouchPos = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float deltaX = Input.mousePosition.x - startTouchPos.x;
            MoveHorizontal(deltaX);
            startTouchPos = Input.mousePosition;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartGame();
                startTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.position.x - startTouchPos.x;
                MoveHorizontal(deltaX);
                startTouchPos = touch.position;
            }
        }
    }
    void MoveHorizontal(float deltaX)
    {
        targetPosition.x += deltaX * horizontalSpeed;
        targetPosition.x = Mathf.Clamp(targetPosition.x, -xLimit, xLimit);
    }
    void SmoothMove()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothness * Time.deltaTime
        );
    }
    void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
        }
    }
}