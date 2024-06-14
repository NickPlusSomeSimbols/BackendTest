using BackendTest.DAL.Models;

namespace BackendTest.DAL.Interfaces
{
    public interface IImagePlugin
    {
        string Name { get; }
        void Apply(ref Image image, params object[] parameters);
    }
}