using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FlagManager : MonoBehaviourPunCallbacks, IPunObservable
{
    private Player[] player;
    public static int playerCount;
    public static bool player1 = false;
    public static bool player2 = false;
    public static bool player3 = false;
    public static bool player4 = false;
    private bool seikai = false;

    void Start()
    {
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount; //プレイヤーの数取得
        player = PhotonNetwork.PlayerList; //プレイヤー情報の取得
    }

    //プレイヤー入室時の処理
    public override void OnPlayerEnteredRoom(Player newPlayer){
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        player = PhotonNetwork.PlayerList;
    }

    //プレイヤー退室時の処理
    public override void OnPlayerLeftRoom(Player otherPlayer){
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        player = PhotonNetwork.PlayerList;
        //誰か１人でも退出したら準備OKをリセット
        player1 = false;
        player2 = false;
        player3 = false;
        player4 = false;
    }
   
    void Update(){
        if(photonView.IsMine){
            //ゲームスタートを押した時
            if(GameStartButton.gameStartOn == true){
                if(playerCount > 0){
                    if(player[0].IsLocal){
                        player1 = true;
                        ExitButton.isPlayer1 = true;
                    }
                    if(playerCount > 1){
                        if(player[1].IsLocal){
                            player2 = true;
                            ExitButton.isPlayer2 = true;
                        }
                        if(playerCount > 2){
                            if(player[2].IsLocal){
                                player3 = true;
                                ExitButton.isPlayer3 = true;
                            }
                            if(playerCount > 3){
                                if(player[3].IsLocal){
                                    player4 = true;
                                    ExitButton.isPlayer4 = true;
                                }
                            }
                        }
                    }    
                }
            }
            //プレイヤーの人数によっていないプレイヤーの準備OKフラグをリセット
            if(playerCount < 2){  
                player2 = false;
                player3 = false;
                player4 = false;
                if(playerCount < 3){
                    player3 = false;
                    player4 = false;
                    if(playerCount < 4){
                        player4 =false;
                    }
                }
            }
            //ゲームがスタートしたら準備をリセット
            if(MasterManager.startOn == true){
                GameStartButton.gameStartOn = false;
                player1 = false;
                player2 = false;
                player3 = false;
                player4 = false;
            } else {
                TimerText.seikai = false;
            }
            if(TimerText.seikai == true){
                seikai = true;
            }
        }
    }

    //プレイヤーの準備OKフラグを同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(player1);
            stream.SendNext(player2);            
            stream.SendNext(player3);
            stream.SendNext(player4);
            stream.SendNext(seikai);
            if(seikai == true){
                seikai = false;
            }
        } else {
            player1 = (bool)stream.ReceiveNext();
            player2 = (bool)stream.ReceiveNext();
            player3 = (bool)stream.ReceiveNext();
            player4 = (bool)stream.ReceiveNext();
            seikai = (bool)stream.ReceiveNext();
            if(seikai == true){
                TimerText.seikai = true;
                seikai = false;
            }
        }
    }
}
