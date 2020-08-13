using System;
using System.Runtime.InteropServices;
using _2DArraySearch;
using FluentAssertions;
using Xunit;

namespace _2DArraySearchTests
{
    public class BinarySearch2DTests
    {
        readonly BinarySearch2D<FruitsBasket> _fruitSearchInstance;
        readonly BinarySearch2D<Student> _studentSearchInstance;
        private readonly BinarySearch2D<TestClass> _testSearchInstance;

        private readonly FruitsBasket[,] _fruitArray;
        private readonly Student[,] _studentArray;
        private readonly TestClass[,] _testArray;

        public BinarySearch2DTests()
        {
            _fruitSearchInstance = new BinarySearch2D<FruitsBasket>();
            _studentSearchInstance = new BinarySearch2D<Student>();
            _testSearchInstance = new BinarySearch2D<TestClass>();

            _fruitArray = new FruitsBasket[,]
            {
                { new FruitsBasket("Orange", new DateTime(2020, 7, 21), "CTest1"), new FruitsBasket("Apple", new DateTime(2020, 8, 1), "BTest1") },
                { new FruitsBasket("Grape", new DateTime(2020, 6, 30), "ATest1"), new FruitsBasket("Lemon", new DateTime(2020, 8, 15), "DTest1") }
            };

            _studentArray = new Student[,]
            {
                {new Student(1, "Bob", 66.57f), new Student(2, "William", 55.63f), new Student(3, "Grace", 99.98f)},
                {new Student(4, "Graham", 99.99f), new Student(5, "Hallburn", 78.73f), new Student(6, "Ciaci", 55.46f)}
            };

            _testArray = new TestClass[,]
            {
                {
                    new TestClass("TestC", new TestNestedClass("NestedC")),
                    new TestClass("TestB", new TestNestedClass("NestedB"))
                },
                {
                    new TestClass("TestA", new TestNestedClass("NestedA")),
                    new TestClass("TestD", new TestNestedClass("NestedD"))
                }
            };
        }

        [Theory]
        [InlineData("NestedA", 1, 0)]
        [InlineData("NestedB", 0, 1)]
        [InlineData("NestedC", 0, 0)]
        [InlineData("NestedD", 1, 1)]
        public void BinarySearch_NestedIComparableProperty_ReturnsCorrectPosition(string searchParameter, int xCoord, int yCoord)
        {
            var searchVal = new TestClass("", new TestNestedClass(searchParameter));
            var coord = _testSearchInstance.BinarySearch(_testArray, "TestNestedClass", searchVal);
            coord.Should().BeEquivalentTo(new BinarySearch2D<TestClass>.Point(xCoord, yCoord));
        }

        [Fact]
        public void BinarySearch_PropertyInvalid_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _studentSearchInstance.BinarySearch(_studentArray, "NotAValue", new object()));
        }

        [Theory]
        [InlineData(66.57f, 0, 0)]
        [InlineData(78.73f, 1, 1)]
        [InlineData(99.98f, 0, 2)]
        [InlineData(99.99f, 1, 0)]
        public void BinarySearch_Marks_FloatProperty_ReturnsCorrectPosition(float searchParameter, int xCoord, int yCoord)
        {
            var studentPoint = new BinarySearch2D<Student>.Point(xCoord, yCoord);
            var searchVal = new Student(2, "", searchParameter);
            var cord = _studentSearchInstance.BinarySearch(_studentArray, "PercentageMarks", searchVal);

            cord.Should().BeEquivalentTo(studentPoint);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(3, 0, 2)]
        [InlineData(5, 1, 1)]
        public void BinarySearch_StudentId_Int32Property_ReturnsCorrectPosition(int searchParameter, int xCoord, int yCoord)
        {
            var studentPoint = new BinarySearch2D<Student>.Point(xCoord, yCoord);
            var searchVal = new Student(searchParameter, "", 34.55f);
            var cord = _studentSearchInstance.BinarySearch(_studentArray, "StudentId", searchVal);

            cord.Should().BeEquivalentTo(studentPoint);
        }

        [Theory]
        [InlineData("Orange", 0, 0)]
        [InlineData("Apple", 0, 1)]
        [InlineData("Grape", 1, 0)]
        [InlineData("Lemon", 1, 1)]
        public void BinarySearch_FruitName_StringProperty_ReturnsCorrectPosition(string searchParameter, int xCoord, int yCoord)
        {
            var fruitPoint = new BinarySearch2D<FruitsBasket>.Point(xCoord, yCoord);
            var searchVal = new FruitsBasket(searchParameter, new DateTime(2020, 7, 21), "CTest1");
            var cord = _fruitSearchInstance.BinarySearch(_fruitArray, "FruitName", searchVal);

            cord.Should().BeEquivalentTo(fruitPoint);
        }

        [Theory]
        [InlineData("21/07/2020", 0, 0)]
        [InlineData("01/08/2020", 0, 1)]
        [InlineData("30/06/2020", 1, 0)]
        [InlineData("15/08/2020", 1, 1)]
        public void BinarySearch_ExpiryDate_DateTimeProperty_ReturnsCorrectPosition(string searchParameter, int xCoord, int yCoord)
        {
            var date = DateTime.Parse(searchParameter);
            var fruitPoint = new BinarySearch2D<FruitsBasket>.Point(xCoord, yCoord);
            var searchVal = new FruitsBasket(searchParameter, date, "CTest1");
            var cord = _fruitSearchInstance.BinarySearch(_fruitArray, "ExpiryDate", searchVal);

            cord.Should().BeEquivalentTo(fruitPoint);
        }

        [Theory]
        [InlineData("CTest1", 0, 0)]
        [InlineData("BTest1", 0, 1)]
        [InlineData("ATest1", 1, 0)]
        [InlineData("DTest1", 1, 1)]
        public void BinarySearch_NewProp_StringProperty_ReturnsCorrectPosition(string searchParameter, int xCoord, int yCoord)
        {
            var fruitPoint = new BinarySearch2D<FruitsBasket>.Point(xCoord, yCoord);
            var searchVal = new FruitsBasket(searchParameter, DateTime.Now, searchParameter);
            var cord = _fruitSearchInstance.BinarySearch(_fruitArray, "NewProp", searchVal);

            cord.Should().BeEquivalentTo(fruitPoint);
        }
    }
}
