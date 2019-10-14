using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new Monkey();

        Because of = () =>
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_the_user_input_is_empty
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("5"); };

        It should_return_that_number = () => { _result.Should().Be(5); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_the_user_input_us_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2"); };

        It should_return_the_sum_of_those_two_numbers = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_contains_an_unknown_amount_of_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3,4"); };

        It should_return_the_sum_of_all_the_numbers = () => { _result.Should().Be(10); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_the_user_input_is_multiple_numbers_with_newline_and_comma_delimiters
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1\n2,3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_using_a_custom_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };

        It should_return_the_sum = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_th_user_input_has_one_negative_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2")); };

        It should_throw_an_exception = () => { _result.Message.Should().Be("negatives not allowed: -2"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_contains_multiple_negatives
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-1,2,-3")); };

        It should_throw_an_exception_with_all_negatives = () => { _result.Message.Should().Be("negatives not allowed: -1, -3"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_contains_numbers_greater_than_1001
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,1002"); };

        It should_return_the_sum_of_numbers_less_than_1001 = () => { _result.Should().Be(1); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_using_one_multicharacter_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }
}

// 10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
// 11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)