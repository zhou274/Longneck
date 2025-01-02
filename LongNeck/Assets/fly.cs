


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public GameObject[] OnflyRing;
      public GameObject Onfly;
      public Material _material;
    // Start is called before the first frame update

  
 

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
            
                OnflyRing[0].SetActive(false);
                OnflyRing[1].SetActive(false);
                OnflyRing[2].GetComponent<MeshRenderer>().enabled=true;
                OnflyRing[3].GetComponent<MeshRenderer>().enabled=true;
              
                OnflyRing[2].GetComponent<MeshRenderer>().material=_material;
                OnflyRing[3].GetComponent<MeshRenderer>().material.color=Color.white;
                playerMove._playerMove.PlayerAnim.enabled=false;
                playerMove._playerMove.TouchSpeed=0.0f;
           
             
              StartCoroutine(Animfalse());
              }
        }
       public  IEnumerator Animfalse()
        {
            yield return new WaitForSeconds(5.5f);
            OnflyRing[2].GetComponent<MeshRenderer>().enabled=false;
            OnflyRing[3].GetComponent<MeshRenderer>().enabled=false;
            playerMove._playerMove.Player.transform.parent=null;
            playerMove._playerMove.PlayerAnim.enabled=true;
            playerMove._playerMove.PlayerAnim.SetBool("isWalk",true);
            playerMove._playerMove.TouchSpeed=0.01f;
              //  playerMove._playerMove.PlayerAnim.SetBool("isIdle",false);                // playerMove._playerMove.FlyAnim.SetBool("isfly",false);
        }
}
