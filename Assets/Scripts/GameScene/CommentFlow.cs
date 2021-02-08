using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CommentFlow : MonoBehaviourPunCallbacks, IPunObservable
{
    private float speed;
    private string text;

    //コメントの初期位置を指定してコメントを表示
    void Start()
    {
        if(photonView.IsMine){
            speed = -600.0f;
            float positionY = Random.Range(1320f, 350f);
            transform.position = new Vector3(3000f, positionY, 0f);
            text = photonView.Owner.NickName + " : " + SendButton.inText;
            this.gameObject.GetComponent<Text>().text = text;
            SendButton.inText = ""; 
        }
    }

    //コメントを右から左へ流す
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    //コメントの同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(text);
        } else {
            this.gameObject.GetComponent<Text>().text = (string)stream.ReceiveNext();
        }
    }
}
