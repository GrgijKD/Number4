using System.Text;

namespace Geography
{
    public abstract class GeographicalObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GeographicalObject(double x, double y, string name, string description)
        {
            X = x;
            Y = y;
            Name = name;
            Description = description;
        }

        public virtual string GetInformation()
        {
            return $"Назва: {Name}, Опис: {Description}, Координати: {X}, {Y}";
        }
    }

    public class River : GeographicalObject
    {
        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }

        public River(double x, double y, string name, string description, double flowSpeed, double totalLength)
            : base(x, y, name, description)
        {
            FlowSpeed = flowSpeed;
            TotalLength = totalLength;
        }

        public override string GetInformation()
        {
            return base.GetInformation() + $", Швидкість течії: {FlowSpeed} см/с, Загальна довжина: {TotalLength} км";
        }
    }

    public class Mountain : GeographicalObject
    {
        public double HighestPoint { get; set; }

        public Mountain(double x, double y, string name, string description, double highestPoint)
            : base(x, y, name, description)
        {
            HighestPoint = highestPoint;
        }

        public override string GetInformation()
        {
            return base.GetInformation() + $", Найвища точка: {HighestPoint} м";
        }
    }

    public interface IGeographicalObject
    {
        string GetInformation();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            River river = new River(45.0, 30.0, "Дніпро", "Найбільша річка України", 120, 2201);
            Mountain mountain = new Mountain(48.0, 24.0, "Говерла", "Найвища гора України", 2061);

            Console.WriteLine(river.GetInformation());
            Console.WriteLine(mountain.GetInformation());
        }
    }
}