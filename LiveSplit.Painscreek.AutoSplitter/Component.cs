using LiveSplit.Model;
using LiveSplit.Painscreek.MemoryReader;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System.Xml;

namespace LiveSplit.Painscreek.AutoSplitter
{
  public class Component : LogicComponent
  {
    public override string ComponentName => "Painscreek Autosplitter";
    public UserSettings ComponentSettings;

    private readonly GameMemoryReader GameReader = new GameMemoryReader();
    private readonly TimerModel TimerControl;

    public Component(LiveSplitState state)
    {
      ComponentSettings = new UserSettings();

      TimerControl = new TimerModel { CurrentState = state };
      TimerControl.InitializeGameTime();
    }

    public override XmlNode GetSettings(XmlDocument document)
    {
      return ComponentSettings.CreateXMLConfigurationNode(document);
    }

    public override System.Windows.Forms.Control GetSettingsControl(LayoutMode _)
    {
      return ComponentSettings;
    }

    public override void SetSettings(XmlNode settings)
    {
      ComponentSettings.LoadXMLConfigurationNode(settings);
    }

    public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
      if (!ComponentSettings.EnableLoadRemoval) return;

      GameState? gameState = GameReader.RefreshGameState();
      if (!gameState.HasValue) return;

      switch (TimerControl.CurrentState.CurrentPhase)
      {
        // Start the timer in the prologue
        case TimerPhase.NotRunning:
          if (gameState.Value.IsTutorialOn) TimerControl.Start();
          break;
        // Toggle pause and running on loading screens
        case TimerPhase.Running:
        case TimerPhase.Paused:
          if (gameState.Value.IsEndingScene)
          {
            TimerControl.Split();
            break;
          }

          bool shouldTimerBePaused = ShouldPauseTimer(gameState.Value);
          if (TimerControl.CurrentState.IsGameTimePaused == shouldTimerBePaused) break;
          TimerControl.CurrentState.IsGameTimePaused = shouldTimerBePaused;
          break;
        // Don't do anything once the run is done
        case TimerPhase.Ended:
          break;
      }
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

    public override void Dispose()
    {
      GameReader.Dispose();
    }

  }
}
