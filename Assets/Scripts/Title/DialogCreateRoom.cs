using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCreateRoom : MonoBehaviour
{
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;
    private InputField input;

 
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        input = this.transform.Find("DialogPanel").gameObject.transform.Find("InputField").gameObject.GetComponent<InputField>(); //入力部のコンポーネント取得
    }

    //ルームを作成する
    public void Create(){
        //入力部が空白じゃない
        if((input.text.Equals(null) == false) && (input.text.Equals("") == false)){
            audioSource.PlayOneShot(buttonOn);
            TitleManager.roomName = input.text; //ルーム名をTitleManagerに渡す
            TitleManager.createOn = true; //ルームを作成する
            TitleManager.startOn = true;
            Destroy(this.gameObject, 1f);
        }
    }

    //キャンセル
    public void Cancel(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }
}
