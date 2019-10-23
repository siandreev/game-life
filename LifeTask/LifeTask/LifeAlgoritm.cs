using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTask
{
    /// <summary>
    /// The event-binding interface for the Form and Logic class.
    /// </summary>
    public  interface Iview
    {  
        event Action TurnFinished;
        event Action ResetEvent;
        event Action CreateEvent;
    }

    /// <summary>
    /// A class that implements the logic of the game.
    /// </summary>
    public class LifeAlgoritm
    {
        private int size;
        private int[,] matrix;
        public event Action<int[,]> ColorizeEvent;

        public int[,] Matrix
        {
            get { return matrix; }
        }

        public LifeAlgoritm(int size, Iview view)
        {
            this.size = size;
            this.matrix = new int[size, size];
            view.ResetEvent += new Action(CreateMatrix);
            view.TurnFinished += new Action(TurnFinishedMethood);
            view.CreateEvent += new Action(CreateMatrix);
        }

        public LifeAlgoritm(int[,] matrix)
        {
            this.size = matrix.GetLength(0);
            this.matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
            this.TurnFinishedMethood();
        }

        /// <summary>
        /// A method that allows you to unsubscribe an object that is no longer needed from events, so that there are no conflicts of events when using a new object.
        /// </summary>
        /// <param name="view"></param>
        public void Unsubscribe(Iview view)
        {
            try
            {
                view.ResetEvent -= new Action(CreateMatrix);
                view.TurnFinished -= new Action(TurnFinishedMethood);
                view.CreateEvent -= new Action(CreateMatrix);
            }
            catch { }
        }

        /// <summary>
        /// Create a random matrix in a new round.
        /// </summary>
        private void CreateMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {                
                    int lifeStatus = rand.Next(0, 8);
                    if (lifeStatus == 1)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }
            }
            ColorizeEvent(matrix);
        }

        /// <summary>
        /// Change of field (birth and death of the cell) at the end of the turn.
        /// </summary>
        private void TurnFinishedMethood()
        {
            int[,] extendedMatrix = new int[size + 2, size + 2];
            int[,] countNeighborsMatrix = new int[size, size];

            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; ++j)
                {
                    extendedMatrix[i + 1, j + 1] = matrix[i, j];
                }
            }

            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; ++j)
                {
                    countNeighborsMatrix[i, j] = extendedMatrix[i + 2, j + 2] + extendedMatrix[i + 2, j + 1] + extendedMatrix[i + 1, j + 2] + extendedMatrix[i + 2, j] + extendedMatrix[i, j + 2] + extendedMatrix[i, j + 1] + extendedMatrix[i + 1, j] + extendedMatrix[i, j];
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; ++j)
                {
                    switch (countNeighborsMatrix[i, j])
                    {
                        case 0:
                        case 1:
                            countNeighborsMatrix[i, j] = 0;
                            break;
                        case 2:
                            if (matrix[i, j] == 1)
                            {
                                countNeighborsMatrix[i, j] = 1;                              
                            }
                            else
                            {
                                countNeighborsMatrix[i, j] = 0;
                            }
                            break;
                        case 3:
                            countNeighborsMatrix[i, j] = 1;
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            countNeighborsMatrix[i, j] = 0;
                            break;
                    }
                }
            }
            matrix = countNeighborsMatrix;
            if (ColorizeEvent != null)
            {
                ColorizeEvent(matrix);
            }
        }
    }
}
