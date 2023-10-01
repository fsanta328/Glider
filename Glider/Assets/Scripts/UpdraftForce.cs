using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdraftForce : MonoBehaviour
{
    public float updraftStrength = 1000f; // Adjust the strength of the updraft force

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");

        // Check if the collider inside the updraft zone is the glider's collider
        // if (other.CompareTag("Glider"))
        {
            Debug.Log("hit glider");
            Rigidbody gliderRb = other.GetComponent<Rigidbody>();

            // Apply the updraft force to the glider in the upward direction
            gliderRb.AddForce(Vector3.up * updraftStrength);
        }
    }
}
