using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //初期地点の設定
    void Start()
    {
        this.gameObject.transform.position = new Vector3(0, 1, 0);
}

    // Update is called once per frame
    void Update()
    {
        //現在の位置を取得
        Vector3 pos = this.gameObject.transform.position;

        //↑↓←→キー　各移動速度を設定
        const float V = 0.15f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + V);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - V);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x - V, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position = new Vector3(pos.x + V, pos.y, pos.z);
        }

        //WASDキー　各移動速度を設定
        const float V1 = 0.2f;
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + V1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - V1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position = new Vector3(pos.x - V1, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position = new Vector3(pos.x + V1, pos.y, pos.z);
        }
    }



public class MyScript : MonoBehaviour
    {
        void Update()
        {

            /*よくわからないやつ
             *特定の判定を得たときに表示させる
             *今は機能してない
             */
            void OnCollisionStay(Collision collision)
            {
                Debug.Log("当たり判定");

            }
        }
    }
}



