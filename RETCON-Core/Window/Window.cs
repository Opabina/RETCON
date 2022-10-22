using GLFW;
using System.IO;
using static OpenGL.Gl;

namespace RETCON.Core.Window
{
    //TODO: Clean up code and make it more dynamic and implement event support

    public class Window
    {
        private string _title;
        private uint _width;
        private uint _height;

        private GLFW.Window _window = GLFW.Window.None;
        private uint _program = 0;

        public Window(string title, uint width, uint height)
        {
            _title = title;
            _width = width;
            _height = height;
        }

        public static bool Initialize()
        {
            return Glfw.Init();
        }

        public void Destroy()
        {
            if(_window != GLFW.Window.None)
                Glfw.DestroyWindow(_window);
        }

        private static void PrepareContext()
        {
            // Set some common hints for the OpenGL profile creation
            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.Decorated, true);
        }

        public virtual void Render()
        {
            PrepareContext();

            Create();
            CreateProgram();

            // Define Triangle
            CreateVertices(out var vao, out var vbo);

            var location = glGetUniformLocation(_program, "color");
            SetRandomColor(location);

            while(!Glfw.WindowShouldClose(_window))
            {
                Glfw.SwapBuffers(_window);
                Glfw.PollEvents();

                glClear(GL_COLOR_BUFFER_BIT);

                glDrawArrays(GL_TRIANGLES, 0, 4);
            }

            Glfw.Terminate();
        }

        public virtual void Create()
        {
            _window = Glfw.CreateWindow((int)_width, (int)_height, _title, GLFW.Monitor.None, GLFW.Window.None);
            Glfw.MakeContextCurrent(_window);
            Import(Glfw.GetProcAddress);

            // Center window
            var screen = Glfw.PrimaryMonitor.WorkArea;
            var x = (screen.Width - (int)_width) / 2;
            var y = (screen.Height - (int)_height) / 2;
            Glfw.SetWindowPosition(_window, x, y);
        }

        public virtual void CreateProgram()
        {
            var vertex = CreateShader(GL_VERTEX_SHADER, File.ReadAllText("./Shaders/triangle.vert"));
            var fragment = CreateShader(GL_FRAGMENT_SHADER, File.ReadAllText("./Shaders/triangle.frag"));

            _program = glCreateProgram();
            glAttachShader(_program, vertex);
            glAttachShader(_program, fragment);

            glLinkProgram(_program);

            glDeleteShader(vertex);
            glDeleteShader(fragment);

            glUseProgram(_program);
        }

        private static uint CreateShader(int type, string source)
        {
            var shader = glCreateShader(type);
            glShaderSource(shader, source);
            glCompileShader(shader);
            return shader;
        }

        public static void Terminate()
        {
            Glfw.Terminate();
        }

        public virtual void KeyCallback(GLFW.Window window, Keys key, int scancode, InputState state, ModifierKeys mods)
        {
            switch (key)
            {
                case Keys.Escape:
                    Glfw.SetWindowShouldClose(_window, true);
                    break;
            }
        }

        private static unsafe void CreateVertices(out uint vao, out uint vbo)
        {
            var vertices = new[] {
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                0.0f,  0.5f, 0.0f,
                0.5f,  0.5f, 0.0f,
            };

            vao = glGenVertexArray();
            vbo = glGenBuffer();

            glBindVertexArray(vao);

            glBindBuffer(GL_ARRAY_BUFFER, vbo);
            fixed (float* v = &vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 3, GL_FLOAT, false, 3 * sizeof(float), NULL);
            glEnableVertexAttribArray(0);
        }

        static System.Random rand = new System.Random();
        private static void SetRandomColor(int location)
        {
            var r = (float)rand.NextDouble();
            var g = (float)rand.NextDouble();
            var b = (float)rand.NextDouble();
            glUniform3f(location, r, g, b);
        }
    }
}
