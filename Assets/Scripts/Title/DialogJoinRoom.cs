using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogJoinRoom : MonoBehaviour
{
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;
    private InputField input;
 

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソースの取得
        input = this.transform.Find("DialogPanel").gameObject.transform.Find("InputField").gameObject.GetComponent<InputField>(); //入力部のコンポーネントを取得
    }

    //ルームに参加する
    public void Join(){
        //入力が空白じゃない
        if((input.text.Equals(null) == false) && (input.text.Equals("") == false)){
            audioSource.PlayOneShot(buttonOn);
            TitleManager.roomName = input.text; //ルーム名をTitleManagerに渡す
            TitleManager.joinOn = true; //ルームに参加
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
