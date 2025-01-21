using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    public void goTitle()
    {
        StageManager.sMng.GoToTitle();
    }
    public void goSelect()
    {
        StageManager.sMng.GoToSelect();
    }
    public void goStage(int stage)
    {
        StageManager.sMng.GoToStage(stage);
    }
    public void goSuccess()
    {
        StageManager.sMng.GoToSuccess();
    }
    public void goFail()
    {
        StageManager.sMng.GoToFail();
    }
    public void goRetry()
    {
        StageManager.sMng.Retry();
    }

}
