using Assets.Scripts;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject gliderPrefab;
    public Transform startPosition;
    public Camera gameCamera;

    protected GameObject glider;
    public GameObject Glider { get { return glider; } }

    private static LevelManager instance;

    public static LevelManager Instance()
    {
        return instance;
    }

    public LevelManager()
    {
        instance = this;
    }

    public void Start()
    {
        SpawnGlider();

        if (glider != null && gameCamera != null)
        {
            CameraController camController = gameCamera.GetComponent<CameraController>();
            if (camController != null)
            {
                PlayerController controller = glider.GetComponent<PlayerController>();

                // awful
                camController.targetGlider = controller.gliderRigidbody.gameObject.transform;
            }
        }
    }

    public void SpawnGlider()
    {
        if (glider == null)
        {
            // spawn the glider
            glider = Instantiate(gliderPrefab, startPosition);
            PlayerController controller = glider.GetComponent<PlayerController>();

            // add listener for button press, might be moved later to its own thing
            controller.OnKeyCodePress += OnKeyPressed;
        }
    }

    /// <summary>
    /// handle Key presses
    /// </summary>
    /// <param name="key"></param>
    public void OnKeyPressed(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Mouse0:
                StartLevel();
                break;
            case KeyCode.R:
                RestartGlider();
                break;
        }
    }

    public void RestartGlider()
    {
        if (glider != null)
        {
            PlayerController playerController = glider.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // enable physics for rigidbody
                playerController.gliderRigidbody.isKinematic = true;
                playerController.gliderRigidbody.gameObject.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);// = startPosition;
            }
        }
        else
        {
            Debug.Log("Trying to reset glider when it has not been assigned, spawn glider first.");
        }
    }

    /// <summary>
    /// Used to unlocked the glider for launch/starting position
    /// </summary>
    public void StartLevel()
    {
        if (glider == null)
        {
            Debug.Log("Unable to start level, spawn glider first.");
            return;
        }

        // release glider
        // maybe change to launch the glider or have some gameplay element to control power/angle of launch
        PlayerController playerController = glider.GetComponent<PlayerController>();
        if (playerController != null)
        {
            // enable physics for rigidbody
            playerController.gliderRigidbody.isKinematic = false;
        }    
    }

    public void Reset()
    {
        glider = null;
    }
}
