using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PSwitchState : byte
{
    Active,
    Inactive
}
public class PSwitchPickup : Pickup
{
    protected PSwitchState switchState;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = false;

        pickupType = EPickupType.PSwitch;
        switchState = PSwitchState.Inactive;
        Animator animator = GetComponent<Animator>();
        animator.Play("P-SwitchOn");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mario")) // Asegúrate que el tag de Mario está correctamente asignado
        {
            Vector2 normal = collision.GetContact(0).normal;
            if (normal.y  < -0.9f && switchState != PSwitchState.Active) // Aproximadamente desde arriba
            {
                ActivateSwitch();
            }
        }
    }

    public void ActivateSwitch()
    {
        switchState = PSwitchState.Active;
        Animator animator = GetComponent<Animator>();
        animator.Play("P-SwitchOff");
        GetComponent<Collider2D>().isTrigger = true;
        Game.Instance.ActivatePSwitchEffect();
    }

}
