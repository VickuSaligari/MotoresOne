using UnityEngine;

public class Button : MonoBehaviour, IInteractuable
{
    [SerializeField] TargetsManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Movement player) && PointsManager.Instance.Points <= 200)
        {
            Interact(true);
        }
    }

    public void Interact(bool interacting)
    {
        manager.StartGame();
    }
}