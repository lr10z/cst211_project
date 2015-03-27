using System;
using System.Text;

namespace CST211ADTLibrary
{
    public class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(string msg)
            : base("Syntax Error: " + msg)
        {
        }
    }

    public class PostfixEvaluator : ArrayListStack
    {
        // post-fix expressions look like...
        // 5 3 + --> 5 + 3 = 8
        // 2 5 3 + * --> 2 * (5 + 3) = 16
        // each expression has single-digit numbers and operators '+', '-', '*', '/'
        // each digit and operator is separated by a space character ' '


        //
        // member variables
        //
        private ArrayListStack m_theStack;
        private string m_expression;
        private int m_size;


        //
        // ctor
        //
        public PostfixEvaluator(string expression)
        {
            m_expression = expression;
            m_size = 0;
        }


        // evaluates the expression using integer arithmetic,
        // returns resulting integer value;
        // throws a SyntaxErrorException for invalid experessions
        public int eval()
        {

            //
            // creates new stack
            //
            m_theStack = new ArrayListStack();


            //
            // parses expression into individual strings
            //
            string [] parts = m_expression.Split(new char[] { ' ' });


            //
            // loops through each string of expression
            //
            foreach (string s in parts)
            {

                //
                // checks if string is empty
                //
                if (s == "")
                {
                    throw new SyntaxErrorException("empty string");
                }


                //
                // checks if string is an operator
                //
                if (s == "+" || s == "-" || s == "*" || s == "/")
                {


                    //
                    // throws error is there are operands missing
                    //
                    if (parts.Length < 3)
                    {
                        throw new SyntaxErrorException("insufficient operands");
                    }
                

                    //
                    // pops strings off top of stack and converts
                    // them to an integers to evaluate expression
                    //
                    int operand1 = (int)m_theStack.pop(),
                        operand2 = (int)m_theStack.pop();


                    //
                    // normalizes size of stack due to removal/pop
                    // of operands
                    //
                    m_size -= 2;


                    //
                    // integer arithmetic is done based on operator
                    //
                    switch (s)
                    {
                        case "+":
                            m_theStack.push(operand1 + operand2);
                            break;

                        case "-":
                            m_theStack.push(operand2 - operand1);
                            break;

                        case "*":
                            m_theStack.push(operand1 * operand2);
                            break;

                        case "/":
                            m_theStack.push(operand2 / operand1);
                            break;
                    }

                }


                //
                // checks if string is a number
                // if so, it is converted to an integer and pushed
                // onto the stack
                //
                else if (s[0] >= '0' && s[0] <= '9')
                {
                    int i = System.Convert.ToInt32(s);
                    m_theStack.push(i);
                    ++m_size;
                }


                //
                // throws error if string is an invalid operand
                //
                else if (s[0] >= 'a' && s[0] <= 'z')
                {
                    throw new SyntaxErrorException("invalid operand");
                }


                //
                // throws error is string is an invalid operator
                //
                else
                {
                    throw new SyntaxErrorException("invalid operator");
                }

            }



            //
            // throws error if there are not enough operators for the 
            // operands available
            //
            if( m_size == 1 && parts.Length > 1 )
            {
                throw new SyntaxErrorException("too many operands");
            }



            //
            // returns resulting integer value left on stack
            // from the arithmetic evaluation of expression
            //
            return (int)m_theStack.pop();
        }
    }
}
