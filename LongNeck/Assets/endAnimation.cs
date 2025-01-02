


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAnimation : MonoBehaviour
{
    // Start is called before the first frame update
        public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody" || other.tag=="head" || other.tag=="ring")
         {
           playerMove._playerMove.Finish_x1_0_Anim.enabled=true;
              playerMove._playerMove.HeightCount.SetActive(true);
              // playerMove._playerMove._PlayerPos=0;
              playerMove._playerMove.HeightCountTxt.text="X1.0";
              // playerMove._playerMove.TotalHeightTxt.text="6.5";
                 
              
              StartCoroutine(HeightCounttext());
           Debug.Log("enter");
         }
    }
     public  IEnumerator HeightCounttext()
     {
       playerMove._playerMove.HeightCount.SetActive(true);
       yield return new WaitForSeconds(4.0f);
      playerMove._playerMove.HeightCount.SetActive(false);
      playerMove._playerMove.TotalHeight.SetActive(true);
     }

}
