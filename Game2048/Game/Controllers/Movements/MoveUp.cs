using Models;

namespace Actions.Movements
{
    public class MoveUp : AbstractAction<MoveUp>
    {
        public override void Execute(Grid grid)
        {
            //I => Columns J =>Rows

            for (int i = 0; i < grid.Columns; i++)
            {
                var row = GetColumn(grid, i);
                row.Reverse();
                MergeList(row);
                MoveList(row);
                row.Reverse();
                SetColumn(grid, row, i);
            }
        }
    }
}
