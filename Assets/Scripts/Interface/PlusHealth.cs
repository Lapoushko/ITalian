using UnityEngine;
using UnityEngine.UI;

public class PlusHealth : MonoBehaviour
{
    [SerializeField]
    Gradient _gradient;
    Material _myMat;

    [SerializeField] float speedChanged = 0.3f;

    [Header("Parameters Stay")]
    float t;
    public float amp = 2f;
    public float freq = 2;
    public float offset;
    Vector3 startPos;

    void Start()
    {
        this._myMat = gameObject.GetComponent<SpriteRenderer>().material;
        startPos = transform.position;
    }

    void Update()
    {
        this._myMat.color = this._gradient.Evaluate(Mathf.PingPong(Time.time * speedChanged, 1f));
        t = t + Time.deltaTime;
        offset = amp * Mathf.Sin(t * freq);
        transform.position = startPos + new Vector3(0, offset, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) { AudioManager.instance.Play("Powerup"); Destroy(gameObject); }
    }
}