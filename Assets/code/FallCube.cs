using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCube : MonoBehaviour
{
    //Playerと離れたとき判定いく：OnCollisionExit
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", .5f);    //FullCube落下 Fall呼び出し
            Invoke("Delete", .7f);  //FullCube消去 Delete呼び出し
        }
    }

    void Fall()
    {
        //対象に重力を発生させる⇒落下させる
        GetComponent<Rigidbody>().isKinematic = false;

    }
    void Delete()
    {
        //0.5秒後に対象を削除
        Destroy(gameObject, .5f);
    }
}