using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogFriend : MonoBehaviour
{
    public GameObject createRoom;
    public GameObject joinRoom;
    public AudioClip buttonOn;
    public AudioClip canselOn;
    private AudioSource audioSource;

    void Start(){
        audioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソースの取得
    } 

    //ルームを作成する
    public void CreateRoom(){
        audioSource.PlayOneShot(buttonOn);
        Instantiate(createRoom); //ルーム作成のダイアログ表示
        Destroy(this.gameObject, 0.2f);
    }

    //ルームに参加する
    public void JoinRoom(){
        audioSource.PlayOneShot(buttonOn);
        Instantiate(joinRoom); //ルームに参加するのダイアログ表示
        Destroy(this.gameObject, 0.2f);
    }

    //キャンセル
    public void Cancel(){
        audioSource.PlayOneShot(canselOn);
        Destroy(this.gameObject, 0.2f);
    }
}
