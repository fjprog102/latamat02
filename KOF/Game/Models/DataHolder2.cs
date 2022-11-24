namespace KOF.Models;

/*
public abstract class DataHolder
{
    public abstract object GetEntity();
    public abstract object GetId();

    public abstract int? GetChanged();

    public abstract void SetChanged(int value);
}

public abstract class GenericDataHolder<T> : DataHolder
{
    public T? Entity { get; set; }
    public string? Id { get; set; }

    public int? Changed { get; set; }

    public override object GetEntity()
    {
        return Entity!;
    }

    public override object GetId()
    {
        return Id!;
    }

    public override int? GetChanged()
    {
        return Changed!;
    }

    public override void SetChanged(int value)
    {
        Changed = value;
    }
}

public class PowerCardDataHolder : GenericDataHolder<PowerCard>
{
    public void SetEntity(string name, int cost, int type)
    {
        Entity = new PowerCard(name, cost, type);
    }

    public void SetId(String id)
    {
        Id = id;
    }
}

*/
