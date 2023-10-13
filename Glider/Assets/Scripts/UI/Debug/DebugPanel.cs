using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    public TextMeshProUGUI gliderVelocity;
    public TextMeshProUGUI gliderXSpeed;
    public TextMeshProUGUI gliderYSpeed;
    public TextMeshProUGUI gliderState;
    public TextMeshProUGUI gliderAngle;

    private Rigidbody gliderRigidBody;

    public void AssignGliderRigibody()
    {
        LevelManager levelManager = LevelManager.Instance();
        if (levelManager != null)
        {
            if (levelManager.Glider != null)
            {
                gliderRigidBody = levelManager.Glider.GetComponent<Rigidbody>();
                if (gliderRigidBody == null)
                {
                    Debug.Log("Unable to assign glider rigidbody");
                }
            }
            else
            {
                Debug.LogWarning("No glider assigned");
            }
        }
        else
        {
            Debug.LogWarning("No level manager isntance assigned");
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            if (gameObject.activeInHierarchy)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
    }

    public void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            if (gliderRigidBody == null)
            {
                AssignGliderRigibody();
            }
            else
            {
                if (!gliderRigidBody.IsSleeping())
                    SetGliderText();
                else
                {
                    Debug.Log("Rigibody sleeping");
                }
            }
        }
    }

    private void SetGliderText()
    {
        //Debug.Log($"Normalized = {gliderRigidBody.velocity.normalized}, SQR {gliderRigidBody.velocity.sqrMagnitude}");
        gliderVelocity.text = gliderRigidBody.velocity.magnitude.ToString();
        gliderXSpeed.text = gliderRigidBody.velocity.x.ToString();
        gliderYSpeed.text = gliderRigidBody.velocity.y.ToString();
        gliderAngle.text = gliderRigidBody.transform.rotation.z.ToString() + "º";
    }
}