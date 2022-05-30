using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSwaper : MonoBehaviour
{
    public RuntimeAnimatorController monstro_anim;
    public RuntimeAnimatorController player_anim;
    public Animator animator;
    private bool isMonster = false;
    // Update is called once per frame
    void Start()
    {
        
        //animator.runtimeAnimatorController = monstro_anim;
        //animator.runtimeAnimatorController = Resources.Load("Assets/Animation/Player.controller") as RuntimeAnimatorController;
    }
    public void Swap()
    {
        if (isMonster)
        {
            animator.runtimeAnimatorController = player_anim;
            isMonster = false;
        }
        else
        {
            animator.runtimeAnimatorController = monstro_anim;
            isMonster = true;
        }
    }
}
