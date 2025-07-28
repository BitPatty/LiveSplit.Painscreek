using LiveSplit.Model;
using LiveSplit.Painscreek.AutoSplitter;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

[assembly: ComponentFactory(typeof(Factory))]

namespace LiveSplit.Painscreek.AutoSplitter
{
  public class Factory : IComponentFactory
  {
    public string ComponentName => "Painscreek Load Remover";
    public string Description => "Load remover for 'The Painscreek Killings'";
    public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    public ComponentCategory Category => ComponentCategory.Control;
    public IComponent Create(LiveSplitState state) => new Component(state);
    public string UpdateName => ComponentName;
    public string XMLURL => "https://raw.githubusercontent.com/BitPatty/LiveSplit.Painscreek/master/update.xml";
    public string UpdateURL => "https://raw.githubusercontent.com/BitPatty/LiveSplit.Painscreek/master/";
  }
}
