using System.Collections.Generic;
using BackendTest.DAL.Interfaces;

namespace BackendTest.BLL.DataProcessing
{
    public class PluginManager
    {
        private Dictionary<string, IImagePlugin> _availablePlugins;

        public PluginManager()
        {
            _availablePlugins = new Dictionary<string, IImagePlugin>();
        }

        public void LoadPlugins()
        {
            // Plugins loading

            _availablePlugins.Add("Resize", new ResizePlugin());
            _availablePlugins.Add("Blur", new BlurPlugin());
        }

        public IImagePlugin GetPlugin(string pluginName)
        {
            return _availablePlugins.ContainsKey(pluginName) ? _availablePlugins[pluginName] : null;
        }
    }
}