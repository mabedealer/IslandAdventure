using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static int currentDoorNumber = 0; //シーンをまたぐ時、何番出口だったかを記憶していくstatic変数



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //全Exitタグを調べた該当したGameObjectをすべて配列に格納する
        GameObject[] exits = GameObject.FindGameObjectsWithTag("Exit"); //FindGameObjectWithTag（sなし単数）は単品

        //配列の中を全点検
        foreach (GameObject exitObj in exits)
        {
            if (currentDoorNumber == exitObj.GetComponent<Exit>().doorNumber)
            {
                //番号が一致したExitオブジェクトのX座標とY座標
                float x = exitObj.transform.position.x;
                float y = exitObj.transform.position.y;
                //プレイヤーがいるべき座標を明確にして座標として加工する
                switch (exitObj.GetComponent<Exit>().direction)
                {
                    case Direction.up:
                        y += 1;
                        break;
                    case Direction.down:
                        y -= 1;
                        break;
                    case Direction.left:
                        x -= 1;
                        break;
                    case Direction.right: //上記３つの条件以外である場合、defaultと書くこともできる
                        x += 1;
                        break;
                }
                //シーン上にいるプレイヤーを探してくる
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    //プレイヤーを加工した座標に配置する
                    player.transform.position = new Vector2(x, y);
                }
                break; //該当するExitが見つかったのでforeachを抜ける場合、breakをここで使う
            }
        }

    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
