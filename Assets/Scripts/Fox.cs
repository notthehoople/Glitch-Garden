using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        // If the thing we bump into has a Defender component then it's a defender we should attack
        if (otherObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
