using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ClearButton : MonoBehaviourPunCallbacks
{
    public static bool clearOn;
    private float destroyTime; 
    public AudioClip clearSE;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        clearOn = false;
        destroyTime = 0.1f;
    }


    void Update()
    {
        if(clearOn == true){
            destroyTime -= Time.deltaTime; //描画が確実に消えるまでの時間を確保
            if(destroyTime < 0){
                clearOn = false;
                destroyTime = 0.13f;
            }
        }
    }

    //クリアボタンを押した時
    public void Clear(){
        if(photonView.IsMine){
            audioSource.PlayOneShot(clearSE);
            clearOn = true;       
        }
    }
}
