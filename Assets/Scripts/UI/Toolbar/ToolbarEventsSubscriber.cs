using UnityEngine;

public class ToolbarEventsSubscriber : EventsSubscriber
{
    [SerializeField] private Toolbar toolbar;

    // Refresh Screen?
    private void Events_ChangeCurrentScreen(object sender, ToolbarEvents.ChangeCurrentScreenEventArgs e)
    {
        toolbar.SetCurrentScreen(e.screen);
    }

    protected override void SubscribeToEvents()
    {
        ToolbarEvents.ChangeCurrentScreen += Events_ChangeCurrentScreen;
    }

    protected override void UnsubscribeToEvents()
    {
        ToolbarEvents.ChangeCurrentScreen -= Events_ChangeCurrentScreen;
    }
}
