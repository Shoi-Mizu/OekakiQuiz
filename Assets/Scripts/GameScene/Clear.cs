using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Clear : MonoBehaviourPunCallbacks, IPunObservable
{
    public static bool clearOn;
    private float destroyTime;

    void Start()
    {
        destroyTime = 0.1f;
    }


    void Update()
    {
        if(ClearButton.clearOn == true){
            clearOn = ClearButton.clearOn;
        }
        if(ClearButton.clearOn == false){
            if(clearOn == true){
                destroyTime -= Time.deltaTime; //描画が確実に消えるまでの時間を確保
                if(destroyTime < 0){
                    clearOn = false;
                    destroyTime = 0.13f;
                }
            }
        }
    }

    //クリアボタンが押されたか同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(clearOn);
        } else {
            clearOn = (bool)stream.ReceiveNext();
        }
    }
}
