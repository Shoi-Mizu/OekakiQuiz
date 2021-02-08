using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogExit : MonoBehaviour
{
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //退出するを押した時
    public void GameExit(){
        audioSource.PlayOneShot(buttonOn);
        ExitButton.exit = true;
        Destroy(this.gameObject);
    }

    //キャンセルした時
    public void Cancel(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }
}
