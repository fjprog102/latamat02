using Models;

namespace Actions.Movements
{
    public class MoveLeft : AbstractAction<MoveLeft>
    {
        public override void Execute(Grid grid)
        {
            for (int i = 0; i < grid.Columns; i++)
            {
                var row = GetRow(grid, i);
                row.Reverse();
                MergeList(row);
                MoveList(row);
                row.Reverse();
                SetRow(grid, row, i);
            }
        }
    }
}
