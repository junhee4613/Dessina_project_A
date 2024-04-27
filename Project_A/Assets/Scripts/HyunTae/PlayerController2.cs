using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    public GameObject GameOver_text;
    public TMP_Text BestScore_text;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    private bool isDie = false;
    private Movement2D movement2D;
    private Weapon weapon;

    private int score;
    public int Score
    {
        // score ���� ������ ���� �ʵ���
        set => score = Mathf.Max(0, value);
        get => score;
    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
    }

    void Start()
    {
        int bestscore = PlayerPrefs.GetInt("TextPlayerBestScore");
        PlayerPrefs.SetInt("TextPlayerBestScore", bestscore);
        BestScore_text.text = "Best Score " + bestscore;
    }

    private void Update()
    {
        // �÷��̾ ��� �ִϸ��̼� ��� ���� �� �̵�, ������ �Ұ����ϰ� ����
        if (isDie == true) return;

        // ���� Ű�� ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        // ���� Ű�� Down/Up���� ���� ����/����
        if (Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }

    }

    private void LateUpdate()
    {
        // �÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϵ��� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void OnDie()
    {
        // ���� ����
        weapon.StopFiring();
        // �̵� ���� �ʱ�ȭ
        movement2D.MoveTo(Vector3.zero);
        // ����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());

        Destroy(GetComponent<MeshRenderer>());

        //gameObject.SetActive(false);

        // ��� �� Ű �÷��̾� ���� ���� ���� ���ϰ� �ϴ� ����
        isDie = true;
        int bestscore = PlayerPrefs.GetInt("TextPlayerBestScore");

        if (bestscore < Score)
        {
            bestscore = Score;
            PlayerPrefs.SetInt("TextPlayerBestScore", bestscore);
        }
        BestScore_text.text = "Best Score " + bestscore;
        GameOver_text.SetActive(true);
        
    }


    public void OnDieEvent()
    {
        // ����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        
    }
}


/*
 * File : PlayerController.cs
 * Desc
 *	: �÷��̾� ĳ���Ϳ� �����ؼ� ���
 *	
 * Functions
 *	: OnDie() - �÷��̾� ��� �� ȣ���ϴ� �Լ�
 *	: OnDieEvent() - ��� �ִϸ��̼� ��� ���� ȣ���ϴ� �Լ�
 */