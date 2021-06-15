using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
   
    // ContainerOfQuests script
    // Managing our quest
    public static TaskManager taskManager;
    public int amoutOfObjects;
    public int amoutOftasks;

    // contains all available quests (questwindows)
    public List<Task> taskList = new List<Task>();

    // contains all completed quests
    public List<Task> completedTaskList = new List<Task>();

    // List of task objects
    public List<TaskObject> taskObject = new List<TaskObject>();

    private void Start()
    {
        // check amount of objects/tasks in game
        amoutOfObjects = GameObject.FindGameObjectsWithTag("Object").Length;
        amoutOftasks = GameObject.FindGameObjectsWithTag("QuestWindow").Length;
    }

}
