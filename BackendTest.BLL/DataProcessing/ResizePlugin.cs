using BackendTest.DAL.Interfaces;
using BackendTest.DAL.Models;
using System;

namespace BackendTest.BLL.DataProcessing
{
    public class ResizePlugin : ImagePluginBase
    {
        public override string Name => "Resize";

        public override void Apply(ref Image image, params object[] parameters)
        {
            // Simulate resizing the image
            Console.WriteLine("Resizing image to " + parameters[0] + " pixels");
        }
    }

    public class BlurPlugin : ImagePluginBase
    {
        public override string Name => "Blur";

        public override void Apply(ref Image image, params object[] parameters)
        {
            // Simulate blurring the image
            Console.WriteLine("Blurring image with " + parameters[0] + " pixels");
        }
    }
}