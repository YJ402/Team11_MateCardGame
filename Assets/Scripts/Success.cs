using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class Success : MonoBehaviour
{
    GameManager GM;
    public Image[] image;
    public Sprite[] img;
    public string[] sprite;
    public TMP_Text tmp;
    public int CardIndex { get; private set; }
    public int Stage { get; private set; }
    private string[] names = { "강영준", "김상현", "정순원", "정승제", "정성욱", "염기용" };

    void Start()
    {
        GM = GameManager.Instance;
        stage(Stage);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void stage(int Stage)
    {

        Stage = GM.stageNum;
        tmp.text = names[Stage - 1];
        for (int i = 0; i < image.Length; i++)
        {
            Sprite Load = Resources.Load<Sprite>($"Stage{Stage}/img{i}");
            if (Load != null)
            {
                image[i].sprite = Load;
            }
        }
    }
}