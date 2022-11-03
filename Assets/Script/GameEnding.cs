using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //遊戲勝利時,圖片淡入淡出的時間
    public float fadeTimeVal = 1f;
    //遊戲勝利圖片的顯示時間
    public float displayTimeVal = 1f;
    public GameObject player;
    //遊戲圖片的畫布背景 0勝利 1失敗
    public CanvasGroup[] background;
    bool isExit;
    bool isFall;
    public float Timer=0f;
    public GameObject Pause;
    bool isPause = true;
    //0 勝利 1失敗
    public AudioSource[] audioSources;
    public GameObject[] Audios;
    public Scrollbar scrollbar;
    public Text musicText;
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject == player)
        {
            isExit = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isExit)
        {
            audioSources[0].volume = 0;
            Audios[0].SetActive(true); 
            EndLevel(background[0]);            
        }
        if(isFall)
        {
            audioSources[0].volume = 0;
            Audios[1].SetActive(true);
            EndLevel(background[1]);         
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isExit==false&&isFall==false)
            {
                Pause.SetActive(isPause);
                isPause = !isPause;
            }           
        }
    }
    public void Caught()
    {
        isFall = true;
    }
    void EndLevel(CanvasGroup igCanvas)
    {
        Timer+= Time.deltaTime;
        igCanvas.alpha = Timer/fadeTimeVal;
        if(Timer>=fadeTimeVal+displayTimeVal)
        {
            igCanvas.alpha = 0;
            SceneManager.LoadScene("Main");
        }
    }
    public void Continue()
    {
        Pause.SetActive(false);
        isPause = true;
    }
    public void MusicUpDown()
    {
        for(int i = 0 ; i<audioSources.Length;i++)
        {
            audioSources[0].volume = scrollbar.value;
        }       
        musicText.text = ((int)(scrollbar.value*100)).ToString(); 
    }
}
