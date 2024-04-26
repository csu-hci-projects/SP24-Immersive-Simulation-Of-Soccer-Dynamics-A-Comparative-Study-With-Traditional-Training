using UnityEngine;

public class Kick : MonoBehaviour
{
    public GameObject soccerBall;
    public GameObject goal;

    public float kickForce = 100f;
    public float minKickInterval = 1f;
    public float maxKickInterval = 3f;

    private float timer = 0f;

    public void Start()
    {
        SetRandomKickInterval();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= minKickInterval)
        {
            KickBall();
            SetRandomKickInterval();
            timer = 0f;
        }
    }

    private float GetRandomKickInterval()
    {
        return Random.Range(minKickInterval, maxKickInterval);
    }

    private void SetRandomKickInterval()
    {
        float randomInterval = GetRandomKickInterval();
        timer = -Random.Range(0f, randomInterval);
    }

    private void KickBall()
    {
        if (soccerBall == null || goal == null)
        {
            Debug.LogError("Soccer ball or goal is not assigned!");
            return;
        }

        GameObject newBall = Instantiate(soccerBall, transform.position, Quaternion.identity);

        // Calculate a random angle within a 30 degree arc on the left side
        float randomAngle = Random.Range(170f, 190f); // 165 to 195 degree arc (left side)
        Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f);

        // Calculate direction vector based on random angle
        Vector3 directionToGoal = randomRotation * transform.forward;

        Rigidbody ballRb = newBall.GetComponent<Rigidbody>();

        if (ballRb != null)
        {
            ballRb.AddForce(directionToGoal * kickForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody not found on the soccer ball!");
        }
    }

}