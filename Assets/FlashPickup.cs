using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPickup : Pickup
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("Flash");
    }

    public void DestroyOnEnd()
    {
        Destroy(this);
    }


}
