using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDialog : MonoBehaviour
{
    public GameObject someoneStartCanvas;
    public GameObject friendStratCanvas;
    public GameObject configCanvas;
    public AudioClip buttonOn;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソースを取得
    }

    //誰かと遊ぶ（ランダムマッチング）のダイアログ表示
    public void CreateSomeone(){
        audioSource.PlayOneShot(buttonOn);
        Instantiate(someoneStartCanvas);
    }

    //フレンドマッチのダイアログ表示
    public void CreateFriend(){
        audioSource.PlayOneShot(buttonOn);
        Instantiate(friendStratCanvas);
    }

    //設定ダイアログ表示
    public void CreateConfig(){
        audioSource.PlayOneShot(buttonOn);
        Instantiate(configCanvas);
    }
}
