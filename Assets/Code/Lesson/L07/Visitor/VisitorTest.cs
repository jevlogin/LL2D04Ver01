using UnityEngine;


namespace JevLogin.Lesson07.Visitor
{
    public sealed class VisitorTest : MonoBehaviour
    {
        public float Damage;
        private Camera _mainCamera;
        private float _deticateDistance = 20.0f;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetButtonDown(AxisManager.FIRE1))
            {
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, _deticateDistance))
                {
                    if (hit.collider.TryGetComponent<Hit>(component: out var damage))
                    {
                        damage.Activate(new ApplyDamage(), Damage);
                        damage.Activate(new ConsoleDisplay(), Damage);
                    }
                }
            }
        }
    }
}