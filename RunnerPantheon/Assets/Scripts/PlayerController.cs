using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runningSpeed;
    public float halfRunningSpeed;
    public float doubleRunningSpeed;
    public float normalRunningSpeed;
    public float xSpeed;
    public float limitX;
    [SerializeField] private GameManager gameManager;



    public bool isGameContinue;

    

    void Start()
    {
        isGameContinue = true;
        normalRunningSpeed = runningSpeed;
        halfRunningSpeed = runningSpeed / 2;
        doubleRunningSpeed = runningSpeed * 2;
    }


    void Update()
    {
        if (!gameManager.isStarted)
        {
            return;
        }


        if (isGameContinue)
        {
            SwipeCheck();
        }
        
    }


    void SwipeCheck()
    {
        
        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

}
