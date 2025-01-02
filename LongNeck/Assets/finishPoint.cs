


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPoint : MonoBehaviour
{
    // Start is called before the first frame update
      public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody" || other.tag=="head" || other.tag=="ring")
         {
           playerMove._playerMove.isfinish=true;
           Debug.Log("finish");
          StartCoroutine(MoveRotate());
         }
    }
     public  IEnumerator MoveRotate()
     {
        yield return new WaitForSeconds(0.1f);
       for(int i=0;i<playerMove._playerMove.PlayerPos.Length;i++)
       {
         playerMove._playerMove.PlayerPos[i].SetActive(false);
       }


          if(playerMove._playerMove.childcount>10 && playerMove._playerMove.childcount<= 20  )
              {
                playerMove._playerMove._PlayerPos=1;
                playerMove._playerMove.PlayerPos[1].SetActive(true);
                playerMove._playerMove.TotalHeightTxt.text="6.6";
              }
              else if(playerMove._playerMove.childcount> 20 && playerMove._playerMove.childcount<= 30 )
              {
                playerMove._playerMove._PlayerPos=2;
                playerMove._playerMove.PlayerPos[2].SetActive(true);
                playerMove._playerMove.TotalHeightTxt.text="8";
              }
               else if(playerMove._playerMove.childcount>30 && playerMove._playerMove.childcount <=40)
              {
               playerMove._playerMove._PlayerPos=3;
               playerMove._playerMove.PlayerPos[3].SetActive(true);
               playerMove._playerMove.TotalHeightTxt.text="10.5";
              }
             else if(playerMove._playerMove.childcount>40 && playerMove._playerMove.childcount<= 50 )
              {
               playerMove._playerMove._PlayerPos=4;
               playerMove._playerMove.PlayerPos[4].SetActive(true);
               playerMove._playerMove.TotalHeightTxt.text="14";
              }
             else if(playerMove._playerMove.childcount>50 && playerMove._playerMove.childcount<= 60 )
              {
                playerMove._playerMove._PlayerPos=5;
                playerMove._playerMove.PlayerPos[5].SetActive(true);
                playerMove._playerMove.TotalHeightTxt.text="18.5";
              }
              else
              {
                playerMove._playerMove._PlayerPos=0;
                playerMove._playerMove.PlayerPos[0].SetActive(true);
                  playerMove._playerMove.TotalHeightTxt.text="4.8";
              }

      
     }
}
