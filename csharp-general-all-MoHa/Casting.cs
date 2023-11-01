


namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1:
            // this is upcasting
            // here text and shape point to the same object, but the have different views (different properties available)
            // shape will have less properties available than text
            // text will have more properties available than shape
            Text text = new Text();
            Shape shape = text;
            text.Width = 200;
            shape.Width = 100;
            System.Console.WriteLine(text.Width); // 100, they are pointing to the same object

            // Example 2:
            // int this case, the base class Stream, is the parent class of the class FileStream and MemoryStream (view > Object Explorer)
            // it can be declared like this (using one of the several overloads):
            // StreamReader reader = new StreamReader(new FileStream());
            // StreamReader reader = new StreamReader(new MemoryStream());
            // no need explicit casting
            
            // Example 3:
            // ArrayList is not ideal, because it accepts all types
            var list = new ArrayList();
            list.Add(1);
            list.Add("Jamecho");
            list.Add(new Text());
            // following is a generic list, it prevents to cast, and all members will be Shape type (or int, string, etc)
            var anotherList = new List<Shape>();

            // Example 4:
            // Downcasting
            Shape shape2 = new Text();
            // up here shape2 is a text object, but does not have the text properties
            Text text2 = (Text)shape2;
            // now text2 will have access the text properties

            // Example 5: 
            // Downcasting
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Subexample 1
                // sender will not have access to the bottom properties and methods
                // so need to downcast, to provide access to methods of the bottom class
                // in this case is safe to cast like this, because we are sure that Button_Click comes from Button
                var button = (Button) sender;

                // // Subexample 2
                // using the keyword "as"
                // If we are not sure that Button_Click comes from Button, the use the as keyword
                var button = sender as Button;
                if (button != null)
                {
                    MessageBox.Show(button.ActualHeight.ToString());
                }
                MessageBox.Show("Hallo, Welt!");
            }

        }
    }

    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw()
        {

        }
    }

    public class Text : Shape
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }
    }
}