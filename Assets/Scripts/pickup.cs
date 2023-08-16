using EventChannelSystem;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    [Header("Score Fields")]
    [SerializeField] private int score;
    [SerializeField] private IntEventChannel onPickUpCollect;
    [Header("VFX")]
    [SerializeField] private ParticleSystem coinCollectFX;
    private float _speed;
    // Start is called before the first frame update
    private void Start()
    {
        int sign = Random.value > .5f ? 1 : -1;
        _speed = Random.Range(minSpeed, maxSpeed) * sign;
    }

    private void Update()
    {
        transform.eulerAngles += new Vector3(0f, _speed, 0f) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPickUpCollect.RaiseEvent(score);
            Instantiate(coinCollectFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

