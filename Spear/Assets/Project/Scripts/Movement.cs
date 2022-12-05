using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Touch touch;
    private Transform leftPoint,rightPoint;


    [Header("Objects")]
    public Transform plane;
    public GameManager gameManager;

    [Header("Touch Settings")]
    public float speed = 2.0f;
    public float sensitive = 8;


    void Start()
    {
        leftPoint = plane.FindChild("LeftPoint");
        rightPoint = plane.FindChild("RightPoint");
    }
    void Update()
    {
        if(gameManager.gameState == GameManager.GameState.Start)
        {
            Move();
            MoveXAxis();
        }

    }



    private void Move()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void MoveXAxis()
    {
        transform.position = new Vector3(MovementDistance(), transform.position.y, transform.position.z);
    }


    private float MovementDistance()
    {

        return Mathf.Clamp(SensitiveX(),leftPoint.position.x,rightPoint.position.x);
    }
    private float SensitiveX()
    {
        return transform.position.x + Touch().x * (sensitive / 1000);
    }
    private Vector2 Touch()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                return touch.deltaPosition;

            }
            else return new Vector2(0,0);
        }
        else return new Vector2(0,0);
    }

}
