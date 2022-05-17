using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject canvasForLoading;
    [SerializeField] private Image progressBarImage;

    private float _target;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            
    }

    public async void LoadNewScene(int sceneNumber)
    {
        progressBarImage.fillAmount = 0;
        _target = 0;
        canvasForLoading.SetActive(true);

        PlayerMovement.checkpoint = new Vector2(0, 0);
        
        var scene = SceneManager.LoadSceneAsync(sceneNumber);
        DoorControl.scene = sceneNumber;
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        canvasForLoading.SetActive(false);
    }
    
    void Update()
    {
        progressBarImage.fillAmount = Mathf.MoveTowards(progressBarImage.fillAmount, _target, Time.deltaTime);
    }
}
