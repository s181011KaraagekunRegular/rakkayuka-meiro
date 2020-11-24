using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransStage1 : MonoBehaviour
{

    // Use this for initialization
    public void OnClick()
    {
        // メインシーンへ移動
        SceneManager.LoadScene("Stage1");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}