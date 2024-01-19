using Rhino;
using Rhino.Commands;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.DocObjects;
using System.Windows.Forms;

namespace CopyLayerPath
{
    public class CopyLayerPathCommand : Command
    {
        public CopyLayerPathCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static CopyLayerPathCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "CopyLayerPath";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            GetObject go = new GetObject();
            go.SetCommandPrompt("Select one object.");
            Format current = Format.FullPath;
            go.AddOptionEnumList("format", current);

            while (true)
            {
                switch (go.Get())
                {
                    case GetResult.Option:
                        current = (Format)go.Option().CurrentListOptionIndex;
                        break;
                    case GetResult.Object:
                        ObjRef obj = go.Object(0);
                        int layerIndex = obj.Object().Attributes.LayerIndex;
                        Layer layer = obj.Object().Document.Layers.FindIndex(layerIndex);

                        string data;
                        switch (current)
                        {
                            case Format.FullPath:
                                data = layer.FullPath;
                                break;
                            case Format.Path:
                                data = layer.Name;
                                break;
                            case Format.Guid:
                                data = layer.Id.ToString();
                                break;
                            default:
                                data = default;
                                break;
                        }
                        RhinoApp.WriteLine($"Copied a Layer {current}! -> {data}");
                        Clipboard.SetDataObject(data);
                        return Result.Success;
                }
            }
        }
    }

    internal enum Format
    {
        FullPath,
        Path,
        Guid,
    }
}
