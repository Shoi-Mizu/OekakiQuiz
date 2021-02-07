using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class OdaiData : MonoBehaviourPunCallbacks, IPunObservable
{
    List<string> data = new List<string>();
    public static string odai;
    public static bool odaiDestroy;
    // Start is called before the first frame update
    void Start()
    {
        data.Add("いぬ");
        data.Add("ねこ");
        data.Add("ごりら");
        data.Add("こあらのまーち");
        data.Add("ぴかちゅう");
        data.Add("いるか");
        data.Add("さめ");
        data.Add("いか");
        data.Add("つき");
        data.Add("たいよう");
        data.Add("うんどうかい");
        data.Add("こんせんと");
        data.Add("くま");
        data.Add("しょうとくたいし");
        data.Add("めじゃー");
        data.Add("たぬき");
        data.Add("じゅうでんき");
        data.Add("るふぃ");
        data.Add("たおる");
        data.Add("さめ");
        data.Add("らむね");
        data.Add("にわとり");
        data.Add("えあこん");
        data.Add("せんぷうき");
        data.Add("たからばこ");
        data.Add("あくしゅ");
        data.Add("ゆーえすびー");
        data.Add("らけっと");
        data.Add("すけーとぼーど");
        data.Add("ごみばこ");
        data.Add("こたつ");
        data.Add("きりん");
        data.Add("かがみもち");
        data.Add("べると");
        data.Add("きーぼーど");
        data.Add("りもこん");
        data.Add("やきにく");
        data.Add("めぐすり");
        data.Add("にっぱー");
        data.Add("ぺんち");
        data.Add("かったー");
        data.Add("かぶとむし");
        data.Add("くわがた");
        data.Add("まりお");
        data.Add("すぷれー");
        data.Add("かご");
        data.Add("かば");
        data.Add("さる");
        data.Add("うさぎ");
        data.Add("きつね");
        data.Add("すらいむ");
        data.Add("くるま");
        data.Add("ぱそこん");
        data.Add("いんかん");
        data.Add("でんしゃ");
        data.Add("べんとう");
        data.Add("もあいぞう");
        data.Add("かしつき");
        data.Add("すべりだい");
        data.Add("しか");
        data.Add("ととろ");
        data.Add("ねずみ");
        data.Add("かぎ");
        data.Add("きゃべつ");
        data.Add("くじら");
        data.Add("かんがるー");
        data.Add("らっこ");
        data.Add("きんたろう");
        data.Add("ももたろう");
        data.Add("はち");
        data.Add("えのき");
        data.Add("もり");
        data.Add("ぼち");
        data.Add("たきび");
        data.Add("きゃんぷふぁいやー");
        data.Add("つり");
        data.Add("ぼくしんぐ");
        data.Add("ぼーりんぐ");
        data.Add("おさけ");
        data.Add("かえる");
        data.Add("ほうせき");
        data.Add("きんとれ");
        data.Add("おじぞうさん");
        data.Add("とうふ");
        data.Add("おんせん");
        data.Add("かばん");
        data.Add("おおかみ");
        data.Add("なっとう");
        data.Add("もち");
        data.Add("さくら");
        data.Add("たこやき");
        data.Add("はさみ");
        data.Add("でんわ");
        data.Add("まふらー");
        data.Add("ざぶとん");
        data.Add("やかん");
        data.Add("せんたく");
        data.Add("だるま");
        data.Add("とうきょうたわー");
        data.Add("にくまん");
        odai = data[Random.Range(0, data.Count)];
        odaiDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(odaiDestroy == true){
            Destroy(this.gameObject);
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(odai);
        } else {
            odai = (string)stream.ReceiveNext();
        }
    }
}
