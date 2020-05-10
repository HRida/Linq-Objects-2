using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Revision
{
    class Employee
    {
        public int ID { get; set; }
        public int Salary { get; set; }
    }
    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class Order
    {
        public int ID { get; set; }
        public string Product { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            linq();
        }
        
        private void linq()
        {
            int[] array1 = { 1, 2, 3, 6, 7, 8 };
            // Example Employee
            Employee[] employees = new Employee[]
	            {
	                new Employee(){ID = 4, Salary = 40000},
	                new Employee(){ID = 0, Salary = 40000},
	                new Employee(){ID = 7, Salary = 60000},
	                new Employee(){ID = 9, Salary = 60000}
	            };
            // Example customers.
            var customers = new Customer[]
	            {
	                new Customer{ID = 5, Name = "Sam"},
	                new Customer{ID = 6, Name = "Dave"},
	                new Customer{ID = 7, Name = "Julia"},
	                new Customer{ID = 8, Name = "Sue"}
	            };
            // Example orders.
            var orders = new Order[]
	            {
	                new Order{ID = 5, Product = "Book"},
	                new Order{ID = 6, Product = "Game"},
	                new Order{ID = 7, Product = "Computer"},
	                new Order{ID = 8, Product = "Shirt"}
	            };

            ///////////////
            // Query expression.
            var elements = from element in array1
                           orderby element descending
                           where element > 2
                           select element;

            foreach(var element in elements){
                Linq1.Content += element.ToString()+"\n" ;
            }

            // Use orderby, orderby ascending, and orderby descending.
            var result2 = from element in array1
                          orderby element descending //or ascending
                          select element;

            //average
            Linq1.Content += "Average =" + array1.Average().ToString();
            /////////////


            ///////////////////
            // Highest salaries first.    // Lowest IDs first.
            var result = from em in employees
                         orderby em.ID ascending, em.Salary descending
                         select em;

            foreach (var r in result)
            {
                Linq2.Content += r.ID + " " + r.Salary + "\n";
            }
            ///////////////


            

            //////////////
            // Group elements by IsEven.
            var result3 = from element in array1
                         orderby element
                         group element by IsEven(element);
            // Loop over groups.
            foreach (var group in result3)
            {
                // Display key and its values.
                Linq3.Content +=group.Key.ToString()+"\n";
                foreach (var value in group)
                {
                    Linq3.Content += value.ToString() + "\n";
                }
                
            }
            ///////////////
            
            ///////////////
            // Join on the ID properties.
            var query = from c in customers
                        join o in orders on c.ID equals o.ID
                        select new { c.Name, o.Product };
            foreach (var q in query)
            {
                Linq4.Content += q.Name + " " + q.Product + "\n";
            }
            //////////////

            //////////////
            var result4 = from element in array1
                         let v = element * 100
                         where v >= 500
                         select v;
            foreach (var r in result4)
            {
                Linq5.Content += r.ToString() + "\n";
            }
            //////////////
        }

        static void linqExtension()
        {
            string[] array = new string[] { "A", "B", "C", "D" };
            var list1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] array1 = { 1, 3, 5 };
            int[] array2 = { 0, 2, 4 };

            // Convert it to a List with the ToList extension.
            List<string> list = array.ToList();

            // Call reverse extension method on the array.
            var reverse = array.Reverse();

            // The Select method changes each element in the result.
            var result1 = array.Select(element => element.ToUpper());

            // Invoke Distinct extension method.
            var result2 = array.Distinct();

            
            // Concat array1 and array2.
            var result3 = array1.Concat(array2);

            // Use Where method to remove null strings.
            var result4 = array.Where(item => item != null);

            // Use Where method to remove null and empty strings.
            var result5 = array.Where(item => !string.IsNullOrEmpty(item));

            // Union the two arrays.
            var result6 = array1.Union(array2);

            // Test ElementAt for 0, 1, 2.
            string z = array.ElementAt(0);

            // Order alphabetically by reversed strings.
            var result = array.OrderBy(a => new string(a.ToCharArray().Reverse().ToArray()));

            // Use instance method.
            bool b1 = list1.Contains(7);


        }

        static bool IsEven(int value)
        {
            return value % 2 == 0;
        }
        
    }
}
