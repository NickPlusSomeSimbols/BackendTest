using BackendTest.DAL.Interfaces;
using BackendTest.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackendTest.BLL.DataProcessing
{
    public class ImageProcessor
    {
        private List<IImagePlugin> _plugins;

        public ImageProcessor()
        {
            _plugins = new List<IImagePlugin>();
        }

        public void AddPlugin(IImagePlugin plugin)
        {
            _plugins.Add(plugin);
        }

        public void RemovePlugin(string pluginName)
        {
            _plugins.RemoveAll(p => p.Name == pluginName);
        }

        public void ProcessImage(ref Image image, List<(string pluginName, object[] parameters)> operations)
        {
            foreach (var operation in operations)
            {
                var plugin = _plugins.FirstOrDefault(p => p.Name == operation.pluginName);
                if (plugin != null)
                {
                    plugin.Apply(ref image, operation.parameters);
                }
            }
        }
    }
}