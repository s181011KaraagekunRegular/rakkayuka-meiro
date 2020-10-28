using UnityEngine;
using System.Collections;

public class Playercontrol : MonoBehaviour
{

    GameObject Player;
    GameObject wall_Left;
    GameObject wall_Right;
    GameObject wall_Bottom;
    GameObject wall_Top;

    Vector3 LeftPos;
    Vector3 RightPos;
    Vector3 BottomPos;
    Vector3 TopPos;

    // Use this for initialization
    void Start()
    {

        Player = GameObject.Find("Player");
        wall_Left = GameObject.Find("Wall Left");
        wall_Right = GameObject.Find("Walll Right");
        wall_Bottom = GameObject.Find("Wall Bottom");
        wall_Top = GameObject.Find("Wall Top");

        LeftPos = wall_Left.transform.position;
        RightPos = wall_Right.transform.position;
        BottomPos = wall_Bottom.transform.position;
        TopPos = wall_Top.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x+1, LeftPos.x, RightPos.x),
        Mathf.Clamp(Player.transform.position.y, BottomPos.y, TopPos.y), transform.position.z));

    }
}