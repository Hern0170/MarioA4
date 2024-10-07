using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : Pickup
{

    private Vector2 velocity;
    private Animator animator;
    private bool IsFlipped = false;

    public bool isFlipped
    { 
        get { return isFlipped; }
        set { IsFlipped = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pickupType = EPickupType.Coin;
        animator.Play("CoinPickup");
    }
    private void Update()
    {
        StopAnim();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pickupState == EPickupState.Active)
        {
            if (other.gameObject.CompareTag("World") || other.gameObject.CompareTag("Enemy"))
            {
                ContactFilter2D filter = new ContactFilter2D().NoFilter();
                List<Collider2D> results = new List<Collider2D>();
                other.OverlapCollider(filter, results);
            }
        }
    }

    public void StopAnim()
    {

        if (!IsFlipped)
        {
            animator.speed = 1;
        }
        else
        {
            //animator.Play("Coin",0,1);
            animator.speed = 0;

        }
    }
}
