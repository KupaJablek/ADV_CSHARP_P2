﻿using Project2_Group_15.ConversionsProcesses;

namespace Project2_Group_15 {
    public class Postfix {
        // will contain conversion process from indix to postfix notation
        // (a-b) *c is represented as ab-c*
        public List<string> ConvertToPostfix(List<string> InFix) {
            List<string> PostFix = new();

            foreach (string expression in InFix) {
                // convert expression to postfix and add to convertedList

                Stack<char> expStack = new();

                string output = "";

                for (int i = 0; i < expression.Length; i++) {

                    // determine if char is digit or number
                    char c = expression[i];
                    if (Char.IsDigit(c)) { // operand
                        output += c;
                    } else if (c == '(') {
                        // push to stack
                        expStack.Push(c);
                    } else if (c == ')') {
                        while (expStack.Count() > 0 && expStack.Peek() != '(') {
                            output += expStack.Pop();
                        }

                        expStack.Pop();

                    } else { // operator
                        while (
                            expStack.Count() > 0 && 
                            Util.GetOperandPriority(expStack.Peek()) >= 
                            Util.GetOperandPriority(c))
                        { 
                            output += expStack.Pop();
                        }

                        expStack.Push(c);
                    }
                }

                // add all remaining items on stack to output
                while (expStack.Count() > 0) { 
                    output += expStack.Pop();
                }
                PostFix.Add(output);
            }

            return PostFix;
        }
    }
}
