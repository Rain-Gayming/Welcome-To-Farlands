using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoadScene : MonoBehaviour
{
    public void OpenScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
