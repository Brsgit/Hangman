using System;

// sorry for that

public static class Mediator
{
    public static event Action<Result> onMessage;

    public static void SendMessage(Result result)
    {
        onMessage?.Invoke(result);
    }
}
