using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] List<GameObject> Items;
    public int LivesLeft { get; private set; }
    public float Time { get; private set; }
    public float SpeedMax { get; private set; }
    public int Points { get; private set; }
    public int Damage { get; private set; }
    public bool IsOn { get; private set; }
    public float DistanceToTarget { get; private set; }
    public bool IsNight { get; private set; }

    private GameObject ItemsContainer;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        ItemsContainer = GameObject.Find("ItemsContainer");
        LivesLeft = 3;
        Time = 0;
        SpeedMax = 5.0f;
        Points = 0;
        Damage = 0;
        IsOn = false;
        DistanceToTarget = 0.0f;
        IsNight = false;

        InvokeRepeating("SpawnerLoop", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Time += UnityEngine.Time.deltaTime;
    }

    void SpawnerLoop()
    {
        if (ItemsContainer != null)
        {
            int seed = System.Environment.TickCount;
            Random.InitState(seed);
            float max_pos_x = 4.0f;
            float min_pos_x = -4.0f;
            float max_pos_y = 3.0f;
            Vector2 pos = new Vector2(Random.Range(min_pos_x, max_pos_x), max_pos_y);
            int item = Random.Range(0, Items.Count - 1);

            GameObject newItem = Instantiate(Items[item]);
            newItem.transform.SetParent(ItemsContainer.transform);
            newItem.transform.position = pos;
            newItem.GetComponent<Item>().MaxSpeed = SpeedMax;
        }
    }
}
