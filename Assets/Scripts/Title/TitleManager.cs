using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviourPunCallbacks
{
    public GameObject canvasLoading;
    public GameObject canvasFailed;
    public static bool startOn = false;
    public static bool randomOn = false;
    public static bool createOn = false;
    public static bool joinOn = false;
    public static string roomName;

    void Start(){
        DialogConfig.playerName = PlayerPrefs.GetString("NAME", "Player"); //設定した名前を取り出す。無ければPlayer。
        PhotonNetwork.LocalPlayer.NickName = DialogConfig.playerName; //名前を他のプレイヤーにも表示するようにする。
    }

    //ルーム作成、もしくはルームに参加する
    public override void OnConnectedToMaster(){
        //ランダムマッチング
        if(randomOn == true){
            PhotonNetwork.JoinRandomRoom();

        //ルームを作成する
        } else if(createOn == true){
            PhotonNetwork.CreateRoom(roomName,
                new RoomOptions(){ MaxPlayers = 4, IsVisible = false});

        //ルームに参加する
        } else if(joinOn == true){
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    //ルーム作成、入室時にゲームシーンへ移動する
    public override void OnJoinedRoom(){
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene("GameScene");
    }

    //ルーム作成が失敗したときにメッセージを表示する
    public override void OnCreateRoomFailed(short returnCode, string message){
        createOn = false;
        randomOn = false;
        Instantiate(canvasFailed);
        PhotonNetwork.Disconnect();
    }

    //マッチングが失敗したときにメッセージを表示する
    public override void OnJoinRoomFailed(short returnCode, string message){
        joinOn = false;
        randomOn = false;
        Instantiate(canvasFailed);
        PhotonNetwork.Disconnect();
    }

    //ランダムマッチングが失敗した時にルームを作る
    public override void OnJoinRandomFailed(short returnCode, string message){
        PhotonNetwork.CreateRoom(null, new RoomOptions(){ MaxPlayers = 4 });
    } 


    void Update()
    {
        //ルーム入室、作成したらローディング画面表示して、ネットワーク接続を始める
        if(startOn == true){
            startOn = false;
            Instantiate(canvasLoading);
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
