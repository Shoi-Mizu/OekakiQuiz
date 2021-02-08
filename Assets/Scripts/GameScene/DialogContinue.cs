using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class DialogContinue : MonoBehaviour
{
    public AudioClip buttonSE;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //コンティニューした時
    public void Continue(){
        audioSource.PlayOneShot(buttonSE);
        ContinueCanvas.kaisuu += 1;
        ContinueCanvas.continueOn = false;
        ContinueCanvas.destroy = true;
    }

    //退出した時
    public void GameExit(){
        audioSource.PlayOneShot(buttonSE);
        ContinueCanvas.destroy = true;
        ExitButton.exit = true;
    }

}
