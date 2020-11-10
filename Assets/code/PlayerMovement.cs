using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.code
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = .5f;

        // playerの位置を特定
        private Vector3 pos;

        void Update()
        {
            // Inputの前に「-」を付ける。
            float moveH = -Input.GetAxis("Horizontal") * moveSpeed;
            float moveV = Input.GetAxis("Vertical") * moveSpeed;
            //初期位置(0,0,0)からずれる方向、距離(⇓,⇑,前)
            transform.Translate(moveH, 0.0f, moveV);

            //上で入力した上限、下限値を設定　つまり可動範囲を設定できる
            Clamp();
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
            */
            pos.x = Mathf.Clamp(pos.x, 0, 0);
            pos.z = Mathf.Clamp(pos.z, 1, 2f);

            transform.position = pos;
        }
    }
}