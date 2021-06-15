using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    [SerializeField]
    GameObject questWindow;

    // contains all quest details
    // task status
    public enum TaskStatus { Waiting, InProgress, Complete }
    public TaskStatus status;
    public bool isDone = false;
    public bool questInProgress = false;

    [SerializeField]
    GameObject title;
    [SerializeField]
    GameObject description;
    [SerializeField]
    GameObject taskToDo;

    //public int id;
    //public int nextTaskID; // will hold unlockable id when current id is completed (chain quests)

}
