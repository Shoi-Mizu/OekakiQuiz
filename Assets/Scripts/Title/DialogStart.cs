using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStart : MonoBehaviour
{
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;

    //オーディオソースの取得
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //ゲームを始めるボタンを押した時
    public void GameStart(){
        audioSource.PlayOneShot(buttonOn); //音を鳴らす
        TitleManager.randomOn = true; //ランダムマッチングで入室
        TitleManager.startOn = true; 
        Destroy(this.gameObject, 1f);
    }

    //キャンセルを押した時
    public void Cancel(){
        audioSource.PlayOneShot(canselOn); //音を鳴らす
        Destroy(this.gameObject, 0.2f);
    }
}
