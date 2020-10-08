using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Scoretext : MonoBehaviour
{
    private GameObject ScoreText;

    private int score=0;

    private int nowScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        this.ScoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()
    {   
        this.ScoreText.GetComponent<Text>().text = "Score:" + this.nowScore + "p";
    }
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

        this.nowScore +=score;
      
    }
}
   