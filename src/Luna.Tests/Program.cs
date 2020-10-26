using Luna.Audio;
using Luna.Windowing;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Luna.Tests
{
    public class Program
    {
        static async Task CreateWindowAsync()
        {
            var primaryWindow = WindowManager.AddWindow("Luna", VideoMode.DesktopMode, Styles.Resize);

            CircleShape circle = new CircleShape(5f);

            primaryWindow.KeyReleased += PrimaryWindow_KeyReleased;

            while (primaryWindow.IsOpen)
            {
                primaryWindow.DispatchEvents();

                if (primaryWindow.HasFocus())
                {
                    primaryWindow.Draw(circle, RenderStates.Default);
                }

                primaryWindow.Display();
            }

            circle.Dispose();

            WindowManager.Dispose();

            Console.ReadKey();
        }

        private static void PrimaryWindow_KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                WindowManager.Windows.FirstOrDefault().Close();
        }

        static void Main() => CreateWindowAsync().GetAwaiter().GetResult();
    }
}
