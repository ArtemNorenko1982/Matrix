using Matrix.Core.Interfaces;

namespace Matrix.Core
{
    public class RotationService : IRotationService
    {
        public int[,] ClockwiseMatrixRotation(int[,] source)
        {
            var matrixRank = source.GetLength(0);
            var loopCount = matrixRank / 2;
            for (int i = 0; i < loopCount; i++)
            {
                for (int j = i; j < matrixRank - 1 - i; j++)
                {
                    // store the first item
                    var tmp = source[i, j];

                    // move bottom left to the top left
                    source[i, j] = source[matrixRank - 1 - j, i];

                    // move bottom right to the bottom left 
                    source[matrixRank - 1 - j, i] = source[matrixRank - 1 - i, matrixRank - 1 - j];

                    // move top to bottom right
                    source[matrixRank - 1 - i, matrixRank - 1 - j] = source[j, matrixRank - 1 - i];

                    // assign temp to the top
                    source[j, matrixRank - 1 - i] = tmp;
                }
            }

            return source;
        }

        public int[,] AnticlockwiseMatrixRotation(int[,] source)
        {
            var matrixRank = source.GetLength(0);
            for (int i = 0; i < matrixRank / 2; i++)
            {
                for (int j = i; j < matrixRank - i - 1; j++)
                {
                    var tmp = source[i, j];
                    // from  right to top 
                    source[i, j] = source[j, matrixRank - 1 - i];

                    // from bottom to right 
                    source[j, matrixRank - 1 - i] = source[matrixRank - 1 - i, matrixRank - 1 - j];

                    // from left to bottom 
                    source[matrixRank - 1 - i, matrixRank - 1 - j] = source[matrixRank - 1 - j, i];

                    // assign temp to left 
                    source[matrixRank - 1 - j, i] = tmp;
                }
            }

            return source;
        }
    }
}
