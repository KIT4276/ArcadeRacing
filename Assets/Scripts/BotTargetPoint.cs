using UnityEngine;

namespace Racing
{
    public class BotTargetPoint : MonoBehaviour
    {

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 5f);
        }
    }
}
