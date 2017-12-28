using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    interface StackInterface
    {
        void push(DataStructures.Node node);
        void pop();
        DataStructures.Node peek();

        bool isEmpty();
    }
}
