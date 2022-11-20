using Models;

namespace Actions.Movements
{
    public class MoveRight : AbstractAction<MoveRight>
    {
        public override void Execute(Grid grid)
        {
            for (int i = 0; i < grid.Columns; i++)
            {
                var row = GetRow(grid, i);
                MergeList(row);
                MoveList(row);
                SetRow(grid, row, i);
            }
        }
    }
}
