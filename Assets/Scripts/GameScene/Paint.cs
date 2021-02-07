using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Paint : MonoBehaviourPunCallbacks, IPunObservable
{
    LineRenderer paint; //描画担当
    Vector3 mousePosition; //タッチした座標
    Vector3 position; //タッチした座標を変換した値
    int count; //頂点の数
    bool paintOn; //描画するかどうか
    List<Vector3> receivePosition = new List<Vector3>(); //同期処理用の描画した座標を保存するList
    int receiveCount;
    bool receivePaint = false;

    void Start()
    {
        paintOn = true;
        //paintの初期設定
        paint = GetComponent<LineRenderer>();
        paint.startWidth = 0.05f;
        paint.endWidth = 0.05f;
        paint.material.color = Color.black;
        paint.startColor = Color.black;
        paint.endColor = Color.black;

        if(photonView.IsMine){
            mousePosition = Input.mousePosition; //タッチした場所の座標を取得
            position = Camera.main.ScreenToWorldPoint(mousePosition); //座標の変換
            if((2.7f > position.x) && (position.x > -2.7f) && (2.2f > position.y) && (position.y > -3.4f)){ //描画範囲内か確認
                count += 1;
                paint.positionCount = count; //頂点の数設定
                paint.SetPosition(count - 1, position); //描画処理
                receivePosition.Add(position); //座標を保存
            }
        }
    }


    //描画処理
    void Update()
    {
        if(photonView.IsMine){
            if(paintOn == true){
                if(Input.GetMouseButton(0)){
                    mousePosition = Input.mousePosition;
                    position = Camera.main.ScreenToWorldPoint(mousePosition);
                    if((2.7f > position.x) && (position.x > -2.7f) && (2.2f > position.y) && (position.y > -3.4f)){ 
                        count += 1;
                        paint.positionCount = count; 
                        paint.SetPosition(count - 1, new Vector3(position.x, position.y, 1f));
                        receivePosition.Add(position);
                    }
                }
                if(Input.GetMouseButtonUp(0)){
                    paintOn = false; //指を離したら、このオブジェクトでの描画を終わる
                }
            }
        }
    }

    //描画を同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(count);
            stream.SendNext(paintOn);
            //描画した分だけ座標を送信する
            for(int i = receiveCount; receiveCount < count; receiveCount++){
                stream.SendNext(receivePosition[receiveCount]);
            }
        } else {
            //描画した人の座標を受け取って、他クライアント側でも描画する処理
            count = (int)stream.ReceiveNext();
            paintOn = (bool)stream.ReceiveNext();
            if(paintOn == true){
                receivePaint = true;
            }
            if(receivePaint == true){
            paint = GetComponent<LineRenderer>();
                for(int i = receiveCount; receiveCount < count; receiveCount++){
                    position = (Vector3)stream.ReceiveNext();
                    receivePosition.Add(position);
                    paint.positionCount = receiveCount + 1; 
                    paint.SetPosition(receiveCount, new Vector3(receivePosition[receiveCount].x, receivePosition[receiveCount].y, 1f));
                }
            }
            if(paintOn == false){
                receivePaint = false;
            }
        }
    }
}
