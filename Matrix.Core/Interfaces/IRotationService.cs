namespace Matrix.Core.Interfaces
{
    public interface IRotationService
    {
        int[,] AnticlockwiseMatrixRotation(int[,] source);
        int[,] ClockwiseMatrixRotation(int[,] source);
    }
}
