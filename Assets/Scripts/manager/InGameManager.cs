using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static bool StartGame = false;

    public static bool None = false;
    public static bool nextGame = false;

    //public static float kMoster;

    private static InGameManager instance = null;

    public GameObject curPlayer;
    public ParticleSystem healer;
    public GameObject skillAttack;
    public Player player;

    [Header("Skill")]
    public float healMaxDelay = 10f;
    public float bombMaxDelay = 20f;
    float healCurDelay;
    float bombCurDelay;

    public GameObject t;

    public ParticleSystem star;

    [Header("Timer")]
    public float time = 0;
    public static float times = 0;
    public Text Stime;

    [Header("Stage")]
    public static float stages;

    public Text kill;

    public static InGameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        times = 0;
        Player.Lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        NextStage();
        SkillSeting();
        ERRORSKILL();
        timer();
        SetTime();
        Monster();
    }

    public void NextStage()
    {
        if(MonserSpawn.monster >= (MonserSpawn.mSpawn * 2))
        {
            SceneManager.LoadScene("Score");
        }
    }

    void timer()
    {
        if (time > 1)
        {
            times += 1;
            time = 0;
        }
        time += Time.deltaTime;
    }

    public void SkillSeting()
    {
        if (curPlayer == null) return;

        healCurDelay += Time.deltaTime;
        bombCurDelay += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Q) && healCurDelay >= healMaxDelay)
        {
            if (player.hp >= player.MaxHp)
            {
                StartCoroutine(NoHeal());
            }
            else
            {
                Vector3 ptr = player.transform.position;
                player.HpRecover(10);
                Instantiate(healer, new Vector3(ptr.x, ptr.y, ptr.z), Quaternion.Euler(ptr.x + 90, ptr.y, ptr.z));
                healCurDelay = 0f;
            }
        }

        if (Input.GetKey(KeyCode.E) && bombCurDelay >= bombMaxDelay)
        {
            Instantiate(skillAttack, player.transform.position, Quaternion.identity);
            bombCurDelay = 0f;
        }

        Skill.Setskill(1 - healCurDelay / healMaxDelay);
        aSkill.Setskill(1 - bombCurDelay / bombMaxDelay);
    }

    public void ERRORSKILL()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Instantiate(star, new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z), Quaternion.identity);
                }
            }
        }
    }

    public void SetTime()
    {
        Stime.text = string.Format("{0:#,0}", times);
    }

    public void Monster()
    {
        kill.text = string.Format("{0:#,0}", MonserSpawn.monster);
    }

    IEnumerator NoHeal()
    {
        t.SetActive(true);

        yield return new WaitForSeconds(1);

        t.SetActive(false);
        StopCoroutine(NoHeal());
    }
}
