using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void PlayGame(int sceneNumber)
    {
        Destroy(gameObject);
        LevelManager.Instance.LoadNewScene(sceneNumber);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
