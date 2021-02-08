using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DialogGameStart : MonoBehaviour
{
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;

    void Start(){
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //ゲームを始めるボタンを押した時
    public void GameStart(){
        audioSource.PlayOneShot(buttonOn);
        GameStartButton.gameStartOn = true;
        Destroy(this.gameObject, 0.2f);
    }

    //キャンセルを押した時
    public void Cancel(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }
}
