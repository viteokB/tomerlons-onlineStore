namespace Presentation.Common;

public interface IPresenter
{
    void Run();
}

public interface IPresetner<in TArg>
{
    void Run(TArg arg);
}