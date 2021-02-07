using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class DialogConfig : MonoBehaviour
{
    private InputField input;
    private Text content;
    public static string playerName;
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;

    //それぞれのコンポーネントを取得
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        input = this.transform.Find("DialogPanel").gameObject.transform.Find("InputField").gameObject.GetComponent<InputField>();
        content = this.transform.Find("DialogPanel").gameObject.transform.Find("ContentText").gameObject.GetComponent<Text>();
        content.text = "現在のプレイヤー名は\n" + playerName + " です。";
    }

    //名前を設定する
    public void SetName(){
        if((input.text.ToString().Equals(null) == false) && (input.text.ToString().Equals("") == false)){
            audioSource.PlayOneShot(buttonOn);
            playerName = input.text;
            PhotonNetwork.LocalPlayer.NickName = playerName;
            content.text = "現在のプレイヤー名は\n" + playerName + " です。";
            PlayerPrefs.SetString("NAME", playerName); //プレイヤー名を保存する
            PlayerPrefs.Save(); //アプリのセーブ
        }
    }

    public void Destroy(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }
}
