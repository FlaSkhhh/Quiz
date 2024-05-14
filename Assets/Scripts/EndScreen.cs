using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject troll; 
    [SerializeField] GameObject score;

    [SerializeField] Text enterNameText;

    [SerializeField] Animator anim;
    [SerializeField] AudioSource aud;

    bool nameChanged = false;

    void Start()
    {
        aud.volume = Settings.volumeAmount;
        if(Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform)
        {
            nameChanged = true;
            enterNameText.text = "Unfortunately WebGl version doesn't support touchscreen keyboard so just press confirm.";
        }
    }
    
    public void NameChange()
    {
        nameChanged = true;
    }

    public void ConfirmButton()
    {
        if (nameChanged)
        {
            troll.SetActive(false);
            score.SetActive(true);
            //aud.Play();
        }
        else
        {
            enterNameText.text = "Please enter a valid Username below";
            enterNameText.color = new Color(1, 0, 0, 1);
        }
    }

    public void Home()
    {
        anim.SetTrigger("close");
        Invoke("LoadScene", 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
