using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    interface QueueInterface
    {
        DataStructures.Node peek();
        void EnQueue(DataStructures.Node node);
        void DeQueue();
        bool isEmpty();
    }
    
}
