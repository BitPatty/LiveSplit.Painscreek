using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Painscreek.AutoSplitter
{
  public partial class UserSettings : UserControl
  {
    public bool EnableLoadRemoval { get; set; }
    public bool EnableTimerStart { get; set; }
    public bool EnableFinalSplit { get; set; }

    public UserSettings()
    {
      InitializeComponent();

      // Data bindings
      Checkbox_EnableLoadRemoval.DataBindings.Add("Checked", this, "EnableLoadRemoval", false, DataSourceUpdateMode.OnPropertyChanged);
      Checkbox_EnableTimerStart.DataBindings.Add("Checked", this, "EnableTimerStart", false, DataSourceUpdateMode.OnPropertyChanged);
      Checkbox_EnableFinalSplit.DataBindings.Add("Checked", this, "EnableFinalSplit", false, DataSourceUpdateMode.OnPropertyChanged);
    }

    /// <summary>
    /// Creates the XML configuration node for LiveSplit based on the current configuration
    /// </summary>
    /// <param name="document">The XML document</param>
    /// <returns>The created XML node</returns>
    public XmlNode CreateXMLConfigurationNode(XmlDocument document)
    {
      XmlElement parent = document.CreateElement("Settings");
      parent.AppendChild(ToXMLElement(document, "SchemaVersion", 1));
      parent.AppendChild(ToXMLElement(document, nameof(EnableLoadRemoval), EnableLoadRemoval));
      parent.AppendChild(ToXMLElement(document, nameof(EnableTimerStart), EnableTimerStart));
      parent.AppendChild(ToXMLElement(document, nameof(EnableFinalSplit), EnableFinalSplit));
      return parent;
    }

    /// <summary>
    /// Loads the values from the XML configuration node
    /// </summary>
    /// <param name="settings">The XML node</param>
    public void LoadXMLConfigurationNode(XmlNode settings)
    {
      EnableLoadRemoval = ParseXMLBooleanValue(settings, nameof(EnableLoadRemoval), true);
      EnableTimerStart = ParseXMLBooleanValue(settings, nameof(EnableTimerStart), true);
      EnableFinalSplit = ParseXMLBooleanValue(settings, nameof(EnableFinalSplit), true);
    }

    /// <summary>
    /// Parses the boolean values based on the serialized version of the settings.
    /// </summary>
    private static bool ParseXMLBooleanValue(XmlNode settings, string setting, bool defaultValue)
    {
      return settings[setting] != null
       ? (Boolean.TryParse(settings[setting].InnerText, out bool val) ? val : defaultValue)
       : defaultValue;
    }

    /// <summary>
    /// Returns a serialized version of a setting based on its identifier.
    /// </summary>
    private static XmlElement ToXMLElement<T>(XmlDocument document, string name, T value)
    {
      XmlElement str = document.CreateElement(name);
      str.InnerText = value.ToString();
      return str;
    }

  }
}
