namespace SunamoAsync;
public class AsyncHelperSEShared
{
    public static Dictionary<string, object> MergeDictionaries(Dictionary<string, VoidVoid> potentiallyValid,
        Dictionary<string, TaskVoid> potentiallyValidAsync)
    {
        var actionsMerge = new Dictionary<string, object>(potentiallyValid.Count + potentiallyValidAsync.Count);
        if (potentiallyValid != null)
            foreach (var item in potentiallyValid)
                actionsMerge.Add(item.Key, item.Value);

        if (potentiallyValidAsync != null)
            foreach (var item in potentiallyValidAsync)
                actionsMerge.Add(item.Key, item.Value);

        return actionsMerge;
    }

    public static
#if ASYNC
    async Task
#else
        void
#endif
        InvokeTaskVoidOrVoidVoid(object o)
    {
        var t = o.GetType();

        if (t == Types.tVoidVoid)
        {
            (o as VoidVoid).Invoke();
        }
        else if (t == Types.tTaskVoid)
        {
            var taskVoid = o as TaskVoid;
#if ASYNC
            await
#endif
            taskVoid();
            ;
        }
    }
}
