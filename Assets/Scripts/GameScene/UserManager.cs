using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class UserManager : MonoBehaviourPunCallbacks, IPunObservable
{
    private GameObject canvas;
    private Text playerName;
    private Text writter;
    private Text preparation;
    private string writterText;

    void Start()
    {
        playerName = this.transform.Find("PlayerName").gameObject.GetComponent<Text>(); //名前表示部を取得
        playerName.text = photonView.Owner.NickName; //保存していた名前を取り出す
        writter = this.transform.Find("WritterText").gameObject.GetComponent<Text>(); //描き手かどうかを表示する部分を取得
        preparation = this.transform.Find("PreparationText").gameObject.GetComponent<Text>(); //準備OKかどうかを表示する部分を取得
        
        //プレイヤーアイコンの表示位置を取得し、表示させる
        canvas = GameObject.Find("CanvasGame"); 
        canvas = canvas.transform.Find("Scroll View").gameObject;
        canvas = canvas.transform.Find("Viewport").gameObject;
        canvas = canvas.transform.Find("Content").gameObject;
        transform.SetParent(canvas.transform, false);
        transform.position = new Vector2(0f, 0f);
    }


    //プレイヤーアイコンにステータスを表示させる
    void Update()
    {
        //オブジェクトの所有者か
        if(photonView.IsMine){
            //ルームの親か
            if(PhotonNetwork.IsMasterClient){
                writter.text = "描く人（親）";
            } else {
                writter.text = "";                
            }
            //始めるを押したか
            if(GameStartButton.gameStartOn == true){
                preparation.text = "準備OK";
            } else {
                preparation.text = "";
            }
        }
    }

    //他のプレイヤーと通信（同期）する
    //プレイヤーのステータスを同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(writter.text);
            stream.SendNext(preparation.text);
        } else {
            writter = this.transform.Find("WritterText").gameObject.GetComponent<Text>();
            writter.text = (string)stream.ReceiveNext();
            preparation = this.transform.Find("PreparationText").gameObject.GetComponent<Text>();
            preparation.text = (string)stream.ReceiveNext();
        }
    }
}
