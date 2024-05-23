namespace SunamoStringFormat;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

public class ThrowEx
{
    #region from ThrowExShared.cs - all ok 17-10-21
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public static void DummyNotThrow(Exception ex)
    {
    }
    /// <summary>
    ///     Verify whether A3 contains A4
    ///     true if everything is OK
    ///     false if some error occured
    /// </summary>
    /// <param name="type"></param>
    /// <param name="v"></param>
    /// <param name="p"></param>
    /// <param name="after"></param>
    public static bool NotContains(string p, params string[] after)
    {
        return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), p, after));
    }
    #region from Local\ThrowExShared64.cs
    public static void IsNotAllowed(string what)
    {
        ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what));
    }
    public static void BadFormatOfElementInList(object elVal, string listName)
    {
        ThrowIsNotNull(Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(T.Item1, T.Item2), elVal, listName));
    }
    public static readonly Type type = typeof(ThrowEx);
    public static void IsTheSame(string fst, string sec)
    {
        ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(T.Item1, T.Item2), fst, sec));
    }
    public static void WrongNumberOfElements(int requireElements, string nameCount, IEnumerable<string> ele)
    {
        ThrowIsNotNull(Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(T.Item1, T.Item2), requireElements,
        nameCount, ele));
    }
    /// <summary>
    ///     Return & throw exception whether
    ///     directory NOT exists
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="folder1"></param>
    public static void DirectoryWasntFound(string folder1)
    {
        ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), folder1));
    }
    public static void DivideByZero()
    {
        ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode()));
    }
    public static void ViolationSqlIndex(string tableName, string abcToStringColumnsInIndex)
    {
        ThrowIsNotNull(Exceptions.ViolationSqlIndex(FullNameOfExecutedCode(), tableName,
        abcToStringColumnsInIndex));
    }
    public static void Custom(Exception message, bool reallyThrow = true)
    {
        Custom(Exceptions.TextOfExceptions(message), reallyThrow);
    }
    public static bool WrongExtension(string path, string ext)
    {
        return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, ext));
    }
    public static bool DuplicatedElements(string nameOfVariable, IList<string> d, string message = Consts.se)
    {
        return ThrowIsNotNull(Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, d, message));
    }
    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    {
        return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list));
    }
    public static bool IsNotPositiveNumber(string nameOfVariable, int? n)
    {
        return ThrowIsNotNull(
        Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, n)
        );
    }
    /// <summary>
    ///     no additional check
    /// </summary>
    /// <param name="item"></param>
    public static void NotExists(string item)
    {
        ThrowIsNotNull(
        Exceptions.NotExists(FullNameOfExecutedCode(), item)
        );
    }
    public static void Socket(int socketError)
    {
        ThrowIsNotNull(
        Exceptions.Socket(FullNameOfExecutedCode(), socketError)
        );
    }
    #endregion
    /// <summary>
    ///     Default use here method with one argument
    ///     Return false in case of exception, otherwise true
    ///     In console app is needed put in into try-catch error due to there is no globally handler of errors
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="exception"></param>
    public static bool ThrowIsNotNull(Exception exception)
    {
        if (exception != null)
        {
            Custom(exception);
            return false;
        }
        return true;
    }
    #endregion
    #region Only in xlf
    public static void NotFoundTranSlationKeyWithCustomError(string message)
    {
        Custom(message);
    }
    public static void NotFoundTranSlationKeyWithoutCustomError(string message)
    {
        Custom(message);
    }
    #endregion
    #region from ThrowEx.cs
    public static void InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        if (length != requiredLenght)
        {
            ThrowIsNotNull(Exceptions.InvalidExactlyLength(variableName, length, requiredLenght));
        }
    }
    public static Func<char, bool> IsLockedByBitLocker;
    public static bool LockedByBitLocker(string path)
    {
        // pokračovat na tohle
        if (IsLockedByBitLocker != null)
        {
            var p = path[0];
            if (IsLockedByBitLocker(p))
            {
                Custom($"Drive {p}:\\ is locked by BitLocker");
                return true;
            }
        }
        return false;
    }
    public static void CallingSyncMethodInAsyncApp()
    {
        Custom("Calling sync method in async app");
    }
    public static void Argument(string a1, string a2 = null)
    {
        Custom(a1, true, a2);
    }
    public static void ArgumentNull(string a1, string a2 = null)
    {
        Custom(a1, true, a2);
    }
    public static void ExcAsArg(Exception ex, string message = Consts.se)
    {
        ThrowIsNotNull(Exceptions.ExcAsArg, ex, message);
    }
    public static void Ftp(string message, Exception ex = null)
    {
        ThrowIsNotNull(Exceptions.Ftp, ex, message);
    }
    public static void IO(string v)
    {
        ThrowIsNotNull(Exceptions.IO, v);
    }
    public static void InvalidOperation(string s)
    {
        ThrowIsNotNull(Exceptions.InvalidOperation, s);
    }
    public static void ArgumentOutOfRange(string s)
    {
        ThrowIsNotNull(Exceptions.ArgumentOutOfRange, s);
    }
    public static void FtpCommand(object s)
    {
        ThrowIsNotNull(Exceptions.FtpCommand, s);
    }
    public static void FtpAuthentication(object s)
    {
        ThrowIsNotNull(Exceptions.FtpAuthentication, s);
    }
    //FtpAuthentication
    public static void InvalidCast(string v)
    {
        ThrowIsNotNull(Exceptions.InvalidCast, v);
    }
    public static void ObjectDisposed(string v)
    {
        ThrowIsNotNull(Exceptions.ObjectDisposed, v);
    }
    public static void Timeout(string v)
    {
        ThrowIsNotNull(Exceptions.Timeout, v);
    }
    public static void FtpSecurityNotAvailable(string v)
    {
        ThrowIsNotNull(Exceptions.FtpSecurityNotAvailable, v);
    }
    //FtpSecurityNotAvailable
    public static void FtpMissingSocket(Exception ex)
    {
        ThrowIsNotNull(Exceptions.FtpMissingSocket, ex);
    }
    public static void UriFormat(string url, Func<string, bool> uhIsUri)
    {
        ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri);
    }
    public static void FtpListParse()
    {
        Custom("FtpListParse");
    }
    public static void Format(string v)
    {
        ThrowIsNotNull(Exceptions.Format, v);
    }
    #endregion
    #region from ThrowEx.cs
    #region DifferentCountInLists
    #endregion
    #endregion
    /// <summary>
    ///     Je lichý
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="e"></param>SunamoCl
    /// <returns></returns>
    public static bool IsOdd(string colName, ICollection e)
    {
        var f = Exceptions.IsOdd;
        return ThrowIsNotNull(f, colName, e);
    }
    #region from ThrowExShared64.cs - all ok 17-10-21
    private static Tuple<string, string, string> T => Exc.GetStackTrace2();
    public static bool DifferentCountInListsTU<T, U>(string namefc, List<T> countfc, string namesc, List<U> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc,
        countsc.Count));
    }
    public static bool DifferentCountInLists<T>(string namefc, List<T> countfc, string namesc, List<T> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc,
        countsc.Count));
    }
    public static bool DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc, namesc,
        countsc));
    }
    public static void Custom(string message, bool reallyThrow = true, string v2 = Consts.se)
    {
        var joined = string.Join(Consts.se, message, v2);
        ThrowIsNotNull(Exceptions.Custom(FullNameOfExecutedCode(), joined), reallyThrow);
    }
    public static bool reallyThrow2 = true;
