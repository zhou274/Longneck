


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
 bool isAdshow=false;
void Start()
{
 
isAdshow=false;
}
         public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
           playerMove._playerMove.Player.GetComponent<Rigidbody>().useGravity =true;
           Debug.Log("end");
             foreach(Transform t in playerMove._playerMove.PlayerHeadTop.transform)
           {
               t.GetComponent<Rigidbody>().useGravity = true;
           
        }
       
        StartCoroutine(LevelFail());
        
        
         }
    }
    public  IEnumerator LevelFail()
    {
       if(!isAdshow)
        {
isAdshow=true;
      Debug.Log("ads");
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(uicontrol._uicontrol.LosePanel());
        }
        // Time.timeScale=0;
    }
}
