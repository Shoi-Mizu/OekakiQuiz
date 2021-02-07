using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class StateComment : MonoBehaviourPunCallbacks, IPunObservable
{
    float speed = -2000.0f;
    float time = 1.3f;
    float startTime = 1f;
    Text seikaiText;
    public static bool seikai = false;
    public static bool path = false;
    public static bool timeup = false;
    public static bool start = false; 
    public AudioClip seikaiSE;
    public AudioClip startSE;
    public AudioClip failedSE;
    public AudioClip hajimariSE;
    private AudioSource audioSource;
    private bool hyouji = true;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        seikaiText = this.GetComponent<Text>();
        //正解の時
        if(seikai == true){
            audioSource.PlayOneShot(seikaiSE);
            seikaiText.text = "正解したよ！！";
            seikai = false;
        //パスした時
        } else if(path == true){
            audioSource.PlayOneShot(failedSE);
            seikaiText.text = "パスされました！";
            path = false;
        //タイムアップの時
        } else if(timeup == true){
            audioSource.PlayOneShot(failedSE);
            seikaiText.text = "タイムアップ！";
            timeup = false;
        //スタートの時
        } else {
            audioSource.PlayOneShot(hajimariSE);
            seikaiText.text = "始まります...";
        }
    }

    void Update()
    {
        //スタートの表示
        //右端から流れてきて真ん中で止まる
        if((transform.position.x > 540f) && (time > 0f)){
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        //時間が経ったら真ん中から左に流れる
        if(time < 0){
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
            Destroy(this.gameObject, 1.5f);
        }
        //真ん中まできたら時間が進む
        if(transform.position.x < 540f){
            if(start == true){
                startTime -= Time.deltaTime;
                if(startTime < 0){
                    start = false;
                    seikaiText.text = "スタート！";
                    audioSource.PlayOneShot(startSE);
                }
            } else {
                time -= Time.deltaTime;
            }
        }

        //スタート以外の表示
        if(hyouji == true){
            hyouji = false;
            if(seikai == true){
                audioSource.PlayOneShot(seikaiSE);
                seikaiText.text = "正解したよ！！";
                seikai = false;
            } else if(path == true){
                audioSource.PlayOneShot(failedSE);
                seikaiText.text = "パスされました！";
                path = false;
            } else if(timeup == true){
                audioSource.PlayOneShot(failedSE);
                seikaiText.text = "タイムアップ！";
                timeup = false;
            }
        }
    }


    //コメントの同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(seikaiText.text);
            stream.SendNext(start);
            stream.SendNext(seikai);
            stream.SendNext(path);
            stream.SendNext(timeup);
        } else {
            seikaiText = this.GetComponent<Text>();
            seikaiText.text = (string)stream.ReceiveNext();
            start = (bool)stream.ReceiveNext();
            seikai = (bool)stream.ReceiveNext();
            path = (bool)stream.ReceiveNext();
            timeup = (bool)stream.ReceiveNext();
        }
    }
}
