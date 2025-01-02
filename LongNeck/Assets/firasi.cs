


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firasi : MonoBehaviour
{
     public Animator anim;
     public Texture[] newTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void OnTriggerEnter(Collider other)
    {
         
           if(other.tag=="tirnak_first")
         {   
            anim.SetBool("enter",true);
          }
            if(other.tag=="tirnak" )
            {
                other.GetComponent<Renderer>().material.mainTexture=newTexture[0];
            }
            if(other.tag=="tirnak_0" )
            {
                other.GetComponent<Renderer>().material.mainTexture=newTexture[0];
            }
            
         

     }
       public void OnTriggerExit(Collider other)
    {
         
           if(other.tag=="tirnak_first")
         {

   
       anim.SetBool("enter",false);
       anim.SetBool("exit",false);

          Debug.Log("exit");
          }
     }
}
