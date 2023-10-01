using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody gliderRigidbody;

    public Vector3 glideUp;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gliderRigidbody.AddForce(glideUp, ForceMode.Force);
        }
    }
}
