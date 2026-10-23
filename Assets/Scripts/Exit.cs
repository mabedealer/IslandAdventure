using UnityEngine;
using UnityEngine.SceneManagement;

//複数シーンをまたぐとき、マネージャーが必要。
//プレイヤーは、Exitに達する。Exitは番号とまたぎ先情報を持っている。
//またぎ先にも番号を持っている。Exitの番号と、またぎ先の番号がリンクし、またぐ。

public class Exit : MonoBehaviour
{
    [Header("移動先となるシーン名")]
    [SerializeField]private string _sceneName;

    [Header("出入り口の識別番号・方向")]
    public int doorNumber;
    public Direction direction;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //static変数に自分の識別番号を授ける
            RoomManager.currentDoorNumber =doorNumber;
            //ここにSceneManager.LoadScene(_sceneName);と書かない理由は、あえて別メソッドにした。
            Invoke("Load", 0.2f); //Loadという名前が欲しい。Load()ではない。コルーチンを使うことも考えられるがここではinvoke。
            Load();
        }
    }
    //シーンを切り替えるメソッド
    private void Load()
    {
        SceneManager.LoadScene(_sceneName);
    }    
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
