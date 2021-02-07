using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviourPunCallbacks
{
    public static bool isPlayer1 = false;
    public static bool isPlayer2 = false;
    public static bool isPlayer3 = false;
    public static bool isPlayer4 = false;
    public static bool exit = false;
    public GameObject canvasExit;
    private GameObject exitDialog;
    public AudioClip buttonOn;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        exit = false;
    }


    void Update()
    {
        //退出時
        if(exit == true){
            exit = false;
            PhotonNetwork.Disconnect(); //photonのサーバーから出る
            SceneManager.LoadScene("TitleScene"); //タイトルに戻る
        }
    }

    //退出ボタンを押した時
    public void ChangeScene(){
        audioSource.PlayOneShot(buttonOn);
        exitDialog = (GameObject)Instantiate(canvasExit);
    }
}
