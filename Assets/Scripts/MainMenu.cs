using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject homePage;
    [SerializeField] GameObject settingsPage;
    [SerializeField] Animator anim;

    void Start()
    {
        Settings.volumeAmount = 0.8f;
    }
     
    public void Play()
    {
        anim.SetTrigger("close");
        Invoke("LoadScene", 1f);
    }
    
    public void Setting()
    {
        homePage.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
