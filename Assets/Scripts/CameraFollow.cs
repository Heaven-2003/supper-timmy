using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public bool follow;
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [Header("Smooth Factors")]
        [SerializeField] private float smoothFactor;

        private void OnValidate()
        {
            FollowTarget(false);
            LookTarget(false);
        }

        private void FixedUpdate()
        {
            if (follow)
            {
                FollowTarget(true);
                LookTarget(true);
            }
        }

        private void LookTarget(bool smooth)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookTarget = Quaternion.LookRotation(dir, Vector3.up);
            if (smooth)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * smoothFactor);
            }
            else
            {
                transform.rotation = lookTarget;
            }
        }

        private void FollowTarget(bool smooth)
        {
            Vector3 targetPos = target.position + offset;
            if (smooth)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothFactor);
            }
            else
            {
                transform.position = targetPos;
            }
        }

    }
}