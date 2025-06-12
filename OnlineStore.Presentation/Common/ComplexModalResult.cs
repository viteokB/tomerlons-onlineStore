namespace Presentation.Common;

public record ComplexModalResult<T>(
    ModalResult ModalResult, 
    T? ModalResultData);