#if MB
static void ShowMb(string s)
{
PD.ShowMb(s);
}
#endif
    public static bool ThrowIsNotNull<A, B>(Func<string, A, B, string> f, A ex, B message)
    {
        var exc = f(FullNameOfExecutedCode(T.Item1, T.Item2), ex, message);
        return ThrowIsNotNull(exc);
    }
    public static bool ThrowIsNotNull<A>(Func<string, A, string> f, A o)
    {
        var exc = f(FullNameOfExecutedCode(T.Item1, T.Item2), o);
        return ThrowIsNotNull(exc);
    }
    public static bool ThrowIsNotNull(Func<string, string> f)
    {
        var exc = f(FullNameOfExecutedCode(T.Item1, T.Item2));
        return ThrowIsNotNull(exc);
    }
    //public static void ThrowIsNotNull(Func<string, string, string> f, string a1)
    //{
    //    var exc = f(FullNameOfExecutedCode(T.Item1, T.Item2), a1);
    //    ThrowIsNotNull(exc);
    //}
    private static string lastMethod;
    /// <summary>
    /// Pokud tu chci mít Sl, musím zdůvodnit proč ho tu chci mít
    /// V SunamoExceptions bude jen to co vyvolává výjimky, nic jiného
    /// </summary>
    //private static Action<string> Sl => PD.WriteToStartupLogRelease;
    public static bool debuggerBreakOnEveryExc = false;
    /// <summary>
    ///     true if everything is OK
    ///     false if some error occured
    ///     In console app is needed put in into try-catch error due to there is no globally handler of errors
    /// </summary>
    /// <param name="exception"></param>
    public static bool ThrowIsNotNull(string exception, bool reallyThrow = true)
    {
        if (debuggerBreakOnEveryExc)
{
            System.Diagnostics.Debugger.Break();
        }
        // Výjimky se tak často nevyhazují. Tohle je daň za to že jsem tu měl arch
        // jež nebyla dobře navržená. V ThrowEx se to již podruhé volat nebude.
        var cm = T.Item2;
        if (exception != null)
        {
            if (lastMethod == cm)
                //                string lastMethodIsCm = "lastMethod == cm";
                //#if MB
                //                ShowMb(lastMethodIsCm);
                //#endif
                //                Sl(lastMethodIsCm);
                return false;
            if (lastMethod == null)
            {
                //                string lastMethodIsConstsNulled = "lastMethod = " + ConstsSE.nulled;
                //#if MB
                //                    ShowMb(lastMethodIsConstsNulled);
                //#endif
                //                Sl(lastMethodIsConstsNulled);
            }
            else
            {
                var lastMethodIs = "lastMethod = " + lastMethod;
#if MB
ShowMb();
#endif
                //Sl(lastMethodIs);
            }
            lastMethod = cm;
            if (Exc.aspnet)
            {
                //exception = exception.Replace("Violation of PRIMARY KEY constraint", ShortenedExceptions.ViolationOfPK);
                // Will be written in globalasax error
                writeServerError(T.Item3, exception);
                if (reallyThrow && reallyThrow2) throw new Exception(exception);
            }
            else
            {
#if MB
//ShowMb($"reallyThrow = {reallyThrow} && reallyThrow2 = {reallyThrow2}");
#endif
                if (reallyThrow && reallyThrow2)
                {
#if MB
ShowMb("Throw exc");
#endif
                    throw new Exception(exception);
                }
            }
        }
        return true;
    }
    /// <summary>
    ///     !Path.IsWindowsPathFormat
    /// </summary>
    /// <param name="stacktrace"></param>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="argName"></param>
    /// <param name="argValue"></param>
    public static void IsNotWindowsPathFormat(string argName, string argValue)
    {
        ThrowIsNotNull(Exceptions.IsNotWindowsPathFormat(null, argName, argValue));
    }
    public static string FullNameOfExecutedCode()
    {
        // t,Item1, t,Item2, true
        var f = FullNameOfExecutedCode(T.Item1, T.Item2, true);
        return f;
    }
    public static void IsNullOrEmpty(string argName, string argValue)
    {
        ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue));
    }
    public static void IsNullOrWhitespace(string argName, string argValue)
    {
        ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue));
    }
    public static void ArgumentOutOfRangeException(string paramName, string message = null)
    {
        ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), paramName, message));
    }
    public static void IsNull(string variableName, object variable = null)
    {
        ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable));
    }
