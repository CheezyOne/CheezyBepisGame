using UnityEngine;
public class ClicksRegister : MonoBehaviour
{
    [SerializeField] private float _repelRadius = 5f, _repelForce = 10f;
    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 clickPosition3D = new Vector3(clickPosition.x, clickPosition.y, 0);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(clickPosition, _repelRadius);

            foreach (Collider2D collider in colliders)
            {
                Vector3 Distance = collider.transform.position - clickPosition3D;
                float DistanceFloat = Vector3.Distance(collider.transform.position, clickPosition3D);
                //DistanceFloat = Mathf.Clamp01(DistanceFloat);
                Vector2 repelDirection = Distance.normalized;
                if (collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D ColliderRigidBody))
                {
                    ColliderRigidBody.AddForce(repelDirection * _repelForce/ DistanceFloat, ForceMode2D.Impulse);
                }
            }
        }
    }
}
