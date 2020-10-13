using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見えるZ軸の座標の最大値
    private float visiblePosZ = -6.5f;

    //GameOverTextを取得
    private GameObject gameoverText;

    //Scoretextを取得
    private GameObject ScoreText;

    private int score = 0;
    private int nowScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //得点の表示
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            score = 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score = 30;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score = 20;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score = 100;
        }
        else
        {
            score = 0;
        }
        this.nowScore += score;
        this.ScoreText.GetComponent<Text>().text = "Score:" + this.nowScore + "p";
    }
}
