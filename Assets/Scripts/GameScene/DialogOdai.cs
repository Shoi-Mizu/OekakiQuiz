using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class DialogOdai : MonoBehaviour
{
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;
    public Text odaiText;

    void Start()
    {
        odaiText.text = OdaiData.odai;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //閉じるボタンを押した時
    public void Toji(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }

    //パスした時
    public void Path(){
        audioSource.PlayOneShot(buttonOn);
        if(MasterManager.startOn == true){
            TimerText.pathOn = true;
        }
        Destroy(this.gameObject, 0.2f);
    }
}
