using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static bool StartGame = false;

    public static bool None = false;
    public static bool nextGame = false;

    public static float kMoster;

    private static InGameManager instance = null;

    public GameObject curPlayer;
    public ParticleSystem healer;
    public GameObject skillAttack;
    Player player;

    [Header("Skill")]
    public float healMaxDelay = 10f;
    public float bombMaxDelay = 20f;
    float healCurDelay;
    float bombCurDelay;

    public GameObject t;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kMoster >= MonserSpawn.mSpawn * 2)
        {
            nextGame = true;
        }
        if(nextGame == true)
        {
            nextGame = false;
            SceneManager.LoadScene("InGame2");
        }
        SkillSeting();
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

    IEnumerator NoHeal()
    {
        t.SetActive(true);

        yield return new WaitForSeconds(1);

        t.SetActive(false);
        StopCoroutine(NoHeal());
    }
}
