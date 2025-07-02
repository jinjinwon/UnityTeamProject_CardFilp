using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Rtan : MonoBehaviour
{
    [SerializeField] private float speed = 0.4f;

    public void Initialized()
    {
        this.gameObject.SetActive(false);
    }

    public void OnSpawnRtan()
    {
        speed = Random.Range(0.4f, 1.5f);
        RtanReset();
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        Vector3 viewPort = Camera.main.WorldToViewportPoint(transform.position);

        bool isOutView = viewPort.x < -0.05f || viewPort.x > 1.05f || viewPort.y < 0 || viewPort.y > 1 || viewPort.z < 0;

        if (isOutView)
        {
            this.gameObject.SetActive(false);
        }

        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void RtanReset()
    {
        float x = Random.Range(-2.25f, 2.25f);
        transform.position = new Vector3(x, 5f, 0);
    }
}
