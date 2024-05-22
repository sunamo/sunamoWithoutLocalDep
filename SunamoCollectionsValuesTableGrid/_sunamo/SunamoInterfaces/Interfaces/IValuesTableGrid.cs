namespace SunamoCollectionsValuesTableGrid;

using System.Data;

internal interface IValuesTableGrid<T>
{
    bool IsAllInColumn(int i, T value);
    bool IsAllInRow(int i, T value);
    DataTable SwitchRowsAndColumn();
    DataTable ToDataTable();
}