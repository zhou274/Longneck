


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPicUp : MonoBehaviour
{
    // Start is called before the first frame update
    public float ringCount;
    public GameObject ringCountAnim;
    
    public static RingPicUp _RingPicUp;
    public void Awake()
    {
      _RingPicUp=this;
    }
    void Start()
    {
        ringCountAnim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Rotate(0, 100*Time.deltaTime, 0);
    }
       public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
          
              if ( playerMove._playerMove.PlayerBody.GetComponent<SkinnedMeshRenderer>().material.name == this.gameObject.GetComponent<MeshRenderer>().material.name)
          {
                playerMove._playerMove.childcount++;
           
                // Debug.Log("Child = "+ playerMove._playerMove.childcount); 
                ringCount=ringCount+0.7f;
               
                // CameraPosition

                playerMove._playerMove.MainCamera.transform.position=new Vector3(
                playerMove._playerMove.MainCamera.transform.position.x,
                playerMove._playerMove.MainCamera.transform.position.y+0.3f,
                playerMove._playerMove.MainCamera.transform.position.z-0.3f);

                playerMove._playerMove.childObjects.Add(this.gameObject);
    //  HeadPos
     
                playerMove._playerMove.PlayerHead.transform.position=new Vector3(
                playerMove._playerMove.PlayerHead.transform.position.x,
                playerMove._playerMove.PlayerHead.transform.position.y+ringCount,
                playerMove._playerMove.PlayerHead.transform.position.z);
   
              StartCoroutine(ringCountAnims());
              playerMove._playerMove.RingPicParticle.Play();
     // RingPos
            this.gameObject.transform.Rotate(90, 0, 0);
            this.gameObject.transform.parent= playerMove._playerMove.PlayerHeadTop.transform;
            this.gameObject.transform.position=new Vector3(
            playerMove._playerMove.PlayerHead.transform.position.x,
            playerMove._playerMove.PlayerHead.transform.position.y-ringCount,
            playerMove._playerMove.PlayerHead.transform.position.z);
       // Ring BreakPos
           
            this.gameObject.GetComponent<RingPicUp>().enabled=false;
          }
           else
          {            
                  WrongRingPicUp();
          }
                      playerMove._playerMove.ringCountTxt.text=playerMove._playerMove.childcount.ToString("");
         }

    else
    {
                       playerMove._playerMove.RingPicParticle.Stop();
    }
    }
     public IEnumerator ringCountAnims()
     {

       ringCountAnim.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        ringCountAnim.SetActive(false);
     }
        public IEnumerator ringbreakAnims()
     {
      playerMove._playerMove.ringBreak[0].GetComponent<MeshRenderer>().material=playerMove._playerMove.PlayerHeadTop.transform.GetChild(playerMove._playerMove.childcount+1).GetComponent<MeshRenderer>().material; 
     playerMove._playerMove.ringBreak[1].GetComponent<MeshRenderer>().material=playerMove._playerMove.PlayerHeadTop.transform.GetChild(playerMove._playerMove.childcount+1).GetComponent<MeshRenderer>().material;
       playerMove._playerMove.ringBreakAnim.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        playerMove._playerMove.ringBreakAnim.SetActive(false);
     }
     public void WrongRingPicUp()
     {
        ringCountAnim.SetActive(false);
        if( playerMove._playerMove.childObjects.Count>0)
                  {
                    ringCount=ringCount-0.7f;
                    if( playerMove._playerMove.childcount>0)
                    {
                        playerMove._playerMove.childcount--; 
                        
                    Destroy(playerMove._playerMove.PlayerHeadTop.transform.GetChild(playerMove._playerMove.childcount+1).gameObject);

                    Debug.Log("Child = "+ playerMove._playerMove.childcount); 
                    playerMove._playerMove.ringBreakAnim.transform.position=playerMove._playerMove.PlayerHeadTop.transform.GetChild(playerMove._playerMove.childcount+1).transform.position;
                     
                    StartCoroutine(ringbreakAnims());
                    playerMove._playerMove.PlayerHead.transform.position=new Vector3(
                    playerMove._playerMove.PlayerHead.transform.position.x,
                    playerMove._playerMove.PlayerHead.transform.position.y+ringCount,
                    playerMove._playerMove.PlayerHead.transform.position.z);
                 
                  }
                  } 
     }
}
