using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class TimerText : MonoBehaviourPunCallbacks, IPunObservable
{
    private Text timerText;
    public static bool pathOn = false; //パスするか
    public static bool seikai = false; //正解か
    private float totalTime = 120.0f; //制限時間
    private int secondTime; //タイマー表示用
    private float startTime = 2.5f; //スタートからカウントダウン開始までの時間
    private Text answerText; //答え
    private int kaisuu = 1; //一回だけ処理するための変数

    //タイマーと答えの表示部を取得
    void Start()
    {
        timerText = transform.Find("TimerText").gameObject.GetComponent<Text>();
        answerText = GameObject.Find("CanvasAnswer").transform.Find("AnswerText").gameObject.GetComponent<Text>();
    }

    //タイマーのカウントダウンと表示の処理
    void Update()
    {
        //ゲームが始まったか
        if(MasterManager.startOn == true){
            //このオブジェクトを所有しているか
            if(photonView.IsMine){
                //始まってすぐ
                if(kaisuu == 1){
                    PhotonNetwork.InstantiateSceneObject("CanvasStateText", Vector2.zero, Quaternion.identity); //スタートの合図のテキストを生成
                    StateComment.start = true; //スタートのテキストを表示させるためにtrueにする
                    answerText.text = ""; //答えの表示を消す
                    kaisuu = 0;
                }
                startTime -= Time.deltaTime;
                //カウントダウン開始
                if(startTime < 0){
                    totalTime -= Time.deltaTime;
                    secondTime = (int)totalTime;
                    timerText.text = "残り " + secondTime.ToString() + " 秒"; //タイマーの表示

                    //タイムアップした時
                    if(secondTime < 0){
                        timerText.text = "タイムアップ！";
                        PhotonNetwork.Instantiate("CanvasStateText", Vector2.zero, Quaternion.identity);
                        StateComment.timeup = true;
                        MasterManager.startOn = false;
                        totalTime = 120.0f;
                        answerText.text = OdaiData.odai;
                        OdaiData.odaiDestroy = true;
                        Timer.odaiCount = 1;
                        kaisuu = 1;
                        startTime = 2.5f;
                    }

                    //パスした時
                    if(pathOn == true){
                        timerText.text = "パスされました！";
                        PhotonNetwork.Instantiate("CanvasStateText", Vector2.zero, Quaternion.identity);
                        StateComment.path = true;
                        MasterManager.startOn = false;
                        totalTime = 120.0f;
                        answerText.text = OdaiData.odai;
                        OdaiData.odaiDestroy = true;
                        Timer.odaiCount = 1;
                        pathOn = false;
                        kaisuu = 1;
                        startTime = 2.5f;
                    }

                    //正解した時
                    if(seikai == true){
                        timerText.text = "正解がでました！";
                        PhotonNetwork.Instantiate("CanvasStateText", Vector2.zero, Quaternion.identity);
                        StateComment.seikai = true;
                        MasterManager.startOn = false;
                        totalTime = 120.0f;
                        answerText.text = OdaiData.odai;
                        OdaiData.odaiDestroy = true;
                        Timer.odaiCount = 1;
                        seikai = false;
                        kaisuu = 1;
                        startTime = 2.5f;
                    }
                }
            }    
        }
    }

    //タイマーと、お題と、答えを同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(timerText.text);
            stream.SendNext(OdaiData.odaiDestroy);
            stream.SendNext(answerText.text);
        } else {
            timerText = transform.Find("TimerText").gameObject.GetComponent<Text>();
            answerText = GameObject.Find("CanvasAnswer").transform.Find("AnswerText").gameObject.GetComponent<Text>();
            timerText.text = (string)stream.ReceiveNext();
            OdaiData.odaiDestroy = (bool)stream.ReceiveNext();
            answerText.text = (string)stream.ReceiveNext();
        }
    }
}
