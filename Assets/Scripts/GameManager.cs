using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] MainQuiz qz;
    [SerializeField] AudioSource aud;
    [SerializeField] AudioSource clk;
    [SerializeField] Animator anim;

    bool gameOver = false;

    void Start()
    {
        aud.volume = Settings.volumeAmount;
        clk.volume = Settings.volumeAmount;
    }

    void Update()
    {
        if (qz.gameComplete&&!gameOver)
        {
            gameOver = true;
            anim.SetTrigger("close");
            Invoke("LoadScene",1f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
