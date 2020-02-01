using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public string PlayerName = "P1"; // can also be "P2"

    public CharacterController Controller;

    public float Speed = 40;

    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    public void Move()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal" + PlayerName), Input.GetAxis("Vertical" + PlayerName));
        Vector2 stepAmt = input * Time.deltaTime;
        Vector3 step = new Vector3(stepAmt.x, 0, stepAmt.y) * Speed;
        Controller.Move(step);
    }
}
