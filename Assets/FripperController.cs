using System.Collections;

using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;

    //左フリッパーのfingerId
    private int left;

    //右フリッパーのfingerId
    private int right;


    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //マルチタッチに対応
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                //左フリッパーを上げる
                if (t.phase == TouchPhase.Began && tag == "LeftFripperTag" && t.position.x < Screen.width / 2.0f)
                {
                    SetAngle(this.flickAngle);
                    left = t.fingerId;
                }
                //右フリッパーを上げる
                if (t.phase == TouchPhase.Began && tag == "RightFripperTag" && t.position.x >= Screen.width / 2.0f)
                {
                    SetAngle(this.flickAngle);
                    right = t.fingerId;
                }
                //左フリッパーを下げる
                if (t.phase == TouchPhase.Ended && tag == "LeftFripperTag" && t.fingerId == left)
                {
                    SetAngle(this.defaultAngle);
                }
                //右フリッパーを下げる
                if (t.phase == TouchPhase.Ended && tag == "RightFripperTag" && t.fingerId == right)
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
