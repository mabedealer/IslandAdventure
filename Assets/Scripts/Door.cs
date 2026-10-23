using UnityEngine;

public class Door : MonoBehaviour
{
    private UIController _uiCnt; //UIControllerスクリプトを参照できる変数
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UIControllerスクリプトを探してくる
        _uiCnt = GameObject.FindFirstObjectByType<UIController>();
    }
    //接触した時、
    //①相手がPlayerタグを持つものであれば
    //②鍵が１以上所持されていれば
    //ドアは消滅・UIControllerの鍵テキストの更新
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(ItemKeeper.hasKeys >0)
            {
                ItemKeeper.hasKeys--; //1減らす
                Destroy(gameObject); //ドア消滅
                _uiCnt.UpdateItemCount(ItemType.key, ItemKeeper.hasKeys); //UI更新
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
