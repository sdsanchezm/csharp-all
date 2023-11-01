namespace inheritance
{
    public class PresentationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void Copy()
        {
            Console.WriteLine("Object copied from class Copy()");
        }

        public void Duplicated()
        {
            Console.WriteLine("Object Duplicated from class Duplicated()");
        }
    }
}