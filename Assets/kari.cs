using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    GameObject Player;
    GameObject wall_Left;
    GameObject wall_Right;
    GameObject wall_Bottom;
    GameObject wall_Top;

    bool MoveRight;
    bool MoveLeft;

    void Start()
    {

        Player = GameObject.Find("Player");
        wall_Left = GameObject.Find("Wall Left");
        wall_Right = GameObject.Find("Walll Right");
        wall_Bottom = GameObject.Find("Wall Bottom");
        wall_Top = GameObject.Find("Wall Top");

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight = true;
            MoveLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft = true;
            MoveRight = false;
        }
        else
        {
            MoveRight = false;
            MoveLeft = false;
        }

        //↑↑ここまでやった
        Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x, wall_Left.transform.position.x, wall_Right.transform.position.x),
    Mathf.Clamp(Player.transform.position.y, wall_Bottom.transform.position.y, wall_Top.transform.position.y),
    Player.transform.position.z));

    }
    //↑↑ここまでやった
    /*   void FixedUpdate()
       {

           if (MoveRight)
           {
               Player.GetComponent().velocity = (transform.up * 2);
               Player.transform.Rotate(new Vector3(0, 0, -5));
           }
           else if (MoveLeft)
           {
               Player.GetComponent().velocity = (transform.up * 2);
               Player.transform.Rotate(new Vector3(0, 0, 5));
           }
           else
           {
               Player.GetComponent().velocity = (transform.up * 0);
           }
       }
   */
}