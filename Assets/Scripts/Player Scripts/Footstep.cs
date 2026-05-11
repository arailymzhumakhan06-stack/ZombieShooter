using UnityEngine;

public class Footstep : MonoBehaviour
{
    [SerializeField] float stepInterval = 0.45f;      // �������� ����� ������
    [SerializeField] float walkSpeedThreshold = 1f;   // ����������� �������� ��� �����
    [SerializeField] float runSpeedThreshold = 5f;    // �������� ��� ����

    private Rigidbody rb;
    private float stepTimer = 0f;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Footstep: Rigidbody not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (rb == null) return;

        // �������� �������������� �������� (��� ������������ ������������)
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        float currentSpeed = horizontalVelocity.magnitude;

        // ���������, �������� �� ����� ���������� ������
        isMoving = currentSpeed > walkSpeedThreshold;

        if (isMoving)
        {
            stepTimer += Time.deltaTime;

            // ������������ ��������: ��������� ��� ������, ���� ��� ����
            float dynamicInterval = stepInterval;
            if (currentSpeed > runSpeedThreshold)
            {
                dynamicInterval = stepInterval * 0.6f; // ��� - ���� ����
            }

            if (stepTimer >= dynamicInterval)
            {
                AudioManager.Instance?.PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; // ���������� ����� �����
        }
    }
}