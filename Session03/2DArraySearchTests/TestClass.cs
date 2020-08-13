namespace _2DArraySearchTests
{
    public class TestClass
    {
        public TestClass(string name, TestNestedClass nested)
        {
            Name = name;
            TestNestedClass = nested;
        }

        public string Name { get; set; }
        public TestNestedClass TestNestedClass { get; set; }
    }
}