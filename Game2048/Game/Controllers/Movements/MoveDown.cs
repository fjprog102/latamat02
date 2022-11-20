using Models;

namespace Actions.Movements
{
    public class MoveDown : AbstractAction<MoveDown>
    {
        public override void Execute(Grid grid)
        {
            for (int i = 0; i < grid.Columns; i++)
            {
                var row = GetColumn(grid, i);
                MergeList(row);
                MoveList(row);
                SetColumn(grid, row, i);
            }
        }
    }
}
