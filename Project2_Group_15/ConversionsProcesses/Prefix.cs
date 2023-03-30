﻿using Project2_Group_15.ConversionsProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15 {
    public class Prefix {
        // will contain conversion process from indix to prefix notation
        // (a-b) *c is represented as *-abc
        public List<string> ConvertToPrefix(List<string> InFix) { 
            List<string> PreFix = new List<string>();
            
            foreach (string expression in InFix) {
                // convert expression to prefix and add to convertedList
                
                Stack<char> operators = new Stack<char>();
                Stack<string> operands = new Stack<string>();

                char[] exp = expression.Reverse().ToArray();

                for (int i = 0; i < exp.Length; i++) {
                    char c = exp[i];

                    if (c == ')') {
                        operators.Push(c);
                    } else if (c == '(') {
                        while (operators.Count > 0 &&
                        operators.Peek() != ')') {

                            string operand1 = operands.Pop();

                            string operand2 = operands.Pop();

                            char op = operators.Pop();

                            string tmp = op + operand1 + operand2;
                            operands.Push(tmp);
                        }
                        operators.Pop();
                    } else if (Char.IsDigit(c)) {
                        operands.Push(c.ToString());
                    } else {
                        while (operators.Count > 0 && Util.GetOperandPriority(c) <=
                            Util.GetOperandPriority(operators.Peek()))
                            {
                            string op1 = operands.Pop();

                            string op2 = operands.Pop();

                            char op = operators.Pop();

                            string tmp = op + op1 + op2;
                            operands.Push(tmp);
                        }
                        operators.Push(c);
                    }
                }

                while (operators.Count() > 0)
                {
                    string op1 = operands.Pop();

                    string op2 = operands.Pop();

                    char op = operators.Pop();

                    string tmp = op + op1 + op2;
                    operands.Push(tmp);
                }

                PreFix.Add(operands.Peek());
            }
            return PreFix;
        }
    }
}
