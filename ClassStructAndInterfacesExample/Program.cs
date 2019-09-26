using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructAndInterfacesExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var quad2 = new Quad(4)
            {
                Gas = 10.3,
                Id = 1
            };

            var quad = new Quad(4)
            {
                Gas = 10.3,
                Id = 1
            };

            if(quad2 == quad)
            {

            }

            var motocross = new Motocross(2);

            var bmx = new BMX(3);

            motocross.ChangeWheels(2);
            quad.ChangeWheels(5);
            bmx.ChangeWheels(2);
                                
            Console.ReadKey();
        }

        static void DoAcrobats(IAcrobatics v)
        {
            v.Acrobate();
        }
    }

    public class Motocross : Vehiculo, IAcrobatics
    {
        public Motocross(int wheels) : base(wheels)
        {
            base.Wheels = wheels;
        }

        public void Acrobate()
        {
            
        }
    }

    public class BMX : Vehiculo, IAcrobatics
    {
        public BMX(int wheels) : base(wheels)
        {
        }

        public void Acrobate()
        {

        }

        public override void ChangeWheels(int wheels)
        {
            Wheels = 4;
        }
    }

    public class Quad : Vehiculo
    {
        public Quad(int wheels) : base(wheels)
        {
        }

        public override void ChangeWheels(int wheels)
        {
            if(wheels > 4)
            {
                throw new Exception("Wheels must be greater than 4");
            }
            base.ChangeWheels(wheels);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Gas.GetHashCode();
        }
    }

    public abstract class Vehiculo
    {
        public Vehiculo(int wheels)
        {
            Wheels = wheels;
        }

        public virtual void ChangeWheels(int wheels)
        {
            Wheels = wheels + 1;
        }

        public int Id { get; set; }

        public int Wheels { get; protected set; }

        public double Gas { get; set; }

        public Location LocationGps { get; set; }
    }

    public interface IAcrobatics
    {
        void Acrobate();
    }

    public struct Location
    {        
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    
}
