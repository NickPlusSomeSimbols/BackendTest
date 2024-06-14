using System;
using System.Collections.Generic;
using System.Linq;
using BackendTest.BLL.DataProcessing;
using BackendTest.DAL.Models;

public class Program
{
    static void Main(string[] args)
    {
        var pluginManager = new PluginManager();
        pluginManager.LoadPlugins();

        var imageProcessor = new ImageProcessor();
        imageProcessor.AddPlugin(pluginManager.GetPlugin("Resize"));
        imageProcessor.AddPlugin(pluginManager.GetPlugin("Blur"));

        while (true)
        {
            // Request image file path
            Console.WriteLine("Please enter the file path of the image (or type 'exit' to quit):");
            string filePath = Console.ReadLine();

            if (filePath.ToLower() == "exit")
            {
                break;
            }

            // Load the image
            Image image;
            try
            {
                image = new Image(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load image: {ex.Message}");
                continue;
            }

            // Define operations
            var operations = new List<(string, object[])>();

            while (true)
            {
                var availableOperations = pluginManager.GetAvailablePluginNames();
                Console.WriteLine($"Enter operation name and parameters (available operations: {string.Join(", ", availableOperations)}), or type 'process' to apply operations:");
                string input = Console.ReadLine();

                if (input.ToLower() == "process")
                {
                    break;
                }

                var parts = input.Split(' ');
                string operationName = parts[0];
                var plugin = pluginManager.GetPlugin(operationName);

                if (plugin == null)
                {
                    Console.WriteLine("Invalid operation name. Please try again.");
                    continue;
                }

                if (operations.Any(op => op.Item1 == operationName))
                {
                    Console.WriteLine("Operation already added. Please choose a different operation.");
                    continue;
                }

                object[] parameters = parts.Skip(1).ToArray();

                operations.Add((operationName, parameters));
            }

            // Process the image
            imageProcessor.ProcessImage(ref image, operations);

            Console.WriteLine($"Image processing completed. (Processed image name: {image.FilePath})");
        }
    }
}
