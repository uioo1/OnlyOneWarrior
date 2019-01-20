using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public string[] sceneName;

    public int sceneNum = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToScene()
    {
        PauseMenu.paused = false;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName[sceneNum]);
    }

    public void SceneNumToOne()
    {
        sceneNum = 1;
    }
}
