namespace OnlineStore.Core.Interfaces;

public interface IMapWith<TFrom, TTo>
{
    public static abstract TTo Map(TFrom from);
}