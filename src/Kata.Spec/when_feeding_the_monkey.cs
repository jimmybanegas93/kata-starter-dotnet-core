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
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1"); };

        It should_return_that_number = () => { _result.Should().Be(1); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2"); };

        It should_return_the_sum_of_those_two_numbers = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_has_an_unknown_amount_of_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_return_the_sum_of_all_the_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_has_new_line_and_comma_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add( "1\n2,3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_has_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,2,-3")); };

        It should_throw_an_exception_with_that_negative = () => { _result.Message.Should().Be("negatives not allowed: -3"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_has_multiple_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-1,2,-3"));  };

        It should_throw_an_exception = () => { _result.Message.Should().Be("negatives not allowed: -1, -3"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_has_numbers_greater_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,1002,4"); };

        It should_ignore_numbers_greater_than_1000 = () => { _result.Should().Be(5); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_the_user_input_has_multiple_number_with_multiple_character_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_has_several_multi_character_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add ("//[*][%]\n1*2%3"); };

        It should_return_the_sum_of_the_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }
}
