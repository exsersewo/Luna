using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Windowing
{
    public class WindowManager
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private static List<RenderWindow> windows = new List<RenderWindow>();
#pragma warning restore IDE0044 // Add readonly modifier
        public static IReadOnlyList<RenderWindow> Windows { get => windows.AsReadOnly(); }

        public static RenderWindow AddWindow(string title, VideoMode videoMode, Styles style)
        {
            var window = new RenderWindow(videoMode, title, style);
            windows.Add(window);
            return window;
        }

        public static void ReplaceWindow(Window window, string title, VideoMode videoMode, Styles style)
        {
            var oldwindow = windows.Find(x => x == window);

            var newwindow = new RenderWindow(videoMode, title, style);

            windows[windows.IndexOf(oldwindow)] = newwindow;

            oldwindow.Dispose();
        }

        public static void RemoveWindow(RenderWindow window)
            => windows.Remove(window);

        public static void RemoveWindow(int window)
            => windows.RemoveAt(window);

        public static void Dispose()
        {
            foreach(var window in windows)
            {
                window.Dispose();
            }
        }
    }
}
