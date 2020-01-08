using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepMap : MonoBehaviour
{

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }
}