#pragma warning disable
    /// <summary>
    ///     CA2211	Non-constant fields should not be visible
    ///     IDE0044	Make field readonly
    ///     Must be public due to GlobalAsaxHelper
    /// </summary>
    public static Action<string, string> writeServerError;
#pragma warning enable
    /// <summary>
    ///     First can be Method base, then A2 can be anything
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    public static string FullNameOfExecutedCode(object type, string methodName, bool fromThrowEx = false)
    {
        if (methodName == null)
        {
            var depth = 2;
            if (fromThrowEx) depth++;
            methodName = Exc.CallingMethod(depth);
        }
        var typeFullName = string.Empty;
        if (type is Type)
        {
            var type2 = (Type)type;
            typeFullName = type2.FullName;
        }
        else if (type is MethodBase)
        {
            var method = (MethodBase)type;
            typeFullName = method.ReflectedType.FullName;
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString();
        }
        else
        {
            var t = type.GetType();
            typeFullName = t.FullName;
        }
        return string.Concat(typeFullName, AllStrings.dot, methodName);
    }
    #endregion
    #region from ThrowEx64.cs
    public static void NotImplementedCase(object niCase)
    {
        ThrowIsNotNull(Exceptions.NotImplementedCase, niCase);
    }
    public static void NotImplementedMethod()
    {
        ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }
    #endregion
    public static void StartIsHigherThanEnd(int start, int end)
    {
        ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(T.Item1, T.Item2), start, end));
    }
    public static void FolderCannotBeDeleted(string repairedBlogPostsFolder, Exception ex)
    {
        ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), repairedBlogPostsFolder, ex));
    }
    public static Action<object> showExceptionWindow = null;
    /// <summary>
    ///     A1 have to be Dictionary<T, U>, not IDictionary without generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="type"></param>
    /// <param name="v"></param>
    /// <param name="en"></param>
    /// <param name="dictName"></param>
    /// <param name="key"></param>
    public static void KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
    {
        ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(ThrowEx.T.Item1, ThrowEx.T.Item2), en, dictName,
        key));
    }
    public static void FirstLetterIsNotUpper(string selectedFile)
    {
        ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile);
    }
    public static void NotSupportedExtension(string extension)
    {
        Custom("Extensions is not supported: " + extension);
    }
    #region from Local\ThrowEx.cs
    #region Must be as first - newly created method fall into this
    public static void BadMappedXaml(string nameControl, string additionalInfo)
    {
        ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo));
    }
    public static void CannotCreateDateTime(int year, int month, int day, int hour, int minute, int seconds,
    Exception ex)
    {
        ThrowIsNotNull(Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute,
        seconds, ex));
    }
    /// <summary>
    ///     TODO: replace FileDoesntExists ->FileOrFolderDoesntExists
    /// </summary>
    /// <param name="stacktrace"></param>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="fulLPath"></param>
    public static void FileDoesntExists(string fulLPath)
    {
        ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath));
    }
    public static void UseRlc()
    {
        ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode()));
    }
    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    {
        return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(T.Item1, T.Item2), colName, col, indexName,
        index));
    }
    public static void CustomWithStackTrace(Exception ex)
    {
        Custom(Exceptions.TextOfExceptions(ex));
    }
    /// <summary>
    ///     Return & throw exception whether directory exists
    /// </summary>
    /// <param name="type"></param>
    /// <param name="v"></param>
    /// <param name="photosPath"></param>
    public static bool DirectoryExists(string path)
    {
        return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path));
    }
    public static void IsWhitespaceOrNull(string variable, object data)
    {
        ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data));
    }
    public static void HaveAllInnerSameCount(List<List<string>> elements)
    {
        ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements));
    }
    public static bool NotContains(object p1, Type type, string v1, string p2, string v2, string v3)
    {
        return false;
    }
    /// <summary>
    ///     Must be string due to in sunamo is not NamespaceElement
    /// </summary>
    /// <param name="name"></param>
    public static void NameIsNotSetted(string nameControl, string nameFromProperty)
    {
        ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty));
    }
    public static void HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(T.Item1, T.Item2), nameDict,
        qsDict, remains));
    }
    public static void DoesntHaveRequiredType(string variableName)
    {
        ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName));
    }

    public static void MoreThanOneElement(string listName, int count, string moreInfo = Consts.se)
    {
        var fn = FullNameOfExecutedCode();
        var exc = Exceptions.MoreThanOneElement(fn, listName, count, moreInfo);
        ThrowIsNotNull(exc);
    }
    public static bool NotInt(string what, int? value)
    {
        return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value));
    }
    /// <summary>
    ///     Should always check for null before because otherwise stacktrace and methodName is computed uselesSly
    ///     must be in code coz Invoke in ThrowIsNotNull should add more lines
    ///     NOT checking whether variable is null, but whether is not null!
    /// </summary>
    /// <param name="stacktrace"></param>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="variableName"></param>
    /// <param name="variable"></param>
    public static void IsNotNull(string variableName, object variable)
    {
        ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable));
    }
    public static void ArrayElementContainsUnallowedStrings(string arrayName, int dex, string valueElement,
    params string[] unallowedStrings)
    {
        ThrowIsNotNull(Exceptions.ArrayElementContainsUnallowedStrings(FullNameOfExecutedCode(), arrayName, dex,
        valueElement, unallowedStrings));
    }
    public static void OnlyOneElement(string colName, ICollection list)
    {
        ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list));
    }
    public static void StringContainsUnallowedSubstrings(string input, params string[] unallowedStrings)
    {
        ThrowIsNotNull(
        Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }
    /// <summary>
    ///     Is used when single (not list etc) bad arg is entered to method
    /// </summary>
    /// <param name="stacktrace"></param>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="valueVar"></param>
    /// <param name="nameVar"></param>
    public static void InvalidParameter(string valueVar, string nameVar)
    {
        ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar));
    }
    public static void ElementCantBeFound(string nameCollection, string element)
    {
        ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element));
    }
    //IsNotWindowsPathFormat
    #endregion
    #region Without parameters
    public static void NotSupported()
    {
        ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode()));
    }
    #endregion
    #region Without locating executing code
    public static void CheckBackslashEnd(string stacktrace, string r)
    {
        ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(T.Item1, T.Item2), r));
    }
    #endregion
    public static void WasNotKeysHandler(string name, object keysHandler)
    {
        ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(T.Item1, T.Item2), name, keysHandler));
    }
    #region Helpers
    public static void IsEmpty(IEnumerable folders, string colName, string additionalMessage = Consts.stringEmpty)
    {
        ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage));
    }
    public static void NoPassedFolders(ICollection folders)
    {
        ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders));
    }
    public static void RepeatAfterTimeXTimesFailed(int times, int timeoutInMs, string address,
    int sharedAlgorithmSlastError)
    {
        ThrowIsNotNull(Exceptions.RepeatAfterTimeXTimesFailed(FullNameOfExecutedCode(T.Item1, T.Item2), times,
        timeoutInMs, address, sharedAlgorithmSlastError));
    }
    /// <summary>
    ///     Throw exc A4,5 is same count of elements
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <param name="detailLocation"></param>
    /// <param name="before"></param>
    /// <param name="after"></param>
    public static void ElementWasntRemoved(string detailLocation, int before, int after)
    {
        ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, before, after));
    }
    public static void FolderCantBeRemoved(string folder)
    {
        ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder));
    }
    public static void FileHasExtensionNotParseableToImageFormat(string fnOri)
    {
        ThrowIsNotNull(
        Exceptions.FileHasExtensionNotParseableToImageFormat(FullNameOfExecutedCode(T.Item1, T.Item2), fnOri));
    }
    public static void FileSystemException(Exception ex)
    {
        ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(T.Item1, T.Item2), ex));
    }
    public static void FuncionalityDenied(string description)
    {
        ThrowIsNotNull(Exceptions.FuncionalityDenied(FullNameOfExecutedCode(T.Item1, T.Item2), description));
    }
    public static void CannotMoveFolder(string item, string nova, Exception ex)
    {
        ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(T.Item1, T.Item2), item, nova, ex));
    }
    public static bool NotContains(string p, string folderWithProjectsFolders)
    {
        return false;
    }
    public static void WasAlreadyInitialized()
    {
        ThrowIsNotNull(FullNameOfExecutedCode(T.Item1, T.Item2) + " was already initialized!");
    }
    public static void IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    {
        if (isWindowsPathFormat(input))
            ThrowIsNotNull(FullNameOfExecutedCode(T.Item1, T.Item2) + input + "is path but only key is expected");
    }
    public static void FolderIsNotEmpty(string variableName, string path)
    {
        ThrowIsNotNull(FullNameOfExecutedCode(T.Item1, T.Item2) +
        $"Folder {path} is not empty. Variable name: {variableName}");
    }
    public static void NotInRange(string variableName, List<string> item, int isLt, int isGt)
    {
        ThrowIsNotNull(FullNameOfExecutedCode(T.Item1, T.Item2) +
        $"{variableName} with items {JoinNL(item)} is out of range, it is < {isLt} or > {isGt}");
    }
    public static void PassedListInsteadOfArray(string variableName, string[] v)
    {
        ThrowIsNotNull(Exceptions.PassedListInsteadOfArray(FullNameOfExecutedCode(T.Item1, T.Item2), variableName, v.ToList()));
    }
    #endregion
    #endregion
    static string JoinNL(List<string> l)
    {
        StringBuilder sb = new();
        foreach (var item in l) sb.AppendLine(item);
        var r = string.Empty;
        r = sb.ToString();
        return r;
    }

    

    //    private static void ThrowIsNotNull(Func<string, object, string> f, object o)
    //{
    //    ThrowIsNotNull(f, o);
    //}
    //private static void ThrowIsNotNull(Func<string, Exception, string> f, Exception o)
    //{
    //    ThrowIsNotNull(f, o);
    //}
    //private static void ThrowIsNotNull(Func<string, string> f)
    //{
    //    ThrowIsNotNull(f);
    //}
    //private static void ThrowIsNotNull(Func<string, string, string> f, string a1)
    //{
    //    ThrowIsNotNull(f, a1);
    //}
}