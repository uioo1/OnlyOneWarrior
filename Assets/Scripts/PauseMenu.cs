using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausedUI;
    public GameObject OptionUI;
    public GameObject TouchUI;

    public static bool paused = false;
    public bool IsOption = false;

    void Start()
    {
        PausedUI.SetActive(false);
        OptionUI.SetActive(false);
    }

    void Update()
    {
        if(paused == true)
        {
            PausedUI.SetActive(true);
            OptionUI.SetActive(false);
            TouchUI.SetActive(false);
            Time.timeScale = 0;

            if(IsOption == true)
            {
                PausedUI.SetActive(false);
                OptionUI.SetActive(true);
            }
        }

        if(paused == false)
        {
            PausedUI.SetActive(false);
            OptionUI.SetActive(false);
            TouchUI.SetActive(true);
            
            Time.timeScale = 1;
        }
    }

    public void PreferenceButtonDown()
    {
        paused = !paused;   
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        paused = false;
        Application.LoadLevel(Application.loadedLevel);
    }


    public void Options()
    {
        IsOption = true;
    }

    public void OptionsBack()
    {
        IsOption = false;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
    }
}
