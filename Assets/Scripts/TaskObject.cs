using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskObject : MonoBehaviour
{
    [SerializeField]
    // Object used in this task
    GameObject otherGameObject;
    [SerializeField]
    // Handler to confirm/continue to next task
    TaskHandler taskHandler;


    [SerializeField]
    TaskManager taskManager;

    [SerializeField]
    int currentActiveObject = 0;


    [SerializeField]
    // If this task is activated
    bool isActive = false;
    
    public void SetActiveStatus(bool newStatus)
    {
        isActive = newStatus;
        taskHandler.ActiveQuest(isActive);
    }

    // If the chosen object collide
    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject == otherGameObject)
            {
                Debug.Log("Task completed!!");
                taskHandler.TaskFinished();
            }
        }
    }
}
