using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    
    public static bool gameStartOn = false;
    public GameObject canvasDialog;
    private GameObject dialog;
    public AudioClip buttonOn;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //スタートボタンを押した時の処理
    public void GameStart(){
        if((gameStartOn == false) && (MasterManager.startOn == false) &&(ContinueCanvas.continueOn == false)){
            audioSource.PlayOneShot(buttonOn);
            dialog = (GameObject)Instantiate(canvasDialog);
        }
    }

}
