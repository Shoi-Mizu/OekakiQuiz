using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPaint : MonoBehaviour
{

    //クリアボタンが押されたら、描画した物を消す
    void Update()
    {
        if(Clear.clearOn == true){
            Destroy(this.gameObject);
        }
    }
}
