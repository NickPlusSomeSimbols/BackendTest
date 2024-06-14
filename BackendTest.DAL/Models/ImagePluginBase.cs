using BackendTest.DAL.Interfaces;

namespace BackendTest.DAL.Models
{
    public abstract class ImagePluginBase : IImagePlugin
    {
        public abstract string Name { get; }
        public abstract void Apply(ref Image image, params object[] parameters);
    }
}
