namespace SunamoCollectionsValuesTableGrid;

using System.Data;

public interface IValuesTableGrid<T>
{
    bool IsAllInColumn(int i, T value);
    bool IsAllInRow(int i, T value);
    DataTable SwitchRowsAndColumn();
    DataTable ToDataTable();
}