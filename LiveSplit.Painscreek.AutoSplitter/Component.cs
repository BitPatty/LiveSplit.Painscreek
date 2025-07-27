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
    private readonly MemoryReader.MemoryReader GameMemory = new MemoryReader.MemoryReader();
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

      GameMemory.UpdateGameState();
      GameState? gameState = GameMemory.CurrentGameState;
      if (gameState == null || !gameState.HasValue) return;

      if (!TimerControl.CurrentState.IsGameTimePaused && gameState.Value.LevelLoading)
        TimerControl.CurrentState.IsGameTimePaused = true;
      else if (TimerControl.CurrentState.IsGameTimePaused && !gameState.Value.LevelLoading)
        TimerControl.CurrentState.IsGameTimePaused = false;
    }

    public override void Dispose()
    {
      GameMemory.Dispose();
    }

  }
}
