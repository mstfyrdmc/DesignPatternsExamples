using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultitonDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Her marka için tek bir ID verdi.Parametreye göre instance üretti.1-2 ve 3-4 instanceları aynı çıktı.
            //2
            Camera camera = Camera.GetCamera("NICON");
            Camera camera2 = Camera.GetCamera("NICON");
            Camera camera3 = Camera.GetCamera("CANON");
            Camera camera4 = Camera.GetCamera("CANON");

            Console.WriteLine(camera.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            Console.ReadLine();
            //
        }
    }

    //1
    class Camera
    {
        //birden fazla instance olacağı için dictionary'de tutuyoruz.
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }

        public Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
    //
}
