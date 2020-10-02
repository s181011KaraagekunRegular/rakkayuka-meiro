using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCube : MonoBehaviour
{

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", .5f);
            Invoke("Delete", .7f);
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;

    }
    void Delete()
    {
        Destroy(gameObject, .5f);
    }
}