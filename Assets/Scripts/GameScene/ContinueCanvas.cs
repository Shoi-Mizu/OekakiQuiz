using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ContinueCanvas : MonoBehaviour
{

    public GameObject continueCanvas;
    public GameObject continuePrefab;
    private GameObject continueDialog;
    public static bool continueOn = false;
    public static int kaisuu = 0;
    public static bool destroy = false;
    private float viewTime = 1.5f;
    private string gameID;
    private bool hyouji = false;


    void Start(){
        gameID = "iPhonの時のID"; //プラットフォームに合わせた広告IDを入れる
        Advertisement.Initialize(gameID); //広告の初期化
    }


    void Update()
    {
        if(MasterManager.startOn == true){
            continueOn = true;
            hyouji = true;
        }

        //ゲームが終わった時
        if((MasterManager.startOn == false) && (continueOn == true) && (hyouji == true)){
            viewTime -= Time.deltaTime;
            if(viewTime < 0){
                hyouji = false;
                viewTime = 1.5f;
                //コンティニューダイアログを生成する
                continueDialog = (GameObject)Instantiate(continuePrefab);
                continueDialog.transform.SetParent(continueCanvas.transform, false);
                continueDialog.transform.position = new Vector2(0f, 0f);
            }
        }

        //コンティニューダイアログを消す
        if(destroy == true){
            destroy = false;
            Destroy(continueDialog);
        }

        //４回以上コンティニューしたら広告を表示する
        if(kaisuu >= 4){
            kaisuu = 0;
            if(Advertisement.IsReady()){
                Advertisement.Show();
            }
        }
    }

}
