using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() => this.gameObject.transform.position = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        //現在の位置を取得
        Vector3 pos = this.gameObject.transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.15f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - 0.15f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x - 0.15f, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x + 0.15f, pos.y, pos.z);
        }


        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.2f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - 0.2f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position = new Vector3(pos.x - 0.2f, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position = new Vector3(pos.x + 0.2f, pos.y, pos.z);
        }
    }
}