using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskHandler : MonoBehaviour
{
    // Panel script
    public Image borderImg;
    public Image blackCheckmark;
    public Sprite greenCheckmark;

    [SerializeField]
    TaskManager taskManager;

    [SerializeField]
    int currentActiveObject = 0; //Currently active object, index 0
    
    private void Start()
    {
        SetQuestWindowStatus();
    }

    public void SetQuestWindowStatus()
    {
        // Loop through tasklist
        for (int i = 0; i < taskManager.taskList.Count; i++)
        {
            // set task status
            if (taskManager.taskList[0].questInProgress == false && taskManager.taskList[0].status == Task.TaskStatus.Waiting)
            {
                taskManager.taskList[0].status = Task.TaskStatus.InProgress;
                taskManager.taskList[0].questInProgress = true;
                // Set the index 0 object to activate
                taskManager.taskObject[currentActiveObject].SetActiveStatus(true);
            }
        } 
    }

    /*Finishes the current active task and activates next if not finished*/
    public void TaskFinished()
    {
        for (int i = 0; i < taskManager.taskList.Count; i++)
        {
            if (taskManager.taskList[i].questInProgress == true && taskManager.taskList[i].status == Task.TaskStatus.InProgress)
            {
                taskManager.taskList[i].status = Task.TaskStatus.Complete;
                taskManager.taskList[i].questInProgress = false;
                taskManager.taskList[i].isDone = true;
                taskManager.completedTaskList.Add(taskManager.taskList[i]);
                taskManager.taskList.Remove(taskManager.taskList[i]);
                ActiveObject();
                QuestIsDone();
                ActiveQuest(false);
            }
            else
            {
                for (int j = 0; j < taskManager.taskList.Count; j++)
                {

                    if (taskManager.taskList[0].questInProgress == false && taskManager.taskList[0].status == Task.TaskStatus.Waiting)
                    {
                        taskManager.taskList[0].status = Task.TaskStatus.InProgress;
                        taskManager.taskList[0].questInProgress = true;
                        // Set the index 0 task object to activate
                        taskManager.taskObject[currentActiveObject].SetActiveStatus(true);
                    }
                }
            }
        }
    }

    public void ActiveObject()
    {
        for (int i = 0; i < taskManager.taskObject.Count; i++)
        {
            if (taskManager.taskObject[i] == taskManager.taskObject[currentActiveObject])
            {
                // Set the finished task object to not active
                taskManager.taskObject[currentActiveObject].SetActiveStatus(false);
                // Remove the inactive object
                taskManager.taskObject.Remove(taskManager.taskObject[currentActiveObject]);
            }
        }
    }

    // Set border around active quest
    public void ActiveQuest(bool isActive)
    {
        if (isActive != false)
        {
            borderImg.enabled = true;
        }
        else
        {
            borderImg.enabled = false;
        }
    }

    public void QuestIsDone()
    {
        blackCheckmark.sprite = greenCheckmark;
    }
}
