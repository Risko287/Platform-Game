using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneAfterClick(string sceneName)
    {
        Destroy(gameObject);
        LevelManager.Instance.LoadNewScene(sceneName);
    }
}
