using LiveSplit.Model;
using LiveSplit.Painscreek.MemoryReader;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System.Diagnostics;
using System.Timers;

//using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Painscreek.AutoSplitter
{
  public class Component : LogicComponent
  {
    public override string ComponentName => "Painscreek Autosplitter";
    public UserSettings ComponentSettings;

    private readonly GameMemoryReader GameReader = new GameMemoryReader();
    private readonly TimerModel TimerControl;
    private readonly Timer MemoryUpdateTimer;

    private bool WasUpdateCalled = false;
    private GameState? previousGameState = null;

    public Component(LiveSplitState state)
    {
      ComponentSettings = new UserSettings();
      TimerControl = new TimerModel { CurrentState = state };
      TimerControl.InitializeGameTime();
      MemoryUpdateTimer = new Timer() { Interval = 15, Enabled = true };
    }

    /// <summary>
    /// Called by LiveSplit when requesting the current settings for saving
    /// </summary>
    /// <param name="document">The document</param>
    /// <returns>The component configuration node</returns>
    public override XmlNode GetSettings(XmlDocument document)
    {
      return ComponentSettings.CreateXMLConfigurationNode(document);
    }

    /// <summary>
    /// Called by LiveSplit when the user is requesting the configuration panel
    /// </summary>
    /// <param name="_">The current layout mode</param>
    /// <returns>The configuration panel</returns>
    public override System.Windows.Forms.Control GetSettingsControl(LayoutMode _)
    {
      return ComponentSettings;
    }

    /// <summary>
    /// Called by LiveSplit on initialization, provides the saved user settings
    /// </summary>
    /// <param name="settings">The saved settings</param>
    public override void SetSettings(XmlNode settings)
    {
      ComponentSettings.LoadXMLConfigurationNode(settings);
    }

    /// <summary>
    /// Called by LiveSplit on each update cycle
    /// </summary>
    /// <param name="invalidator">The renderinvalidator</param>
    /// <param name="state">The current LiveSplit state</param>
    /// <param name="width">The component width</param>
    /// <param name="height">The component height</param>
    /// <param name="mode">The current LiveSplit layout mode</param>
    public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
      // Initialize the update timer
      if (!WasUpdateCalled)
      {
        WasUpdateCalled = true;
        MemoryUpdateTimer.Elapsed += MemoryUpdateTimerEventHandler;
      }

      GameState? gameState = GameReader.GetLastState();
      if (!gameState.HasValue)
      {
        previousGameState = gameState;
        return;
      }

      switch (TimerControl.CurrentState.CurrentPhase)
      {
        // Start the timer in the prologue
        case TimerPhase.NotRunning:
          if (!ComponentSettings.EnableTimerStart) break;
          if (gameState.Value.IsTutorialOn) TimerControl.Start();
          break;
        // Toggle pause and running on loading screens
        case TimerPhase.Running:
        case TimerPhase.Paused:
          if (gameState.Value.IsEndingScene)
          {
            if (!ComponentSettings.EnableFinalSplit) break;
            TimerControl.Split();
            break;
          }

          if (!ComponentSettings.EnableLoadRemoval) break;
          bool shouldTimerBePaused = ShouldPauseTimer(gameState.Value);
          if (TimerControl.CurrentState.IsGameTimePaused == shouldTimerBePaused) break;
          TimerControl.CurrentState.IsGameTimePaused = shouldTimerBePaused;
          break;
        // Don't do anything once the run is done
        case TimerPhase.Ended:
          break;
      }

      previousGameState = gameState;
    }

    /// <summary>
    /// Determines whether the game timer should be paused based on the game's state
    /// </summary>
    /// <param name="gameState">The game state</param>
    /// <returns>True if it should be paused</returns>
    private bool ShouldPauseTimer(GameState gameState)
    {
      // Note: Flashlight is disabled in start menu
      if (gameState.IsStartMenu) return false;

      // The flashlight is enabled before fade-in on playable scenes
      // It is always disabled on loading screens
      if (gameState.IsFlashlightComponentDisabled && gameState.IsInSceneTransition) return true;

      return false;
    }

    /// <summary>
    /// Updates the game state from memory
    /// </summary>
    /// <param name="sender">The event sender</param>
    /// <param name="eventArgs">The event arguments</param>
    private void MemoryUpdateTimerEventHandler(object sender, ElapsedEventArgs eventArgs)
    {
      try
      {
        Debug.WriteLine("Refreshing game state");
        var updatedState = GameReader.RefreshGameState();

        if (!updatedState.HasValue)
          Debug.WriteLine("Could not read game data");

        Debug.WriteLine("Refresh completed");
      }
      catch { }
    }

    /// <summary>
    /// Disposes the component
    /// </summary>
    public override void Dispose()
    {
      MemoryUpdateTimer.Enabled = false;
      GameReader.Dispose();
      MemoryUpdateTimer.Dispose();
    }
  }
}
