//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;



namespace Cfg
{ 
public partial class Tables
{

    public Tables(System.Func<string, ByteBuf> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();

        PostInit();
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}