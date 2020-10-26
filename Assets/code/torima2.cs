using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*

        基本形

        Mathf.Clampは値を制限内に収める関数である
        Mathf.Clamp(対象の値, 最小値, 最大値);


        最小値を返す方法

        int 対象の値 = 3;
        int 最小値 = 10;
        int 最大値 = 20;

        対象の値(3)が最小値(10)より低いため("3"～10～20)
        最小値(10)を返す
        int 結果(10) = Mathf.Clamp(対象の値, 最小値, 最大値);


        最大値を返す方法

        int 対象の値 = 50;
        int 最小値 = 10;
        int 最大値 = 20;

        対象の値(50)が最大値(20)より大きいため(10～20～"50")
        最大値(20)を返す
        int 結果(20) = Mathf.Clamp(対象の値, 最小値, 最大値);


        何もしないとき

        int 対象の値 = 16;
        int 最小値 = 10;
        int 最大値 = 20;

        対象の値(16)は最小値と最大値の間にあるので(10～"16"～20)
        そのまま16を返す
        int 結果(16) = Mathf.Clamp(対象の値, 最小値, 最大値);


        三次元のベクトルを用いた制限方法

        public void RestrictedMove(Vector3 Position, Vector3 Vec3Min, Vector3 Vec3Max, Space Type)
        {
            座標と移動を加算した値
            Vector3 Result = transform.localPosition + Position;

            if (IsRange(Result.x, Vec3Min.x, Vec3Max.x) == true)
            {
                transform.Translate(Position.x, 0, 0, Type);
            }

            if (IsRange(Result.y, Vec3Min.y, Vec3Max.y) == true)
            {
                transform.Translate(0, Position.y, 0, Type);
            }

            if (IsRange(Result.z, Vec3Min.z, Vec3Max.z) == true)
            {
                transform.Translate(0, 0, Position.z, Type);
            }
        }*/

    }
}

//自分用テンプレート


//using UnityEngine;
//using System.Collections;

public class RangeLimiterTranslate : MonoBehaviour
{

    //物理挙動付きの座標移動
    //対象にRigidbodyが無いと機能しない
    public void RestrictedMoveRigidbody(Vector3 Position, Vector3 Vec3Min, Vector3 Vec3Max, Space Type)
    {
        Vector3 Result = Restricted(Position, Vec3Min, Vec3Max, Type);

        GetComponent<Rigidbody>().MovePosition(transform.position + Result);
    }

    //Transformによる移動
    public void RestrictedMove(Vector3 Position, Vector3 Vec3Min, Vector3 Vec3Max, Space Type)
    {
        Vector3 Result = Restricted(Position, Vec3Min, Vec3Max, Type);

        transform.Translate(Result, Type);
    }

    //移動結果を制限内に調整する
    public Vector3 Restricted(Vector3 Position, Vector3 Vec3Min, Vector3 Vec3Max, Space Type)
    {
        //最終的に移動できる座標
        Vector3 Result = Vector3.zero;

        //座標と移動を加算した値
        Vector3 MovePosition = transform.localPosition + Position;

        //XYZ軸の判定
        if (IsRange(MovePosition.x, Vec3Min.x, Vec3Max.x) == true)
        {
            Result.x += Position.x;
        }

        if (IsRange(MovePosition.y, Vec3Min.y, Vec3Max.y) == true)
        {
            Result.y += Position.y;
        }

        if (IsRange(MovePosition.z, Vec3Min.z, Vec3Max.z) == true)
        {
            Result.z += Position.z;
        }

        return Result;
    }

    //範囲内に存在するかの判定式
    public bool IsRange(float Target, float Min, float Max)
    {
        //「Max <= Result」ならMaxの値を入れる
        //「Result <= Min」ならMinの値を入れる
        //「Min <= Result <= Max」なら何もしない
        float Result = Mathf.Clamp(Target, Min, Max);

        //調整が入らなければ、範囲内なのでtrue
        if (Result == Target) return true;
        //制限された場合false
        return false;
    }
}