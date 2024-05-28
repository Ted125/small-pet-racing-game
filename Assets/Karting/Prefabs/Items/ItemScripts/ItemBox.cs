using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public class ItemBox : MonoBehaviour
    {
        private MeshRenderer m_mesh;
        private Collider m_collider;

        private void Start()
        {
            m_mesh = GetComponent<MeshRenderer>();
            m_collider = GetComponent<Collider>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                other.gameObject.GetComponentInParent<PlayerItems>().SetRandomHeldItem();
                StartCoroutine(OnHitRoutine());
            }
        }

        private IEnumerator OnHitRoutine()
        {
            TurnOff();
            yield return new WaitForSeconds(5f);
            TurnOn();
        }

        private void TurnOff()
        {
            m_mesh.enabled = false;
            m_collider.enabled = false;
        }

        private void TurnOn()
        {
            m_mesh.enabled = true;
            m_collider.enabled = true;
        }
    }

    

}
