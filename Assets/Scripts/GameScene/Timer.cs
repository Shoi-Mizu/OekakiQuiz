using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Timer : MonoBehaviourPunCallbacks
{
    private GameObject odai;
    public static int odaiCount = 1;


    //ゲームがスタートしたら、お題のオブジェクトを生成する
    void Update()
    {
        if(MasterManager.startOn == true){
            if(odaiCount == 1){
            odai = (GameObject)PhotonNetwork.Instantiate("OdaiObject", Vector2.zero, Quaternion.identity);
            odaiCount--;                
            }
        }
    }
}
