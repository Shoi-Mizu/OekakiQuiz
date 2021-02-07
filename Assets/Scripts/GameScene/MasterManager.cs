using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MasterManager : MonoBehaviourPunCallbacks, IPunObservable
{

    int playerCount; //プレイヤーの数
    bool selectOn = true; //プレイヤー選択をするか
    Player[] player; //プレイヤーの情報
    public static bool startOn = false; //ゲームを開始するか

    void Start()
    {
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount; //プレイヤーの数取得
        player = PhotonNetwork.PlayerList; //プレイヤー情報取得
    }

    //プレイヤーがルームに入った時
    public override void OnPlayerEnteredRoom(Player newPlayer){
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        player = PhotonNetwork.PlayerList;
    }

    //プレイヤーがルームから出た時
    public override void OnPlayerLeftRoom(Player otherPlayer){
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        player = PhotonNetwork.PlayerList;
    }

    void Update()
    {
        if(photonView.IsMine){

            //描画開始時の処理
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
                if((2.7f > position.x) && (position.x > -2.7f) && (2.2f > position.y) && (position.y > -3.4f)){
                    PhotonNetwork.Instantiate("PaintImage", new Vector3(position.x, position.y, 0f), Quaternion.identity);
                    PhotonNetwork.Instantiate("PaintObject", new Vector3(position.x, position.y, 0f), Quaternion.identity);
                }
            }

            //入室プレイヤー数に応じて準備OKの数を確認する
            if(playerCount == 1){
                if(FlagManager.player1){
                    startOn = true;
                }
            }
            if(playerCount == 2){
                if((FlagManager.player1) && (FlagManager.player2)){
                    startOn = true;
                }
            }
            if(playerCount == 3){
                if((FlagManager.player1) && (FlagManager.player2) && (FlagManager.player3)){
                    startOn = true;
                }
            }
            if(playerCount == 4){
                if((FlagManager.player1) && (FlagManager.player2) && (FlagManager.player3) && (FlagManager.player4)){
                    startOn = true;
                }
            }
            if(startOn == false){
                selectOn = true;
            }
        }
    }

    //スタート開始の同期と描き手（親）のプレイヤー選択
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(startOn);
            if(startOn == true){
                if(selectOn == true){
                    selectOn = false;
                    PhotonNetwork.SetMasterClient(player[Random.Range(0, playerCount)]);
                }
            }
        } else {
            startOn = (bool)stream.ReceiveNext();
            if(startOn == true){
                selectOn = false;
            }
        }
    }
}
