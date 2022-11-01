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
using Newtonsoft.Json;
using System.Diagnostics;
using JsonHelper;


namespace json_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class Account
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime DOB { get; set; }
        }


        [JsonObject(MemberSerialization.OptIn)]
        public class TestClass
        {
            private string classname;
            private string name;
            private int age;

            [JsonIgnore]
            public string Classname { get => classname; set => classname = value; }

            [JsonProperty]
            public string Name { get => name; set => name = value; }

            [JsonProperty]
            public int Age { get => age; set => age = value; }

            public override string ToString()
            {
                return base.ToString();
            }

            public static void ClassMethod( string value)
            {
                Process.Start(value);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account
            {
                Name = "John Doe",
                Email = "john@microsoft.com",
                DOB = new DateTime(1980, 2, 20, 0, 0, 0, DateTimeKind.Utc),
            };
            string json = JsonHelper.JsonSerializeHelper.Serialize(account);

            TextBlock.Text = json;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            TestClass testClass = new TestClass();
            testClass.Classname = "test_classname";
            testClass.Name = "nishikinor";
            testClass.Age = 18;
            string testString = JsonHelper.JsonSerializeHelper.Serialize(testClass);

            TextBlock2.Text = testString;

            //ObjectDataProvider odp = new ObjectDataProvider();
            //odp.MethodName = "ClassMethod";
            //odp.MethodParameters.Add("calc.exe");
            //odp.ObjectInstance = testClass;

            // string obj1 = JsonHelper.JsonSerializeHelper.Serialize(odp);

            string jsonString = "{\"$type\":\"System.Windows.Data.ObjectDataProvider, PresentationFramework\",\"objectInstance\":{\"$type\":\"json_wpf.MainWindow+TestClass, json-wpf\",\"name\":\"nishikinor\",\"age\":18},\"methodName\":\"ClassMethod\",\"methodParameters\":{\"$type\":\"MS.Internal.Data.ParameterCollection, PresentationFramework\",\"$values\":[\"calc.exe\"]},\"isAsynchronous\":false,\"isInitialLoadEnabled\":true,\"data\":null,\"error\":null}";

            JsonHelper.JsonSerializeHelper.Deserialize<Object>(jsonString);
        }

    }
}
