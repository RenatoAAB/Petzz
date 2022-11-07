using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private static GameObject bear;
    public static Animator animator;
    private static bool bearInstatiated = false;

    public static AudioSource source;
    public static AudioClip success;
    public static AudioClip fail;

    public static bool IsBearInstantiated(){
        return bearInstatiated;
    }

    public static void instantiatedBear(GameObject bearAux){
        bearInstatiated = true;
        bear = bearAux;
        animator = bear.GetComponent<Animator>();
    }

    public static void OnPlayButtonClick(){
        if(bearInstatiated){
            //source.PlayOneShot(success);
            animator.SetTrigger("Jump");
        }
        else{
           //source.PlayOneShot(fail);
        }
    }

    public static void OnFeedButtonClick(){
        if(bearInstatiated){
           // source.PlayOneShot(success);
            animator.SetTrigger("Attack1");
        }
        else{
           // source.PlayOneShot(fail);
        }
    }


}
