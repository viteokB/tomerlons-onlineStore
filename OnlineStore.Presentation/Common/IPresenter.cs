﻿namespace Presentation.Common;

public interface IPresenter
{
    void Run();
}

public interface IPresenter<in TArg>
{
    void Run(TArg arg);
}