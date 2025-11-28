using UnityEngine;

public class EventsSubscriber : MonoBehaviour
{
    public void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeToEvents();
    }

    protected virtual void SubscribeToEvents()
    {

    }

    protected virtual void UnsubscribeToEvents()
    {

    }
}
