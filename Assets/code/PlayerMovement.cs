﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.code
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 0.2f;

        // playerの位置を特定
        private Vector3 pos;

        void Update()
        {
            // Inputの前に「-」を付ける。
            float moveH = -Input.GetAxis("Horizontal") * moveSpeed;
            float moveV = -Input.GetAxis("Vertical") * moveSpeed;
            transform.Translate(moveH, 0.0f, moveV);

            //上で入力した上限、下限値を設定　つまり可動範囲を設定できる
            Clamp();
        }

        // プレーヤーの移動できる範囲を制限する命令ブロック
        void Clamp()
        {
            // プレーヤーの位置情報を「pos」という箱の中に入れる。
            pos = transform.position;

            pos.x = Mathf.Clamp(pos.x, -10, 10);
            pos.z = Mathf.Clamp(pos.z, -10, 10);

            transform.position = pos;
        }
    }
}