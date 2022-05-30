using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public GameObject butt;
    public string TargetScene;
    private float time;

    void Start()
    {
        butt.SetActive(false);
    }

    void Update()
    {
        time = Time.timeSinceLevelLoad;
        if (time >= 5.0f)
        {
            butt.SetActive(true);
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(TargetScene);
    }
}
