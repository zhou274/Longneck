


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCamera;
    public float TouchSpeed,speed;
    public bool isStart,isfinish;
    public int count;
    public GameObject Finger,Nail;
    public GameObject[] PlayerPos;
    public int  _PlayerPos;

    public GameObject PlayerHead;
    public GameObject PlayerHeadTop;
    public GameObject PlayerBody;
    public GameObject Player;
    public ParticleSystem RingPicParticle;
    public List<GameObject> childObjects = new List<GameObject>();

    public Animator PlayerAnim;
    public Animator FlyAnim;
    public Animator Finish_x1_0_Anim;
    public Animator Finish_x1_1_Anim,Finish_x1_2_Anim,Finish_x1_3_Anim;
     public int childcount;
     public TextMeshProUGUI ringCountTxt;
     public TextMeshProUGUI HeightCountTxt;
     public TextMeshPro TotalHeightTxt;
     public GameObject TotalHeight;
     public GameObject HeightCount;
     public GameObject ringBreakAnim;
     public GameObject[] ringBreak;


    public static playerMove _playerMove;

    public float minX = -15.3f;
    public float maxX = 15.3f;

    public GameObject PopPanel;
    public void Awake()
    {
        _playerMove=this;
    }
    void Start()
    {
        Time.timeScale=1;
        RingPicParticle.Stop();
        Finish_x1_0_Anim.enabled=false;
        Finish_x1_1_Anim.enabled=false;
        Finish_x1_2_Anim.enabled=false;
        Finish_x1_3_Anim.enabled=false;
        count=0;
        isfinish=false;
        isStart=false;
        //TouchSpeed=0.01f;
      
      
      
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStart && PopPanel.activeSelf==false)
        {
            isStart = true;
            uicontrol._uicontrol.Tap.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -15.3f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 15.3f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 只在滑动阶段处理移动
            if (touch.phase == TouchPhase.Moved)
            {
                // 计算目标位置（先限制再移动）
                float deltaX = touch.deltaPosition.x * TouchSpeed * Time.deltaTime;
                float newX = transform.position.x + deltaX;

                // 直接限制目标位置，避免越界
                newX = Mathf.Clamp(newX, minX, maxX);

                // 应用位置
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
        //touch
        //if (Input.touchCount > 0 && transform.position.x >= -15.3f && transform.position.x <= 15.3f)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    transform.Translate(touch.deltaPosition.x * TouchSpeed, 0, 0);
        //}
        //else if (transform.position.x > 15.3f)
        //{
        //    transform.position = new Vector3(15.25f, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x < -15.3f)
        //{
        //    transform.position = new Vector3(-15.25f, transform.position.y, transform.position.z);

        //}
        if (isStart && !isfinish)
        {
            PlayerAnim.SetBool("isWalk", true);
            PlayerMov();


        }
        if (isfinish)
        {
            //  if(isfinish && isStart)

            //  StartCoroutine(uicontrol._uicontrol.WinPanel());
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerPos[_PlayerPos].transform.position, speed * Time.deltaTime);
            }
        }
        // Debug.Log("PlayerHead.transform.position"+PlayerHead.transform.position);


    }
    public void PlayerMov()
    {

       transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
   
    
      public void Lose()
      {
            Debug.Log("lose");

           StartCoroutine(uicontrol._uicontrol.LosePanel());
      }
       public void NailCut()
      {

            
           
            Nail.SetActive(true);
            
            Nail.transform.position= new Vector3(this.transform.position.x,this.transform.position.y+10,this.transform.position.z+20);
           

      }
    
}
