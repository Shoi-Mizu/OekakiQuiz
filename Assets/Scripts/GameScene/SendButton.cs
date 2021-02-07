using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class SendButton : MonoBehaviourPunCallbacks
{
    public InputField inputField;
    public static string inText = "";
    public AudioClip buttonOn;
    private AudioSource audioSource;

    //コメント入力部とオーディオソースの取得
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //入力中の処理
    public void CommentView(){
        if(inputField.text.Equals("") == false){
            inText = inputField.text;
        }
    }

    //送信ボタンを押した時の処理
    public void CommentGenerate(){
        if(inputField.text.Equals("") == false){
            audioSource.PlayOneShot(buttonOn);
            Check();
            PhotonNetwork.Instantiate("CanvasComment", Vector3.zero, Quaternion.identity);
            inputField.text = "";
        }
    }

    //正解かどうかチェック
    void Check(){
        if(MasterManager.startOn == true){
            if(inText.Equals(OdaiData.odai)){
                TimerText.seikai = true;
            }
        }
    }
}
