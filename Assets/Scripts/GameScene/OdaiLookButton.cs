using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OdaiLookButton : MonoBehaviourPunCallbacks
{
    public GameObject odaiCanvas;
    private GameObject odaiDialog;
    public AudioClip buttonOn;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void OdaiLook(){
        //描き手か
        if(photonView.IsMine){
            audioSource.PlayOneShot(buttonOn);
            odaiDialog = (GameObject)Instantiate(odaiCanvas);
        }
    }
}
