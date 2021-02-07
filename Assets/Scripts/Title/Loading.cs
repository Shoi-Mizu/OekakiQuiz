using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Loading : MonoBehaviourPunCallbacks
{

    //ルーム作成が失敗した時、オブジェクト削除
    public override void OnCreateRoomFailed(short returnCode, string message){
        Destroy(this.gameObject);
    }

    //マッチングが失敗した時、オブジェクト削除
    public override void OnJoinRoomFailed(short returnCode, string message){
        Destroy(this.gameObject);
    }
}
