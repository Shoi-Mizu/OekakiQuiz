using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public AudioClip canselOn;
    private AudioSource audioSource;

    void Start(){
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //閉じるボタン押した時の処理
    public void Cancel(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }
}
