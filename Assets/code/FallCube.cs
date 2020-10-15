using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 2);

        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
