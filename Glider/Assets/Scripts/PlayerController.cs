using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody gliderRigidbody;

    public Vector3 glideUp;

    public delegate void KeyCodePressed(KeyCode keyCode);
    public event KeyCodePressed OnKeyCodePress;

    public void Update()
    {
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
    }
}
