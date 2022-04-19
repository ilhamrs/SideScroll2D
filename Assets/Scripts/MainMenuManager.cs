using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject aboutPanel;
    bool isAboutPanelActive;
    // Start is called before the first frame update
    void Start()
    {
        isAboutPanelActive = false;
        aboutPanel.SetActive(isAboutPanelActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void AboutPanel()
    {
        if (isAboutPanelActive)
        {
            isAboutPanelActive = false;
        }
        else
        {
            isAboutPanelActive = true;
        }
        aboutPanel.SetActive(isAboutPanelActive);
    }
}
