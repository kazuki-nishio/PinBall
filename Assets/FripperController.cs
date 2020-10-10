using System.Collections;

using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;

    private float flickAngle = -20;


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
            
        
        if(Input.GetKeyDown(KeyCode.RightArrow)&& tag=="RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)&& tag=="LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)&& tag=="RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //touchに対応
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);

                if (t.phase == TouchPhase.Began && tag == "LeftFripperTag"&&t.position.x<Screen.width/2.0f)
                {
                    SetAngle(this.flickAngle);
                }

                if (t.phase == TouchPhase.Began && tag == "RightFripperTag" && t.position.x >= Screen.width/2.0f)
                {
                    SetAngle(this.flickAngle);
                }

                if (t.phase == TouchPhase.Ended && tag == "LeftFripperTag"&&t.position.x < Screen.width/2.0f)
                {
                    SetAngle(this.defaultAngle);
                }

                if (t.phase == TouchPhase.Ended && tag == "RightFripperTag" && t.position.x >= Screen.width/2.0f)
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
