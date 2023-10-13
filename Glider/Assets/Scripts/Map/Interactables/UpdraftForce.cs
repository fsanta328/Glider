using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpdraftDirection
{
    Up, Down, Left, Right
}

public class UpdraftForce : MonoBehaviour
{
    public float updraftStrength = 1000f; // Adjust the strength of the updraft force

    public UpdraftDirection direction = UpdraftDirection.Up;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");

        // Check if the collider inside the updraft zone is the glider's collider
        // if (other.CompareTag("Glider"))
        {
            Debug.Log("hit glider");
            Rigidbody gliderRb = other.GetComponent<Rigidbody>();

            // Apply the updraft force to the glider in the upward direction
            gliderRb.AddForce(GetUpdraftVector3() * updraftStrength);
        }
    }

    public Vector3 GetUpdraftVector3()
    {
        switch (direction)
        {
            case UpdraftDirection.Up:
                return Vector3.up;
            case UpdraftDirection.Down:
                return Vector3.down;
            case UpdraftDirection.Left:
                return Vector3.left;
            case UpdraftDirection.Right:
                return Vector3.right;

            default:
                return Vector3.up;
        }
    }
}
