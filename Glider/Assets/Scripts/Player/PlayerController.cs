using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody gliderRigidbody;

    public Vector3 glideUp;
    [Tooltip("Determines the pitch angle when point the front of the glider towards the ground.")]
    public Vector3 pitchToGround;

    //m_EulerAngleVelocity = new Vector3(0, 0, 100);
    protected float yDirection;
    protected bool isGrounded = false;

    public delegate void KeyCodePressed(KeyCode keyCode);
    public event KeyCodePressed OnKeyCodePress;

    public void Update()
    {
        Debug.Log($"smooth ={yDirection}");
        Debug.Log($"raw ={Input.GetAxisRaw("Vertical")}");
        if (Input.GetKey(KeyCode.Space))
        {
            gliderRigidbody.AddForce(glideUp, ForceMode.Force);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            // reset glider to spawn
            if (OnKeyCodePress != null)
            {
                OnKeyCodePress(KeyCode.R);
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            // release the glider from start
            if (OnKeyCodePress != null)
            {
                OnKeyCodePress(KeyCode.Mouse0);
            }
        }
        else if (Input.GetButton("Vertical"))
        {
            yDirection = Input.GetAxis("Vertical");
            if (yDirection < 0)
            {
                TiltToSky();
            }
            else if (yDirection > 0)
            {
                TiltToGround();
            }
        }
        //else if (Input.GetButton("down"))
        //{
        //    TiltToSky();
        //}
    }

    /// <summary>
    /// Not exactly neutral as 0 rotation but the default glide rotation the glider will go towards.
    /// </summary>
    public void TiltToNeutral()
    {

    }

    public void TiltToGround()
    {
        Quaternion deltaRotation = Quaternion.Euler(-pitchToGround * Time.fixedDeltaTime);
        gliderRigidbody.MoveRotation(gliderRigidbody.rotation * deltaRotation);
    }

    public void TiltToSky()
    {
        Quaternion deltaRotation = Quaternion.Euler(pitchToGround * Time.fixedDeltaTime);
        gliderRigidbody.MoveRotation(gliderRigidbody.rotation * deltaRotation);
    }
}
