/*
* MATLAB Compiler: 4.15 (R2011a)
* Date: Wed May 18 06:17:27 2016
* Arguments: "-B" "macro_default" "-W" "dotnet:calculation,Classification,0.0,private"
* "-T" "link:lib" "-d" "D:\calculation\src" "-w" "enable:specified_file_mismatch" "-w"
* "enable:repeated_file" "-w" "enable:switch_ignored" "-w" "enable:missing_lib_sentinel"
* "-w" "enable:demo_license" "-v" "class{Classification:C:\Users\Raghda
* Refaat\Desktop\Dataset 2a\classifiy.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace calculationNative
{

  /// <summary>
  /// The Classification class provides a CLS compliant, Object (native) interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Raghda Refaat\Desktop\Dataset 2a\classifiy.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Classification : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Classification()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = "calculation.ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR("",
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Classification class.
    /// </summary>
    public Classification()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Classification()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object classifiy()
    {
      return mcr.EvaluateFunction("classifiy", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="featuresT">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object classifiy(Object featuresT)
    {
      return mcr.EvaluateFunction("classifiy", featuresT);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="featuresT">Input argument #1</param>
    /// <param name="rightLeftT">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object classifiy(Object featuresT, Object rightLeftT)
    {
      return mcr.EvaluateFunction("classifiy", featuresT, rightLeftT);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="featuresT">Input argument #1</param>
    /// <param name="rightLeftT">Input argument #2</param>
    /// <param name="featuresE">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object classifiy(Object featuresT, Object rightLeftT, Object featuresE)
    {
      return mcr.EvaluateFunction("classifiy", featuresT, rightLeftT, featuresE);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="featuresT">Input argument #1</param>
    /// <param name="rightLeftT">Input argument #2</param>
    /// <param name="featuresE">Input argument #3</param>
    /// <param name="rightLeftE">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object classifiy(Object featuresT, Object rightLeftT, Object featuresE, Object 
                      rightLeftE)
    {
      return mcr.EvaluateFunction("classifiy", featuresT, rightLeftT, featuresE, rightLeftE);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] classifiy(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "classifiy", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="featuresT">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] classifiy(int numArgsOut, Object featuresT)
    {
      return mcr.EvaluateFunction(numArgsOut, "classifiy", featuresT);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="featuresT">Input argument #1</param>
    /// <param name="rightLeftT">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] classifiy(int numArgsOut, Object featuresT, Object rightLeftT)
    {
      return mcr.EvaluateFunction(numArgsOut, "classifiy", featuresT, rightLeftT);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="featuresT">Input argument #1</param>
    /// <param name="rightLeftT">Input argument #2</param>
    /// <param name="featuresE">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] classifiy(int numArgsOut, Object featuresT, Object rightLeftT, Object 
                        featuresE)
    {
      return mcr.EvaluateFunction(numArgsOut, "classifiy", featuresT, rightLeftT, featuresE);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the classifiy M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="featuresT">Input argument #1</param>
    /// <param name="rightLeftT">Input argument #2</param>
    /// <param name="featuresE">Input argument #3</param>
    /// <param name="rightLeftE">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] classifiy(int numArgsOut, Object featuresT, Object rightLeftT, Object 
                        featuresE, Object rightLeftE)
    {
      return mcr.EvaluateFunction(numArgsOut, "classifiy", featuresT, rightLeftT, featuresE, rightLeftE);
    }


    /// <summary>
    /// Provides an interface for the classifiy function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("classifiy", 4, 1, 0)]
    protected void classifiy(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("classifiy", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
