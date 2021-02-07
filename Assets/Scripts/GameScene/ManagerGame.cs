using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManagerGame : MonoBehaviourPunCallbacks
{
     void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true; //入室時に受信を許可する
        PhotonNetwork.Instantiate("ClearObject", Vector2.zero, Quaternion.identity); //描画クリアオブジェクトの生成
        PhotonNetwork.Instantiate("UserIcon", Vector2.zero, Quaternion.identity); //プレイヤーのアイコン生成
        PhotonNetwork.InstantiateSceneObject("CanvasTimer", Vector2.zero, Quaternion.identity); //タイマー表示部の生成
        PhotonNetwork.Instantiate("FlagManager", Vector2.zero, Quaternion.identity); //フラグ管理オブジェクトの生成
    }
}
