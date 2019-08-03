namespace BattleCity.Core.Utils
{
    internal static class MatrixUtil
    {
        public static TValue[,] RotateLeft<TValue>(TValue[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            TValue[,] rotatedMatrix = new TValue[rows, cols];
            for (int rowIndex = 0; rowIndex < rows; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < cols; ++colIndex)
                {
                    rotatedMatrix[rowIndex, colIndex] = matrix[cols - colIndex - 1, rowIndex];
                }
            }
            return rotatedMatrix;
        }

        public static TValue[,] RotateRight<TValue>(TValue[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            TValue[,] rotatedMatrix = new TValue[rows, cols];
            for (int rowIndex = 0; rowIndex < rows; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < cols; ++colIndex)
                {
                    rotatedMatrix[rowIndex, colIndex] = matrix[colIndex, rows - rowIndex - 1];
                }
            }
            return rotatedMatrix;
        }

        public static TValue[,] MirrorVertical<TValue>(TValue[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            TValue[,] mirroredMatrix = new TValue[rows, cols];
            for (int rowIndex = 0; rowIndex < rows; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < cols; ++colIndex)
                {
                    mirroredMatrix[rowIndex, cols - 1 - colIndex] = matrix[rowIndex, colIndex];
                }
            }
            return mirroredMatrix;
        }

        public static TValue[,] MirrorHorizontal<TValue>(TValue[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            TValue[,] mirroredMatrix = new TValue[rows, cols];
            for (int rowIndex = 0; rowIndex < rows; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < cols; ++colIndex)
                {
                    mirroredMatrix[rows - 1 - rowIndex, colIndex] = matrix[rowIndex, colIndex];
                }
            }
            return mirroredMatrix;
        }
    }
}