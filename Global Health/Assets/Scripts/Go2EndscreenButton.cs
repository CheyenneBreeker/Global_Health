using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2EndscreenButton : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("Endscreen");
    }
}
