using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    internal class PresetInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Author { get; set; }
        public string KnowledgeCheck { get; set; }
        public string TimeFrame { get; set; }
        public string ModdedLevel { get; set; }
        public string CastleType { get; set; }
        public string TransformEarly { get; set; }
        public string TransformFocus { get; set; }
        public string WinCondition { get; set; }
        public string MetaExtension { get; set; }
        public string MetaComplexity { get; set; }
        public string ItemStats { get; set; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
