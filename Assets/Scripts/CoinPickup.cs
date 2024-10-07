using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : Pickup
{
    public Collider2D frontTrigger; 
    public Collider2D backTrigger;  
    private Vector2 velocity;
    private bool IsFlipped = true;
    // Start is called before the first frame update
    void Start()
    {
        pickupType = EPickupType.Coin;
        Animator animator = GetComponent<Animator>();
        animator.Play("Coin");
        //animator.speed = 0;
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

                if (results.Contains(frontTrigger))
                {
                    velocity.x = -PickupConstants.MushroomSpeed;
                }
                else if (results.Contains(backTrigger))
                {
                    velocity.x = PickupConstants.MushroomSpeed;
                }
            }
        }
    }

    public void StopAnimation()
    {
        if (!IsFlipped)
        {
            animator.speed = 1;
        }
        else
        {
            animator.Play("Coin",0,frameTime);
            animator.speed = 0;

        }
    }
}
