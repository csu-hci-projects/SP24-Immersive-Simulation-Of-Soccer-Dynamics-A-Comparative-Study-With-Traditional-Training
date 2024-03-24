using UnityEngine;

public class RandomKickController: MonoBehavior {
    public GameObject soccerBall;
    public GameObject goal;

    public float kickForce = 10f;
    public float minKickInterval = 1f;
    public float maxKickInterval = 3f;

    private float timer = 0f;

    public void Start() {
        setRandomKcikInterval();
    }

    public void Update() {
        timer += Time.deltaTime;
        if (timer >= GetRandomKickInterval())
        {
            KickBall();
            SetRandomKickInterval();  // Set a new random kick interval
            timer = 0f;  // Reset the timer
        }
    }

    float GetRandomKickInterval() {
        // Generate a random kick interval between min and max values
        return Random.Range(minKickInterval, maxKickInterval);
    }

    void SetRandomKickInterval() {
        // Set a new random kick interval
        float randomInterval = GetRandomKickInterval();
        timer = -Random.Range(0f, randomInterval);  // Start timer with a negative value to avoid waiting for the first kick
    }

    void KickBall() {
        // Instantiate a new soccer ball
        GameObject newBall = Instantiate(soccerBall, transform.position, Quaternion.identity);

        // Calculate direction towards the goal
        Vector3 directionToGoal = (goal.transform.position - transform.position).normalized;

        // Apply force to the ball towards the goal
        Rigidbody ballRb = newBall.GetComponent<Rigidbody>();
        if (ballRb != null) {
            ballRb.AddForce(directionToGoal * kickForce, ForceMode.Impulse);
        }
    }
}