using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Assets.code
{
    public class PlayerMovement : MonoBehaviour
    {
        /*
        Playerの操作系
        const V：一回当たりの移動量を設定
        moveSpeed：移動速度の設定…速すぎると判定抜けの可能性あり
         */
        private const float V = 1.1f;
        public float moveSpeed = .5f;

        void Start() => this.gameObject.transform.position = new Vector3(5, 1, 1);
        // playerの位置を特定
        private Vector3 pos;

        void Update()
        {
            // Inputの前に「-」を付ける。
            float moveH = -Input.GetAxis("Horizontal") * moveSpeed;
            float moveV = -Input.GetAxis("Vertical") * moveSpeed;
            //初期位置(0,1,0)からずれる方向、距離(⇓,⇑,前後)
            transform.Translate(moveH, 0, moveV);

            //上で入力した上限、下限値を設定 ⇒⇒⇒ 可動範囲域を設定できる
            Clamp();

            //現在の座標を取得
            //            Vector3 pos = this.gameObject.transform.position;

            Vector3 pos = new Vector3(0, 0, 0);

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
        }

        // プレーヤーの移動できる範囲を制限する命令ブロック
        void Clamp()
        {
            // プレーヤーの位置情報を「pos」という箱の中に入れる。
            pos = transform.position;
            /*
            ≪注意≫現在の視点上での動き（変域の設定）
              x値　+：右側の可動域,-：左側の可動域
              y値　+：上部への可動域,-：下部への可動域
            　z値　+：,　　　　　　　　-：
            */
            pos.x = Mathf.Clamp(pos.x, 5, -5);
            pos.y = Mathf.Clamp(pos.y, 0, 0);
            pos.z = Mathf.Clamp(pos.z, 0, 0);
            transform.position = pos;


        }
    }
}